using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;

using System.Linq;

namespace baseprotect
{
    public partial class JoinerForm : Form
    {
        BaseprotectDB db;
        StreamWriter errorLogger;
        StreamWriter sqlLogger;

        public JoinerForm()
        {
            InitializeComponent();

            Converter<Person>.RegisterConverter(typeof(TableToPerson));
            Converter<NetEvent>.RegisterConverter(typeof(TableToEvent));
            Converter<PersonToEvent>.RegisterConverter(typeof(TableToPersonEventRelation));

            sqlLogger = new StreamWriter("SQLLog.log");
            errorLogger = new StreamWriter("ErrorLog.log");
        }

        private void JoinerForm_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = string.Format("DbLinqProvider=Sqlite;Data Source={0};", Config.GetDBPath());
                db = new BaseprotectDB(new System.Data.SQLite.SQLiteConnection(connStr));

                db.Log = sqlLogger;

                TranslatorFactory.RegisterFormater("TOI", typeof(TOITranslator));
                TranslatorFactory.RegisterFormater("Sniper", typeof(SniperTranslator));
                TranslatorFactory.RegisterFormater("Tabelle1", typeof(TabelleTranslator));

                populateList();
            }
            catch (Exception ex)
            {
                errorLogger.Write(ex.StackTrace);
                errorLogger.Flush();
                MessageBox.Show(ex.Message);
            }
        }

        private void populateList()
        {
            mainList.Clear();

            IEnumerable<PersonTreeListWrapper> objects =
                PersonTreeListWrapper.WrappAll(db, db.Persons);

            if (objects.Count() == 0)
                return;

            mainList.SetObjects(objects);   
            mainList.CanExpandGetter = delegate(object x)
            {
                return x is PersonTreeListWrapper;
            };

            mainList.ChildrenGetter = delegate(object x)
            {
                PersonTreeListWrapper person = x as PersonTreeListWrapper;

                var subQuery = from ev_p in db.PersonsToEvents
                               where ev_p.PersonID == person.PersonID
                               select ev_p;

                List<object> items = new List<object>();
                foreach (var e in subQuery)
                {
                    var query = from ev in db.Events
                                where ev.ID == e.EventID
                                select new { FirstName = ev.IP, SecondName = ev.Date, 
                                             Notified = ev.GUID, City = ev.Hash, NumOfEvents = ev.Server };

                    foreach (var _event in query)
                    {
                        items.Add(_event);
                    }
                }
                return items;
            }; 
        }

        private void newDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                NewDataForm newDataForm = new NewDataForm(db);
                newDataForm.ShowDialog();
                populateList();
            }
            catch (Exception ex)
            {
                errorLogger.Write(ex.StackTrace);
                errorLogger.Flush();
                MessageBox.Show(ex.Message);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var notifiedPersons = from p in db.Persons
                                      join n in db.Notifies on p.ID equals n.PersonID
                                      select p.ID;

                SaveFileDialog dlg = new SaveFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CSVExporter exporter = new CSVExporter(db, dlg.FileName);
                    exporter.Export(notifiedPersons.AsEnumerable<int>().ToArray());
                }
            }
            catch (Exception ex)
            {
                errorLogger.Write(ex.StackTrace);
                errorLogger.Flush();
                MessageBox.Show(ex.Message);
            }
        }
    }

}
