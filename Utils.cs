using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Data.Common;
using System.Data;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace baseprotect
{
    public class Version
    {
        public static String Revision()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }
    }

    public class Utils
    {
        public static Object Missing = System.Type.Missing;

        public static DateTime CombineDateAndTime(DateTime date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day,
                                time.Hours, time.Minutes, time.Seconds);
        }

        public static string DateString(DateTime date)
        {
            return date.ToString("dd.MM.yyyy HH:mm:ss");
        }

        public static string String(object value)
        {
            if (value is DateTime)
                return DateString((DateTime)value);
            else
                return value.ToString();
        }

        public static string Convert(string s)
        {
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.Unicode;

            byte[] utfBytes = utf8.GetBytes(s);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            return iso.GetString(isoBytes);
        }

        public static void HandleException(Exception e, StreamWriter w)
        {
            if (e.InnerException != null)
            {
                w.Write(e.InnerException.Message);
                w.Write(e.InnerException.StackTrace);
            }

            w.Write(e.StackTrace);
            w.Flush();

            MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool LongerContainShorter(string first, string second)
        {
            string longer =  first.Length >= second.Length ? first : second;
            string shorter = first.Length < second.Length ? first : second;

            return longer.Trim().ToUpper().Contains(shorter.Trim().ToUpper());
        }

        public class Getter<R>
        {
            public static R Get( object o, string member )
            {
                Type objType = o.GetType();
                Object Value = objType.GetProperty(member).GetValue(o, null);
                if (Value is R)
                    return (R)Value;
                return default(R);
            }
        }

        public class EnumeratorJoin<T>
        {
            static public IEnumerable<T> Join(params IEnumerable<T>[] enums)
            {
                foreach (IEnumerable<T> en in enums)
                    foreach (T t in en)
                        yield return t;
            }
        }

        public static byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public static void WriteFully(Stream stream, byte[] data)
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(data);
                writer.Close();
            }
        }

        public static void BringToFront(Form form)
        {
            form.TopMost = true;
            form.TopMost = false;
        }

        public static object[] GetOneDimension(object[,] array, int index)
        {
            object[] arr = new object[array.GetLength(1) + 1];
            for (int i = array.GetLowerBound(1); i <= array.GetLength(1); i++)
            {
                arr[i] = array[index, i];
            }
            return arr;
        }

        public static void IgnoreExceptions(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception)
            {
            }
        }
    }

    public static class Extenions
    {
        public static RadioButton GetChecked(this GroupBox group)
        {
            foreach(RadioButton control in group.Controls)
            {
                if (control.Checked)
                    return control;
            }
            return null;
        }

        public static IEnumerable<string> SplitByLength(this string s, int length)
        {
            for (int i = 0; i < s.Length; i += length)
            {
                if (i + length <= s.Length)
                {
                    yield return s.Substring(i, length);
                }
                else
                {
                    yield return s.Substring(i);
                }
            }
        }

        public static IEnumerable<string> SplitByLengthFromEnd(this string s, int length)
        {
            int i = s.Length;
            while(i > 0)
            {
                i = i - length;
                if (i < 0)
                    yield return s.Substring(0, length + i);
                else
                    yield return s.Substring(i, length);
            }
        }

        private static string GetMD5(this string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            MD5 hashString = new MD5CryptoServiceProvider();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }

    public class EnumerableWrapper<T>
    {
        IEnumerable<T> impl;

        public EnumerableWrapper(IEnumerable<T> enumerable)
        {
            impl = enumerable;
        }
 
        public T First
        {
            get{ return impl.First<T>(); }
        }

        public T Last
        {
            get { return impl.Last<T>(); }
        }

        public static implicit operator List<T>(EnumerableWrapper<T> wrapper)
        {
            return wrapper.impl.ToList();
        }

        public IEnumerable<T> ToEnumerable()
        {
            return impl;
        }
    }

    public class CompiledQueries
    {    
        public static Func<BaseprotectDB, int, int, IEnumerable<NetEvent>> eventsQuery =
           System.Data.Linq.CompiledQuery.Compile<BaseprotectDB, int, int, IEnumerable<NetEvent>>
           (
               (BaseprotectDB db, int personID, int projectID) =>
                   from e in db.Events
                   join pte in db.PersonsToEvents on e.ID equals pte.EventID
                   where e.ProjectID == projectID && pte.PersonID == personID 
                   select e                 
          );

        public static Func<BaseprotectDB, int, IEnumerable<NetEvent>> projectEventsQuery =
           System.Data.Linq.CompiledQuery.Compile<BaseprotectDB, int, IEnumerable<NetEvent>>
           (
               (BaseprotectDB db, int projectID) =>
                   from e in db.Events
                   where e.ProjectID == projectID
                   select e
          );
        
        public static Func<BaseprotectDB, int, IEnumerable<Person>> projectPersonQuery =
           System.Data.Linq.CompiledQuery.Compile<BaseprotectDB, int,  IEnumerable<Person>>
           (
               (BaseprotectDB db, int ProjectID) =>
                   (from p in db.Persons
                   join ptp in db.PersonInProject on p.ID equals ptp.PersonID
                   where ptp.ProjectID == ProjectID
                   select p).Distinct()
           );
    }

    public class TypeUtils
    {
        public static T GetValueFromAnonymousType<T>(object dataitem, string itemkey)
        {
            System.Type type = dataitem.GetType();
            PropertyInfo info = type.GetProperty(itemkey);
            if (info != null)
            {
                T itemvalue = (T)info.GetValue(dataitem, null);
                return itemvalue;
            }
            return default(T);
        }

        public static T GetFromReader<T>(DbDataReader reader, String item)
        {
            try
            {
                if (!reader.HasColumn(item))
                {
                    if (typeof(T) == typeof(String))
                        return (T)(Object)String.Empty;
                    return default(T);
                }

                return TypeUtils.EnsureValid<T>(reader[item]);
            }
            catch (Exception)
            {
                if (typeof(T) == typeof(String))
                    return (T)(Object)String.Empty;
                return default(T);
            }
        }

        public static T EnsureValid<T>(Object obj)
        {
            if (obj.GetType() == typeof(System.DBNull))
            {
                if (typeof(T) == typeof(String))
                    return (T)(Object)String.Empty;
                return default(T);
            }

            else if (obj.GetType() == typeof(T))
                return (T)obj;
            else
            {
                if (typeof(T) == typeof(String))
                    return (T)(Object)String.Empty;
                return default(T);
            }
        }

        public static T EnsureValid<T>(Object obj, bool _throw)
        {
            if (obj.GetType() == typeof(System.DBNull))
            {
                if (typeof(T) == typeof(String))
                    return (T)(Object)String.Empty;
                return default(T);
            }

            else if (obj.GetType() == typeof(T))
                return (T)obj;
            else
            {
                if (typeof(T) == typeof(String))
                    return (T)(Object)String.Empty;
                if (_throw)
                    throw new Exception(String.Format("Wrong type {0}", typeof(T)));
                return default(T);
            }
        }
    }

    public static class StringExtensions 
    {
        public static string RemoveDigits(this string key)
        {
	        return Regex.Replace(key, @"\d", "");
        }

        public static string GetMd5Hash(this string input)
        {
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++){
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }

    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }
    }

    public static class DateTimeUtils
    {
        public static DateTime GetNISTDate(bool convertToLocalTime)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            DateTime date = DateTime.Today;
            string serverResponse = string.Empty;

            // Represents the list of NIST servers
            string[] servers = new string[] {
                             "64.90.182.55",
                             "206.246.118.250",
                             "207.200.81.113",
                             "128.138.188.172",
                             "64.113.32.5",
                             "64.147.116.229",
                             "64.125.78.85",
                             "128.138.188.172"
                              };

            // Try each server in random order to avoid blocked requests due to too frequent request
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    // Open a StreamReader to a random time server
                    StreamReader reader = new StreamReader(new System.Net.Sockets.TcpClient(servers[ran.Next(0, servers.Length)], 13).GetStream());
                    serverResponse = reader.ReadToEnd();
                    reader.Close();

                    // Check to see that the signiture is there
                    if (serverResponse.Length > 47 && serverResponse.Substring(38, 9).Equals("UTC(NIST)"))
                    {
                        // Parse the date
                        int jd = int.Parse(serverResponse.Substring(1, 5));
                        int yr = int.Parse(serverResponse.Substring(7, 2));
                        int mo = int.Parse(serverResponse.Substring(10, 2));
                        int dy = int.Parse(serverResponse.Substring(13, 2));
                        int hr = int.Parse(serverResponse.Substring(16, 2));
                        int mm = int.Parse(serverResponse.Substring(19, 2));
                        int sc = int.Parse(serverResponse.Substring(22, 2));

                        if (jd > 51544)
                            yr += 2000;
                        else
                            yr += 1999;

                        date = new DateTime(yr, mo, dy, hr, mm, sc);

                        // Convert it to the current timezone if desired
                        if (convertToLocalTime)
                            date = date.ToLocalTime();

                        // Exit the loop
                        break;
                    }

                }
                catch (Exception ex)
                {
                    /* Do Nothing...try the next server */
                }
            }

            return date;
        }

        /// <summary>
        /// <para>Truncates a DateTime to a specified resolution.</para>
        /// <para>A convenient source for resolution is TimeSpan.TicksPerXXXX constants.</para>
        /// </summary>
        /// <param name="date">The DateTime object to truncate</param>
        /// <param name="resolution">e.g. to round to nearest second, TimeSpan.TicksPerSecond</param>
        /// <returns>Truncated DateTime</returns>
        public static DateTime Truncate(this DateTime date, long resolution)
        {
            return new DateTime(date.Ticks - (date.Ticks % resolution), date.Kind);
        }
    }

    public static class SqlCeUpgrade
    {
        public static void EnsureVersion40(this System.Data.SqlServerCe.SqlCeEngine engine, string filename)
        {
            SQLCEVersion fileversion = DetermineVersion(filename);
            if (fileversion == SQLCEVersion.SQLCE20)
                throw new ApplicationException("Unable to upgrade from 2.0 to 4.0");

            if (SQLCEVersion.SQLCE40 > fileversion)
            {
                engine.Upgrade();
            }
        }

        private enum SQLCEVersion
        {
            SQLCE20 = 0,
            SQLCE30 = 1,
            SQLCE35 = 2,
            SQLCE40 = 3
        }

        private static SQLCEVersion DetermineVersion(string filename)
        {
            var versionDictionary = new Dictionary<int, SQLCEVersion> 
            { 
                { 0x73616261, SQLCEVersion.SQLCE20 }, 
                { 0x002dd714, SQLCEVersion.SQLCE30},
                { 0x00357b9d, SQLCEVersion.SQLCE35},
                { 0x003d0900, SQLCEVersion.SQLCE40}
            };

            int versionLONGWORD = 0;
            try
            {
                using (var fs = new FileStream(filename, FileMode.Open))
                {
                    fs.Seek(16, SeekOrigin.Begin);
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        versionLONGWORD = reader.ReadInt32();
                    }
                }
            }
            catch
            {
                throw;
            }
            if (versionDictionary.ContainsKey(versionLONGWORD))
            {
                return versionDictionary[versionLONGWORD];
            }
            else
            {
                throw new ApplicationException("Unable to determine database file version");
            }
        }


    }
}
