/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/ncccodenavi

Released under AGPL see LICENSE for more information
*/

namespace Win.CodeNavi
{
    partial class frmCodeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodeView));
            this.richText = new System.Windows.Forms.RichTextBox();
            this.ctxCodeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCERTSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdSendFileNamePathToNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.lineNumbersForRichText = new LineNumbersControlForRichTextBox.LineNumbersForRichText();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdCopy = new System.Windows.Forms.ToolStripButton();
            this.cmdSearch = new System.Windows.Forms.ToolStripButton();
            this.cmdGoogle = new System.Windows.Forms.ToolStripButton();
            this.cmdCERT = new System.Windows.Forms.ToolStripButton();
            this.ctxCodeView.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richText
            // 
            this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richText.BackColor = System.Drawing.SystemColors.Window;
            this.richText.ContextMenuStrip = this.ctxCodeView;
            this.richText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richText.HideSelection = false;
            this.richText.Location = new System.Drawing.Point(50, 47);
            this.richText.Name = "richText";
            this.richText.ReadOnly = true;
            this.richText.Size = new System.Drawing.Size(836, 325);
            this.richText.TabIndex = 0;
            this.richText.Text = "";
            this.richText.WordWrap = false;
            this.richText.SelectionChanged += new System.EventHandler(this.richText_SelectionChanged);
            this.richText.TextChanged += new System.EventHandler(this.richText_TextChanged);
            this.richText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richText_KeyPress);
            this.richText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richText_MouseDown);
            this.richText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richText_MouseUp);
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
            // lineNumbersForRichText
            // 
            this.lineNumbersForRichText.AutoSizing = true;
            this.lineNumbersForRichText.BackgroundGradientAlphaColor = System.Drawing.Color.Transparent;
            this.lineNumbersForRichText.BackgroundGradientBetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbersForRichText.BackgroundGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbersForRichText.BorderLinesColor = System.Drawing.Color.SlateGray;
            this.lineNumbersForRichText.BorderLinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbersForRichText.BorderLinesThickness = 1F;
            this.lineNumbersForRichText.DockSide = LineNumbersControlForRichTextBox.LineNumbersForRichText.LineNumberDockSide.Left;
            this.lineNumbersForRichText.GridLinesColor = System.Drawing.Color.SlateGray;
            this.lineNumbersForRichText.GridLinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbersForRichText.GridLinesThickness = 1F;
            this.lineNumbersForRichText.LineNumbersAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbersForRichText.LineNumbersAntiAlias = true;
            this.lineNumbersForRichText.LineNumbersAsHexadecimal = false;
            this.lineNumbersForRichText.LineNumbersClippedByItemRectangle = true;
            this.lineNumbersForRichText.LineNumbersLeadingZeroes = true;
            this.lineNumbersForRichText.LineNumbersOffset = new System.Drawing.Size(0, 0);
            this.lineNumbersForRichText.Location = new System.Drawing.Point(29, 47);
            this.lineNumbersForRichText.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbersForRichText.MarginLinesColor = System.Drawing.Color.SlateGray;
            this.lineNumbersForRichText.MarginLinesSide = LineNumbersControlForRichTextBox.LineNumbersForRichText.LineNumberDockSide.Right;
            this.lineNumbersForRichText.MarginLinesStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbersForRichText.MarginLinesThickness = 1F;
            this.lineNumbersForRichText.Name = "lineNumbersForRichText";
            this.lineNumbersForRichText.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbersForRichText.ParentRichTextBox = this.richText;
            this.lineNumbersForRichText.SeeThroughMode = false;
            this.lineNumbersForRichText.ShowBackgroundGradient = true;
            this.lineNumbersForRichText.ShowBorderLines = true;
            this.lineNumbersForRichText.ShowGridLines = true;
            this.lineNumbersForRichText.ShowLineNumbers = true;
            this.lineNumbersForRichText.ShowMarginLines = true;
            this.lineNumbersForRichText.Size = new System.Drawing.Size(20, 325);
            this.lineNumbersForRichText.TabIndex = 2;
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
            this.Controls.Add(this.richText);
            this.Controls.Add(this.lineNumbersForRichText);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCodeView";
            this.ShowInTaskbar = false;
            this.Text = "Code View - ";
            this.Load += new System.EventHandler(this.frmCodeView_Load);
            this.Shown += new System.EventHandler(this.frmCodeView_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCodeView_KeyDown);
            this.ctxCodeView.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxCodeView;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private LineNumbersControlForRichTextBox.LineNumbersForRichText lineNumbersForRichText;
        private System.Windows.Forms.ToolStripMenuItem cmdCERTSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdCopy;
        private System.Windows.Forms.ToolStripButton cmdSearch;
        private System.Windows.Forms.ToolStripButton cmdGoogle;
        private System.Windows.Forms.ToolStripButton cmdCERT;
        private System.Windows.Forms.ToolStripMenuItem cmdSendFileNamePathToNotes;
        public System.Windows.Forms.RichTextBox richText;
    }
}