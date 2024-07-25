using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;

public class TestListView : System.Windows.Forms.ListView
{
    private const int WM_HSCROLL = 0x114;
    private const int WM_VSCROLL = 0x115;
    public event EventHandler Scroll;

    protected void OnScroll()
    {

        if (this.Scroll != null)
            this.Scroll(this, EventArgs.Empty);

    }

    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 0x000c2c9)
            this.OnScroll();
    }
}

namespace Auto_Clicker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PositionsGroupBox = new System.Windows.Forms.GroupBox();
            this.SleepTimeTextBox = new System.Windows.Forms.TextBox();
            this.QueuedYPositionTextBox = new System.Windows.Forms.TextBox();
            //this.RightClickCheckBox = new System.Windows.Forms.CheckBox();
            this.SleepTimeLabel = new System.Windows.Forms.Label();
            this.AddPositionButtonLeft = new System.Windows.Forms.Button();
            this.AddPositionButtonRight = new System.Windows.Forms.Button();
            this.AddPositionButtonMiddle = new System.Windows.Forms.Button();
            this.LoadSequenceButton = new System.Windows.Forms.Button();
            this.SaveSequenceButton = new System.Windows.Forms.Button();
            this.QueuedXPositionLabel = new System.Windows.Forms.Label();
            this.QueuedYPositionLabel = new System.Windows.Forms.Label();
            this.QueuedXPositionTextBox = new System.Windows.Forms.TextBox();
            this.PositionsListView = new TestListView();
            this.TxtEdit = new System.Windows.Forms.TextBox();
            this.XCoordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YCoordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LRHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SleepTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueuedPositionsLabel = new System.Windows.Forms.Label();
            //this.CurrentPosGroupBox = new System.Windows.Forms.GroupBox();
            this.CopyToAddButton = new System.Windows.Forms.Button();
            this.CurrentYCoordTextBox = new System.Windows.Forms.TextBox();
            this.XCoordLabel = new System.Windows.Forms.Label();
            this.YCoordLabel = new System.Windows.Forms.Label();
            this.CurrentXCoordTextBox = new System.Windows.Forms.TextBox();
            this.StartingOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.StopClickingButton = new System.Windows.Forms.Button();
            this.StartClickingButton = new System.Windows.Forms.Button();
            this.CurClickingStatus = new System.Windows.Forms.Label();
            this.NumRepeatsTextBox = new System.Windows.Forms.TextBox();
            this.NumRepeatsLabel = new System.Windows.Forms.Label();
            this.CurrentPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.AboutLabel = new System.Windows.Forms.Label();
            this.PositionsGroupBox.SuspendLayout();
            this.ListViewContextMenu.SuspendLayout();
            //this.CurrentPosGroupBox.SuspendLayout();
            this.StartingOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionsGroupBox
            // 
            this.PositionsGroupBox.Controls.Add(this.SleepTimeTextBox);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionTextBox);
            //this.PositionsGroupBox.Controls.Add(this.RightClickCheckBox);
            this.PositionsGroupBox.Controls.Add(this.SleepTimeLabel);
            this.PositionsGroupBox.Controls.Add(this.AddPositionButtonLeft);
            this.PositionsGroupBox.Controls.Add(this.AddPositionButtonRight);
            this.PositionsGroupBox.Controls.Add(this.AddPositionButtonMiddle);
            this.PositionsGroupBox.Controls.Add(this.LoadSequenceButton);
            this.PositionsGroupBox.Controls.Add(this.SaveSequenceButton);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionTextBox);
            this.PositionsGroupBox.Controls.Add(this.PositionsListView);
            this.PositionsGroupBox.Controls.Add(this.TxtEdit);
            this.PositionsGroupBox.Controls.Add(this.QueuedPositionsLabel);
            this.PositionsGroupBox.Location = new System.Drawing.Point(285, 3);
            this.PositionsGroupBox.Name = "PositionsGroupBox";
            this.PositionsGroupBox.Size = new System.Drawing.Size(350, 309);
            this.PositionsGroupBox.TabIndex = 0;
            this.PositionsGroupBox.TabStop = false;
            this.PositionsGroupBox.Text = "Sequence of Mouse Clicks";
            // 
            // SleepTimeTextBox
            // 
            this.SleepTimeTextBox.Location = new System.Drawing.Point(227, 254);
            this.SleepTimeTextBox.Name = "SleepTimeTextBox";
            this.SleepTimeTextBox.Size = new System.Drawing.Size(116, 20);
            this.SleepTimeTextBox.TabIndex = 11;
            this.SleepTimeTextBox.Text = "1000";
            // 
            // QueuedYPositionTextBox
            // 
            this.QueuedYPositionTextBox.Location = new System.Drawing.Point(256, 225);
            this.QueuedYPositionTextBox.Name = "QueuedYPositionTextBox";
            this.QueuedYPositionTextBox.Size = new System.Drawing.Size(87, 20);
            this.QueuedYPositionTextBox.TabIndex = 10;
            this.QueuedYPositionTextBox.ReadOnly = true;
            this.QueuedYPositionTextBox.BackColor = Color.Gold;
            this.QueuedYPositionTextBox.ForeColor = Color.Blue;
            // 
            // RightClickCheckBox
            //
            /*
            this.RightClickCheckBox.AutoSize = true;
            this.RightClickCheckBox.Location = new System.Drawing.Point(8, 256);
            this.RightClickCheckBox.Name = "RightClickCheckBox";
            this.RightClickCheckBox.Size = new System.Drawing.Size(83, 17);
            this.RightClickCheckBox.TabIndex = 9;
            this.RightClickCheckBox.Text = "Right Click?";
            this.RightClickCheckBox.UseVisualStyleBackColor = true;
            */
            // 
            // SleepTimeLabel
            // 
            this.SleepTimeLabel.AutoSize = true;
            this.SleepTimeLabel.Location = new System.Drawing.Point(123, 257);
            this.SleepTimeLabel.Name = "SleepTimeLabel";
            this.SleepTimeLabel.Size = new System.Drawing.Size(106, 13);
            this.SleepTimeLabel.TabIndex = 15;
            this.SleepTimeLabel.Text = "Time to Sleep (ms) - ";
            // 
            // AddPositionButtonLeft
            // 
            this.AddPositionButtonLeft.Location = new System.Drawing.Point(6, 224);
            this.AddPositionButtonLeft.Name = "AddPositionButtonLeft";
            this.AddPositionButtonLeft.Size = new System.Drawing.Size(111, 23);
            this.AddPositionButtonLeft.TabIndex = 4;
            this.AddPositionButtonLeft.Text = "Add Left Click (F4)";
            this.AddPositionButtonLeft.UseVisualStyleBackColor = true;
            this.AddPositionButtonLeft.Click += new System.EventHandler(this.AddPositionButtonLeft_Click);
            // 
            // AddPositionButtonRight
            // 
            this.AddPositionButtonRight.Location = new System.Drawing.Point(6, 252);
            this.AddPositionButtonRight.Name = "AddPositionButtonRight";
            this.AddPositionButtonRight.Size = new System.Drawing.Size(111, 23);
            this.AddPositionButtonRight.TabIndex = 5;
            this.AddPositionButtonRight.Text = "Add Right Click (F5)";
            this.AddPositionButtonRight.UseVisualStyleBackColor = true;
            this.AddPositionButtonRight.Click += new System.EventHandler(this.AddPositionButtonRight_Click);
            // 
            // AddPositionButtonMiddle
            // 
            this.AddPositionButtonMiddle.Location = new System.Drawing.Point(6, 280);
            this.AddPositionButtonMiddle.Name = "AddPositionButtonMiddle";
            this.AddPositionButtonMiddle.Size = new System.Drawing.Size(121, 23);
            this.AddPositionButtonMiddle.TabIndex = 6;
            this.AddPositionButtonMiddle.Text = "Add Middle Click (F6)";
            this.AddPositionButtonMiddle.UseVisualStyleBackColor = true;
            this.AddPositionButtonMiddle.Click += new System.EventHandler(this.AddPositionButtonMiddle_Click);
            // 
            // LoadSequenceButton
            // 
            this.LoadSequenceButton.Location = new System.Drawing.Point(136, 280);
            this.LoadSequenceButton.Name = "LoadSequenceButton";
            this.LoadSequenceButton.Size = new System.Drawing.Size(100, 23);
            this.LoadSequenceButton.TabIndex = 10;
            this.LoadSequenceButton.Text = "Load Sequence";
            this.LoadSequenceButton.UseVisualStyleBackColor = true;
            this.LoadSequenceButton.Click += new System.EventHandler(this.LoadSequenceButton_Click);
            // 
            // SaveSequenceButton
            // 
            this.SaveSequenceButton.Location = new System.Drawing.Point(240, 280);
            this.SaveSequenceButton.Name = "SaveSequenceButton";
            this.SaveSequenceButton.Size = new System.Drawing.Size(100, 23);
            this.SaveSequenceButton.TabIndex = 11;
            this.SaveSequenceButton.Text = "Save Sequence";
            this.SaveSequenceButton.UseVisualStyleBackColor = true;
            this.SaveSequenceButton.Click += new System.EventHandler(this.SaveSequenceButton_Click);
            // 
            // QueuedXPositionLabel
            // 
            this.QueuedXPositionLabel.AutoSize = true;
            this.QueuedXPositionLabel.Location = new System.Drawing.Point(123, 228);
            this.QueuedXPositionLabel.Name = "QueuedXPositionLabel";
            this.QueuedXPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.QueuedXPositionLabel.TabIndex = 7;
            this.QueuedXPositionLabel.Text = "X";
            // 
            // QueuedYPositionLabel
            // 
            this.QueuedYPositionLabel.AutoSize = true;
            this.QueuedYPositionLabel.Location = new System.Drawing.Point(236, 228);
            this.QueuedYPositionLabel.Name = "QueuedYPositionLabel";
            this.QueuedYPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.QueuedYPositionLabel.TabIndex = 8;
            this.QueuedYPositionLabel.Text = "Y";
            // 
            // QueuedXPositionTextBox
            // 
            this.QueuedXPositionTextBox.Location = new System.Drawing.Point(143, 225);
            this.QueuedXPositionTextBox.Name = "QueuedXPositionTextBox";
            this.QueuedXPositionTextBox.Size = new System.Drawing.Size(87, 20);
            this.QueuedXPositionTextBox.TabIndex = 8;
            this.QueuedXPositionTextBox.ReadOnly = true;
            this.QueuedXPositionTextBox.BackColor = Color.Gold;
            this.QueuedXPositionTextBox.ForeColor = Color.Blue;
            // 
            // PositionsListView
            // 
            this.PositionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.XCoordHeader,
            this.YCoordHeader,
            this.LRHeader,
            this.SleepTimeHeader});
            this.PositionsListView.ContextMenuStrip = this.ListViewContextMenu;
            this.PositionsListView.FullRowSelect = true;
            this.PositionsListView.GridLines = true;
            this.PositionsListView.Location = new System.Drawing.Point(6, 32);
            this.PositionsListView.Name = "PositionsListView";
            this.PositionsListView.Size = new System.Drawing.Size(338, 181);
            this.PositionsListView.TabIndex = 1;
            this.PositionsListView.UseCompatibleStateImageBehavior = false;
            this.PositionsListView.View = System.Windows.Forms.View.Details;
            /////////////////////////////////////////
            this.TxtEdit.Visible = false;
            this.PositionsListView.MouseUp += new MouseEventHandler(this.PositionsListView_MouseUp);
            this.PositionsListView.MouseDown += new MouseEventHandler(this.PositionsListView_MouseDown);
            this.PositionsListView.Scroll += new System.EventHandler(this.PositionsListView_Scroll);
            this.TxtEdit.Leave += new System.EventHandler(this.TxtEdit_Leave);
            this.TxtEdit.KeyUp += new KeyEventHandler(this.TxtEdit_KeyUp);
            /////////////////////////////////////////
            // 
            // XCoordHeader
            // 
            this.XCoordHeader.Text = "X";
            this.XCoordHeader.Width = 70*2;
            // 
            // YCoordHeader
            // 
            this.YCoordHeader.Text = "Y";
            this.YCoordHeader.Width = 70*2;
            // 
            // LRHeader
            // 
            this.LRHeader.Text = "L/M/R";
            this.LRHeader.Width = 50*2;
            // 
            // SleepTimeHeader
            // 
            this.SleepTimeHeader.Text = "ms";
            this.SleepTimeHeader.Width = 100*2;
            // 
            // ListViewContextMenu
            // 
            this.ListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveAllMenuItem,
            this.RemoveSelectedMenuItem});
            this.ListViewContextMenu.Name = "ListViewContextMenu";
            this.ListViewContextMenu.Size = new System.Drawing.Size(167, 48);
            // 
            // RemoveAllMenuItem
            // 
            this.RemoveAllMenuItem.Name = "RemoveAllMenuItem";
            this.RemoveAllMenuItem.Size = new System.Drawing.Size(166, 22);
            this.RemoveAllMenuItem.Text = "Remove All Items";
            this.RemoveAllMenuItem.Click += new System.EventHandler(this.RemoveAllMenuItem_Click);
            // 
            // RemoveSelectedMenuItem
            // 
            this.RemoveSelectedMenuItem.Name = "RemoveSelectedMenuItem";
            this.RemoveSelectedMenuItem.Size = new System.Drawing.Size(166, 22);
            this.RemoveSelectedMenuItem.Text = "Remove Selected";
            this.RemoveSelectedMenuItem.Click += new System.EventHandler(this.RemoveSelectedMenuItem_Click);
            // 
            // QueuedPositionsLabel
            // 
            this.QueuedPositionsLabel.AutoSize = true;
            this.QueuedPositionsLabel.Location = new System.Drawing.Point(3, 16);
            this.QueuedPositionsLabel.Name = "QueuedPositionsLabel";
            this.QueuedPositionsLabel.Size = new System.Drawing.Size(123, 13);
            this.QueuedPositionsLabel.TabIndex = 0;
            this.QueuedPositionsLabel.Text = "Cursor Position (X, Y), Button to Click (L/M/R), Time to Sleep (ms)";
            // 
            // CurrentPosGroupBox
            // 
            //this.CurrentPosGroupBox.Controls.Add(this.CopyToAddButton);
            //this.CurrentPosGroupBox.Controls.Add(this.CurrentYCoordTextBox);
            //this.CurrentPosGroupBox.Controls.Add(this.XCoordLabel);
            //this.CurrentPosGroupBox.Controls.Add(this.YCoordLabel);
            //this.CurrentPosGroupBox.Controls.Add(this.CurrentXCoordTextBox);
            //this.CurrentPosGroupBox.Location = new System.Drawing.Point(12, 12);
            //this.CurrentPosGroupBox.Name = "CurrentPosGroupBox";
            //this.CurrentPosGroupBox.Size = new System.Drawing.Size(267, 131);
            //this.CurrentPosGroupBox.TabIndex = 2;
            //this.CurrentPosGroupBox.TabStop = false;
            //this.CurrentPosGroupBox.Text = "Current Mouse Cursor Position";
            // 
            // CopyToAddButton
            // 
            this.CopyToAddButton.Location = new System.Drawing.Point(9, 85);
            this.CopyToAddButton.Name = "CopyToAddButton";
            this.CopyToAddButton.Size = new System.Drawing.Size(252, 30);
            this.CopyToAddButton.TabIndex = 6;
            this.CopyToAddButton.Text = "Copy to Add Click (F3)";
            this.CopyToAddButton.UseVisualStyleBackColor = true;
            this.CopyToAddButton.Click += new System.EventHandler(this.CopyToAddButton_Click);
            // 
            // CurrentYCoordTextBox
            // 
            this.CurrentYCoordTextBox.Location = new System.Drawing.Point(47, 49);
            this.CurrentYCoordTextBox.Name = "CurrentYCoordTextBox";
            this.CurrentYCoordTextBox.Size = new System.Drawing.Size(214, 20);
            this.CurrentYCoordTextBox.TabIndex = 5;
            // 
            // XCoordLabel
            // 
            this.XCoordLabel.AutoSize = true;
            this.XCoordLabel.Location = new System.Drawing.Point(6, 26);
            this.XCoordLabel.Name = "XCoordLabel";
            this.XCoordLabel.Size = new System.Drawing.Size(14, 13);
            this.XCoordLabel.TabIndex = 2;
            this.XCoordLabel.Text = "X";
            // 
            // YCoordLabel
            // 
            this.YCoordLabel.AutoSize = true;
            this.YCoordLabel.Location = new System.Drawing.Point(6, 56);
            this.YCoordLabel.Name = "YCoordLabel";
            this.YCoordLabel.Size = new System.Drawing.Size(14, 13);
            this.YCoordLabel.TabIndex = 3;
            this.YCoordLabel.Text = "Y";
            // 
            // CurrentXCoordTextBox
            // 
            this.CurrentXCoordTextBox.Location = new System.Drawing.Point(47, 23);
            this.CurrentXCoordTextBox.Name = "CurrentXCoordTextBox";
            this.CurrentXCoordTextBox.Size = new System.Drawing.Size(214, 20);
            this.CurrentXCoordTextBox.TabIndex = 4;
            // 
            // StartingOptionsGroupBox
            // 
            this.StartingOptionsGroupBox.Controls.Add(this.StopClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.StartClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.CurClickingStatus);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsTextBox);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsLabel);
            this.StartingOptionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.StartingOptionsGroupBox.Name = "StartingOptionsGroupBox";
            this.StartingOptionsGroupBox.Size = new System.Drawing.Size(267, 150);
            this.StartingOptionsGroupBox.TabIndex = 2;
            this.StartingOptionsGroupBox.TabStop = false;
            this.StartingOptionsGroupBox.Text = "Starting Options";
            // 
            // StopClickingButton
            // 
            this.StopClickingButton.Location = new System.Drawing.Point(6, 85);
            this.StopClickingButton.Name = "StopClickingButton";
            this.StopClickingButton.Size = new System.Drawing.Size(255, 37);
            this.StopClickingButton.TabIndex = 3;
            this.StopClickingButton.Text = "Stop Clicking (F2)";
            this.StopClickingButton.UseVisualStyleBackColor = true;
            this.StopClickingButton.Click += new System.EventHandler(this.StopClickingButton_Click);
            // 
            // StartClickingButton
            // 
            this.StartClickingButton.Location = new System.Drawing.Point(6, 42);
            this.StartClickingButton.Name = "StartClickingButton";
            this.StartClickingButton.Size = new System.Drawing.Size(255, 37);
            this.StartClickingButton.TabIndex = 2;
            this.StartClickingButton.Text = "Start Clicking the Sequence (F1)";
            this.StartClickingButton.UseVisualStyleBackColor = true;
            this.StartClickingButton.Click += new System.EventHandler(this.StartClickingButton_Click);
            // 
            // CurClickingStatus
            //
            this.CurClickingStatus.AutoSize = true;
            this.CurClickingStatus.Location = new System.Drawing.Point(6, 127);
            this.CurClickingStatus.Name = "CurClickingStatus";
            this.CurClickingStatus.Size = new System.Drawing.Size(255, 37);
            this.CurClickingStatus.TabIndex = 0;
            this.CurClickingStatus.TabStop = false;
            this.CurClickingStatus.Text = "Status: Not Clicking";
            this.CurClickingStatus.BackColor = System.Drawing.Color.Gold;
            this.CurClickingStatus.ForeColor = System.Drawing.Color.Blue;
            // 
            // NumRepeatsTextBox
            // 
            this.NumRepeatsTextBox.Location = new System.Drawing.Point(120, 16);
            this.NumRepeatsTextBox.Name = "NumRepeatsTextBox";
            this.NumRepeatsTextBox.Size = new System.Drawing.Size(141, 20);
            this.NumRepeatsTextBox.TabIndex = 1;
            this.NumRepeatsTextBox.Text = "1";
            // 
            // NumRepeatsLabel
            // 
            this.NumRepeatsLabel.AutoSize = true;
            this.NumRepeatsLabel.Location = new System.Drawing.Point(6, 19);
            this.NumRepeatsLabel.Name = "NumRepeatsLabel";
            this.NumRepeatsLabel.Size = new System.Drawing.Size(108, 13);
            this.NumRepeatsLabel.TabIndex = 0;
            this.NumRepeatsLabel.Text = "Number of Cycles - ";
            // 
            // CurrentPositionTimer
            // 
            this.CurrentPositionTimer.Interval = 1;
            this.CurrentPositionTimer.Tick += new System.EventHandler(this.CurrentPositionTimer_Tick);
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Location = new System.Drawing.Point(12, 315);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(186, 13);
            this.AboutLabel.TabIndex = 3;
            this.AboutLabel.Text = "Open Source Developer Federica Domani (federicadomani@mailfence.com)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 337); // Main Window Size
            this.Controls.Add(this.AboutLabel);
            this.Controls.Add(this.StartingOptionsGroupBox);
            //this.Controls.Add(this.CurrentPosGroupBox);
            this.Controls.Add(this.PositionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = true;
            this.Name = "MainForm";
            this.Text = "AutoClicker2 Record Play The Lists... Extended v5.9.7.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.PositionsGroupBox.ResumeLayout(false);
            this.PositionsGroupBox.PerformLayout();
            this.ListViewContextMenu.ResumeLayout(false);
            //this.CurrentPosGroupBox.ResumeLayout(false);
            //this.CurrentPosGroupBox.PerformLayout();
            this.StartingOptionsGroupBox.ResumeLayout(false);
            this.StartingOptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PositionsGroupBox;
        private System.Windows.Forms.TextBox SleepTimeTextBox;
        private System.Windows.Forms.TextBox QueuedYPositionTextBox;
        //private System.Windows.Forms.CheckBox RightClickCheckBox;
        private System.Windows.Forms.Label SleepTimeLabel;
        private System.Windows.Forms.Button AddPositionButtonLeft;
        private System.Windows.Forms.Button AddPositionButtonRight;
        private System.Windows.Forms.Button AddPositionButtonMiddle;
        private System.Windows.Forms.Button LoadSequenceButton;
        private System.Windows.Forms.Button SaveSequenceButton;
        private System.Windows.Forms.Label QueuedXPositionLabel;
        private System.Windows.Forms.Label QueuedYPositionLabel;
        private System.Windows.Forms.TextBox QueuedXPositionTextBox;
        private TestListView PositionsListView;
        private System.Windows.Forms.TextBox TxtEdit;
        private System.Windows.Forms.ColumnHeader XCoordHeader;
        private System.Windows.Forms.ColumnHeader YCoordHeader;
        private System.Windows.Forms.ColumnHeader LRHeader;
        private System.Windows.Forms.ColumnHeader SleepTimeHeader;
        private System.Windows.Forms.Label QueuedPositionsLabel;
        //private System.Windows.Forms.GroupBox CurrentPosGroupBox;
        private System.Windows.Forms.Button CopyToAddButton;
        private System.Windows.Forms.TextBox CurrentYCoordTextBox;
        private System.Windows.Forms.Label XCoordLabel;
        private System.Windows.Forms.Label YCoordLabel;
        private System.Windows.Forms.TextBox CurrentXCoordTextBox;
        private System.Windows.Forms.GroupBox StartingOptionsGroupBox;
        private System.Windows.Forms.Button StopClickingButton;
        private System.Windows.Forms.Button StartClickingButton;
        private System.Windows.Forms.Label CurClickingStatus;
        private System.Windows.Forms.TextBox NumRepeatsTextBox;
        private System.Windows.Forms.Label NumRepeatsLabel;
        private System.Windows.Forms.Timer CurrentPositionTimer;
        private System.Windows.Forms.ContextMenuStrip ListViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveSelectedMenuItem;
        private System.Windows.Forms.Label AboutLabel;
    }
}

