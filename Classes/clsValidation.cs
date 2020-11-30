using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace ITS.Exwold.Desktop
{
    public class clsValidation
    {
        public clsValidation(DataInterface.execFunction database)
        {
            _db = database;
        }

        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        #endregion

        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion
        
        private async Task<DataTable> getIncompleteOrders(string productId)
        {
            //Check the ProductID is a number
            int Id;
            if (int.TryParse(productId, out Id))
            {
                //Get Incomplete orders
                _db.QueryParameters.Clear();
                _db.QueryParameters.Add("ProductId", productId);
                return await _db.executeSP("[GUI].[getProductById]", true);
            }
            else
            { return null;  }
        }


        public async Task<bool> ValidateInput(
            string CheckString, string DisplayString, 
            string CheckType = "Alpha", int CheckLengthMax = 1000, 
            int CheckLengthMin = 0, string Canbe0 = "yes")
        {
            if (CheckString.Length < CheckLengthMin)
            {
                MessageBox.Show(DisplayString + " is too short");
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " too few Chars");
                return true;
            }
            if (CheckString.Length > CheckLengthMax)
            {
                MessageBox.Show(DisplayString + " is too long");
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " too many Chars");
                return true;
            }
            if (CheckType == "Numeric")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "[a-zA-Z]");
                if (containsLetter == true || CheckString.StartsWith("-"))
                {
                    MessageBox.Show(DisplayString + " should be numeric only");
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " should be numeric only");

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
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " should be whole number only");

                    return true;
                }
            }
            if (CheckType == "SalesOrderAdd")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "[ _,.£$%&]");
                if (containsLetter == true)
                {
                    MessageBox.Show(DisplayString + " Cannot contain _ , . or [space]");
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " Cannot contain _ , . £ $ % & or [space]");

                    return true;
                }
                //Mesh Remove
                //string sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchNo = '" + CheckString + "' AND (Status <> '4' AND Status <> '5')";
                //DataTable CheckRows = Program.ExwoldDb.ExecuteQuery(sql);
                DataTable CheckRows = await getIncompleteOrders(CheckString);
                if (CheckRows.Rows.Count > 0)
                {
                    MessageBox.Show(DisplayString + " '" + CheckString + "' is already in progress");
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " is already in progress");

                    return true;
                }
                if (CheckType == "SalesOrderEdit")
                {
                    containsLetter = Regex.IsMatch(CheckString, "[ _,.£$%&]");
                    if (containsLetter == true)
                    {
                        MessageBox.Show(DisplayString + " Cannot contain _ , . or [space]");
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " Cannot contain _ , . £ $ % & or [space]");

                        return true;
                    }
                    //Get Incomplete orders
                    CheckRows = await getIncompleteOrders(CheckString);

                    //Mesh Remove
                    //sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchNo = '" + CheckString + "' AND (Status <> '4' AND Status <> '5')";
                    //CheckRows = Program.ExwoldDb.ExecuteQuery(sql);
                    if (CheckRows.Rows.Count > 1)
                    {
                        MessageBox.Show(DisplayString + " '" + CheckString + "' is already in progress");
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " is already in progress");

                        return true;
                    }

                }
            }
            if (CheckType == "ProdLine")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "[0123456789]");
                if (containsLetter == false)
                {
                    MessageBox.Show(DisplayString + " Must be 1,2,3,4,5 or 6");
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " not 1,2,3,4,5 or 6");

                    return true;
                }

            }
            if (CheckType == "DateTime")
            {
                DateTime dt;
                if (!DateTime.TryParse(DisplayString, out dt))
                {
                    MessageBox.Show($"{DisplayString} Must a valid date");
                    return false;
                }
                return true;
            }
            if (Canbe0 == "No")
            {
                bool containsLetter = Regex.IsMatch(CheckString, "^0$");
                if (containsLetter == true)
                {
                    MessageBox.Show(DisplayString + " Cannot be 0");
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), DisplayString + " cannot be 0");

                    return true;
                }

            }
            return false;
        }
    }
}
