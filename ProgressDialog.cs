using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace baseprotect
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog(string opname)
        {
            InitializeComponent();
            Text = opname;
            Show();
        }

        public ProgressBar GetProgressBar()
        {
            return progress;
        }

        public void Begin(int beg, int end)
        {
            progress.Maximum = end;
            progress.Minimum = beg;
        }

        public void Update(int step)
        {
            while(--step >= 0)
                progress.PerformStep();
        }

        public void Reset()
        {
            progress.Value = progress.Minimum;
        }
    }
}
