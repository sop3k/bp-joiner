using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace baseprotect
{
    class TreeListViewItemWrapper
    {
        public TreeListViewItemWrapper()
        {
            Items = null;
        }

        public TreeListViewItemWrapper(int ColumnCount)
        {
            Items = new object[ColumnCount];
        }

        public object this[object index]
        {
            get
            {
                try
                {
                    if (index is string)
                        return Items[int.Parse((string)index)];
                    else
                        return Items[(int)index];
                }
                catch (Exception ex)
                {
                    throw new IndexOutOfRangeException(index.ToString(), ex);
                }
            }
            set
            {
                try
                {
                    if (index is string)
                        Items[int.Parse((string)index)] = value;
                    else
                        Items[(int)index] = value;
                }
                catch (Exception ex)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        protected object[] Items;
    }

    class PersonTreeListWrapper : TreeListViewItemWrapper
    {
        public PersonTreeListWrapper(Person person, int _num_of_events, string _notified)
        {
            Items = new object[]{person.FirstName, person.SecondName,_notified, 
                                 person.City, _num_of_events, person.ID };
        }

        public string GetPersonField(int index)
        {
            string[] names = {"FirstName", "SecondName", "", "City", "", "ID" };
            return names[index];
        }

        public static IEnumerable<PersonTreeListWrapper> WrappAll(BaseprotectDB db,
                                                                  IEnumerable<Person> enumerable)
        {
            List<PersonTreeListWrapper> result = new List<PersonTreeListWrapper>();

            foreach (Person person in enumerable)
            {
                int num_of_events = db.PersonsToEvents.Count(p => p.PersonID == person.ID);
                string notified = "No";
                if (db.Notifies.Count(n => n.PersonID == person.ID) != 0)
                {
                    var notifyDate = from n in db.Notifies
                                     where n.PersonID == person.ID
                                     select n.Date;

                    notified = notifyDate.Single().ToShortDateString();
                }
                result.Add( new PersonTreeListWrapper(person, num_of_events, notified));
            }
            return result.AsEnumerable();
        }

        public int PersonID
        {
            get { return (int)this[5]; }
        }

    }

    class NetEventTreeListWrapper : TreeListViewItemWrapper
    {
        public NetEventTreeListWrapper(NetEvent ev)
        {
            Items = new object[] { ev.IP.ToString(),
                        Utils.CombineDateAndTime(ev.Date, ev.Time.TimeOfDay).ToString(),
                        ev.GUID, ev.Hash, ev.Server };
        }
    }
}
