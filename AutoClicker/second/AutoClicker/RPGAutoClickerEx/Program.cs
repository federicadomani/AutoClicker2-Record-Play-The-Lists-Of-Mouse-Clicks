using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Drawing;
using System.Resources;

using System.Runtime.InteropServices;

namespace Auto_Clicker
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // Required for Windows Forms applications
        public static void Main()
        {
            /*
            Icon ico = Icon.ExtractAssociatedIcon("favicon2.ico");
            Image img = Image.FromFile("favicon2.ico");
            ResXResourceWriter rsxw = new ResXResourceWriter("favicon.resx");
            rsxw.AddResource("favicon.ico", ico);
            rsxw.AddResource("favicon.img", img);
            rsxw.Close();
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
