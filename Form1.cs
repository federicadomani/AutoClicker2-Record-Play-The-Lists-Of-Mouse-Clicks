using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoClicker
{

    public partial class Form1 : Form
    {
        bool clickatcursor = true;
        int clickamount = 0;
        int currentclick = 1;
        Point clickLocation = new Point(0, 0);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public const int START_HOTKEY = 1;
        public const int STOP_HOTKEY = 2;
        public const int SELECT_HOTKEY = 3;

        public Form1()
        {
            InitializeComponent();
            amounttext.Text = Properties.Settings.Default.clickamountsave;
            clickintervaltext.Text = Properties.Settings.Default.clickintervalsave;
            try
            {
                clicktcombo.SelectedIndex = Properties.Settings.Default.clicktypesave;
            }
            catch
            {
                clicktcombo.SelectedIndex = 0;
            }
            try
            {
                typecombo.SelectedIndex = Properties.Settings.Default.clicktimessave;
            }
            catch
            {
                typecombo.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.curfixedsave == false)
            {
                cursorrbut.Checked = true;
            }
            else
            {
                fixedrbut.Checked = true;
            }
            clickLocation = Properties.Settings.Default.pointsave;
            string locationstring = clickLocation.ToString();
            coordlabel.Text = (locationstring.Remove(locationstring.Length - 1)).Remove(0, 1);
            RegisterHotKey(this.Handle, START_HOTKEY, 0, Properties.Settings.Default.startkey);
            RegisterHotKey(this.Handle, STOP_HOTKEY, 0, Properties.Settings.Default.stopkey);
            RegisterHotKey(this.Handle, SELECT_HOTKEY, 0, Properties.Settings.Default.selectkey);
            //change hotkey apperance on buttons
            startbutton.Text = "Start (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.startkey.ToString())).ToString() + ")";
            stopbut.Text = "Stop (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.stopkey.ToString())).ToString() + ")";
            fixedlabel.Text = "Fixed Location (Press " + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.selectkey.ToString())).ToString() + " to Set):";
        }

        public void updateapperance()
        {
            startbutton.Text = "Start (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.startkey.ToString())).ToString() + ")";
            stopbut.Text = "Stop (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.stopkey.ToString())).ToString() + ")";
            fixedlabel.Text = "Fixed Location (Press " + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.selectkey.ToString())).ToString() + " to Set):";
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == START_HOTKEY)
            {
                //UnregisterHotKey(this.Handle, 1);
                start();
                //RegisterHotKey(this.Handle, 1, 0, Properties.Settings.Default.startkey);
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == STOP_HOTKEY)
            {
                stop();
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == SELECT_HOTKEY)
            {
                clickLocation = Cursor.Position;
                Properties.Settings.Default.pointsave = clickLocation;
                Properties.Settings.Default.Save();
                string locationstring = clickLocation.ToString();
                coordlabel.Text = (locationstring.Remove(locationstring.Length - 1)).Remove(0, 1);
            }
            base.WndProc(ref m);
        }

        public void start()
        {
            if (clicktimer.Enabled == true)
            {
                MessageBox.Show("AutoClicker Professional is already clicking!", "Already clicking");
            }
            else
            {
                bool intervalerror = false;
                bool amounterror = false;
                int timerinterv = 1000;
                currentclick = 0;
                try
                {
                    timerinterv = Convert.ToInt32(clickintervaltext.Text);
                }
                catch
                {
                    intervalerror = true;
                }
                try
                {
                    clickamount = Convert.ToInt32(amounttext.Text);
                }
                catch
                {
                    amounterror = true;
                }
                if (intervalerror == false)
                {
                    if (amounterror == false)
                    {
                        if (cursorrbut.Checked == true)
                        {
                            clickatcursor = true;
                        }
                        else
                        {
                            clickatcursor = false;
                        }
                        statuslabel.Text = "Clicking ... ";
                        //disable buttons
                        cursorrbut.Enabled = false;
                        fixedrbut.Enabled = false;
                        amounttext.Enabled = false;
                        clickintervaltext.Enabled = false;
                        clicktcombo.Enabled = false;
                        typecombo.Enabled = false;
                        startbutton.Enabled = false;
                        statusheaderlabel.ForeColor = Color.LimeGreen;
                        statuslabel.ForeColor = Color.LimeGreen;
                        clicktimer.Interval = timerinterv;
                        clicktimer.Start();
                    }
                    else
                    {
                        MessageBox.Show("Invalid click amount enetered", "Invalid click amount");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid time interval enetered", "Invalid interval");
                }
            }
        }

        public void stop()
        {
            if (clicktimer.Enabled == true)
            {
                //reenable buttons
                cursorrbut.Enabled = true;
                fixedrbut.Enabled = true;
                amounttext.Enabled = true;
                clickintervaltext.Enabled = true;
                clicktcombo.Enabled = true;
                typecombo.Enabled = true;
                startbutton.Enabled = true;
                clicktimer.Stop();
                statuslabel.Text = "Not Clicking";
                statusheaderlabel.ForeColor = Color.Magenta;
                statuslabel.ForeColor = Color.Magenta;
            }
            else
            {
                MessageBox.Show("AutoClicker Professional is not clicking!", "Not clicking");
            }
        }

        const int MOUSEEVENTF_LEFTDOWN = 2;
        const int MOUSEEVENTF_LEFTUP = 4;
        const int MOUSEEVENTF_RIGHTDOWN = 8;
        const int MOUSEEVENTF_RIGHTUP = 16;
        const int MOUSEEVENTF_MIDDLEUP = 32;
        const int MOUSEEVENTF_MIDDLEDOWN = 64;
        //input type constant
        const int INPUT_MOUSE = 0;

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);

        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        public struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        };


        public void clickatcur()
        {
            int clickbutton = clicktcombo.SelectedIndex;
            int clicktimes = typecombo.SelectedIndex + 1;
            while (clicktimes > 0)
            {
                //set up the INPUT struct and fill it for the mouse down
                INPUT i = new INPUT();
                i.type = INPUT_MOUSE;
                i.mi.dx = 0;
                i.mi.dy = 0;
                if (clickbutton == 0)
                {
                    i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
                }
                else if (clickbutton == 1)
                {
                    i.mi.dwFlags = MOUSEEVENTF_MIDDLEDOWN;
                }
                else if (clickbutton == 2)
                {
                    i.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
                }
                else
                {
                    i.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
                }
                i.mi.dwExtraInfo = IntPtr.Zero;
                i.mi.mouseData = 0;
                i.mi.time = 0;
                //send the input 
                SendInput(1, ref i, Marshal.SizeOf(i));
                //set the INPUT for mouse up and send it
                if (clickbutton == 0)
                {
                    i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
                }
                else if (clickbutton == 1)
                {
                    i.mi.dwFlags = MOUSEEVENTF_MIDDLEUP;
                }
                else if (clickbutton == 2)
                {
                    i.mi.dwFlags = MOUSEEVENTF_RIGHTUP;
                }
                else
                {
                    i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
                }
                SendInput(1, ref i, Marshal.SizeOf(i));
                clicktimes--;
            }
        }

        private void clicktimer_Tick(object sender, EventArgs e)
        {
            if (clickamount == 0)
            {
                if (clickatcursor == true)
                {
                    clickatcur();
                }
                else
                {
                    Cursor.Position = clickLocation;
                    clickatcur();
                }
            }
            else
            {
                if (clickatcursor == true)
                {
                    clickatcur();
                }
                else
                {
                    Cursor.Position = clickLocation;
                    clickatcur();
                }
                currentclick++;
                if (currentclick == clickamount)
                {
                    stop();
                }
            }
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            start();
        }

        private void stopbut_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm frm = new AboutForm())
            {
                frm.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clickintervaltext_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check if input is number or remove
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void amounttext_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check if input is number or remove
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void amounttext_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.clickamountsave = amounttext.Text;
            Properties.Settings.Default.Save();
        }

        private void clickintervaltext_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.clickintervalsave = clickintervaltext.Text;
            Properties.Settings.Default.Save();
        }

        private void clicktcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.clicktypesave = clicktcombo.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void cursorrbut_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.curfixedsave = false;
            Properties.Settings.Default.Save();
        }

        private void fixedrbut_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.curfixedsave = true;
            Properties.Settings.Default.Save();
        }

        private void typecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.clicktimessave = typecombo.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/autoclicker-professional/");
        }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/p/autoclicker-professional/tickets/");
        }

        private void hotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Hotkeys frm = new Hotkeys(this))
            {
                frm.ShowDialog();
            }
        }
    }
}
