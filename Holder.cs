using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;

namespace baseprotect
{
    public class ValueHolder
    {
        object value;

        public ValueHolder(object v)
        {
            value = v;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
                return false;

            if (value == null)
                return false;

            ValueHolder p = obj as ValueHolder;
            if ((object)p == null)
                return false;

            return value.Equals(p.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            if (value == null)
                return "";
            return value.ToString();
        }

        public T GetValue<T>()
        {
            return (T)value;
        }

        public bool IsNull()
        {
            return value == null;
        }
    }

    public class IPHolder : ValueHolder
    {
        byte[] segments = null;

        char[] sep = new char[] { '.', ' ' };
        string regex_sep = @"[:\.\s]";

        public IPHolder(object addr)
            : base(addr)
        {
            if ( addr != null )
            {
                string saddr;
                if (addr.GetType() != typeof(String)){
                    saddr = Convert.ToString(Convert.ToInt64(addr));
                }
                else
                    saddr = (string)addr;
                
                string[] seg = Regex.Split(saddr, regex_sep).Take(4).ToArray();
                if(seg.Length == 1)
                    seg = saddr.SplitByLengthFromEnd(3).Reverse().ToArray();
                segments = Array.ConvertAll(seg, (s) => { return byte.Parse(s); });
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || segments == null)
                return false;

            IPHolder p = obj as IPHolder;
            if ((object)p == null)
                return false;

            if (p.segments == null)
                return false;

            return p.segments[0] == segments[0] &&
                   p.segments[1] == segments[1] &&
                   p.segments[2] == segments[2] &&
                   p.segments[3] == segments[3];
        }

        public override int GetHashCode()
        {
            return segments.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(".", Array.ConvertAll(segments,
                (s) => { return s.ToString(); })
            );
        }
    }

    public class DateHolder : ValueHolder
    {
        public DateHolder(object d)
            : base(DateHolder.prepareDate(d))
        { }

        public static DateTime? prepareDate(object d)
        {
            if (d == null)
                return null;

            if (typeof(DateTime) == d.GetType())
                return (DateTime)d;

            DateTime? date = new DateTimeRecognizer((string)d).recognize();
            if (date.HasValue)
                return date.Value;
            return null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            DateHolder p = obj as DateHolder;
            if ((object)p == null)
                return false;

            return GetValue<DateTime>().Date.Equals(p.GetValue<DateTime>().Date);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            try
            {
                DateTime val = GetValue<DateTime>();
                return val.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception)
            {
                return "";
            }
        }
    }

    public class TimeHolder : ValueHolder
    {
        public TimeHolder(object t)
            : base(TimeHolder.prepareTime(t))
        { }

        public static TimeSpan? prepareTime(object t)
        {
            if (typeof(DateTime) == t.GetType())
                return ((DateTime)t).TimeOfDay;

            DateTime? time = new DateTimeRecognizer((string)t).recognize();
            if (time.HasValue)
                return time.Value.TimeOfDay;
            return null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            TimeHolder p = obj as TimeHolder;
            if ((object)p == null)
                return false;

            TimeSpan rhs = GetValue<TimeSpan>();
            TimeSpan lhs = p.GetValue<TimeSpan>();

            return (lhs - rhs).Duration() <= TimeSpan.FromMinutes(2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class DateTimeRecognizer
    {
        string data;
        int monthPos, yearPos, dayPos, minPos,
            hourPos, secPos;

        public DateTimeRecognizer(string s)
        {
            data = s.Trim();
        }

        public int TryParseInt(string input)
        {
            int result = 0;
            int.TryParse(input, out result);
            return result;
        }

        public int RecognizeMonth( string month )
        {
            string s = string.Format( "2010/{0}/10", month );
            DateTime d = new DateTime();

            try{
                d = InvariantRecognizer(s);
            }
            catch ( Exception ){
                d = AllCultureRecognizer(s);
            }
            return d.Month;
        }

        private DateTime InvariantRecognizer(string s)
        {
            try
            {
                return DateTime.ParseExact(s, "yyyy/MMMM/dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch ( FormatException )
            {
                return DateTime.ParseExact(s, "yyyy/MMM/dd", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        private DateTime CultureRecognizer(string s, CultureInfo culture)
        {  
                try{
                    return DateTime.ParseExact(s, "yyyy/MMMM/dd", culture);
                }
                catch ( FormatException ){
                    return DateTime.ParseExact(s, "yyyy/MMM/dd", culture);
                }
        }

        private DateTime AllCultureRecognizer(string s)
        {
            try
            {
               return CultureRecognizer(s, CultureInfo.CurrentCulture);
            }
            catch( FormatException )
            {
               foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
               {
                    try{
                        return CultureRecognizer(s, ci);
                    }
                    catch( Exception )
                    {
                        continue;
                    }
               }

               throw;
            }
        }

        public DateTime? recognize()
        {
            string split_pattern = @"[\\\-\.\s:/]";
            string[] parts = Regex.Split( data, split_pattern );
            int[] segments = Array.ConvertAll( parts, ( p ) => { return TryParseInt( p ); } );


            if ( segments.Length > 3 )
            {
                yearPos = Array.FindIndex( segments, ( part ) => { return part > 2000; } );

                if ( yearPos == -1 )
                {//data w formacie USA
                    if ( data.IndexOf( ':' ) > 5 )
                    {//data przed godzina

                        if ( data.IndexOf( ':' ) != data.LastIndexOf( ':' ) )
                        {//z sekundami
                            monthPos = 0;
                            dayPos = monthPos + 1;
                            yearPos = dayPos + 1;
                            hourPos = yearPos + 1;
                            minPos = hourPos + 1;
                            secPos = minPos + 1;
                        }
                        else
                        {//bez sekund
                            monthPos = 0;
                            dayPos = monthPos + 1;
                            yearPos = dayPos + 1;
                            hourPos = yearPos + 1;
                            minPos = hourPos + 1;
                            secPos = -1;
                        }
                    }
                    else
                    {//godzina przed data
                        if ( data.IndexOf( ':' ) != data.LastIndexOf( ':' ) )
                        {//z sekundami
                            hourPos = 0;
                            minPos = hourPos + 1;
                            secPos = minPos + 1;
                            monthPos = secPos + 1;
                            dayPos = monthPos + 1;
                            yearPos = dayPos + 1;
                        }
                        else
                        {//bez sekund
                            hourPos = 0;
                            minPos = hourPos + 1;
                            monthPos = minPos + 1;
                            dayPos = monthPos + 1;
                            yearPos = dayPos + 1;
                            secPos = -1;
                        }
                    }
                }
                else if ( yearPos == 0 )
                {
                    monthPos = yearPos + 1;
                    dayPos = monthPos + 1;
                    hourPos = dayPos + 1;
                    minPos = hourPos + 1;
                    secPos = minPos + 1;
                    if ( data.IndexOf( ':' ) == data.LastIndexOf( ':' ) )
                        secPos = -1;
                }
                else if ( yearPos == 2 )
                {//data przezd godziną

                    if ( data.IndexOf( ':' ) != -1 && data.IndexOf( ':' ) <= 2 )
                    {
                        //godzina przed datą
                        hourPos = 0;
                        minPos = hourPos + 1;

                        monthPos = yearPos + 1;
                        dayPos = monthPos + 1;

                        secPos = -1;
                    }
                    else
                    {
                        monthPos = yearPos - 1;
                        dayPos = monthPos - 1;
                        hourPos = yearPos + 1;
                        minPos = hourPos + 1;
                        secPos = minPos + 1;
                    }

                    if ( data.IndexOf( ':' ) == data.LastIndexOf( ':' ) )
                        secPos = -1;
                }
                else if ( yearPos == 3 )
                {//godzina przed datą

                    if ( data.IndexOf( ':' ) != data.LastIndexOf( ':' ) )
                    {
                        hourPos = 0;
                        minPos = hourPos + 1;
                        secPos = minPos + 1;
                        monthPos = yearPos + 1;
                        dayPos = monthPos + 1;
                    }
                    else
                    {
                        hourPos = 0;
                        minPos = hourPos + 1;
                        secPos = -1;
                        monthPos = yearPos + 1;
                        dayPos = monthPos + 1;
                    }
                }
                else if ( yearPos == segments.Length - 1 )
                {
                    if ( data.IndexOf( ':' ) == data.LastIndexOf( ':' ) )
                    {
                        hourPos = 0;
                        minPos = hourPos + 1;
                        secPos = -1;
                        monthPos = yearPos - 1;
                        dayPos = monthPos - 1;
                    }
                    else
                    {
                        hourPos = 0;
                        minPos = hourPos + 1;
                        secPos = minPos + 1;
                        monthPos = yearPos - 1;
                        dayPos = monthPos - 1;
                    }
                }

                if ( segments[monthPos] == 0 )
                    segments[monthPos] = RecognizeMonth( parts[monthPos] );

                if ( segments[yearPos] < 2000 )
                    segments[yearPos] += 2000;

                int sec = 0;
                if ( secPos != -1 && secPos < segments.Length )
                    sec = segments[secPos];

                return new DateTime( segments[yearPos], segments[monthPos], segments[dayPos],
                                    segments[hourPos], segments[minPos], sec );
            }
            else if ( segments.Length > 0 )
            {
                yearPos = Array.FindIndex( segments, ( part ) => { return part > 2000; } );

                if ( data.Contains( ":" ) )
                {//tylko godzina
                    hourPos = 0;
                    minPos = hourPos + 1;
                    secPos = minPos + 1;

                    int sec = 0;
                    if ( data.IndexOf( ':' ) != data.LastIndexOf( ':' ) )
                        sec = segments[secPos];

                    DateTime now = DateTime.Now;
                    return new DateTime( now.Year, now.Month, now.Day,
                                        segments[hourPos], segments[minPos], sec );
                }
                else
                {//tylko data
                    if ( yearPos < 0 )
                    {
                        monthPos = 0;
                        dayPos = monthPos + 1;
                        yearPos = dayPos + 1;
                    }
                    else if ( yearPos == 0 )
                    {
                        monthPos = yearPos + 1;
                        dayPos = monthPos + 1;
                    }
                    else if ( yearPos == segments.Length - 1 )
                    {
                        monthPos = yearPos - 1;
                        dayPos = monthPos - 1;
                    }

                    if ( segments[yearPos] < 2000 )
                        segments[yearPos] += 2000;

                    return new DateTime( segments[yearPos], segments[monthPos], segments[dayPos] );
                }
            }
            return null;
        }
    }
}
