//////////////////////////////////////////////////////////////////////////////
//
//  Project:    Generic
//  Date:       15 Apr 2012
//  Version:    1.00
//  Copyright:  (c) Copyright 2012 Industrial Technology Systems Ltd.
//              All Rights Reserved.using System
//  For further information, see ReadMe.txt
//
//////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace ExwoldPcInterface
{
    public class ThreadLog
    {
        public enum DebugLevel
        {
            Debug = 0,
            Message = 1,
            Information = 2,
            Warning = 3,
            Error = 4,
            Exception = 5
        }

        //================================================================================
        //   Error handling, and messages displayed on the control
        //================================================================================
        private int todaysDayNumber;
        private List<String> errorLogQueue = new List<String>();
        private String logFilePath   = "C:\\Debug\\";
        private String logFilePrefix = "Exwold_Tracking_PC_";
        private int logDaysToKeep = 30;
        private ThreadLog.DebugLevel loggingLevel = ThreadLog.DebugLevel.Information;
        private Timer logTimer;
        private Boolean hourlyFiles;

        public void Initialise(String logPath, String filenamePrefix, int daysToKeep, ThreadLog.DebugLevel logLevel, Boolean hourly)
        {
            logFilePath = logPath;
            logFilePrefix = filenamePrefix;
            logDaysToKeep = daysToKeep;
            loggingLevel = logLevel;
            hourlyFiles = hourly;
        }

        // Destructor: Save logs before destroying the object
        ~ThreadLog()
        {
            Program.Log.logSave();
        }

        public void StartLogging()
        {
            logTimer = new Timer(new TimerCallback(logTimerCallback), null, 10000, 10000);
            LogMessage(ThreadLog.DebugLevel.Error, "### THREADLOG STARTED ###");
        }


        public void LogMessage(ThreadLog.DebugLevel level, String data)
        {
            try
            {
                if (level >= loggingLevel)
                {
                    errorLogQueue.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "   " + data);
                }
            }
            catch { }
        }
        public void LogMessage(ThreadLog.DebugLevel level, String IPAddress, String data)
        {
            try
            {
                if (level >= loggingLevel)
                    errorLogQueue.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "   " + IPAddress + "   " + data);
            }
            catch { }
        }
        public void LogData(ThreadLog.DebugLevel level, string s, byte[] b)
        {
            try
            {
                if (level >= loggingLevel)
                {
                    string s2 = "";
                    for (int i = 0; i < b.Length; i++)
                    {
                        s2 = s2 + b[i].ToString("x").PadLeft(2, '0') + " ";
                    }
                    LogMessage(level, s, s2);
                }
            }
            catch { }
        }
        public void LogByteData(ThreadLog.DebugLevel level, string s, byte[] b)
        {
            try
            {
                if( level >= loggingLevel )
                {
                    LogMessage(level, s + " " + ByteArrayToAsciiNumbers(b));
                    LogMessage(level, s + " " + ByteArrayToAsciiNumbersReadable(b));
                }
            }
            catch { }
        }
        public void LogByteData(ThreadLog.DebugLevel level, string s1, string s2)
        {
            try
            {
                if( level >= loggingLevel )
                {
                    LogMessage(level, s1 + " " + ByteArrayToAsciiNumbers(s2));
                    LogMessage(level, s1 + " " + ByteArrayToAsciiNumbersReadable(s2));
                }
            }
            catch { }
        }
        public string ByteArrayToAsciiNumbers(byte[] b)
        {
            try
            {
                string s1  = "";
                for(int i = 0; i <= b.Length - 1; i++)
                {
                    s1 = s1 + b[i].ToString("x").PadLeft(2, '0') + " ";
                }
                return s1;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string ByteArrayToAsciiNumbers(string s)
        {
            try
            {
                string s1  = "";
                for(int i = 0; i <= s.Length - 1; i++)
                {
                    byte b = (byte)( s[i] );
                    s1 = s1 + b.ToString("x").PadLeft(2, '0') + " ";
                }
                return s1;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string ByteArrayToAsciiNumbersReadable(byte[] b)
        {
            try
            {
                string s2 = "";
                for( int i = 0; i <= b.Length - 1; i++)
                {
                    if( b[i] >= 32 && b[i] < 127 )
                    {
                        s2 = s2 + (char)b[i] + "  ";
                    }
                    else
                    {
                        s2 = s2 + b[i].ToString("x").PadLeft(2, '0') + " ";
                    }
                }
                return s2;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string ByteArrayToAsciiNumbersReadable(string s)
        {
            try
            {
                string s2 = "";
                for( int i = 0; i <= s.Length - 1; i++)
                {
                    byte b = (byte)( s[i] );
                    if( b >= 32 && b < 127 )
                    {
                        s2 = s2 + (char)b + "  ";
                    }
                    else
                    {
                        s2 = s2 + b.ToString("x").PadLeft(2, '0') + " ";
                    }
                }
                return s2;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void LogMemoryUsage()
        {
            try
            {
                Process myProcess = Process.GetCurrentProcess();
                if (!myProcess.HasExited)
                {
                    // Refresh the current process property values.
                    myProcess.Refresh();
                    // Display current process statistics.
                    LogMessage(ThreadLog.DebugLevel.Exception, "Process:" + myProcess.ToString() +
                                  " PhysicalMemoryUsage:" + myProcess.WorkingSet64 +
                                  " BasePriority:" + myProcess.BasePriority +
                                  " PriorityClass:" + myProcess.PriorityClass +
                                  " UserProcessorTime:" + myProcess.UserProcessorTime + 
                                  " PrivilegedProcessorTime:" + myProcess.PrivilegedProcessorTime +
                                  " TotalProcessorTime:" + myProcess.TotalProcessorTime +
                                  " PagedSystemMemorySize64:" + myProcess.PagedSystemMemorySize64 +
                                  " PagedMemorySize64:" + myProcess.PagedMemorySize64 +
                                  " PeakPagedMemorySize64:" + myProcess.PeakPagedMemorySize64 +
                                  " PeakVirtualMemorySize64:" + myProcess.PeakVirtualMemorySize64 +
                                  " PeakWorkingSet64" + myProcess.PeakWorkingSet64 );
                }
            }
            catch
            {
            }
        }


        //--------------------------------------------------------------------------------
        //   logTimer_Tick
        // When ErrorFilePath is set to a valid path, debug information will be saved.
        // No housekeeping will be performed - it is a manual process to remove the debug log files.
        //--------------------------------------------------------------------------------
        //Mutex logSaveMutex = new Mutex(true, "{05E14C45-116A-4887-8C7C-6729E4E03545}"); 
        Boolean logTimerCallbackInUse = false;
        private void logTimerCallback(Object stateInfo)
        {
            // use the Mutex to ensure we don't have concurrent running
            //if (logSaveMutex.WaitOne(10))
            if (logTimerCallbackInUse == false)
            {
                logTimerCallbackInUse = true;
                logSave();
                //logSaveMutex.ReleaseMutex(); 
                logTimerCallbackInUse = false;
            }

            // safety check so we don't eat memory in race condition
            if (errorLogQueue.Count > 1000)
            {
                errorLogQueue.Clear();
                logTimerCallbackInUse = false;
            }
        }

        public void logSave()
        {
            try
            {
                if (logFilePath != "" && errorLogQueue.Count > 0)
                {
                    // ensure trailling "\"
                    if (!logFilePath.EndsWith("\\"))
                    {
                        logFilePath = logFilePath + "\\";
                    }
                    // create directory object; check if directory exists, if not create it.
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(logFilePath);
                    if (!di.Exists)
                    {
                        try
                        {
                            di.Create();
                        }
                        catch
                        {
                            // error creating path, so ignore saving errors
                            logFilePath = "";
                        }
                    }

                    // If directory exists, save debug info
                    if (di.Exists)
                    {
                        // create file name
                        String filename = "";
                        if (hourlyFiles == true)
                        {
                            filename = logFilePrefix +
                                       String.Format("{0:yyyy}{0:MM}{0:dd}_{0:HH}", DateTime.Now) +
                                       ".log";
                        }
                        else
                        {
                            filename = logFilePrefix +
                                       String.Format("{0:yyyy}{0:MM}{0:dd}", DateTime.Now) +
                                       ".log";
                        }
                        // log outstanding error & logging data
                        System.IO.StreamWriter Str;
                        Str = new System.IO.StreamWriter(logFilePath + filename, true);
                        while (errorLogQueue.Count > 0)
                        {
                            Str.WriteLine(errorLogQueue.ElementAt(0).ToString());
                            errorLogQueue.RemoveAt(0);
                        }
                        Str.Close();
                    }
                }
                else
                {
                    // No log file path is set to do not save, just clear the queue
                    errorLogQueue.Clear();
                }
            }
            catch
            {
                // just fall out and try next time
            }

            try
            {
                // delete any old logs
                if (todaysDayNumber != DateTime.Now.Day)
                {
                    todaysDayNumber = DateTime.Now.Day;
                    RemoveOldLogs(logDaysToKeep);
                }
            }
            catch(Exception ex)
            {
                LogMessage(ThreadLog.DebugLevel.Exception, ex.ToString());
                // just fall out and try next time
            }
        }

        //================================================================================
        // Sub RemoveOldLogs
        // Loops through all files in the Log directory, and deletes any files older than specified.
        // In:       DaysToKeep (int) - the number of day's worth of data to keep
        //================================================================================
        public void RemoveOldLogs(int daysToKeep)
        {
            try
            {
                if( logFilePath != "" )
                {
                    // As when we delete a file below, we change the DirectoryInfo object, 
                    // we need a mechanism to repeatedly call the routine until all relevant files are deleted.
                    Boolean fileDeleted = true;

                    while (fileDeleted == true)
                    {
                        fileDeleted = false;

                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(logFilePath);
                        foreach (System.IO.FileInfo fi in dir.GetFiles())
                        {
                            if (fi.Name.StartsWith(logFilePrefix) && fi.CreationTime.AddDays(daysToKeep) < DateTime.Now)
                            {
                                LogMessage(ThreadLog.DebugLevel.Exception, "RemoveOldLogs() Deleting: " + fi.Name.ToString());
                                fi.Delete();
                                fileDeleted = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(ThreadLog.DebugLevel.Exception, "RemoveOldLogs() " + ex.ToString());
            }
        }

    }

}
