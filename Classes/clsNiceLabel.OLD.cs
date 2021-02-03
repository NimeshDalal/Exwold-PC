/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsNiceLabel.cs
 * Description: Interface to the Nice Label print tool
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              Initial Creation
 *              InitializePrintEngine() using value from config file for NiceLabel SDK directory
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using NiceLabel.SDK;


namespace ITS.Exwold.Desktop
{
    internal class NiceLabel :IDisposable
    {
        #region IDisposable code
        // Pointer to an external unmanaged resource.
        private IntPtr handle;
        // Other managed resource this class uses.
        //private Component component = new Component();
        // Track whether Dispose has been called.
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    //component.Dispose();
                    PrintEngineFactory.PrintEngine.Shutdown();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;
            }
        }
        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~NiceLabel()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            PrintEngineFactory.PrintEngine.Shutdown();
            DisposePrintRequest();
            Dispose(false);            
        }
        #endregion region

        #region local variables
        private string _niceLabelSDKPath = string.Empty;
        private IPrintRequest printRequest;
        private IList<IPrinter> printers;
        #endregion
        #region Properties
        internal IList<IPrinter> LabelPrinters
        { get { return printers; } }
        #endregion
        #region Constructor
        internal NiceLabel(string NiceLabelSDKPath)
        {
            _niceLabelSDKPath = NiceLabelSDKPath;
            InitPrintEngine(_niceLabelSDKPath);
        }
        #endregion

        internal bool PrintInnerLabel(InnerLabelData innerLabelData, string printerName)
        {
            if (innerLabelData == null) throw new ArgumentNullException("innerLabelData");
            try
            {
                DisposePrintRequest();
                ILabel label = PrintEngineFactory.PrintEngine.OpenLabel(innerLabelData.LabelPath);

                // Enable MonitorSpoolJobStatus to raise SpoolJobStatusChanged events.
                label.PrintSettings.MonitorSpoolJobStatus = true;

                label.Variables["GTIN"].SetValue(innerLabelData.GTIN);
                label.Variables["LotNo"].SetValue(innerLabelData.LotNo);
                label.Variables["ProdDate"].SetValue(innerLabelData.ProdDateForLabel);

                //Set the printer to print to
                label.PrintSettings.PrinterName = printerName;
                //Number of labels to print
                printRequest = label.PrintAsync(innerLabelData.PrintQty);

                // Add handler for the PrintRequest's PrintJobStatusChanged event
                this.printRequest.PrintJobStatusChanged += this.PrintRequest_PrintJobStatusChanged;

                // Add handler for the PrintRequest's SpoolJobStatusChanged event
                this.printRequest.SpoolJobStatusChanged += this.PrintRequest_SpoolJobStatusChanged;
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            return false;
        }
        internal bool PrintOuterLabel(OuterLabelData outerLabelData, string printerName)
        {
            if (outerLabelData == null) throw new ArgumentNullException("outerLabelData");

            try
            {
                DisposePrintRequest();
                ILabel label = PrintEngineFactory.PrintEngine.OpenLabel(outerLabelData.LabelPath);

                // Enable MonitorSpoolJobStatus to raise SpoolJobStatusChanged events.
                label.PrintSettings.MonitorSpoolJobStatus = true;

                label.Variables["GTIN"].SetValue(outerLabelData.GTIN);
                label.Variables["LotNo"].SetValue(outerLabelData.LotNo);
                label.Variables["ProdDate"].SetValue(outerLabelData.ProdDateForLabel);
                label.Variables["ProdName1"].SetValue(outerLabelData.ProdName1);
                label.Variables["ProdName2"].SetValue(outerLabelData.ProdName2);

                //Set the printer to print to
                label.PrintSettings.PrinterName = printerName;
                //Number of labels to print
                printRequest = label.Print(outerLabelData.PrintQty);
                //printRequest = label.PrintAsync(outerLabelData.PrintQty);

                // Add handler for the PrintRequest's PrintJobStatusChanged event
                this.printRequest.PrintJobStatusChanged += this.PrintRequest_PrintJobStatusChanged;

                // Add handler for the PrintRequest's SpoolJobStatusChanged event
                this.printRequest.SpoolJobStatusChanged += this.PrintRequest_SpoolJobStatusChanged;
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            return false;
        }

        private bool InitPrintEngine(string SDKPath)
        {
            if (string.IsNullOrEmpty(SDKPath))
                throw new ArgumentNullException("SDKPath", "Path not provided to " + Logging.ThisMethod());
            try
            {
                if (ValidatePath(SDKPath))
                { 
                    PrintEngineFactory.SDKFilesPath = SDKPath; 
                }
                PrintEngineFactory.PrintEngine.Initialize();
                
                // Get the list of printers available on the current system 
                printers = PrintEngineFactory.PrintEngine.Printers;
            }
            catch (SDKException ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), $"SDK EXCEPTION", ex);
                return false;
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(),
                    $"Unexpected error initialising the Print Engine", ex);
                return false;
            }
            return true;
        }

        private bool ValidatePath(string dirPath)
        {
            bool bRtn = false;
            if (string.IsNullOrEmpty(dirPath))
                throw new ArgumentNullException("dirPath", "Path not provided to " + Logging.ThisMethod());

            try
            {
                bRtn = Directory.Exists(dirPath);
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, Logging.ThisMethod(), ex.Message);
            }
            return bRtn;
        }

        /// <summary>
        /// Handles the PrintJobStatusChanged event of the PrintRequest object.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PrintRequest_PrintJobStatusChanged(object sender, EventArgs e)
        {
            IPrintRequest printRequest = sender as IPrintRequest;
            string statusMessage = "PrintJob = " + printRequest.PrintJobStatus.ToString();
            //this.listBoxRequestStatuses.BeginInvoke(new AddStatusDelegate(this.AddStatus), statusMessage);
        }

        /// <summary>
        /// Handles the SpoolJobStatusChanged event of the PrintRequest object.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PrintRequest_SpoolJobStatusChanged(object sender, EventArgs e)
        {
            IPrintRequest printRequest = sender as IPrintRequest;
            string statusMessage = "SpoolJob = " + printRequest.SpoolJobStatus.ToString();
            //this.listBoxRequestStatuses.BeginInvoke(new AddStatusDelegate(this.AddStatus), statusMessage);
        }
        /// <summary>
        /// Disposes the print request.
        /// </summary>
        private void DisposePrintRequest()
        {
            if (this.printRequest != null)
            {
                this.printRequest.PrintJobStatusChanged -= this.PrintRequest_PrintJobStatusChanged;
                this.printRequest.SpoolJobStatusChanged -= this.PrintRequest_SpoolJobStatusChanged;
                this.printRequest.Dispose();
                this.printRequest = null;
            }
        }
    }

    public interface IBasePackLabel
    {
        string LabelPath { get; set; }
        int PrintQty { get; set; }
        string GTIN { get; set; }
        string LotNo { get; set; }
        DateTime ProductionDate { get; set; }

        bool CanPrintLabel(out StringBuilder Errors);
    }
    internal interface IPackLabelIProductName
    {
        string ProductName { get; set; }
    }

    public class InnerLabelData : IBasePackLabel
    {
        #region Private Variables
        private string _labelPath;
        private int _printQty;
        private string _GTIN;
        private string _lotNo;
        private DateTime _prodDate;
        #endregion
        #region Properties
        /// <summary>
        /// Path for the label to print
        /// </summary>
        public string LabelPath
        {
            get { return _labelPath; }
            set { _labelPath = value; }
        }
        /// <summary>
        /// Number of labels to print
        /// </summary>
        public int PrintQty 
        {
            get { return _printQty; } 
            set { _printQty = value; } 
        }
        /// <summary>
        /// Label GTIN (14 characters)
        /// </summary>
        public string GTIN 
        { 
            get { return _GTIN; } 
            set { _GTIN = value; } 
        }
        /// <summary>
        /// Label Lot Number (==Batch Number) (3-20 chars)
        /// </summary>
        public string LotNo 
        { 
            get { return _lotNo; } 
            set { _lotNo = value; } 
        }
        /// <summary>
        /// Label Production Date (Date of Manufacture)
        /// </summary>
        public DateTime ProductionDate 
        { 
            get { return _prodDate; } 
            set { _prodDate = value; } 
        }
        /// <summary>
        /// The date written to the label 'YYMMDD'
        /// </summary>
        public string ProdDateForLabel
        {
            get { return _prodDate.ToString("yyMMdd"); }
        }
        #endregion
        #region Constructor(s)
        public InnerLabelData(){ }
        #endregion
        public virtual bool CanPrintLabel(out StringBuilder Errors)
        {
            Errors = new StringBuilder();
            string ErrorStr = string.Empty;

            if (!validateLabelPath(_labelPath, out ErrorStr))
            {
                Errors.AppendLine(ErrorStr);
                return false;
            }
            if (!validatePrintQty(_printQty, out ErrorStr))
            {
                Errors.AppendLine(ErrorStr);
                return false;
            }
            if (!validateGTIN(_GTIN, out ErrorStr))
            {
                Errors.AppendLine(ErrorStr);
                return false;
            }
            if (!validateLotNo(_lotNo, out ErrorStr))
            {
                Errors.AppendLine(ErrorStr);
                return false;
            }
            if (!validateProductionData(_prodDate, out ErrorStr))
            {
                Errors.AppendLine(ErrorStr);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check the label file exists
        /// </summary>
        /// <param name="LabelPath">Path of the label file</param>
        /// <param name="ErrorStr">Error message to collate</param>
        /// <returns></returns>
        private bool validateLabelPath(string LabelPath, out string ErrorStr)
        {
            ErrorStr = string.Empty;
            bool bRes = File.Exists(LabelPath);
            if (!bRes) 
            {
                ErrorStr = $"Label Path Does not exist\n\'{LabelPath}\'";
            }
            return bRes;
        }
        /// <summary>
        /// GTIN must be 14 Alpha numeric characters
        /// </summary>
        /// <param name="GTIN">GTIN to print</param>
        /// <param name="ErrorStr">Error message to collate</param>
        /// <returns>true/false</returns>
        private bool validateGTIN(string GTIN, out string ErrorStr)
        {
            ErrorStr = string.Empty;
            StringValidator sv = new StringValidator(14, 14, "[a-z][A-Z]  ~!@#$%^&*()[]{}/;’\"|\\");
            if (sv.CanValidate(GTIN.GetType()))
            {
                try
                {
                    sv.Validate(GTIN);
                }
                catch (ArgumentException)
                {
                    ErrorStr = $"GTIN 14 Alpha Numeric Characters\n\'{GTIN}\' Is Invalid";
                    return false;
                    //Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), "GTIN 14 Alpha Numeric Characters", ex);
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Lot Number must be 3-20 Alpha numeric characters
        /// </summary>
        /// <param name="LotNo">Lot No to print</param>
        /// <param name="ErrorStr">Error message to collate</param>
        /// <returns>true/false</returns>
        private bool validateLotNo(string LotNo, out string ErrorStr)
        {
            ErrorStr = string.Empty;
            StringValidator sv = new StringValidator(3, 20, "  ~!@#$%^&*()[]{}/;’\"|\\");
            if (sv.CanValidate(GTIN.GetType()))
            {
                try
                {
                    sv.Validate(GTIN);
                }
                catch (ArgumentException)
                {
                    ErrorStr = $"LotNo 3-20 Alpha Numeric Characters\n\'{LotNo}\' Is Invalid";
                    return false;
                    //Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), "LotNo 3-20 Alpha Numeric Characters", ex);
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// The number of labels to print, must be greater than 0
        /// </summary>
        /// <param name="PrintQty">Number of labels to print</param>
        /// <param name="ErrorStr">Error message to collate</param>
        /// <returns>true/false</returns>
        private bool validatePrintQty(int PrintQty, out string ErrorStr)
        {
            ErrorStr = string.Empty;
            if (PrintQty <= 0)
            {
                ErrorStr = $"Print Quantity must be greater than zero\n\'{PrintQty}\' Is Invalid";
                return false;
            }
            return true;
        }
        /// <summary>
        /// The Production Data (Date of Manufacture)
        /// </summary>
        /// <param name="ProdDate">Prod Date for the label</param>
        /// <param name="ErrorStr">Error message to collate</param>
        /// <returns>true/false</returns>
        private bool validateProductionData(DateTime ProdDate, out string ErrorStr)
        {
            ErrorStr = string.Empty;
            if (ProdDate == null || ProdDate == DateTime.MinValue)
            {
                ErrorStr = $"The Production Date is Invalid\n\'{ProdDate.ToString()}\' Is Invalid";
                return false;
            }
            else
            { return true; }
        }
    }

    public class OuterLabelData : InnerLabelData, IPackLabelIProductName
    {
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
            }
        }
        public string ProdName1
        {
            get
            {
                if (_productName.Length > 30)
                {
                    return _productName.Substring(0, 29);
                }
                else
                {
                    return _productName;
                }
            }
        }
        public string ProdName2
        {
            get
            { 
                if (_productName.Length > 30)
                {
                    return _productName.Substring(30, _productName.Length - 30);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public override bool CanPrintLabel(out StringBuilder Errors)
        {
            Errors = new StringBuilder();
            string ErrorStr = string.Empty;
            //Validate from the base
            bool bBaseRtn = base.CanPrintLabel(out Errors);
            //Validate the Productname
            bool bAdditionalRtn = validateProductName(_productName, out ErrorStr);
            if (!bAdditionalRtn)
            {
                Errors.AppendLine(ErrorStr);
            }
            return (bBaseRtn & bAdditionalRtn);
        }

        /// <summary>
        /// The Product Name
        /// </summary>
        /// <param name="ProductName">Product Name for the label</param>
        /// <param name="ErrorStr">Error message to collate</param>
        /// <returns>true/false</returns>
        private bool validateProductName(string ProductName, out string ErrorStr)
        {
            ErrorStr = string.Empty;
            StringValidator sv = new StringValidator(6, 50, "~!@#$%^&*[]{}/;’\"|\\");
            if (sv.CanValidate(ProductName.GetType()))
            {
                try
                {
                    sv.Validate(ProductName);
                }
                catch (ArgumentException)
                {
                    ErrorStr = $"Product Name is 6-50 Alpha Numeric Characters\n\'{ProductName}\' Is Invalid";
                    return false;
                    //Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), "Product Name is 6-50 Alpha Numeric Characters", ex);
                }
                return true;
            }
            return false;
        }
    }
}

