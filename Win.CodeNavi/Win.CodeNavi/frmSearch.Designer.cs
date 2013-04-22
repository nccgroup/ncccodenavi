/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/ncccodenavi

Released under AGPL see LICENSE for more information
*/

namespace Win.CodeNavi
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.lstResults = new System.Windows.Forms.ListView();
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Extension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LineNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSendToNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSendLineToNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSendFilenameAndPathToNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdShowInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdSearchOpen = new System.Windows.Forms.ToolStripButton();
            this.cmdSearchSend = new System.Windows.Forms.ToolStripButton();
            this.cmdSearchSendCodeLine = new System.Windows.Forms.ToolStripButton();
            this.cmdSearchSendFileandPath = new System.Windows.Forms.ToolStripButton();
            this.cmdSearchAlwaysOnTop = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctxRightClick.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Path,
            this.File,
            this.Extension,
            this.LineNumber,
            this.Line});
            this.lstResults.ContextMenuStrip = this.ctxRightClick;
            this.lstResults.FullRowSelect = true;
            this.lstResults.HideSelection = false;
            this.lstResults.Location = new System.Drawing.Point(12, 42);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(874, 304);
            this.lstResults.TabIndex = 0;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            this.lstResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstResults_ColumnClick);
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            this.lstResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstResults_KeyPress);
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 150;
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 150;
            // 
            // Extension
            // 
            this.Extension.Text = "Ext";
            // 
            // LineNumber
            // 
            this.LineNumber.Text = "Line #";
            // 
            // Line
            // 
            this.Line.Text = "Line";
            this.Line.Width = 400;
            // 
            // ctxRightClick
            // 
            this.ctxRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSelectedFilesToolStripMenuItem,
            this.cmdSendToNotes,
            this.cmdSendLineToNotes,
            this.cmdSendFilenameAndPathToNotes,
            this.cmdShowInExplorer});
            this.ctxRightClick.Name = "ctxRightClick";
            this.ctxRightClick.Size = new System.Drawing.Size(250, 136);
            // 
            // openSelectedFilesToolStripMenuItem
            // 
            this.openSelectedFilesToolStripMenuItem.Name = "openSelectedFilesToolStripMenuItem";
            this.openSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.openSelectedFilesToolStripMenuItem.Text = "&Open Selected Files";
            this.openSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.openSelectedFilesToolStripMenuItem_Click);
            // 
            // cmdSendToNotes
            // 
            this.cmdSendToNotes.Name = "cmdSendToNotes";
            this.cmdSendToNotes.Size = new System.Drawing.Size(249, 22);
            this.cmdSendToNotes.Text = "&Send to Notes";
            this.cmdSendToNotes.Click += new System.EventHandler(this.cmdSendToNotes_Click);
            // 
            // cmdSendLineToNotes
            // 
            this.cmdSendLineToNotes.Name = "cmdSendLineToNotes";
            this.cmdSendLineToNotes.Size = new System.Drawing.Size(249, 22);
            this.cmdSendLineToNotes.Text = "Send &Line to Notes";
            this.cmdSendLineToNotes.Click += new System.EventHandler(this.cmdSendLineToNotes_Click);
            // 
            // cmdSendFilenameAndPathToNotes
            // 
            this.cmdSendFilenameAndPathToNotes.Name = "cmdSendFilenameAndPathToNotes";
            this.cmdSendFilenameAndPathToNotes.Size = new System.Drawing.Size(249, 22);
            this.cmdSendFilenameAndPathToNotes.Text = "Send &Filename and Path to Notes";
            this.cmdSendFilenameAndPathToNotes.Click += new System.EventHandler(this.cmdSendFilenameAndPathToNotes_Click);
            // 
            // cmdShowInExplorer
            // 
            this.cmdShowInExplorer.Name = "cmdShowInExplorer";
            this.cmdShowInExplorer.Size = new System.Drawing.Size(249, 22);
            this.cmdShowInExplorer.Text = "Show File in &Explorer";
            this.cmdShowInExplorer.Click += new System.EventHandler(this.cmdShowInExplorer_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSearchOpen,
            this.cmdSearchSend,
            this.cmdSearchSendCodeLine,
            this.cmdSearchSendFileandPath,
            this.cmdSearchAlwaysOnTop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(898, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // cmdSearchOpen
            // 
            this.cmdSearchOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSearchOpen.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchOpen.Image")));
            this.cmdSearchOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSearchOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSearchOpen.Name = "cmdSearchOpen";
            this.cmdSearchOpen.Size = new System.Drawing.Size(36, 36);
            this.cmdSearchOpen.Text = "Open selected files";
            this.cmdSearchOpen.Click += new System.EventHandler(this.cmdSearchOpen_Click);
            // 
            // cmdSearchSend
            // 
            this.cmdSearchSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSearchSend.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchSend.Image")));
            this.cmdSearchSend.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSearchSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSearchSend.Name = "cmdSearchSend";
            this.cmdSearchSend.Size = new System.Drawing.Size(36, 36);
            this.cmdSearchSend.Text = "Send filename and line of code to notes";
            this.cmdSearchSend.Click += new System.EventHandler(this.cmdSearchSend_Click);
            // 
            // cmdSearchSendCodeLine
            // 
            this.cmdSearchSendCodeLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSearchSendCodeLine.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchSendCodeLine.Image")));
            this.cmdSearchSendCodeLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSearchSendCodeLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSearchSendCodeLine.Name = "cmdSearchSendCodeLine";
            this.cmdSearchSendCodeLine.Size = new System.Drawing.Size(36, 36);
            this.cmdSearchSendCodeLine.Text = "Send line of code to notes";
            this.cmdSearchSendCodeLine.Click += new System.EventHandler(this.cmdSearchSendCodeLine_Click);
            // 
            // cmdSearchSendFileandPath
            // 
            this.cmdSearchSendFileandPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSearchSendFileandPath.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchSendFileandPath.Image")));
            this.cmdSearchSendFileandPath.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSearchSendFileandPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSearchSendFileandPath.Name = "cmdSearchSendFileandPath";
            this.cmdSearchSendFileandPath.Size = new System.Drawing.Size(36, 36);
            this.cmdSearchSendFileandPath.Text = "Send file path to notes";
            this.cmdSearchSendFileandPath.Click += new System.EventHandler(this.cmdSearchSendFileandPath_Click);
            // 
            // cmdSearchAlwaysOnTop
            // 
            this.cmdSearchAlwaysOnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSearchAlwaysOnTop.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearchAlwaysOnTop.Image")));
            this.cmdSearchAlwaysOnTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSearchAlwaysOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSearchAlwaysOnTop.Name = "cmdSearchAlwaysOnTop";
            this.cmdSearchAlwaysOnTop.Size = new System.Drawing.Size(36, 36);
            this.cmdSearchAlwaysOnTop.Text = "toolStripButton1";
            this.cmdSearchAlwaysOnTop.ToolTipText = "Always on top";
            this.cmdSearchAlwaysOnTop.Click += new System.EventHandler(this.cmdSearchAlwaysOnTop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(898, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(84, 17);
            this.lblStatus.Text = "Search not run";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 384);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Results - ABC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearch_FormClosing);
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearch_KeyDown);
            this.ctxRightClick.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstResults;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader LineNumber;
        private System.Windows.Forms.ColumnHeader Line;
        private System.Windows.Forms.ColumnHeader Extension;
        private System.Windows.Forms.ContextMenuStrip ctxRightClick;
        private System.Windows.Forms.ToolStripMenuItem openSelectedFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmdSendToNotes;
        private System.Windows.Forms.ToolStripMenuItem cmdSendLineToNotes;
        private System.Windows.Forms.ToolStripMenuItem cmdSendFilenameAndPathToNotes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdSearchOpen;
        private System.Windows.Forms.ToolStripButton cmdSearchSend;
        private System.Windows.Forms.ToolStripButton cmdSearchSendCodeLine;
        private System.Windows.Forms.ToolStripButton cmdSearchSendFileandPath;
        private System.Windows.Forms.ToolStripButton cmdSearchAlwaysOnTop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem cmdShowInExplorer;
    }
}