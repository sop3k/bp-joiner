using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace baseprotect
{
    public class I18n
    {
        private StreamWriter debug;
        private Dictionary<string, string> written = new Dictionary<string, string>();
        private Dictionary<string, string> dict = new Dictionary<string, string>();

        public I18n(string file)
        {
            LoadDictionary(file);
        }

        public void LoadDictionary(string filename)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] words = line.Split('=');

                    if (words.Length == 2)
                    {
                        PutInDict(words[0], words[1]);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public void PutInDict(string origin, string translate){
            dict.Add(origin, translate);
        }

        public string Get(string origin)
        {
            debug = new StreamWriter("debug.lng", true);
            if (!written.ContainsKey(origin))
            {
                written.Add(origin, "");
                debug.WriteLine(origin + "=");
            }
            debug.Close();
            if (dict.ContainsKey(origin))
                return dict[origin];
            return origin;
        }

        public string this[string origin]
        {
            get { return Get(origin); }
        }


        public void SetLang(Control parent)
        {
            parent.Text = Get(parent.Text);
            foreach (Control c in parent.Controls){
                c.Text = Get(c.Text);
            }
        }
    }
}
