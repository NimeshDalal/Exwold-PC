//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides an interface to :
//  1)  Get selected batch data and display to user
//  2)  Give the user an option to repring the latest pallet from the pallet batch
//  3)  Give the user an option to edit the batch
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          04Apr2017   Stuart Eglington 
//          Initial Creation
//
//******************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Exwold.Desktop
{
    class ScannerCommunications
    {
        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        string BatchNumber;
        #endregion

        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion

        public ScannerCommunications()
        {
            //_db = database;
        }


        // Get message from scanner and respond
        public string HandleMessage(int ScannerNumber, string message)
        {   
 
            if(message.StartsWith("UPDATE"))
            {
                //do update code
                

            }
            if (message.StartsWith("PRINT"))
            {
                //do print code
                BatchNumber = message.Split(':').Last();
                frmPrint frmPrint = new frmPrint(_db);
                frmPrint.PrintBatchFlag = "Print";
                frmPrint.PrintBatchID = BatchNumber;
                frmPrint.ShowDialog();

            }
            if (message.StartsWith("REPRINT"))
            {
                //do reprint code
                BatchNumber = message.Split(':').Last();
                frmPrint frmPrint = new frmPrint(_db);
                frmPrint.PrintBatchFlag = "RePrint";
                frmPrint.PrintBatchID = BatchNumber;
                frmPrint.ShowDialog();
            }

           return "Received: " + message + Environment.NewLine + "From Scanner " + ScannerNumber.ToString();

        }

    }
}
