namespace AutoClicker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startbutton = new System.Windows.Forms.Button();
            this.clicktimer = new System.Windows.Forms.Timer(this.components);
            this.stopbut = new System.Windows.Forms.Button();
            this.clickintervaltext = new System.Windows.Forms.TextBox();
            this.statuslabel = new System.Windows.Forms.Label();
            this.coordlabel = new System.Windows.Forms.Label();
            this.coordlabelList = new System.Collections.Generic.List<string>();
            this.coordlabelListIndex = 0;
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.amounttext = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolrndStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixedrbut = new System.Windows.Forms.RadioButton();
            this.cursorrbut = new System.Windows.Forms.RadioButton();
            this.clickatlabel = new System.Windows.Forms.Label();
            this.fixedlabel = new System.Windows.Forms.Label();
            this.statusheaderlabel = new System.Windows.Forms.Label();
            this.buttonlabel = new System.Windows.Forms.Label();
            this.clicktcombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.typecombo = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // startbutton
            // 
            this.startbutton.Location = new System.Drawing.Point(12, 36);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(124, 23);
            this.startbutton.TabIndex = 0;
            this.startbutton.Text = "Start (?)";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // clicktimer
            // 
            this.clicktimer.Interval = 1000;
            this.clicktimer.Tick += new System.EventHandler(this.clicktimer_Tick);
            // 
            // stopbut
            // 
            this.stopbut.Location = new System.Drawing.Point(145, 36);
            this.stopbut.Name = "stopbut";
            this.stopbut.Size = new System.Drawing.Size(127, 23);
            this.stopbut.TabIndex = 1;
            this.stopbut.Text = "Stop (?)";
            this.stopbut.UseVisualStyleBackColor = true;
            this.stopbut.Click += new System.EventHandler(this.stopbut_Click);
            // 
            // clickintervaltext
            // 
            this.clickintervaltext.Location = new System.Drawing.Point(128, 98);
            this.clickintervaltext.MaxLength = 22;
            this.clickintervaltext.Name = "clickintervaltext";
            this.clickintervaltext.Size = new System.Drawing.Size(144, 20);
            this.clickintervaltext.TabIndex = 3;
            this.clickintervaltext.Text = "1000";
            this.clickintervaltext.TextChanged += new System.EventHandler(this.clickintervaltext_TextChanged);
            this.clickintervaltext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clickintervaltext_KeyPress);
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = true;
            this.statuslabel.ForeColor = System.Drawing.Color.Magenta;
            this.statuslabel.Location = new System.Drawing.Point(125, 258);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(64, 13);
            this.statuslabel.TabIndex = 3;
            this.statuslabel.Text = "Not Clicking";
            // 
            // coordlabel
            // 
            this.coordlabel.AutoSize = true;
            this.coordlabel.Location = new System.Drawing.Point(186, 235);
            this.coordlabel.Name = "coordlabel";
            this.coordlabel.Size = new System.Drawing.Size(48, 13);
            this.coordlabel.TabIndex = 4;
            this.coordlabel.Text = "X=0,Y=0(0)";
            this.coordlabelList = new System.Collections.Generic.List<string>();
            this.coordlabelListIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Clicking Interval (ms):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Times to Click (0 = Infinite):";
            // 
            // amounttext
            // 
            this.amounttext.Location = new System.Drawing.Point(157, 70);
            this.amounttext.MaxLength = 18;
            this.amounttext.Name = "amounttext";
            this.amounttext.Size = new System.Drawing.Size(115, 20);
            this.amounttext.TabIndex = 2;
            this.amounttext.Text = "0";
            this.amounttext.TextChanged += new System.EventHandler(this.amounttext_TextChanged);
            this.amounttext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amounttext_KeyPress);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem
            , this.saveToolStripMenuItem
            , this.saveToolrndStripMenuItem
            , this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToolrndStripMenuItem
            // 
            this.saveToolrndStripMenuItem.Name = "saveToolrndStripMenuItem";
            this.saveToolrndStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.saveToolrndStripMenuItem.Text = "Save for random clicking";
            this.saveToolrndStripMenuItem.Click += new System.EventHandler(this.saveToolrndStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotkeysToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingsToolStripMenuItem.Text = "Options";
            // 
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.hotkeysToolStripMenuItem.Text = "Hotkeys";
            this.hotkeysToolStripMenuItem.Click += new System.EventHandler(this.hotkeysToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem,
            this.bugReportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // bugReportToolStripMenuItem
            // 
            this.bugReportToolStripMenuItem.Name = "bugReportToolStripMenuItem";
            this.bugReportToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.bugReportToolStripMenuItem.Text = "Bug Report";
            this.bugReportToolStripMenuItem.Click += new System.EventHandler(this.bugReportToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fixedrbut
            // 
            this.fixedrbut.AutoSize = true;
            this.fixedrbut.Location = new System.Drawing.Point(145, 205);
            this.fixedrbut.Name = "fixedrbut";
            this.fixedrbut.Size = new System.Drawing.Size(94, 17);
            this.fixedrbut.TabIndex = 6;
            this.fixedrbut.Text = "Fixed Pos.";
            this.fixedrbut.UseVisualStyleBackColor = true;
            this.fixedrbut.CheckedChanged += new System.EventHandler(this.fixedrbut_CheckedChanged);
            // 
            // cursorrbut
            // 
            this.cursorrbut.AutoSize = true;
            this.cursorrbut.Location = new System.Drawing.Point(62, 205);
            this.cursorrbut.Name = "cursorrbut";
            this.cursorrbut.Size = new System.Drawing.Size(55, 17);
            this.cursorrbut.TabIndex = 5;
            this.cursorrbut.Text = "Mouse Cur.";
            this.cursorrbut.UseVisualStyleBackColor = true;
            this.cursorrbut.CheckedChanged += new System.EventHandler(this.cursorrbut_CheckedChanged);
            // 
            // clickatlabel
            // 
            this.clickatlabel.AutoSize = true;
            this.clickatlabel.Location = new System.Drawing.Point(112, 189);
            this.clickatlabel.Name = "clickatlabel";
            this.clickatlabel.Size = new System.Drawing.Size(48, 13);
            this.clickatlabel.TabIndex = 12;
            this.clickatlabel.Text = "Click at:";
            // 
            // fixedlabel
            // 
            this.fixedlabel.AutoSize = true;
            this.fixedlabel.Location = new System.Drawing.Point(10, 235);
            this.fixedlabel.Name = "fixedlabel";
            this.fixedlabel.Size = new System.Drawing.Size(157, 13);
            this.fixedlabel.TabIndex = 13;
            this.fixedlabel.Text = "Fixed Pos. (?/Delete to Add/Clear):";
            // 
            // statusheaderlabel
            // 
            this.statusheaderlabel.AutoSize = true;
            this.statusheaderlabel.ForeColor = System.Drawing.Color.Magenta;
            this.statusheaderlabel.Location = new System.Drawing.Point(76, 258);
            this.statusheaderlabel.Name = "statusheaderlabel";
            this.statusheaderlabel.Size = new System.Drawing.Size(46, 13);
            this.statusheaderlabel.TabIndex = 14;
            this.statusheaderlabel.Text = "Status: ";
            // 
            // buttonlabel
            // 
            this.buttonlabel.AutoSize = true;
            this.buttonlabel.Location = new System.Drawing.Point(12, 129);
            this.buttonlabel.Name = "buttonlabel";
            this.buttonlabel.Size = new System.Drawing.Size(79, 13);
            this.buttonlabel.TabIndex = 15;
            this.buttonlabel.Text = "Mouse Button:";
            // 
            // clicktcombo
            // 
            this.clicktcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clicktcombo.FormattingEnabled = true;
            this.clicktcombo.Items.AddRange(new object[] {
            "Left",
            "Middle",
            "Right",
            "XBUTTON1",
            "XBUTTON2"});
            this.clicktcombo.Location = new System.Drawing.Point(97, 126);
            this.clicktcombo.Name = "clicktcombo";
            this.clicktcombo.Size = new System.Drawing.Size(175, 21);
            this.clicktcombo.TabIndex = 4;
            this.clicktcombo.SelectedIndexChanged += new System.EventHandler(this.clicktcombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Click Type:";
            // 
            // typecombo
            // 
            this.typecombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typecombo.FormattingEnabled = true;
            this.typecombo.Items.AddRange(new object[] {
            "Press Only (Hold the Button)",
            "Single Click (Press & Release)",
            "Double Click (Press & Release twice)"});
            this.typecombo.Location = new System.Drawing.Point(79, 158);
            this.typecombo.Name = "typecombo";
            this.typecombo.Size = new System.Drawing.Size(193, 21);
            this.typecombo.TabIndex = 17;
            this.typecombo.SelectedIndexChanged += new System.EventHandler(this.typecombo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 280);
            this.Controls.Add(this.typecombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clicktcombo);
            this.Controls.Add(this.buttonlabel);
            this.Controls.Add(this.statusheaderlabel);
            this.Controls.Add(this.fixedlabel);
            this.Controls.Add(this.clickatlabel);
            this.Controls.Add(this.cursorrbut);
            this.Controls.Add(this.fixedrbut);
            this.Controls.Add(this.amounttext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coordlabel);
            this.Controls.Add(this.statuslabel);
            this.Controls.Add(this.clickintervaltext);
            this.Controls.Add(this.stopbut);
            this.Controls.Add(this.startbutton);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RPG AutoClicker v5.8.1.2";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.Timer clicktimer;
        private System.Windows.Forms.Button stopbut;
        private System.Windows.Forms.TextBox clickintervaltext;
        private System.Windows.Forms.Label statuslabel;
        private System.Windows.Forms.Label coordlabel;
        private System.Collections.Generic.List<string> coordlabelList;
        private int coordlabelListIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox amounttext;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.RadioButton fixedrbut;
        private System.Windows.Forms.RadioButton cursorrbut;
        private System.Windows.Forms.Label clickatlabel;
        private System.Windows.Forms.Label fixedlabel;
        private System.Windows.Forms.Label statusheaderlabel;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolrndStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label buttonlabel;
        private System.Windows.Forms.ComboBox clicktcombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typecombo;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bugReportToolStripMenuItem;
    }
}

