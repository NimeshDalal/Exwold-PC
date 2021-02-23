using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop
{
    public partial class frmScannerMsg : Form
    {
        //private readonly DataInterface.execFunction _db = null;
        private readonly DataSet _labelDetails;
        private string _simMsg = string.Empty;
        public string SimMsg
        {  get { return _simMsg; } }
        public string GTIN { get; set; }
        public string LotNo { get; set; }
        public string ProdDate { get; set; }
        public string ProdName { get; set; }

        public frmScannerMsg(DataSet LabelDetails)
        {
            InitializeComponent();
            //_db = database;
            _labelDetails = LabelDetails;
        }

        private void frmScannerMsg_Load(object sender, EventArgs e)
        {
            writeLabelDetails(_labelDetails);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSetMsg_Click(object sender, EventArgs e)
        {
            try
            {
                _simMsg = PrepareMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Logging.ThisMethod(), ex.Message);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private string PrepareMessage()
        {
            StringBuilder msg = new StringBuilder();
            string str;
            //Add the stx
            msg.Append((char)MDC_ASCII.Ascii.STX);
            //Add the GTIN
            msg.Append("01");
            if (tbGTIN.Text.Length != 14)
            {
                throw new ArgumentOutOfRangeException("GTIN needs to be 14 chars");
            }
            msg.Append(tbGTIN.Text);
            //Add the Prod Date
            msg.Append("11");
            DateTime prodDate = DateTime.Parse(tbProdDate.Text);
            msg.Append($"{prodDate.ToString("yy")}{prodDate.ToString("MM")}{prodDate.ToString("dd")}");

            //Add the Lot No
            str = tbLotNo.Text.Trim();
            if (string.IsNullOrEmpty(str) || str.Length > 20)
            {
                throw new ArgumentOutOfRangeException("Lot Number is 1 - 20 chars");
            }
            msg.Append("10");
            msg.Append(str);

            //Add the product name
            str = tbProdName.Text.Trim();
            if (!string.IsNullOrEmpty(str))
            {
                //Add the separator char
                msg.Append((char)MDC_ASCII.Ascii.GS);
                // We have a prodname
                if (str.Length > 30)
                {
                    //Need 2x prod name strings
                    msg.Append("240");
                    msg.Append(str.Substring(0, 30));
                    msg.Append((char)MDC_ASCII.Ascii.GS);
                    msg.Append("240");
                    msg.Append(str.Substring(30, str.Length - 30));
                }
                else
                {
                    //Only have one prodname string
                    msg.Append("240");
                    msg.Append(str);
                }
            }
            //Add the ETX
            msg.Append((char)MDC_ASCII.Ascii.ETX);

            return msg.ToString();
        }


        private void writeLabelDetails(DataSet LabelDetails)
        {
            
            if (rdoInnerLabel.Checked && LabelDetails.Tables.Count == 2 && LabelDetails.Tables[1].Columns.Count > 0)
            {
                tbGTIN.Text = LabelDetails.Tables[1].Rows[0]["GTIN"].ToString();
                tbLotNo.Text = LabelDetails.Tables[1].Rows[0]["LotNo"].ToString();
                tbProdDate.Text = fmtDate(LabelDetails.Tables[1].Rows[0]["ManufactureDate"].ToString()).ToString("dd-MMM-yyyy");
                tbProdName.Text = string.Empty;
                tbProdName.Enabled = false;

            }
            else if (rdoOuterLabel.Checked && LabelDetails.Tables.Count == 2 && LabelDetails.Tables[0].Columns.Count > 0)
            {
                tbGTIN.Text = LabelDetails.Tables[0].Rows[0]["GTIN"].ToString();
                tbLotNo.Text = LabelDetails.Tables[0].Rows[0]["LotNo"].ToString();
                tbProdDate.Text = fmtDate(LabelDetails.Tables[1].Rows[0]["ManufactureDate"].ToString()).ToString("dd-MMM-yyyy");
                tbProdName.Text = LabelDetails.Tables[0].Rows[0]["ProductName"].ToString();
                tbProdName.Enabled = true;
            }
            else
            {               
                tbGTIN.Text = GTIN;
                tbLotNo.Text = LotNo;
                tbProdDate.Text = fmtDate(ProdDate).ToString("dd-MMM-yyyy");
                tbProdName.Text = ProdName;
                tbProdName.Enabled = true;
            }
        }
        private DateTime fmtDate(string ProdDate)
        {
            DateTime dte;
            try
            {
                DateTime.TryParse(ProdDate, out dte);
                //DateTime.TryParseExact(ProdDate, "yyMMdd", null, DateTimeStyles.None, out dte);
            }
            catch
            {
                dte = DateTime.Now;
            }
            return dte;
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            writeLabelDetails(_labelDetails);
        }
    }
}

