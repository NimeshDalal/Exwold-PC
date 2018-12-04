//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd. All Rights Reserved.
//
// DISCUSSION
// Reads the PC.xml configuration file
//
// MODIFICATION HISTORY
// FileVersion  ProgVersion  Date        Project/CRF.    Who                     References
//     1.00      1.00.00.00  04Apr2017   702678          Stuart Eglington 
//              Initial Creation
//     1.01      1.03.00.00  30Jan2018   991068/CRF002   Martin Cox
//              Added SDK directory to config file, and associacted changes
//
//******************************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ExwoldPcInterface
{
    class Config
    {
        private const string moduleName = "Config";
        public static void ReadConfig(ref string LogFolder
                                        ,ref string appName
                                        ,ref int logLevel
                                        ,ref string DBConnectionString
                                        ,ref string DatabaseBackupsDaysToKeep
                                        ,ref string DatabaseBackupPath
                                        ,ref string NiceLabelSDKPath )
        {
            const string MethodName = moduleName + " ReadConfig(): ";
            try
            {
                
                String specFile = "PC.xml"; //must be in app folder

                XmlDocument xDoc = new System.Xml.XmlDocument();
                XmlNodeList xNodeList1;

                // Open XML document and read in data Name,Value pairs
                xDoc.Load(specFile);
                xNodeList1 = xDoc.GetElementsByTagName("Config");
                if (xNodeList1 != null)
                {
                    System.Xml.XmlNode xNode1 = xNodeList1.Item(0);
                    foreach (System.Xml.XmlNode xNode2 in xNode1.ChildNodes)
                    {
                        switch (xNode2.Name.ToString())
                        {
                            case "LogLevel"                 : logLevel                  = Convert.ToInt16(xNode2.InnerText.ToString()); break;
                            case "AppName"                  : appName                   = xNode2.InnerText.ToString();                  break;
                            case "LogFolder"                : LogFolder                 = xNode2.InnerText.ToString();                  break;
                            case "DBConnectionString"       : DBConnectionString        = xNode2.InnerText.ToString();                  break;
                            case "DatabaseBackupsDaysToKeep": DatabaseBackupsDaysToKeep = xNode2.InnerText.ToString();                  break;
                            case "DatabaseBackupPath"       : DatabaseBackupPath        = xNode2.InnerText.ToString();                  break;
                            case "NiceLabelSDKPath"         : NiceLabelSDKPath          = xNode2.InnerText.ToString();                  break;
                        }
                    }
                    if (!LogFolder.EndsWith("\\")) LogFolder = LogFolder + "\\";
                }
            }
            catch (Exception e)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, MethodName + "EXCEPTION: " + e.ToString());
            }
        }
    }
}
