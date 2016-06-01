using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;
using System.Data.Common;


namespace baseprotect
{
    class DebugTextWriter : System.IO.TextWriter
    {
        public override void Write(char[] buffer, int index, int count)
        {
            System.Diagnostics.Debug.Write(new String(buffer, index, count));
        }

        public override void Write(string value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.Default; }
        }
    }

    public class Config
    {
        private static DbConnection Connection = null;
        private static Project activeProject = null;
        private static BaseprotectDB db = null;

        public static BaseprotectDB DB
        {
            get 
            {
                if (Config.db == null)
                    RefreshConnection();
                return Config.db; 
            }
        }

        public static BaseprotectDB CreateDBConnection()
        {
            Config.db = new BaseprotectDB(Connection);
            Config.db.Log = new DebugTextWriter();
            
            /*
            try
            {
                if (ActiveProject != null)
                    Config.db.Projects.Attach(ActiveProject);
            }
            catch (Exception e)
            {
                ActiveProject = Config.db.Projects.Single(p => p.ID == ActiveProject.ID);
            }
            */

            ActiveProject = Config.db.Projects.Single(p => p.ID == ActiveProject.ID);
            return Config.db;
        }

        public static BaseprotectDB CreateDBConnection(DbConnection connection)
        {
            Config.Connection = connection;
            Config.Connection.Open();

            Config.db = new BaseprotectDB(Connection);
            Config.db.Log = new DebugTextWriter();

            if (ActiveProject != null)
            {
                try
                {
                    DB.Projects.Attach(ActiveProject);
                    DB.LoadOptions.LoadWith<Person>(p => p.Projects);
                }
                catch (Exception)
                {
                    ActiveProject = Config.db.Projects.Single(p => p.ID == ActiveProject.ID);
                }
            }
            return Config.db;
        }

        public static void RefreshConnection()
        {
            CreateDBConnection();
        }

        public static Project ActiveProject
        {
            get{ return activeProject; }
            set{ activeProject = value; }
        }

        public static string GetTableNamesPattern()
        {
            return @"^TOI|^Tabelle.*|";
        }

        public static string[] GetTableNames()
        {
            return new string[]{@"^TOI",@"^Tabelle.*",};
        }

        public static string[] GetJoinColumns()
        {
            return new string[]{"IP","TIME","DATE"};
        }

        public static string GetActiveProjectName()
        {
            return Config.ActiveProject.Name;
        }
        
        public static string GetSeparator()
        {
            return ";";
        }

        public static string GetHeaderTranslateFile()
        {
            return "header.trn";
        }

        public static int BatchSize()
        {
            return 100;
        }

        public static void LogWrite(String message)
        {
            using (StreamWriter log = new StreamWriter("joiner.log", true))
            {
                log.WriteLine(String.Format("[{0}]: {1}", new DateTime().ToLongTimeString(), message));
            }
        }
    }

    class JoinProcesses
    {
        static public void AddJoinProcess(BaseprotectDB db, int count,
            Table providerTable, Table eventsTable)
        {
            JoinProcess jp = new JoinProcess();
            jp.SetProcessData(count, providerTable, eventsTable);
            db.JoinProcess.InsertOnSubmit(jp);

            db.SubmitChanges();
        }
    }
}
