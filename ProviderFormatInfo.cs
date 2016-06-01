using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace baseprotect
{
    class Fields
    {
        public static HashSet<String> Allowed = new HashSet<String>
        {
            "ip", "date", "time", "timezone", "index", "benken", "hash", "server", "plugintyp",
            "isp", "vorname", "nachname", "city", "email", "postal", "address_details", "sex",
            "full_address", "full_name", "client"
        };
    }

    class ProviderFormatInfo
    {
        public String ProviderName;
        private String[] sheets = {".*"};
        
        Dictionary<string, string> columnsToObject = new Dictionary<string, string>();
        List<object> regexList = new List<object>();

        public ProviderFormatInfo(string providerName)
        {
            ProviderName = providerName;
        }

        public void Load(StreamReader reader)
        {
            int lineNumber = 0;
            String line;

            while((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                String[] parts = line.Split('=');

                if (parts.Length < 2)
                    SyntaxError(lineNumber);

                String name = ParseLeftSide(parts[0]);
                var tokens = ParseRightSide(parts[1]);

                if (name.ToLower() == "sheet_name")
                    sheets = tokens.Cast<String>().ToArray();
                else
                {
                    foreach (Object tok in tokens)
                    {
                        if (tok is Regex)
                            regexList.Add(new { Name = name, Regex = tok });
                        else
                            columnsToObject[tok.ToString().ToUpper()] = name.ToUpper();
                    }
                }
            }
        }

        public virtual String TranslateColumn(Row row, String column)
        {
            String prop;
            String col = Prepare(column);
            if (columnsToObject.TryGetValue(col, out prop))
                return prop;

            foreach (var item in regexList)
            {
                String name = Utils.Getter<String>.Get(item, "Name");
                Regex re = Utils.Getter<Regex>.Get(item, "Regex");

                if (re.Match(col).Success)
                    return name;
            }

            return String.Empty;
        }

        public String Prepare(String column)
        {
            string pattern = @"^[Ff](?<Index>\d+)";
            Match match = Regex.Match(column, pattern);
            if (match.Success)
                return match.Groups["Index"].Value;
            else
                return column.ToUpper();
        }
        
        String ParseLeftSide(String tokens)
        {
            String fieldName = Regex.Replace(tokens, "\\s", String.Empty).ToLower();
            
            if (!Fields.Allowed.Contains(fieldName))
                NameError(fieldName);

            return fieldName;
        }

        IEnumerable<Object> ParseRightSide(String tokens)
        {
            String[] parts = tokens.Split('|');

            foreach (String token in parts)
                yield return ParseRightSideToken(token); 
        }

        Object ParseRightSideToken(String token)
        {
            if (token.StartsWith("(") && token.EndsWith(")"))
                return new Regex(token.Trim('(', ')'));
            return token;
        }

        void NameError(String name)
        {
            //throw NameErrorException(name);
        }

        void SyntaxError(int line)
        {
            //throw SytnaxErrorException(line);
        }

        public String[] Sheets
        {
            get { return sheets; }
        }

        public override string ToString()
        {
            return ProviderName;
        }
    }

    class ProviderFormatInfoMgr
    {
       static public IEnumerable<ProviderFormatInfo> LoadAllFormats(String dir)
       {
            foreach (String file in System.IO.Directory.GetFiles(dir, "*.isp"))
            {
                var pfi = new ProviderFormatInfo(System.IO.Path.GetFileNameWithoutExtension(file));
                using (var reader = new System.IO.StreamReader(System.IO.Path.Combine(dir, file), Encoding.UTF8))
                {
                    pfi.Load(reader);
                    yield return pfi;
                }
            }
        }
    }
}
