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
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using NiceLabel.SDK;


namespace ITS.Exwold.Desktop
{
    internal class NiceLabel : IDisposable
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
        private const int cstPrintTimeout = 5000;

        private string _niceLabelSDKPath = string.Empty;
        private bool _printEngineAvailable = false;
        private CancellationTokenSource ctsPrinting;
        private IPrintRequest printRequest;
        private IList<IPrinter> printers;
        #endregion
        #region Properties
        internal IList<IPrinter> LabelPrinters
        { get { return printers; } }
        
        internal bool PrintEngineAvailable
        { get => _printEngineAvailable; }
        
        #endregion
        #region Constructor
        internal NiceLabel(string NiceLabelSDKPath)
        {
            _niceLabelSDKPath = NiceLabelSDKPath;
            _printEngineAvailable = InitPrintEngine(_niceLabelSDKPath);
        }
        #endregion
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
        internal async Task<bool> PrintInnerLabel(InnerLabelData innerLabelData, string printerName)
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
                //Print the number of labels requested
                await PrintLabel(label, innerLabelData.PrintQty, cstPrintTimeout);
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            return false;
        }
        internal async Task<bool> PrintOuterLabel(OuterLabelData outerLabelData, string printerName)
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
                //Print the number of labels requested
                await PrintLabel(label, outerLabelData.PrintQty, cstPrintTimeout);
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            return false;
        }
        internal async Task<bool> PrintPalletLabel(PalletLabelData palletLabelData, string printerName)
        {
            if (palletLabelData == null) throw new ArgumentNullException("palletLabelData");

            try
            {
                DisposePrintRequest();
                ILabel label = PrintEngineFactory.PrintEngine.OpenLabel(palletLabelData.LabelPath);

                // Enable MonitorSpoolJobStatus to raise SpoolJobStatusChanged events.
                label.PrintSettings.MonitorSpoolJobStatus = true;

                label.Variables["GMID"].SetValue(palletLabelData.GMID);
                label.Variables["Count"].SetValue(palletLabelData.Count);
                label.Variables["NetUnits"].SetValue(palletLabelData.NetUnits);
                label.Variables["NetVolume"].SetValue(palletLabelData.NetVolume);
                label.Variables["NetUnits_AI"].SetValue(palletLabelData.NetUnits_AI);
                label.Variables["BatchNumber"].SetValue(palletLabelData.BatchNumber);
                label.Variables["ProductionDate"].SetValue(palletLabelData.ProductionDate);
                label.Variables["SSCC"].SetValue(palletLabelData.SSCC);
                label.Variables["GTIN"].SetValue(palletLabelData.GTIN);
                label.Variables["LabelNumber"].SetValue(palletLabelData.LabelNumber);
                label.Variables["TotalLabels"].SetValue(palletLabelData.TotalLabels);
                //label.Variables["ProductName"].SetValue(palletLabelData.ProductName);


                //Set the printer to print to
                label.PrintSettings.PrinterName = printerName;
                //Print the number of labels requested
                await PrintLabel(label, palletLabelData.PrintQty, cstPrintTimeout);
            }
            catch(SDKException ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.DetailedMessage);

            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            return false;
        }
        internal void CancelPrint()
        {
            // Cancelled the print task
            if (ctsPrinting != null)
            {
                ctsPrinting.Cancel();
            }
        }
        private async Task<bool> PrintLabel(ILabel labelToPrint, int PrintQty, int PrintTimeout = 5000)
        {
            if (ctsPrinting != null) ctsPrinting.Dispose();
            ctsPrinting = new CancellationTokenSource();
            printRequest = await ActionPrintGetRequest(labelToPrint, PrintQty, PrintTimeout);

            if (printRequest != null)
            {
                // Add handler for the PrintRequest's PrintJobStatusChanged event
                printRequest.PrintJobStatusChanged += PrintRequest_PrintJobStatusChanged;

                // Add handler for the PrintRequest's SpoolJobStatusChanged event
                printRequest.SpoolJobStatusChanged += PrintRequest_SpoolJobStatusChanged;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Task<IPrintRequest> ActionPrintGetRequest(ILabel labelToPrint, int PrintQty, int PrintTimeout = 5000)
        {
            IPrintRequest printRequest;
            int printStatus = int.MinValue;
            var statusHandler = new Progress<int>(value =>
            {
                printStatus = value;
            });
            var status = statusHandler as IProgress<int>;

            // Reset the cancellation token
            ctsPrinting.Dispose();
            ctsPrinting = new CancellationTokenSource();

            //Set the cancellation after the given timeout
            ctsPrinting.CancelAfter(PrintTimeout);

            CancellationToken CancelToken = ctsPrinting.Token;
            ctsPrinting.CancelAfter(PrintTimeout);

            //Defin the print task
            return Task.Run(() =>
            {
                printRequest = null;
                try
                {
                    try
                    {
                        printRequest = labelToPrint.Print(PrintQty);
                    }
                    catch (SDKException ex)
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), ex.DetailedErrorCode);
                    }
                    catch (Exception ex)
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), ex.Message);
                    }
                    CancelToken.ThrowIfCancellationRequested();
                }
                catch (TaskCanceledException)
                {
                    status.Report(-3);
                    return null;
                    //tbProgress.BeginInvoke((Action)delegate ()
                    //{
                    //    tbProgress.Text = "Task Timed-out";
                    //});
                }
                catch (OperationCanceledException)
                {
                    status.Report(-1);
                    return null;
                }
                catch (OperationAbortedException)
                {
                    status.Report(-2);
                    return null;
                }
                // Task completed
                return printRequest;
            });
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
            if (printRequest != null)
            {
                printRequest.PrintJobStatusChanged -= PrintRequest_PrintJobStatusChanged;
                printRequest.SpoolJobStatusChanged -= PrintRequest_SpoolJobStatusChanged;
                printRequest.Dispose();
                printRequest = null;
            }
        }
    }


    public class ValidatePrintData
    {
        /// <summary>
        /// Check the label file exists
        /// </summary>
        /// <param name="LabelPath">Path of the label file</param>
        /// <param name="ErrorStr">Error message to collate</param>
        /// <returns></returns>
        private protected bool validateLabelPath(string LabelPath, out string ErrorStr)
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
        private protected bool validateGTIN(string GTIN, out string ErrorStr)
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
        private protected bool validateLotNo(string LotNo, out string ErrorStr)
        {
            ErrorStr = string.Empty;
            StringValidator sv = new StringValidator(3, 20, "  ~!@#$%^&*()[]{}/;’\"|\\");
            if (sv.CanValidate(LotNo.GetType()))
            {
                try
                {
                    sv.Validate(LotNo);
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
        private protected bool validatePrintQty(int PrintQty, out string ErrorStr)
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
        private protected bool validateProductionData(DateTime ProdDate, out string ErrorStr)
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

    public class InnerLabelData : ValidatePrintData, IBaseLabel, IInnerLabel 
    {
        #region Backing Fields
        private string _labelPath;
        private int _printQty;
        private string _GTIN;
        private string _lotNo;
        private DateTime _prodDate;
        #endregion
        #region Base Properties
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
        #endregion
        #region InnerLabel Properties
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
        #endregion
        /// <summary>
        /// The date written to the label 'YYMMDD'
        /// </summary>
        public string ProdDateForLabel
        {
            get { return _prodDate.ToString("yyMMdd"); }
        }

        #region Constructor(s)
        public InnerLabelData(){ }
        #endregion


    }

    public class OuterLabelData : ValidatePrintData, IBaseLabel, IOuterLabel
    {
        #region Backing Fields
        private string _labelPath;
        private int _printQty;
        private string _GTIN;
        private string _lotNo;
        private DateTime _prodDate;
        private string _productName;        
        #endregion
        #region Constructor(s)
        public OuterLabelData() { }
        #endregion
        #region Base Properties
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
        public bool CanPrintLabel(out StringBuilder Errors)
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
            //Validate the Productname
            if (!validateProductName(_productName, out ErrorStr))
            {
                Errors.AppendLine(ErrorStr);
            }
            return true;
        }

        #endregion
        #region OuterLabel Properties
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
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
            }
        }
        #endregion
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

    public class PalletLabelData : ValidatePrintData, IBaseLabel, IPalletLabel
    {
        #region Backing Fields
        private string _labelPath; 
        private int _printQty;
        private string _GMID;
        private string _Count;
        private string _NetUnits;
        private string _NetVolume;
        private string _NetUnits_AI;
        private string _BatchNumber;
        private string _ProductionDate;
        private string _SSCC;
        private string _GTIN;
        private string _LabelNumber;
        private string _TotalLabels;
        private string _ProductName;
        private string _ProductionLineNo;
        #endregion
        #region Constructor(s)
        public PalletLabelData() { }
        #endregion
        #region Base Properties
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
        public bool CanPrintLabel(out StringBuilder Errors)
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
            return true;
        }
        #endregion
        #region Pallet Label Properties
        public string GMID
        {
            get { return _GMID; }
            set { _GMID = value; }
        }
        public string Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        public string NetUnits
        {
            get { return _NetUnits; }
            set { _NetUnits = value; }
        }
        public string NetVolume
        {
            get { return _NetVolume; }
            set { _NetVolume = value; }
        }
        public string NetUnits_AI
        {
            get { return _NetUnits_AI; }
            set { _NetUnits_AI = value; }
        }
        public string BatchNumber
        {
            get { return _BatchNumber; }
            set { _BatchNumber = value; }
        }
        public string ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }
        public string ProdDateForLabel
        {
            get => _ProductionDate; 
        }
        public string SSCC
        {
            get { return _SSCC; }
            set { _SSCC = value; }
        }
        public string GTIN
        {
            get { return _GTIN; }
            set { _GTIN = value; }
        }
        public string LabelNumber
        {
            get { return _LabelNumber; }
            set { _LabelNumber = value; }
        }
        public string TotalLabels
        {
            get { return _TotalLabels; }
            set { _TotalLabels = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public string ProductionLineNo
        {
            get { return _ProductionLineNo; }
            set { _ProductionLineNo = value; }
        }
        #endregion
    }



    public interface IBaseLabel
    {
        string LabelPath { get; set; }
        int PrintQty { get; set; }
        bool CanPrintLabel(out StringBuilder Errors);
    }
    public interface IInnerLabel
    {
        string GTIN { get; set; }
        string LotNo { get; set; }
        DateTime ProductionDate { get; set; }
        string ProdDateForLabel { get; }
    }
    public interface IOuterLabel
    {
        string GTIN { get; set; }
        string LotNo { get; set; }
        DateTime ProductionDate { get; set; }
        string ProdDateForLabel { get; }
        string ProductName { get; set; }
    }
    public interface IPalletLabel
    {
        string GMID { get; set; }
        string Count { get; set; }
        string NetUnits { get; set; }
        string NetVolume { get; set; }
        string NetUnits_AI { get; set; }
        string BatchNumber { get; set; }
        string ProductionDate { get; set; }
        string ProdDateForLabel { get; }
        string SSCC { get; set; }
        string GTIN { get; set; }
        string LabelNumber { get; set; }
        string TotalLabels { get; set; }
        string ProductName { get; set; }
        string ProductionLineNo { get; set; }
    }

}

