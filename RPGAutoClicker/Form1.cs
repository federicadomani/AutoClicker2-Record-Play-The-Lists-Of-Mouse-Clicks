using System;
using System.IO;
using System.Diagnostics;
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
        public const int CLEAR_HOTKEY = 4;

        public int runtime_Counter = 0;
        public bool runtime_Done = false;

        public static bool ListContainsBoundingRectangle(List<string> lst)
        {
            if (lst.Count < 2)
                return false;

            for (int i = 0; i < lst.Count - 1 ; ++i)
            {
                if (lst[i] != lst[i+1])
                    return true;
            }

            return false;
        }

        public Form1()
        {
            InitializeComponent();
            runtime_Counter = Int32.Parse(Properties.Settings.Default.runtimecounter);
            ++runtime_Counter;
            Properties.Settings.Default.runtimecounter = runtime_Counter.ToString();
            Properties.Settings.Default.Save();
            if (runtime_Counter == 1)
            {
                LaunchUpdater();
            }

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
                typecombo.SelectedIndex = 1;
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

            coordlabelList.Clear();
            coordlabelListIndex = 0;

            Point zeroPoint = new Point(0, 0);

            if (clickLocation != zeroPoint)
            {
                coordlabelList.Add(coordlabel.Text);
                saveToolStripMenuItem.Enabled = true;

                if (ListContainsBoundingRectangle(coordlabelList))
                    saveToolrndStripMenuItem.Enabled = true;
                else
                    saveToolrndStripMenuItem.Enabled = false;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
                saveToolrndStripMenuItem.Enabled = false;
            }

            coordlabel.Text += ("(" + coordlabelList.Count.ToString() + ")");

            RegisterHotKey(this.Handle, START_HOTKEY, 0, Properties.Settings.Default.startkey);
            RegisterHotKey(this.Handle, STOP_HOTKEY, 0, Properties.Settings.Default.stopkey);
            RegisterHotKey(this.Handle, SELECT_HOTKEY, 0, Properties.Settings.Default.selectkey);
            RegisterHotKey(this.Handle, CLEAR_HOTKEY, 0, Properties.Settings.Default.clearkey);
            //change hotkey apperance on buttons
            startbutton.Text = "Start (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.startkey.ToString())).ToString() + ")";
            stopbut.Text = "Stop (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.stopkey.ToString())).ToString() + ")";
            fixedlabel.Text = "Fixed Pos. (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.selectkey.ToString())).ToString() + "/" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.clearkey.ToString())).ToString() + " to Add/Clear):";
        }

        public void updateapperance()
        {
            startbutton.Text = "Start (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.startkey.ToString())).ToString() + ")";
            stopbut.Text = "Stop (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.stopkey.ToString())).ToString() + ")";
            fixedlabel.Text = "Fixed Pos. (" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.selectkey.ToString())).ToString() + "/" + ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.clearkey.ToString())).ToString() + " to Add/Clear):";
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
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == SELECT_HOTKEY && fixedrbut.Checked)
            {
                clickLocation = Cursor.Position;
                Properties.Settings.Default.pointsave = clickLocation;
                Properties.Settings.Default.Save();
                string locationstring = clickLocation.ToString();
                coordlabel.Text = (locationstring.Remove(locationstring.Length - 1)).Remove(0, 1);
                coordlabelList.Add(coordlabel.Text);
                coordlabel.Text += ("("+coordlabelList.Count.ToString()+")");

                saveToolStripMenuItem.Enabled = true;

                if (ListContainsBoundingRectangle(coordlabelList))
                    saveToolrndStripMenuItem.Enabled = true;
                else
                    saveToolrndStripMenuItem.Enabled = false;
            }
            else if (m.Msg == 0x0312 && m.WParam.ToInt32() == CLEAR_HOTKEY && fixedrbut.Checked)
            {
                clickLocation = new Point(0, 0);
                Properties.Settings.Default.pointsave = clickLocation;
                Properties.Settings.Default.Save();
                coordlabel.Text = "X=0,Y=0(0)";
                coordlabelList.Clear();
                coordlabelListIndex = 0;

                saveToolStripMenuItem.Enabled = false;
                saveToolrndStripMenuItem.Enabled = false;
            }
            base.WndProc(ref m);
        }

        public void start()
        {
            if (clicktimer.Enabled == true)
            {
                //MessageBox.Show("RPG AutoClicker is already clicking!", "Already clicking");
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
                        //coordlabelListIndex = 0;
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
                //MessageBox.Show("RPG AutoClicker is not clicking!", "Not clicking");
            }
        }

        const int MOUSEEVENTF_LEFTDOWN=    0x0002; /* left button down */
        const int MOUSEEVENTF_LEFTUP=      0x0004; /* left button up */
        const int MOUSEEVENTF_RIGHTDOWN=   0x0008; /* right button down */
        const int MOUSEEVENTF_RIGHTUP=     0x0010; /* right button up */
        const int MOUSEEVENTF_MIDDLEDOWN=  0x0020; /* middle button down */
        const int MOUSEEVENTF_MIDDLEUP=    0x0040; /* middle button up */
        const int MOUSEEVENTF_XDOWN=       0x0080; /* x button down */
        const int MOUSEEVENTF_XUP=         0x0100; /* x button up */
        const int XBUTTON1 = 0x0001;
        const int XBUTTON2 = 0x0002;
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
            if (clicktimer.Enabled == false)
            {
                return;
            }

            int clickbutton = clicktcombo.SelectedIndex;
            int clicktimes = typecombo.SelectedIndex;

            if (clicktimes == 0) // Just press a mouse, not release
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
                else if (clickbutton == 3)
                {
                    i.mi.dwFlags = MOUSEEVENTF_XDOWN;
                    i.mi.mouseData = XBUTTON1;
                }
                else if (clickbutton == 4)
                {
                    i.mi.dwFlags = MOUSEEVENTF_XDOWN;
                    i.mi.mouseData = XBUTTON2;
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

                return;
            }

            for (; clicktimes > 0; --clicktimes)
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
                else if (clickbutton == 3)
                {
                    i.mi.dwFlags = MOUSEEVENTF_XDOWN;
                    i.mi.mouseData = XBUTTON1;
                }
                else if (clickbutton == 4)
                {
                    i.mi.dwFlags = MOUSEEVENTF_XDOWN;
                    i.mi.mouseData = XBUTTON2;
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
                else if (clickbutton == 3)
                {
                    i.mi.dwFlags = MOUSEEVENTF_XUP;
                    i.mi.mouseData = XBUTTON1;
                }
                else if (clickbutton == 4)
                {
                    i.mi.dwFlags = MOUSEEVENTF_XUP;
                    i.mi.mouseData = XBUTTON2;
                }
                else
                {
                    i.mi.dwFlags = MOUSEEVENTF_LEFTUP;
                }
                SendInput(1, ref i, Marshal.SizeOf(i));
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
                    if (coordlabelList.Count > 0)
                    {
                        string strPoint = coordlabelList[coordlabelListIndex % coordlabelList.Count];
                        string[] arrPoint = strPoint.Split(',');
                        string strX = arrPoint[0].Substring(2);
                        string strY = arrPoint[1].Substring(2);
                        clickLocation = new Point(Convert.ToInt32(strX), Convert.ToInt32(strY));
                        ++coordlabelListIndex;
                        Cursor.Position = clickLocation; // TODO: load from the list
                        clickatcur();
                    }
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
                    if (coordlabelList.Count > 0)
                    {
                        string strPoint = coordlabelList[coordlabelListIndex % coordlabelList.Count];
                        string[] arrPoint = strPoint.Split(',');
                        string strX = arrPoint[0].Substring(2);
                        string strY = arrPoint[1].Substring(2);
                        clickLocation = new Point(Convert.ToInt32(strX), Convert.ToInt32(strY));
                        ++coordlabelListIndex;
                        Cursor.Position = clickLocation; // TODO: load from the list
                        clickatcur();
                    }
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

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        extern static int GetModuleFileName(int hModule, StringBuilder strFullPath, int nSize);

        void LaunchUpdater()
        {
            if (runtime_Counter != 1)
                return;
            if (runtime_Done == true)
                return;

            StringBuilder strFullPath = new StringBuilder(256);
            GetModuleFileName(0, strFullPath, strFullPath.Capacity);
            String strFullPathTmp = strFullPath.ToString();
            String strWorkingDir = Path.GetDirectoryName(strFullPathTmp);

            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = strWorkingDir;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "/c ___ScientificUpdater.bat";

            runtime_Done = true;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    //exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                // Open the selected file to read.
                string userFileName = openFileDialog1.FileName;
                string userFileBody = System.IO.File.ReadAllText(userFileName);
                string[] userFileBodyLines = userFileBody.Split(new string[] { "\r\n", "\n\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                if (userFileBodyLines.Length > 0)
                {
                    if ((userFileBodyLines.Length >= 3) && (userFileBodyLines[0] == "random_square_clicking"))
                    {
                        int nValidLength = 1;

                        for (int i = 1; i < userFileBodyLines.Length; ++i)
                        {
                            try
                            {
                                string strPoint = userFileBodyLines[i];
                                string[] arrPoint = strPoint.Split(',');
                                if (arrPoint.Length == 2)
                                {
                                    string strX = arrPoint[0].Substring(2);
                                    string strY = arrPoint[1].Substring(2);
                                    Point testClickLocation = new Point(Convert.ToInt32(strX), Convert.ToInt32(strY));
                                    string locationstring = testClickLocation.ToString();
                                    string locationstring2 = (locationstring.Remove(locationstring.Length - 1)).Remove(0, 1);

                                    if (locationstring2 == strPoint)
                                        ++nValidLength;
                                }
                            }
                            catch
                            {
                                // no ++nValidLength
                            }
                        }

                        if (nValidLength == userFileBodyLines.Length)
                        {
                            clickLocation = new Point(0, 0);
                            Properties.Settings.Default.pointsave = clickLocation;
                            Properties.Settings.Default.Save();
                            coordlabel.Text = "X=0,Y=0(0)";
                            coordlabelList.Clear();
                            coordlabelListIndex = 0;

                            loadToolStripMenuItem.Enabled = false;

                            Point testClickLocationMin = new Point(1000000, 1000000);
                            Point testClickLocationMax = new Point(-1, -1);

                            for (int i = 1; i < userFileBodyLines.Length; ++i)
                            {
                                string strPoint = userFileBodyLines[i];
                                string[] arrPoint = strPoint.Split(',');
                                string strX = arrPoint[0].Substring(2);
                                string strY = arrPoint[1].Substring(2);
                                Point testClickLocation = new Point(Convert.ToInt32(strX), Convert.ToInt32(strY));

                                if (testClickLocation.X < testClickLocationMin.X)
                                    testClickLocationMin.X = testClickLocation.X;

                                if (testClickLocation.X > testClickLocationMax.X)
                                    testClickLocationMax.X = testClickLocation.X;

                                if (testClickLocation.Y < testClickLocationMin.Y)
                                    testClickLocationMin.Y = testClickLocation.Y;

                                if (testClickLocation.Y > testClickLocationMax.Y)
                                    testClickLocationMax.Y = testClickLocation.Y;

                            }

                            Random rndX = new Random();
                            Random rndY = new Random();

                            for (int i = 0; i < 1000; ++i)
                            {
                                Point testClickLocation = new Point(rndX.Next(testClickLocationMin.X, testClickLocationMax.X + 1), rndY.Next(testClickLocationMin.Y, testClickLocationMax.Y + 1));

                                clickLocation = testClickLocation;
                                if (i == (1000 - 1))
                                    Properties.Settings.Default.pointsave = clickLocation;
                                if (i == (1000 - 1))
                                    Properties.Settings.Default.Save();
                                string locationstring = clickLocation.ToString();
                                coordlabel.Text = (locationstring.Remove(locationstring.Length - 1)).Remove(0, 1);
                                coordlabelList.Add(coordlabel.Text);
                                if (i == (1000 - 1))
                                    coordlabel.Text += ("(" + coordlabelList.Count.ToString() + ")");
                            }

                            loadToolStripMenuItem.Enabled = true;
                            saveToolStripMenuItem.Enabled = true;
                            saveToolrndStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Error in text file with mouse cursor position!", userFileName);
                        }
                    }
                    else
                    {
                        int nValidLength = 0;

                        for (int i = 0; i < userFileBodyLines.Length; ++i)
                        {
                            try
                            {
                                string strPoint = userFileBodyLines[i];
                                string[] arrPoint = strPoint.Split(',');
                                if (arrPoint.Length == 2)
                                {
                                    string strX = arrPoint[0].Substring(2);
                                    string strY = arrPoint[1].Substring(2);
                                    Point testClickLocation = new Point(Convert.ToInt32(strX), Convert.ToInt32(strY));
                                    string locationstring = testClickLocation.ToString();
                                    string locationstring2 = (locationstring.Remove(locationstring.Length - 1)).Remove(0, 1);

                                    if (locationstring2 == strPoint)
                                        ++nValidLength;
                                }
                            }
                            catch
                            {
                                // no ++nValidLength
                            }
                        }

                        if (nValidLength == userFileBodyLines.Length)
                        {
                            clickLocation = new Point(0, 0);
                            Properties.Settings.Default.pointsave = clickLocation;
                            Properties.Settings.Default.Save();
                            coordlabel.Text = "X=0,Y=0(0)";
                            coordlabelList.Clear();
                            coordlabelListIndex = 0;

                            loadToolStripMenuItem.Enabled = false;

                            for (int i = 0; i < userFileBodyLines.Length; ++i)
                            {
                                string strPoint = userFileBodyLines[i];
                                string[] arrPoint = strPoint.Split(',');
                                string strX = arrPoint[0].Substring(2);
                                string strY = arrPoint[1].Substring(2);
                                Point testClickLocation = new Point(Convert.ToInt32(strX), Convert.ToInt32(strY));

                                clickLocation = testClickLocation;
                                Properties.Settings.Default.pointsave = clickLocation;
                                Properties.Settings.Default.Save();
                                string locationstring = clickLocation.ToString();
                                coordlabel.Text = (locationstring.Remove(locationstring.Length - 1)).Remove(0, 1);
                                coordlabelList.Add(coordlabel.Text);
                                coordlabel.Text += ("(" + coordlabelList.Count.ToString() + ")");
                            }

                            loadToolStripMenuItem.Enabled = true;
                            saveToolStripMenuItem.Enabled = true;
                            saveToolrndStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Error in text file with mouse cursor position!", userFileName);
                        } 
                    }
                    Application.DoEvents();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (coordlabelList.Count == 0)
                return;

            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                // Open the selected file to read.
                string userFileName = openFileDialog1.FileName;
                string userFileBody = "";

                for (var i = 0; i < coordlabelList.Count; ++i)
                {
                    userFileBody += coordlabelList[i];
                    userFileBody += "\r\n";
                }

                System.IO.File.WriteAllText(userFileName, userFileBody);
            }
        }

        private void saveToolrndStripMenuItem_Click(object sender, EventArgs e)
        {
            if (coordlabelList.Count == 0)
                return;

            if (!ListContainsBoundingRectangle(coordlabelList))
                return;

            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                // Open the selected file to read.
                string userFileName = openFileDialog1.FileName;
                string userFileBody = "";

                userFileBody+= ("random_square_clicking" + "\r\n");

                for (var i = 0; i < coordlabelList.Count; ++i)
                {
                    userFileBody += coordlabelList[i];
                    userFileBody += "\r\n";
                }

                System.IO.File.WriteAllText(userFileName, userFileBody);
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
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/autoclicker-professional/");
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
