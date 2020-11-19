//////////////////////////////////////////////////////////////////////////////
//
//  Project:    Generic
//  Date:       15 Apr 2012
//  Version:    1.00
//  Copyright:  (c) Copyright 2012 Industrial Technology Systems Ltd. All Rights Reserved.using System
//
//////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Exwold.Desktop
{
    class MDC_ASCII
    {
        public enum Ascii
        {
            NUL = 0,    SOH = 1,    STX = 2,    ETX = 3,    EOT = 4,    ENQ = 5,    ACK = 6,    BEL = 7,
            BS = 8,     HT = 9,     LF = 10,    VT = 11,    NT = 12,    CR = 13,    SO = 14,    SI = 15,
            DLE = 16,   DC1 = 17,   DC2 = 18,   DC3 = 19,   DC4 = 20,   NAK = 21,   SYN = 22,   ETB = 23,
            CAN = 24,   EM = 25,    SUB = 26,   ESC = 27,   FS = 28,    GS = 29,    RS = 30,    US = 31,
            SPA = 32,
            DEL = 127
        };

        public static string ConvertAsciiArrayToReadableString(byte[] byteArray)
        {
            StringBuilder s = new StringBuilder();

            foreach(byte b in byteArray)
            {
                s.Append(ConvertAsciiByteToReadable(b));
            }
            return s.ToString();
        }

        public static string ConvertAsciiArrayToReadableString(char[] charArray)
        {
            StringBuilder s = new StringBuilder();

            foreach(char c in charArray)
            {
                s.Append(ConvertAsciiByteToReadable((byte)c));
            }
            return s.ToString();
        }

        private static string ConvertAsciiByteToReadable(byte b)
        {
            switch( b )
            {
                case 0 : return "<00NUL>";     // Null
                case 1 : return "<01SOH>";     // Start Of Header
                case 2 : return "<02STX>";     // Start of Text
                case 3 : return "<03ETX>";     // End of Text
                case 4 : return "<04EOT>";     // End of Transmission
                case 5 : return "<05ENQ>";     // Enquiry
                case 6 : return "<06ACK>";     // Acknowledge
                case 7 : return "<07BEL>";     // Bell
                case 8 : return "<08BS>";      // Back Space
                case 9 : return "<09HT>";      // Horizontal Tab
                case 10 : return "<10LF>";     // Line Feed
                case 11 : return "<11VT>";     // Vertical Tab
                case 12 : return "<12FF>";     // Form Feed
                case 13 : return "<13CR>";     // Carriage Return
                case 14 : return "<14SO>";     // Shift Out
                case 15 : return "<15SI>";     // Shift In
                case 16 : return "<16DLE>";    // Data Link Escape
                case 17 : return "<17DC1>";    // Device Control 1
                case 18 : return "<18DC2>";    // Device Control 2
                case 19 : return "<19DC3>";    // Device Control 3
                case 20 : return "<20DC4>";    // Device Control 4
                case 21 : return "<21NAK>";    // Negative Acknowledge
                case 22 : return "<22SYN>";    // Synchronise
                case 23 : return "<23ETB>";    // End of Transmission Block
                case 24 : return "<24CAN>";    // Cancel
                case 25 : return "<25EM>";     // End of Medium
                case 26 : return "<26SUB>";    // Substitute
                case 27 : return "<27ESC>";    // Escape
                case 28 : return "<28FS>";     // File Separator
                case 29 : return "<29GS>";     // Group Separator
                case 30 : return "<30RS>";     // Record Separator
                case 31 : return "<31US>";     // Unit Separator
                case 32 : return "<32SPA>";    // Space
                case 127 : return "<127DEL>";  // Delete
                default : return ((char) b).ToString() ;
            }
        }


    }
}
