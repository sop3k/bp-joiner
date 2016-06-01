using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace baseprotect
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
    }

    public class LoadingIndicator : IDisposable
    {
        private Form splashScreen;
        private Form afterLoad; 

        public LoadingIndicator(Form splashScreenForm, Form afterLoadForm)
        {
            splashScreen = splashScreenForm;
            afterLoad = afterLoadForm;
            new Thread(ShowForm).Start();
        }

        private void ShowForm()
        {
            splashScreen.ShowDialog();
        }

        public void Dispose()
        {
            splashScreen.Invoke(new MethodInvoker(delegate()
                {
                    splashScreen.DialogResult = DialogResult.OK;
                }
            ));

            afterLoad.Invoke(new MethodInvoker(delegate()
                {
                    afterLoad.TopMost = true;
                    afterLoad.TopMost = false;
                }
            ));
           
        }
    }
}
