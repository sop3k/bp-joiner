using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.Common;
using System.Transactions;

namespace baseprotect
{
    class ProjectImporter
    {
        Project project;
        BaseprotectDB db;
        String OldProjectName;

        public ProjectImporter(BaseprotectDB _db, Project _project, String oldName)
        {
            db = _db;
            project = _project;
            OldProjectName = oldName;
        }

        public void Import(String Path, Action<int, int> progress)
        {
            var Connection = CreateConnection(Path);
            using(DbTransaction transaction = db.Connection.BeginTransaction())
            {
                db.Transaction = transaction;

                var persons = GetAllPerson(Connection);

                foreach (var p in persons)
                {
                    progress.Invoke(persons.Count(), 1);

                    var id = p.Key;
                    var person = GetIfExists(p.Value);

                    var Events = GetAllPersonEvents(Connection, id);
                    var Notifies = GetAllPersonNotifies(Connection, id);
                    var States = GetAllPersonStates(Connection, id);

                    foreach (NetEvent e in Events)
                    {
                        PersonToEvent relation = new PersonToEvent
                        {
                            Event = e,
                            Owner = person
                        };

                        db.PersonsToEvents.InsertOnSubmit(relation);
                        db.Events.InsertOnSubmit(e);
                    }

                    if (Notifies.Count() == 0)
                    {
                        var state = person.ChangeState(State.NotNotified, "Imported...", null, project);
                        db.States.InsertOnSubmit(state);
                    }

                    foreach (Notify n in Notifies)
                    {
                        n.Notified = person;

                        if (n.Type == NotifyType.Export)
                        {
                            PersonState state = new PersonState();

                            state.Owner = person;
                            state.State = State.Exported;
                            state.Comment = "Exported...";
                            state.Date = n.Date;
                            state.Project = project;

                            person.SetCurrentState(state);
                            db.States.InsertOnSubmit(state);
                        }

                        db.Notifies.InsertOnSubmit(n);
                    }

                    //Tylko zeby Piotrowi zadziałało ładownaie starej bazy.
                    if (Notifies.Count() == 0 && States.Count() > 1)
                    {
                        foreach (PersonState state in States)
                        {
                            if (state.State == State.Exported)
                            {
                                Notify export = new Notify();
                                export.Notified = person;
                                export.Date = state.Date;
                                export.Type = NotifyType.Export;
                                export.Project = Config.ActiveProject;

                                string Comment = string.Format("Imported already exported...");
                                person.ChangeState(State.Exported, Comment, null, Config.ActiveProject);

                                db.Notifies.InsertOnSubmit(export);
                                db.SubmitChanges();
                            }
                        }
                    }

                    project.AddPersonToProject(person);
                    if (!PersonAllreadyInDB(person))
                        db.Persons.InsertOnSubmit(person);

                    db.SubmitChanges();
                }
                transaction.Commit();
                db.Transaction = null;
            }
        }

        public bool CanImport()
        {
            return db.Events.Count(e => e.Project == project) == 0;
        }

        private bool PersonAllreadyInDB(Person person)
        {
            return person.ID != 0;
        }

        private Person GetIfExists(Person person)
        {
            var q = from p in db.Persons
                    where  (p.FirstName == person.FirstName &&
                            p.SecondName == person.SecondName &&
                            p.Postal == person.Postal &&
                            p.City == person.City)
                        || p.ISPName == person.ISPName
                    select p;

            var matched = q.ToList();
            if (matched.Count > 1)
                return matched.SingleOrDefault(p => p.ISPName == person.ISPName) ?? person;
            return matched.SingleOrDefault() ?? person;
        }

        private IEnumerable<KeyValuePair<int,Person>> GetAllPerson(SqlCeConnection Connection)
        {
            String Sql = "SELECT * FROM Person";
            SqlCeDataReader reader = new SqlCeCommand(Sql, Connection).ExecuteReader();
            while (reader.Read())
            {
                int id = TypeUtils.GetFromReader<int>(reader, "id"); 
                yield return new KeyValuePair<int, Person>
                (
                    id, 
                    CreatePersonFromReader(reader)
                );
            }
        }

        private IEnumerable<NetEvent> GetAllPersonEvents(SqlCeConnection Connection, int PersonID)
        {
            String Sql = @" SELECT * FROM Event e 
                            JOIN PersonToEvent pte on e.id = pte.event_id 
                            WHERE pte.person_id = {0}";
            SqlCeDataReader reader = new SqlCeCommand(String.Format(Sql, PersonID), Connection).ExecuteReader();
            while (reader.Read())
                yield return CreateEventFromReader(reader);
        }

        private IEnumerable<Notify> GetAllPersonNotifies(SqlCeConnection Connection, int PersonID)
        {
            String Sql = "SELECT * FROM Notify where person_id = {0}";
            SqlCeDataReader reader = new SqlCeCommand(String.Format(Sql, PersonID), Connection).ExecuteReader();
            while (reader.Read())
                yield return CreateNotifyFromReader(reader);
        }

        private IEnumerable<PersonState> GetAllPersonStates(SqlCeConnection Connection, int PersonID)
        {
            String Sql = "SELECT * FROM PersonState where person_id = {0}";
            SqlCeDataReader reader = new SqlCeCommand(String.Format(Sql, PersonID), Connection).ExecuteReader();
            while (reader.Read())
                yield return CreatePersonStateFromReader(reader);
        }

        private Person CreatePersonFromReader(SqlCeDataReader reader)
        {
            int id = TypeUtils.GetFromReader<int>(reader, "id");
            String akz = TypeUtils.GetFromReader<String>(reader, "baseprotectid");

            return new Person
            {
                City =          TypeUtils.GetFromReader<String>(reader, "adress_city"),
                Details =       TypeUtils.GetFromReader<String>(reader, "adress_details"),
                Postal =        TypeUtils.GetFromReader<String>(reader, "adress_postal"),
                Email =         TypeUtils.GetFromReader<String>(reader, "email"),
                FirstName =     TypeUtils.GetFromReader<String>(reader, "first_name"),
                SecondName =    TypeUtils.GetFromReader<String>(reader, "second_name"),
                ISPName =       TypeUtils.GetFromReader<String>(reader, "isp_name"),

                BaseprotectID = String.Format( "{0}-{1}", akz, id)
            };
        }

        private NetEvent CreateEventFromReader(SqlCeDataReader reader)
        {
            return new NetEvent
            {
                BennKenn =  TypeUtils.GetFromReader<String>(reader,   "benn_kenn"),
                Date =      TypeUtils.GetFromReader<DateTime>(reader, "date"),
                Time =      TypeUtils.GetFromReader<DateTime>(reader, "time"),
                IP =        TypeUtils.GetFromReader<String>(reader,   "ip"),
                Hash =      TypeUtils.GetFromReader<String>(reader,   "hash"),
                GUID =      TypeUtils.GetFromReader<String>(reader,   "guid"),
                DBIndex =   TypeUtils.GetFromReader<int>(reader,      "dbindex"),
                Plugin =    TypeUtils.GetFromReader<String>(reader,   "plugin"),
                Publish =   TypeUtils.GetFromReader<String>(reader,   "publish"),
                Server =    TypeUtils.GetFromReader<String>(reader,   "server"),
                
                ProjectID = project.ID
            };
        }

        private Notify CreateNotifyFromReader(SqlCeDataReader reader)
        {
            return new Notify
            {
                Date = TypeUtils.GetFromReader<DateTime>(reader, "date"),
                Type = (NotifyType)TypeUtils.GetFromReader<int>(reader, "type"),
                ProjectID = project.ID
            };
        }

        private PersonState CreatePersonStateFromReader(SqlCeDataReader reader)
        {
            return new PersonState
            {
                Date = TypeUtils.GetFromReader<DateTime>(reader, "date"),
                State = (State)TypeUtils.GetFromReader<int>(reader, "state")
            };
        }

        SqlCeConnection CreateConnection(String Path)
        {
            String DBPath = System.IO.Path.Combine(Path, "deploy.sdf");
            String connStr = string.Format("Data Source={0};", DBPath);
            var Connection = new System.Data.SqlServerCe.SqlCeConnection(connStr);
            Connection.Open();

            return Connection;
        }
    }
}
