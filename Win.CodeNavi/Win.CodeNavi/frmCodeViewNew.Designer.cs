namespace Win.CodeNavi
{
    partial class frmCodeViewNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodeViewNew));
            this.ctxCodeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.scintilla = new ScintillaNET.Scintilla();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla)).BeginInit();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCERTSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSendFileNamePathToNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdCopy = new System.Windows.Forms.ToolStripButton();
            this.cmdSearch = new System.Windows.Forms.ToolStripButton();
            this.cmdGoogle = new System.Windows.Forms.ToolStripButton();
            this.cmdCERT = new System.Windows.Forms.ToolStripButton();
            this.ctxCodeView.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _scintilla
            // 
            //this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla.LineWrapping.VisualFlags = ScintillaNET.LineWrappingVisualFlags.End;
            this.scintilla.Size = new System.Drawing.Size(836, 325);
            this.scintilla.Location = new System.Drawing.Point(29, 47);
            this.scintilla.Margins.Margin1.AutoToggleMarkerNumber = 0;
            this.scintilla.Margins.Margin1.IsClickable = true;
            this.scintilla.Margins.Margin2.Width = 16;
            this.scintilla.Name = "_scintilla";
            this.scintilla.TabIndex = 0;
            this.scintilla.StyleNeeded += new System.EventHandler<ScintillaNET.StyleNeededEventArgs>(this.scintilla_StyleNeeded);
            this.scintilla.ContextMenuStrip = this.ctxCodeView;
            // 
            // ctxCodeView
            // 
            this.ctxCodeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.googleToolStripMenuItem,
            this.cmdCERTSearch,
            this.cmdSendFileNamePathToNotes});
            this.ctxCodeView.Name = "ctxCodeView";
            this.ctxCodeView.Size = new System.Drawing.Size(250, 114);
            this.ctxCodeView.Opening += new System.ComponentModel.CancelEventHandler(this.ctxCodeView_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.searchToolStripMenuItem.Text = "&Search for Selection Across Code";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.googleToolStripMenuItem.Text = "&Google";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.googleToolStripMenuItem_Click);
            // 
            // cmdCERTSearch
            // 
            this.cmdCERTSearch.Name = "cmdCERTSearch";
            this.cmdCERTSearch.Size = new System.Drawing.Size(249, 22);
            this.cmdCERTSearch.Text = "C&ERT Secure Coding Search";
            this.cmdCERTSearch.Click += new System.EventHandler(this.cmdCERTSearch_Click);
            // 
            // cmdSendFileNamePathToNotes
            // 
            this.cmdSendFileNamePathToNotes.Name = "cmdSendFileNamePathToNotes";
            this.cmdSendFileNamePathToNotes.Size = new System.Drawing.Size(249, 22);
            this.cmdSendFileNamePathToNotes.Text = "Send &Filename and Path to Notes";
            this.cmdSendFileNamePathToNotes.Click += new System.EventHandler(this.cmdSendFileNamePathToNotes_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdCopy,
            this.cmdSearch,
            this.cmdGoogle,
            this.cmdCERT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(898, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // cmdCopy
            // 
            this.cmdCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCopy.Image = ((System.Drawing.Image)(resources.GetObject("cmdCopy.Image")));
            this.cmdCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.Size = new System.Drawing.Size(36, 36);
            this.cmdCopy.Text = "Copy selection to clipboard";
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(36, 36);
            this.cmdSearch.Text = "Search selection across code";
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdGoogle
            // 
            this.cmdGoogle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdGoogle.Image = ((System.Drawing.Image)(resources.GetObject("cmdGoogle.Image")));
            this.cmdGoogle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdGoogle.Name = "cmdGoogle";
            this.cmdGoogle.Size = new System.Drawing.Size(36, 36);
            this.cmdGoogle.Text = "Search selection in Google";
            this.cmdGoogle.Click += new System.EventHandler(this.cmdGoogle_Click);
            // 
            // cmdCERT
            // 
            this.cmdCERT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCERT.Image = ((System.Drawing.Image)(resources.GetObject("cmdCERT.Image")));
            this.cmdCERT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdCERT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCERT.Name = "cmdCERT";
            this.cmdCERT.Size = new System.Drawing.Size(36, 36);
            this.cmdCERT.Text = "Search selection on CERT secure coding";
            this.cmdCERT.Click += new System.EventHandler(this.cmdCERT_Click);
            // 
            // frmCodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 384);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.scintilla);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCodeViewNew";
            this.ShowInTaskbar = false;
            this.Text = "Code View - ";
            this.Load += new System.EventHandler(this.frmCodeViewNew_Load);
            this.Shown += new System.EventHandler(this.frmCodeViewNew_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCodeViewNew_KeyDown);
            this.ctxCodeView.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla)).EndInit();
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxCodeView;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmdCERTSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdCopy;
        private System.Windows.Forms.ToolStripButton cmdSearch;
        private System.Windows.Forms.ToolStripButton cmdGoogle;
        private System.Windows.Forms.ToolStripButton cmdCERT;
        private System.Windows.Forms.ToolStripMenuItem cmdSendFileNamePathToNotes;
        private ScintillaNET.Scintilla scintilla;
    }
}