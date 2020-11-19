/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsLogging.cs
 *              Returns the name of the calling method
 * Description: Logging helper
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              <Description of the change>
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace ITS.Exwold.Desktop
{
    public static class Logging
    {
        internal static string ThisMethod()
        {
            return new StackTrace().GetFrame(1).GetMethod().ThisMethod();
        }

        internal static string ThisMethod(this MethodBase method)
        {
            if (method.DeclaringType.GetInterfaces().Any(i => i == typeof(System.Runtime.CompilerServices.IAsyncStateMachine)))
            {
                var generatedType = method.DeclaringType;
                var originalType = generatedType.DeclaringType;
                var foundMethod = originalType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                    .Single(m => m.GetCustomAttribute<System.Runtime.CompilerServices.AsyncStateMachineAttribute>()?.StateMachineType == generatedType);
                return foundMethod.DeclaringType.Name + "." + foundMethod.Name;
            }
            else
            {
                return method.DeclaringType.Name + "." + method.Name;
            }
        }

        public static void LogMessage(ThreadLog.DebugLevel level, string methodName, string messageText)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine(methodName);
            msg.AppendLine(messageText);
            Program.Log.LogMessage(level, msg.ToString());
        }
    }
}

