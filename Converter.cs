using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Diagnostics;

using SQL = System.Data.Linq;
using System.Windows.Forms;

using System.Reflection;

namespace baseprotect
{
    interface ITableToEntity<TEntity>
        where TEntity : class
    {
        TEntity Find(SQL.Table<TEntity> set, TEntity entity);
        TEntity Create(Row table, bool afterFailed);
        TEntity OnFail(TEntity entity, Row row, BaseprotectDB db, Exception cause);
    }

    class TableToPerson : ITableToEntity<Person>
    {
        public Person Find(SQL.Table<Person> entitySet, Person person)
        {
            if (person == null)
                return null;

            String ISPName = person.ISPName;
            String FirstName = person.FirstName;
            String SecondName = person.SecondName;
            String Postal = person.Postal;
            String City = person.City;

            var isp_matched = from p in entitySet
                              where p.ISPName == ISPName
                              select p;

            var q = from p in entitySet
                    where( p.FirstName == FirstName &&
                           p.SecondName == SecondName &&
                           p.Postal == Postal &&
                           p.City == City)
                    select p;

            var isp_eq = isp_matched.ToList();

            Person entity;
            if (isp_eq.Count > 0)
                entity = isp_eq.Where(p => p.FirstName == FirstName && 
                    p.SecondName == SecondName &&
                    p.City == City && 
                    p.Postal == Postal).SingleOrDefault() ?? person;
            else
                entity = q.SingleOrDefault() ?? person;

            Config.ActiveProject.AddPersonToProject(entity);
            return entity; 
        }

        public Person Create(Row row, bool afterFailed)
        {
            Person person = new Person();

            if (!row["FULL_NAME"].IsNull()){
                string[] data = row["FULL_NAME"].GetValue<String>().Split(',');
                if (data.Length == 2)
                {
                    person.FirstName = Regex.Replace(data[1], @"(\p{P})", "").Trim();
                    person.SecondName = Regex.Replace(data[0], @"(\p{P})", "").Trim();
                }
                else
                {
                    person.SecondName = row["FULL_NAME"].ToString();
                    person.FirstName = " ";
                }
            }else{
                person.FirstName = row["VORNAME"].ToString();
                person.SecondName = row["NACHNAME"].ToString();
            }

            if (!row["FULL_ADRESS"].IsNull())
            {
                person.Postal = TableToPerson.GetPostal(row["FULL_ADRESS"].ToString()); 
                person.City = TableToPerson.GetCity(row["FULL_ADRESS"].ToString()); 
                person.Details = TableToPerson.GetDetails(row["FULL_ADRESS"].ToString());
            }else{
                person.Postal = row["POSTAL"].ToString();
                person.City = row["CITY"].ToString();
                person.Details = row["ADRESS_DETAILS"].ToString();

                if (!row["ADRESS_DETAILS_2"].IsNull())
                    person.Details = String.Format("{0} {1}", person.Details, row["ADRESS_DETAILS_2"]);
            }

            person.ISPName = row["ISP"].ToString();
            person.Email = row["EMAIL"].ToString();

            if ((string.IsNullOrEmpty(person.FirstName.RemoveDigits()) &&
                string.IsNullOrEmpty(person.SecondName.RemoveDigits())) ||
                string.IsNullOrEmpty(person.City.RemoveDigits()) ||
                string.IsNullOrEmpty(person.Details.RemoveDigits()))
            {
                return null;
            }

            //MessageBox.Show(person.FirstName + person.SecondName + person.City + person.Details);

            person.States.Add(TableToPerson.DefaultState(person, Config.ActiveProject));
            return person;
        }

        public Person Create(Person entity)
        {
            Person newEntity = new Person();

            newEntity.FirstName = entity.FirstName;
            newEntity.SecondName = entity.SecondName;
            newEntity.Postal = entity.Postal;
            newEntity.City = entity.City;
            newEntity.Details = entity.Details;
            newEntity.Email = entity.Email;
            newEntity.BaseprotectID = entity.BaseprotectID;
            
            /*
            string prefix = string.Format("[{0}.{1}]", entity.SecondName, entity.FirstName);
            newEntity.ISPName = string.Format("{0}{1}",  prefix, entity.ISPName);
            */

            newEntity.ISPName = CreateNewISPName(entity);
            newEntity.States.Add(TableToPerson.DefaultState(newEntity, Config.ActiveProject));

            Config.ActiveProject.AddPersonToProject(newEntity);

            return newEntity;
        }

        public static string GetCity(string input)
        {
            var s = input.ToCharArray().Reverse().TakeWhile((char p) => { return !char.IsDigit(p); });
            var str = new string(s.Reverse().ToArray());
            return str.Trim();
        }

        public static string GetPostal(string input)
        {
            int CityLen = TableToPerson.GetCity(input).Length;
            string s = input.Substring(0, input.Length - CityLen).Trim();
            var c = s.ToCharArray().Reverse().TakeWhile((char p) => { return char.IsDigit(p); });
            return new string(c.Reverse().ToArray()).Trim();
        }

        public static string GetDetails(string input)
        {
            var s = input.ToCharArray().TakeWhile((char p) => { return p != ','; });
            return new string(s.ToArray()).Trim();
        }

        public static PersonState DefaultState(Person person, Project project)
        {
            PersonState state = new PersonState();

            state.Date = DateTime.Now;
            state.State = State.NotNotified;
            state.Comment = "Person added";
            state.Owner = person;
            state.Project = project;

            return state;
        }

        private static string CreateNewISPName(Person person)
        {
            string prefix = string.Format("[{0}.{1}]", person.SecondName, person.FirstName);
            return string.Format("{0}{1}", prefix, person.ISPName);
        }

        public Person OnFail(Person entity, Row row, BaseprotectDB db, Exception cause)
        {
            var isp = CreateNewISPName(entity);
            var same_isp = from p in db.Persons
                           where p.ISPName == entity.ISPName ||
                                 p.ISPName == isp
                           select new { SecondName = p.SecondName, FirstName = p.FirstName };

            //Person[] same_isp_array = same_isp.ToArray();
            bool duplicated = same_isp.ToArray().Count(p => Utils.LongerContainShorter(p.SecondName, entity.SecondName)) != 0 && 
                              same_isp.ToArray().Count(p => Utils.LongerContainShorter(p.FirstName, entity.FirstName)) != 0;
            
            if (!duplicated)
            {
                //entity.ISPName = Guid.NewGuid().ToString();
                return Create(entity);
            }
            return null;
        }
    }

    class TableToEvent : ITableToEntity<NetEvent>
    {
        public NetEvent Create(Row row, bool afterFailed)
        {
            NetEvent ev = new NetEvent();
            ev.Project = Config.ActiveProject;
         
            ev.Date = row["DATE"].GetValue<DateTime>();
            ev.IP = row["IP"].ToString();
            TimeSpan time = row["TIME"].GetValue<TimeSpan>();
            ev.Time = DateTime.Parse(time.ToString());

            int index = 0;
            int.TryParse(row["INDEX"].ToString(), out index);
            ev.DBIndex = index;
            
            ev.GUID = row["GUID"].ToString();
            ev.Hash = row["HASH"].ToString();
            ev.BennKenn = row["BENNKENN"].ToString();
            ev.Publish = row["PUBLISH"].ToString();
            ev.Plugin = row["PLUGIN"].ToString();
            ev.Server = row["TITLE"].ToString();

            ev.ProjectID = Config.ActiveProject.ID;

            if (String.IsNullOrEmpty(ev.GUID) ||
                String.IsNullOrEmpty(ev.Hash) ||
                String.IsNullOrEmpty(ev.IP) ||
                String.IsNullOrEmpty(ev.BennKenn) ||
                String.IsNullOrEmpty(ev.Title))
            {
                return null;
            }

            return ev;
        }

        public NetEvent OnFail(NetEvent entity, Row row, BaseprotectDB db, Exception cause)
        {
            throw cause;
        }

        public NetEvent Find(SQL.Table<NetEvent> entitySet, NetEvent ev)
        {
            return ev;
        }
    }

    class TableToPersonEventRelation : ITableToEntity<PersonToEvent>
    {
        SQL.Table<Person> personTable;
        SQL.Table<NetEvent> eventTable;

        public TableToPersonEventRelation()
        {
            try
            {
                personTable = Config.DB.Persons;
                eventTable = Config.DB.Events;
            }
            catch(Exception e)
            {
                return;
            }
        }

        public PersonToEvent Create(Row row, bool afterFailed)
        {
                IEnumerable<string> joinColumns = Config.GetJoinColumns().AsEnumerable();
                ValueHolder[] eventData = row[joinColumns];
                PersonToEvent relation = new PersonToEvent();

                string ip = eventData[0].ToString();
                DateTime date = eventData[2].GetValue<DateTime>();
                DateTime time = DateTime.Parse(eventData[1].GetValue<TimeSpan>().ToString());

                string name = row["VORNAME"].ToString();
                string secondname = row["NACHNAME"].ToString();
                string city = row["CITY"].ToString();
                string postal = row["POSTAL"].ToString().Trim().PadLeft(5, '0');

                if (!row["FULL_NAME"].IsNull())
                {
                    string[] data = row["FULL_NAME"].GetValue<String>().Split(',');

                    if (data.Length == 2)
                    {
                        name = Regex.Replace(data[1], @"(\p{P})", "").Trim();
                        secondname = Regex.Replace(data[0], @"(\p{P})", "").Trim();
                    }
                    else
                    {
                        secondname = Regex.Replace(data[0], @"(\p{P})", "").Trim();
                        name = " ";
                    }
                }

                if (!row["FULL_ADRESS"].IsNull())
                {
                    postal = TableToPerson.GetPostal(row["FULL_ADRESS"].ToString());
                    city = TableToPerson.GetCity(row["FULL_ADRESS"].ToString());
                }

                var events = from e in eventTable
                             where  e.IP == ip && 
                                    e.Date == date && 
                                    e.Time == time
                             select e;

                foreach (var ev in events)
                {
                    var persons = from p in personTable
                                  where p.FirstName == name &&
                                        p.SecondName == secondname &&
                                        p.City == city &&
                                        p.Postal == postal
                                  select p;

                    foreach (var person in persons)
                    {
                        relation.Owner = person;
                        relation.Event = ev;

                        if (person.BaseprotectID == null)
                            person.BaseprotectID = SplitBennKenn(ev); //numer akt
                    }
                }

                if (relation.Owner != null && relation.Event != null)
                {
                    return relation;
                }
                return null;
        }

        private string SplitBennKenn(NetEvent ev)
        {
            string bennKenn = ev.BennKenn;
            if (!string.IsNullOrEmpty(bennKenn))
            {
                int pivot = bennKenn.Trim().LastIndexOf('-');
                pivot = pivot < 0 ? bennKenn.Trim().LastIndexOf(' ') : pivot ;
                return bennKenn.Substring(0, pivot);
            }
            return null;
        }

        public PersonToEvent OnFail(PersonToEvent entity, Row row, BaseprotectDB db, Exception cause)
        {
            throw cause;
        }
        public PersonToEvent Find(SQL.Table<PersonToEvent> entitySet, PersonToEvent entity)
        {
            return entity;
        }
    }

    class TableToInfo : ITableToEntity<Info>
    {
        public Info Create(Row row, bool afterFailed)
        {
            Info info = new Info();

            info.BennKenn = row["BENNKENN"].ToString();
            info.Category = row["CATEGORY"].ToString();
            info.MandatNr = row["MANDAT_NR"].ToString();
            info.ProductName = row["PRODUCT_NAME"].ToString();
            info.ProjectPrefix = row["PROJECT_PREFIX"].ToString();

            if (!row["PENALTY"].IsNull())
                info.Penalty = row["PENALTY"].GetValue<decimal>();

            if (!row["PRODUCT_RELEASE_DATE"].IsNull())
                info.ProductReleaseDate = row["PRODUCT_RELEASE_DATE"].GetValue<DateTime>();

            if (!row["WARRANT_DATE"].IsNull())
                info.WarrantDate = row["WARRANT_DATE"].GetValue<DateTime>();

            return info;
        }

        public Info OnFail(Info entity, Row row, BaseprotectDB db, Exception cause)
        {
            throw cause;
        }
        public Info Find(SQL.Table<Info> entitySet, Info entity)
        {
            return entity;
        }
    }

    class Converter<TEntity>
        where TEntity: class
    {
        static Dictionary<Type, Type> mapping = new Dictionary<Type,Type>();

        public static void RegisterConverter(Type Cvt)
        {
            mapping.Add(typeof(TEntity), Cvt);
        }

        public static ITableToEntity<TEntity> Get(params object[] parameters)
        {
            Type CvtType = mapping[typeof(TEntity)];
            return Activator.CreateInstance(CvtType, parameters) as ITableToEntity<TEntity>;
        }
    }
}
