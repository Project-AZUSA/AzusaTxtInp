﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AzusaTxtInp
{
    public partial class Form1 : Form
    {        

        //for global hotkey==============================================================
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (id == 0)  //shift space
                {
                    Console.WriteLine("EVENT(TXTSHOW)");
                    this.Height = textBox1.PreferredHeight;
                    this.Show();
                    this.Activate();
                    this.WindowState = FormWindowState.Normal;
                    textBox1.Text = "";
                    textBox1.Focus();
                }                

            }
        }
        //end block==============================================================
    }
}
