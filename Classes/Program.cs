using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ITS.Exwold.Desktop
{
    static class Program
    {
        static public ThreadLog Log;
        static public List<TCPServer> ScannerServers;
        static public ScannerCommunications ScannerComms = new ScannerCommunications();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new MainStatusForm());

            MainStatusForm mainForm = new MainStatusForm();
            try
            {
                mainForm.ShowDialog();
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
        }
    }
}
