namespace AutoClicker
{
    partial class Hotkeys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotkeys));
            this.starthotkey = new System.Windows.Forms.TextBox();
            this.startlabel = new System.Windows.Forms.Label();
            this.stophotkey = new System.Windows.Forms.TextBox();
            this.selectbox = new System.Windows.Forms.TextBox();
            this.stoplabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectlabel = new System.Windows.Forms.Label();
            this.focusbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // starthotkey
            // 
            this.starthotkey.Location = new System.Drawing.Point(82, 12);
            this.starthotkey.Name = "starthotkey";
            this.starthotkey.ReadOnly = true;
            this.starthotkey.Size = new System.Drawing.Size(118, 20);
            this.starthotkey.TabIndex = 1;
            this.starthotkey.Enter += new System.EventHandler(this.starthotkey_Enter);
            this.starthotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.starthotkey_KeyDown);
            this.starthotkey.Leave += new System.EventHandler(this.starthotkey_Leave);
            // 
            // startlabel
            // 
            this.startlabel.AutoSize = true;
            this.startlabel.Location = new System.Drawing.Point(12, 15);
            this.startlabel.Name = "startlabel";
            this.startlabel.Size = new System.Drawing.Size(59, 13);
            this.startlabel.TabIndex = 8;
            this.startlabel.Text = "Start Key : ";
            // 
            // stophotkey
            // 
            this.stophotkey.Location = new System.Drawing.Point(82, 39);
            this.stophotkey.Name = "stophotkey";
            this.stophotkey.ReadOnly = true;
            this.stophotkey.Size = new System.Drawing.Size(118, 20);
            this.stophotkey.TabIndex = 2;
            this.stophotkey.Enter += new System.EventHandler(this.stophotkey_Enter);
            this.stophotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stophotkey_KeyDown);
            this.stophotkey.Leave += new System.EventHandler(this.stophotkey_Leave);
            // 
            // selectbox
            // 
            this.selectbox.Location = new System.Drawing.Point(82, 66);
            this.selectbox.Name = "selectbox";
            this.selectbox.ReadOnly = true;
            this.selectbox.Size = new System.Drawing.Size(118, 20);
            this.selectbox.TabIndex = 3;
            this.selectbox.Enter += new System.EventHandler(this.selectbox_Enter);
            this.selectbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectbox_KeyDown);
            this.selectbox.Leave += new System.EventHandler(this.selectbox_Leave);
            // 
            // stoplabel
            // 
            this.stoplabel.AutoSize = true;
            this.stoplabel.Location = new System.Drawing.Point(12, 42);
            this.stoplabel.Name = "stoplabel";
            this.stoplabel.Size = new System.Drawing.Size(59, 13);
            this.stoplabel.TabIndex = 4;
            this.stoplabel.Text = "Stop Key : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Magenta;
            this.label3.Location = new System.Drawing.Point(21, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Click on the boxes to change keys";
            // 
            // selectlabel
            // 
            this.selectlabel.AutoSize = true;
            this.selectlabel.Location = new System.Drawing.Point(12, 69);
            this.selectlabel.Name = "selectlabel";
            this.selectlabel.Size = new System.Drawing.Size(64, 13);
            this.selectlabel.TabIndex = 6;
            this.selectlabel.Text = "Select Key :";
            // 
            // focusbox
            // 
            this.focusbox.Location = new System.Drawing.Point(2, 99);
            this.focusbox.Name = "focusbox";
            this.focusbox.Size = new System.Drawing.Size(0, 20);
            this.focusbox.TabIndex = 0;
            // 
            // Hotkeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 121);
            this.Controls.Add(this.focusbox);
            this.Controls.Add(this.selectlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stoplabel);
            this.Controls.Add(this.selectbox);
            this.Controls.Add(this.stophotkey);
            this.Controls.Add(this.startlabel);
            this.Controls.Add(this.starthotkey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Hotkeys";
            this.ShowInTaskbar = false;
            this.Text = "Hotkeys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hotkeys_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox starthotkey;
        private System.Windows.Forms.Label startlabel;
        private System.Windows.Forms.TextBox stophotkey;
        private System.Windows.Forms.TextBox selectbox;
        private System.Windows.Forms.Label stoplabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label selectlabel;
        private System.Windows.Forms.TextBox focusbox;

    }
}