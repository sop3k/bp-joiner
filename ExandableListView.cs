using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using DbLinq.Data.Linq;

namespace baseprotect
{
    class ExTreeListViewItem : TreeListViewItem
    {
        Person person;
        BaseprotectDB db;

        public ExTreeListViewItem(BaseprotectDB _db, Person _person, ListViewGroup group)
        {
            db = _db;
            person =  _person;
        }

        public ExTreeListViewItem Update()
        {
            SubItems.Clear();
            Text = person.FirstName;

            AddColumnValue(person.FirstName);
            AddColumnValue(person.SecondName);
            AddColumnValue(person.Postal);
            AddColumnValue(person.City);
            AddColumnValue("0");

            return this;
        }

        private void AddColumnValue(string value)
        {
            ListViewSubItem subitem = new ListViewSubItem();
            subitem.Text = value;
            SubItems.Add(subitem);
        }
    }
}
