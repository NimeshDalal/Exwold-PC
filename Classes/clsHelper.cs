/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsHelper.cs
 * Description: General helper class for WinForms
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              <Description of the change>
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace ITS.Exwold.Desktop
{
    internal static class Helper
    {
        internal enum BatchStatus : int
        {
            Available = 0,
            InProgress,
            OnHold,
            ReadyToPrint,
            Completed,
            Stopped
        }
        #region Lookups
        /// <summary>
        /// Return the Line status lookup
        /// Usage: string = Helper.Linestatus[(int)id]
        /// </summary>
        internal static Dictionary<int, string> LineStatus = new Dictionary<int, string>
        {
            {-1, "---" },
            {0, "Available" },
            {1, "In-Progress" },
            {2, "On-Hold" },
            {3, "Ready to Print" },
            {4, "Completed" },
            {5, "Stopped" },
        };

        /// <summary>
        /// Return the colour for given line status
        /// Usage: System.Drawing.Color = Helper.LineStatusColour[(int)id]
        /// </summary>
        internal static Dictionary<int, Color> LineStatusColour = new Dictionary<int, Color>
        {
            {-1, Color.DarkGray },
            {0, Color.Black },
            {1, Color.Green },
            {2, Color.Black },
            {3, Color.Green },
            {4, Color.Black },
            {5, Color.Black }
        };
        /// <summary>
        /// Return the visibility for given line status
        /// Usage: bool = Helper.LineStatusVisibility[(int)id]
        /// </summary>
        internal static Dictionary<int, bool> LineStatusVisibility = new Dictionary<int, bool>
        {
            {-1, false },
            {0, false },
            {1, true },
            {2, true },
            {3, true },
            {4, false },
            {5, false }
        };
        #endregion
        #region Methods
        /// <summary>
        /// Clears all textbox controls from a container
        /// </summary>
        /// <param name="container"></param>
        internal static void ClearTextBoxes(System.Windows.Forms.ContainerControl container)
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in container.Controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                    if (control is RichTextBox)
                        (control as RichTextBox).Clear();
                    else func(control.Controls);
            };
        }
        /// <summary>
        /// Copies the properties from the source to the target
        /// </summary>
        /// <param name="source">Control Properties to copy</param>
        /// <param name="target">Control to copy the properties to</param>
        internal static void copyControl(Control source, Control target)
        {
            //Check the control types
            if (source.GetType() != target.GetType())
            {
                throw new Exception(Logging.ThisMethod().ToString() + " Incompatible Control Types");
            }
            try
            {
                foreach (PropertyInfo srcProp in source.GetType().GetProperties())
                {
                    if (srcProp.Name != "Name")
                    {
                        object propValue = srcProp.GetValue(source, null);
                        MethodInfo mi = srcProp.GetSetMethod(true);
                        if (mi != null)
                        {
                            srcProp.SetValue(target, propValue, null);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(Logging.ThisMethod().ToString(), ex);
            }
        }
        /// <summary>
        /// Removes all control of type T from a group box
        /// where the "Tag" property is null or is NOT tagToKeep
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gb">The GroupBox to remove from</param>
        /// <param name="tagToKeep">Tag preperty value to not remove</param>
        internal static void removeControls<T>(GroupBox gb, string tagToKeep = "Header") where T : Control
        {
#if DEBUG
            Console.WriteLine("Matching Controls {0}", gb.Controls.OfType<T>().
                Where(ctl => (ctl.Tag == null) || (ctl.Tag.ToString().Trim() != tagToKeep)).Count().ToString());
#endif

            while (gb.Controls.OfType<T>().
                Where(ctl => (ctl.Tag == null) || (ctl.Tag.ToString().Trim() != tagToKeep)).Count() > 0)
            {
                foreach (T ctrl in gb.Controls.OfType<T>().Where(ctl => (ctl.Tag == null) || (ctl.Tag.ToString().Trim() != tagToKeep)))
                {
                    gb.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
        }
        internal static int dgvHasColumn(DataGridView dgv, string colName)
        {
            if (dgv.Columns.Contains(colName))
            {
                return dgv.Columns[colName].Index;
            }
            else
            {
                return -1;
            }
        }
        internal static bool dgvColumnVisible(DataGridView dgv, string colName, bool Show)
        {
            if (dgv.Columns.Contains(colName))
            {
                dgv.Columns[colName].Visible = Show;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static bool dgvColumnStyle(DataGridView dgv, string colName, string format)
        {
            if (dgv.Columns.Contains(colName))
            {
                dgv.Columns[colName].DefaultCellStyle.Format = format;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static dynamic dgvGetCurrentRowColumn(DataGridView dgv, string colName)
        {
            int colIdx = int.MinValue;
            if (dgv.CurrentRow == null) return null;

            colIdx = dgvHasColumn(dgv, colName);
            if (colIdx >= 0)
            {
                return dgv.CurrentRow.Cells[colIdx].Value;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }

    /// <summary>
    /// Helper class for comms routines
    /// </summary>
    internal static class CommsHelper
    {
        /// <summary>
        /// Asynchronously pings an IP Address (IP4 or IP6)
        /// </summary>
        /// <param name="address"></param>
        /// <returns>a task with IPStatus</returns>
        internal static async Task<System.Net.NetworkInformation.IPStatus> PingIPAddress(string address)
        {
            try
            {
                System.Net.IPAddress ipaddr = System.Net.IPAddress.Parse(address);
            }
            catch (FormatException ex)
            {
                StringBuilder msg = new StringBuilder(Logging.ThisMethod());
                msg.Append("IP Address Format EXCEPTION:");
                msg.AppendLine(address);
                msg.AppendLine(ex.ToString());
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, msg.ToString());
            }
            catch (Exception ex)
            {
                StringBuilder msg = new StringBuilder(Logging.ThisMethod());
                msg.Append("EXCEPTION:");
                msg.AppendLine(address);
                msg.AppendLine(ex.ToString());
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, msg.ToString());
            }
            //Create the ping instance
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            //Send the ping
            System.Net.NetworkInformation.PingReply reply = await ping.SendPingAsync(address);
            return reply.Status;
        }
    }
}

