using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace baseprotect
{
    sealed class TempFile : IDisposable
    {
        string path;

        public TempFile(String ext)
        {
            string fn = string.Format(@"{0}.{1}", Guid.NewGuid(), ext);
            string path = System.IO.Path.GetTempPath();

            this.path = System.IO.Path.Combine(path, fn);
        }

        public string Path
        {
            get
            {
                if (path == null) 
                    throw new ObjectDisposedException(GetType().Name);
                return path;
            }
        }

        ~TempFile() 
        { 
            Dispose(false); 
        }

        public void Dispose() 
        { 
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            if (path != null)
            {
                try { File.Delete(path); }
                catch { } // best effort
                path = null;
            }
        }
    }
}
