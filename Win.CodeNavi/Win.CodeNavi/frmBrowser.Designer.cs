namespace Win.CodeNavi
{
    partial class frmBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrowser));
            this.scintilla = new ScintillaNET.Scintilla();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.cmdFind = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.treeFiles = new System.Windows.Forms.TreeView();
            this.ctxFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdOpeninCodeView = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdShowInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSendFilenameAndPathToNotes = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.ctxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // scintilla
            // 
            this.scintilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla.LineWrapping.VisualFlags = ScintillaNET.LineWrappingVisualFlags.End;
            this.scintilla.Size = new System.Drawing.Size(707, 432);
            this.scintilla.Location = new System.Drawing.Point(57, 12);
            this.scintilla.Margins.Margin1.AutoToggleMarkerNumber = 0;
            this.scintilla.Margins.Margin1.IsClickable = true;
            this.scintilla.Margins.Margin2.Width = 16;
            this.scintilla.Name = "_scintilla";
            this.scintilla.TabIndex = 3;
            // 
            // splitMain
            // 
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.cmdFind);
            this.splitMain.Panel1.Controls.Add(this.txtSearch);
            this.splitMain.Panel1.Controls.Add(this.lblFind);
            this.splitMain.Panel1.Controls.Add(this.treeFiles);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.scintilla);
            this.splitMain.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitMain_Panel2_Paint);
            this.splitMain.Size = new System.Drawing.Size(1031, 458);
            this.splitMain.SplitterDistance = 249;
            this.splitMain.TabIndex = 0;
            this.splitMain.TabStop = false;
            // 
            // cmdFind
            // 
            this.cmdFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFind.Location = new System.Drawing.Point(179, 428);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(58, 23);
            this.cmdFind.TabIndex = 3;
            this.cmdFind.Text = "&Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(45, 428);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(128, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lblFind
            // 
            this.lblFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(12, 431);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(27, 13);
            this.lblFind.TabIndex = 1;
            this.lblFind.Text = "Find";
            // 
            // treeFiles
            // 
            this.treeFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFiles.ContextMenuStrip = this.ctxFile;
            this.treeFiles.Location = new System.Drawing.Point(12, 12);
            this.treeFiles.Name = "treeFiles";
            this.treeFiles.Size = new System.Drawing.Size(225, 408);
            this.treeFiles.TabIndex = 0;
            this.treeFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFiles_AfterSelect);
            this.treeFiles.Click += new System.EventHandler(this.treeFiles_Click);
            this.treeFiles.DoubleClick += new System.EventHandler(this.treeFiles_DoubleClick);
            this.treeFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeFiles_KeyPress);
            // 
            // ctxFile
            // 
            this.ctxFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdOpeninCodeView,
            this.cmdSendFilenameAndPathToNotes,
            this.cmdShowInExplorer});
            this.ctxFile.Name = "ctxFile";
            this.ctxFile.Size = new System.Drawing.Size(250, 92);
            this.ctxFile.Opening += new System.ComponentModel.CancelEventHandler(this.ctxFile_Opening);
            // 
            // cmdOpeninCodeView
            // 
            this.cmdOpeninCodeView.Name = "cmdOpeninCodeView";
            this.cmdOpeninCodeView.Size = new System.Drawing.Size(249, 22);
            this.cmdOpeninCodeView.Text = "&Open in code view";
            this.cmdOpeninCodeView.Click += new System.EventHandler(this.cmdOpeninCodeView_Click);
            // 
            // cmdShowInExplorer
            // 
            this.cmdShowInExplorer.Name = "cmdShowInExplorer";
            this.cmdShowInExplorer.Size = new System.Drawing.Size(249, 22);
            this.cmdShowInExplorer.Text = "Show File in &Explorer";
            this.cmdShowInExplorer.Click += new System.EventHandler(this.cmdShowInExplorer_Click);
            // 
            // cmdSendFilenameAndPathToNotes
            // 
            this.cmdSendFilenameAndPathToNotes.Name = "cmdSendFilenameAndPathToNotes";
            this.cmdSendFilenameAndPathToNotes.Size = new System.Drawing.Size(249, 22);
            this.cmdSendFilenameAndPathToNotes.Text = "Send &Filename and Path to Notes";
            this.cmdSendFilenameAndPathToNotes.Click += new System.EventHandler(this.cmdSendFilenameAndPathToNotes_Click);
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 458);
            this.Controls.Add(this.splitMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBrowser";
            this.ShowInTaskbar = false;
            this.Text = "File Browser";
            this.Load += new System.EventHandler(this.frmBrowser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrowser_KeyDown);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.ctxFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView treeFiles;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.ContextMenuStrip ctxFile;
        private System.Windows.Forms.ToolStripMenuItem cmdOpeninCodeView;
        private System.Windows.Forms.ToolStripMenuItem cmdShowInExplorer;
        private System.Windows.Forms.ToolStripMenuItem cmdSendFilenameAndPathToNotes;
        private ScintillaNET.Scintilla scintilla;
    }
}