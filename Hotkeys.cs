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
    public partial class Hotkeys : Form
    {
        Form1 currentform;
        System.IntPtr form1handle = new System.IntPtr();

        public Hotkeys(Form1 currentform1)
        {
            InitializeComponent();
            currentform = currentform1;
            form1handle = currentform1.Handle;
            starthotkey.Text = ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.startkey.ToString())).ToString();
            stophotkey.Text = ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.stopkey.ToString())).ToString();
            selectbox.Text = ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.selectkey.ToString())).ToString();
        }

        private void starthotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.startkey = e.KeyValue;
            Properties.Settings.Default.Save();
            focusbox.Focus();
        }

        private void starthotkey_Enter(object sender, EventArgs e)
        {
            Form1.UnregisterHotKey(form1handle, Form1.START_HOTKEY);
            starthotkey.Text = "Press a key...";
        }

        private void starthotkey_Leave(object sender, EventArgs e)
        {
            Form1.RegisterHotKey(form1handle, Form1.START_HOTKEY, 0, Properties.Settings.Default.startkey);
            starthotkey.Text = ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.startkey.ToString())).ToString();
            currentform.updateapperance();
        }

        private void stophotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.stopkey = e.KeyValue;
            Properties.Settings.Default.Save();
            focusbox.Focus();
        }

        private void stophotkey_Enter(object sender, EventArgs e)
        {
            Form1.UnregisterHotKey(form1handle, Form1.STOP_HOTKEY);
            stophotkey.Text = "Press a key...";
        }

        private void stophotkey_Leave(object sender, EventArgs e)
        {
            Form1.RegisterHotKey(form1handle, Form1.STOP_HOTKEY, 0, Properties.Settings.Default.stopkey);
            stophotkey.Text = ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.stopkey.ToString())).ToString();
            currentform.updateapperance();
        }

        private void selectbox_KeyDown(object sender, KeyEventArgs e)
        {
            Properties.Settings.Default.selectkey = e.KeyValue;
            Properties.Settings.Default.Save();
            focusbox.Focus();
        }

        private void selectbox_Enter(object sender, EventArgs e)
        {
            Form1.UnregisterHotKey(form1handle, Form1.SELECT_HOTKEY);
            selectbox.Text = "Press a key...";
        }

        private void selectbox_Leave(object sender, EventArgs e)
        {
            Form1.RegisterHotKey(form1handle, Form1.SELECT_HOTKEY, 0, Properties.Settings.Default.selectkey);
            selectbox.Text = ((Keys)Enum.Parse(typeof(Keys), Properties.Settings.Default.selectkey.ToString())).ToString();
            currentform.updateapperance();
        }

        private void Hotkeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            //in case the user closes the form while one of the boxes are focused
            Form1.RegisterHotKey(form1handle, Form1.START_HOTKEY, 0, Properties.Settings.Default.startkey);
            Form1.RegisterHotKey(form1handle, Form1.STOP_HOTKEY, 0, Properties.Settings.Default.stopkey);
            Form1.RegisterHotKey(form1handle, Form1.SELECT_HOTKEY, 0, Properties.Settings.Default.selectkey);
        }

    }
}
