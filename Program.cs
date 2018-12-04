using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ExwoldPcInterface
{
    static class Program
    {
        static public ThreadLog Log;
        static public Database ExwoldDb;
        static public List<TCPServer> ScannerServers;
        static public ScannerCommunications ScannerComms = new ScannerCommunications();
        static public string NiceLabelSDKPath = "";

   
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
            mainForm.ShowDialog();

        }

        static public bool ValidateInput(string CheckString, string DisplayString, string CheckType = "Alpha", int CheckLengthMax = 1000, int CheckLengthMin = 0, string Canbe0 = "yes")
        {
            if (CheckString.Length < CheckLengthMin)
            {
                MessageBox.Show(DisplayString + " is too short");
                const string methodName = "Program.cs ValidateInput: ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " too few Chars");
                return true;
            }
            if (CheckString.Length > CheckLengthMax)
            {
                MessageBox.Show(DisplayString + " is too long");
                const string methodName = "Program.cs ValidateInput: ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " too many Chars");
                return true; 
            }
            if (CheckType == "Numeric")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "[a-zA-Z]");
                if (containsLetter == true || CheckString.StartsWith("-"))
                {
                    MessageBox.Show(DisplayString + " should be numeric only");
                    const string methodName = "Program.cs ValidateInput: ";
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " should be numeric only");

                    return true;
                }
            }
                if (CheckType == "Int")
                {
                    bool containsLetter = Regex.IsMatch(CheckString, "[a-zA-Z]");
                    bool containsDecimal = Regex.IsMatch(CheckString, "[.]");
                    if (containsLetter == true || containsDecimal == true || CheckString.StartsWith("-"))
                    {
                        MessageBox.Show(DisplayString + " should be whole number only");
                        const string methodName = "Program.cs ValidateInput: ";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " should be whole number only");

                        return true;
                    }
                }
            if (CheckType == "SalesOrderAdd")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "[ _,.£$%&]");
                if (containsLetter == true)
                {
                    MessageBox.Show(DisplayString + " Cannot contain _ , . or [space]");
                    const string methodName = "Program.cs ValidateInput: ";
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " Cannot contain _ , . £ $ % & or [space]");

                    return true;
                }
                string sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchNo = '" + CheckString + "' AND (Status <> '4' AND Status <> '5')";
                DataTable CheckRows = Program.ExwoldDb.ExecuteQuery(sql);
                if (CheckRows.Rows.Count > 0)
                {
                    MessageBox.Show(DisplayString + " '" + CheckString + "' is already in progress");
                    const string methodName = "Program.cs ValidateInput: ";
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " is already in progress");

                    return true;
                }
                if (CheckType == "SalesOrderEdit")
                {
                    containsLetter = Regex.IsMatch(CheckString, "[ _,.£$%&]");
                    if (containsLetter == true)
                    {
                        MessageBox.Show(DisplayString + " Cannot contain _ , . or [space]");
                        const string methodName = "Program.cs ValidateInput: ";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " Cannot contain _ , . £ $ % & or [space]");

                        return true;
                    }
                    sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchNo = '" + CheckString + "' AND (Status <> '4' AND Status <> '5')";
                    CheckRows = Program.ExwoldDb.ExecuteQuery(sql);
                    if (CheckRows.Rows.Count > 1)
                    {
                        MessageBox.Show(DisplayString + " '" + CheckString + "' is already in progress");
                        const string methodName = "Program.cs ValidateInput: ";
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " is already in progress");

                        return true;
                    }

                }
            }
            if (CheckType == "ProdLine")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "[123]");
                if (containsLetter == false)
                {
                    MessageBox.Show(DisplayString + " Must be 1, 2 or 3");
                    const string methodName = "Program.cs ValidateInput: ";
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " not 1, 2 or 3");

                    return true;
                }

            }
            if (Canbe0 == "No")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "^0$");
                if (containsLetter == true)
                {
                    MessageBox.Show(DisplayString + " Cannot be 0");
                    const string methodName = "Program.cs ValidateInput: ";
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + DisplayString + " cannot be 0");

                    return true;
                }

            }
            return false;
        }
    }
}
