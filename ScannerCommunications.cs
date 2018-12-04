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

namespace ExwoldPcInterface
{
    class ScannerCommunications
    {
        string BatchNumber;

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
                PrintForm1 frmPrint = new PrintForm1();
                frmPrint.PrintBatchFlag = "Print";
                frmPrint.PrintBatchID = BatchNumber;
                frmPrint.ShowDialog();

            }
            if (message.StartsWith("REPRINT"))
            {
                //do reprint code
                BatchNumber = message.Split(':').Last();
                PrintForm1 frmPrint = new PrintForm1();
                frmPrint.PrintBatchFlag = "RePrint";
                frmPrint.PrintBatchID = BatchNumber;
                frmPrint.ShowDialog();
            }

           return "Received: " + message + Environment.NewLine + "From Scanner " + ScannerNumber.ToString();

        }

    }
}
