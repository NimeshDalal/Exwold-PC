//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
//  Provides Shutdown & LogOff functionality
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          04Apr2017   Martin Cox 
//          Initial Creation
//
//******************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Exwold
{
    /// <summary>
    /// Provides Shutdown & Logoff Functionality,
    /// after calling the methods here, close the program.
    /// </summary>
    class ShutdownLogoff
    {
        // PINVOKE code
        [DllImport("user32.dll")]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        /// <summary>
        /// Tell Windows to Logoff the current session, after calling this close the program
        /// </summary>
        /// <param name="force">Set to true to Force Logoff</param>
        [STAThread]
        public static void Logoff(bool force = false)
        {
            if (force)
                ExitWindowsEx((uint)ExitWindows.LogOff + (uint)ExitWindows.Force, (uint)ShutdownReason.MajorOther | (uint)ShutdownReason.MinorOther);
            else
                ExitWindowsEx((uint)ExitWindows.LogOff, (uint)ShutdownReason.MajorOther | (uint)ShutdownReason.MinorOther);
        }

        /// <summary>
        /// Tell Windows to Shutdown, after calling this close the program
        /// </summary>
        /// <param name="force"></param>
        [STAThread]
        public static void Shutdown(bool force = false)
        {
            if (force)
                ExitWindowsEx((uint)ExitWindows.ShutDown + (uint)ExitWindows.Force, (uint)ShutdownReason.MajorOther | (uint)ShutdownReason.MinorOther);
            else
                ExitWindowsEx((uint)ExitWindows.ShutDown, (uint)ShutdownReason.MajorOther | (uint)ShutdownReason.MinorOther);
        }

        /// <summary>
        /// Tell Windows to Shutdown and Reboot, after calling this close the program
        /// </summary>
        /// <param name="force"></param>
        [STAThread]
        public static void Reboot(bool force = false)
        {
            if (force)
                ExitWindowsEx((uint)ExitWindows.Reboot + (uint)ExitWindows.Force, (uint)ShutdownReason.MajorOther | (uint)ShutdownReason.MinorOther);
            else
                ExitWindowsEx((uint)ExitWindows.Reboot, (uint)ShutdownReason.MajorOther | (uint)ShutdownReason.MinorOther);
        }

        /// <summary>
        /// User defined action: use the flags to instruct Windows to do the action you need, after calling this close the program.
        /// </summary>
        /// <param name="exitWindowsFlags">Sum of required ExitWindows flags</param>
        /// <param name="shutdownReasonFlags">Sum of required ShutdownReason flags</param>
        [STAThread]
        public static void UserDefined(uint exitWindowsFlags, uint shutdownReasonFlags)
        {
                ExitWindowsEx(exitWindowsFlags, shutdownReasonFlags);
        }
    }

    [Flags]
    public enum ExitWindows : uint
    {
        // ONE of the following five:
        LogOff = 0x00,
        ShutDown = 0x01,
        Reboot = 0x02,
        PowerOff = 0x08,
        RestartApps = 0x40,
        // plus AT MOST ONE of the following two:
        Force = 0x04,
        ForceIfHung = 0x10,
    }

    [Flags]
    enum ShutdownReason : uint
    {
        MajorApplication = 0x00040000,
        MajorHardware = 0x00010000,
        MajorLegacyApi = 0x00070000,
        MajorOperatingSystem = 0x00020000,
        MajorOther = 0x00000000,
        MajorPower = 0x00060000,
        MajorSoftware = 0x00030000,
        MajorSystem = 0x00050000,

        MinorBlueScreen = 0x0000000F,
        MinorCordUnplugged = 0x0000000b,
        MinorDisk = 0x00000007,
        MinorEnvironment = 0x0000000c,
        MinorHardwareDriver = 0x0000000d,
        MinorHotfix = 0x00000011,
        MinorHung = 0x00000005,
        MinorInstallation = 0x00000002,
        MinorMaintenance = 0x00000001,
        MinorMMC = 0x00000019,
        MinorNetworkConnectivity = 0x00000014,
        MinorNetworkCard = 0x00000009,
        MinorOther = 0x00000000,
        MinorOtherDriver = 0x0000000e,
        MinorPowerSupply = 0x0000000a,
        MinorProcessor = 0x00000008,
        MinorReconfig = 0x00000004,
        MinorSecurity = 0x00000013,
        MinorSecurityFix = 0x00000012,
        MinorSecurityFixUninstall = 0x00000018,
        MinorServicePack = 0x00000010,
        MinorServicePackUninstall = 0x00000016,
        MinorTermSrv = 0x00000020,
        MinorUnstable = 0x00000006,
        MinorUpgrade = 0x00000003,
        MinorWMI = 0x00000015,

        FlagUserDefined = 0x40000000,
        FlagPlanned = 0x80000000
    }
}
