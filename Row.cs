using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace baseprotect
{
    public class Row
    {
        Dictionary<string, ValueHolder> values;

        public Row()
        {
            values = new Dictionary<string, ValueHolder>();
        }

        public Row(Row lhs, Row rhs)
        {
            values = new Dictionary<string, ValueHolder>(lhs.values);
            foreach (KeyValuePair<string, ValueHolder> item in rhs.values)
            {
                if (values.ContainsKey(item.Key))
                    values[item.Key] = item.Value;
                else
                    values.Add(item.Key, item.Value);
            }
        }

        public ValueHolder[] this[IEnumerable<string> iterable]
        {
            get
            {
                List<ValueHolder> result = new List<ValueHolder>();
                foreach (string column in iterable)
                    result.Add(values[column]);
                return result.ToArray();
            }
        }

        public ValueHolder this[string column]
        {
            get
            {
                if(values.ContainsKey(column))
                    return values[column];
                return new ValueHolder(null);
            }
        }

        public void Add(string column, ValueHolder value)
        {
            if (values.ContainsKey(column))
                Add(string.Format("{0}_1", column), value);
            else
                values.Add(column, value);
        }

        public void RemoveValue(string column)
        {
            values.Remove(column);
        }

        public string[] Columns()
        {
            return values.Keys.ToArray();
        }

        public ValueHolder Ensure(String name)
        {
            ValueHolder holder = this[name];
            if (holder.IsNull())
                throw new ArgumentNullException(name);
            return holder;
        }
    }
}
