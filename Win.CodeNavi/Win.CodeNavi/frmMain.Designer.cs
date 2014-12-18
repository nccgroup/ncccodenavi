/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/ncccodenavi

Released under AGPL see LICENSE for more information
*/

namespace Win.CodeNavi
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolTop = new System.Windows.Forms.ToolStrip();
            this.lblPath = new System.Windows.Forms.ToolStripLabel();
            this.txtCodePath = new System.Windows.Forms.ToolStripComboBox();
            this.cmdCodePath = new System.Windows.Forms.ToolStripButton();
            this.cmdCodeBrowser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSearchTerm = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripComboBox();
            this.lblSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblExts = new System.Windows.Forms.ToolStripLabel();
            this.txtExt = new System.Windows.Forms.ToolStripComboBox();
            this.cmdRemember = new System.Windows.Forms.ToolStripButton();
            this.cmdForget = new System.Windows.Forms.ToolStripButton();
            this.cmdReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOpts = new System.Windows.Forms.ToolStripDropDownButton();
            this.opRegexSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.opCaseSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdshowNotesPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.optIgnoreTest = new System.Windows.Forms.ToolStripMenuItem();
            this.optIgnoreComments = new System.Windows.Forms.ToolStripMenuItem();
            this.optAutoSaveNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdMaxSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdGrepifyScan = new System.Windows.Forms.ToolStripButton();
            this.optGrepify = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolWindows = new System.Windows.Forms.ToolStripDropDownButton();
            this.cmdWinTile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdWinCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.tabNotes = new System.Windows.Forms.TabControl();
            this.tabNotesPage = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripNotesTab = new System.Windows.Forms.ToolStrip();
            this.cmdNotesTabSave = new System.Windows.Forms.ToolStripButton();
            this.cmdSaveNotes = new System.Windows.Forms.ToolStripButton();
            this.cmdDateStamp = new System.Windows.Forms.ToolStripButton();
            this.cmdErase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdWordWrap = new System.Windows.Forms.ToolStripButton();
            this.cmdFormatText = new System.Windows.Forms.ToolStripButton();
            this.cmdFontColour = new System.Windows.Forms.ToolStripButton();
            this.richNotes = new System.Windows.Forms.RichTextBox();
            this.ctxRichNotes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabNCCNews = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.richNCCNews = new System.Windows.Forms.RichTextBox();
            this.tabExclusions = new System.Windows.Forms.TabPage();
            this.toolExcl = new System.Windows.Forms.ToolStrip();
            this.cmdExlSave = new System.Windows.Forms.ToolStripButton();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblExRegexCompile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIntro = new System.Windows.Forms.Label();
            this.richExclusions = new System.Windows.Forms.RichTextBox();
            this.tabForms = new System.Windows.Forms.TabControl();
            this.ctxTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerSave = new System.Windows.Forms.Timer(this.components);
            this.toolTop.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.tabNotesPage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripNotesTab.SuspendLayout();
            this.ctxRichNotes.SuspendLayout();
            this.tabNCCNews.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabExclusions.SuspendLayout();
            this.toolExcl.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.ctxTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTop
            // 
            this.toolTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPath,
            this.txtCodePath,
            this.cmdCodePath,
            this.cmdCodeBrowser,
            this.toolStripSeparator5,
            this.lblSearchTerm,
            this.txtSearch,
            this.lblSearch,
            this.toolStripSeparator4,
            this.lblExts,
            this.txtExt,
            this.cmdRemember,
            this.cmdForget,
            this.cmdReset,
            this.toolStripSeparator3,
            this.toolStripOpts,
            this.toolStripSeparator2,
            this.cmdGrepifyScan,
            this.optGrepify,
            this.toolStripSeparator6,
            this.toolWindows});
            this.toolTop.Location = new System.Drawing.Point(0, 0);
            this.toolTop.Name = "toolTop";
            this.toolTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolTop.Size = new System.Drawing.Size(1729, 39);
            this.toolTop.TabIndex = 0;
            this.toolTop.TabStop = true;
            this.toolTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolTop_KeyPress);
            // 
            // lblPath
            // 
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(77, 36);
            this.lblPath.Text = "Code Path";
            // 
            // txtCodePath
            // 
            this.txtCodePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCodePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtCodePath.AutoToolTip = true;
            this.txtCodePath.Name = "txtCodePath";
            this.txtCodePath.Size = new System.Drawing.Size(332, 39);
            this.txtCodePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodePath_KeyPress);
            this.txtCodePath.TextChanged += new System.EventHandler(this.txtCodePath_TextChanged);
            // 
            // cmdCodePath
            // 
            this.cmdCodePath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCodePath.Image = ((System.Drawing.Image)(resources.GetObject("cmdCodePath.Image")));
            this.cmdCodePath.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdCodePath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCodePath.Name = "cmdCodePath";
            this.cmdCodePath.Size = new System.Drawing.Size(36, 36);
            this.cmdCodePath.Text = "Browser for code";
            this.cmdCodePath.ToolTipText = "Browse for code";
            this.cmdCodePath.Click += new System.EventHandler(this.cmdCodePath_Click);
            // 
            // cmdCodeBrowser
            // 
            this.cmdCodeBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCodeBrowser.Image = ((System.Drawing.Image)(resources.GetObject("cmdCodeBrowser.Image")));
            this.cmdCodeBrowser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdCodeBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCodeBrowser.Name = "cmdCodeBrowser";
            this.cmdCodeBrowser.Size = new System.Drawing.Size(36, 36);
            this.cmdCodeBrowser.Text = "Browse files at this location";
            this.cmdCodeBrowser.Click += new System.EventHandler(this.cmdCodeBrowser_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // lblSearchTerm
            // 
            this.lblSearchTerm.Name = "lblSearchTerm";
            this.lblSearchTerm.Size = new System.Drawing.Size(53, 36);
            this.lblSearchTerm.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(332, 39);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblSearch.Image = ((System.Drawing.Image)(resources.GetObject("lblSearch.Image")));
            this.lblSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(36, 36);
            this.lblSearch.Text = "Search";
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // lblExts
            // 
            this.lblExts.Name = "lblExts";
            this.lblExts.Size = new System.Drawing.Size(78, 36);
            this.lblExts.Text = "Extensions";
            // 
            // txtExt
            // 
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(265, 39);
            this.txtExt.TextChanged += new System.EventHandler(this.txtExt_TextChanged);
            // 
            // cmdRemember
            // 
            this.cmdRemember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdRemember.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemember.Image")));
            this.cmdRemember.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdRemember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRemember.Name = "cmdRemember";
            this.cmdRemember.Size = new System.Drawing.Size(36, 36);
            this.cmdRemember.Text = "Remember this extension set";
            this.cmdRemember.Click += new System.EventHandler(this.cmdRemember_Click);
            // 
            // cmdForget
            // 
            this.cmdForget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdForget.Image = ((System.Drawing.Image)(resources.GetObject("cmdForget.Image")));
            this.cmdForget.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdForget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdForget.Name = "cmdForget";
            this.cmdForget.Size = new System.Drawing.Size(36, 36);
            this.cmdForget.Text = "Forget this extension set";
            this.cmdForget.Click += new System.EventHandler(this.cmdForget_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdReset.Image = ((System.Drawing.Image)(resources.GetObject("cmdReset.Image")));
            this.cmdReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(36, 36);
            this.cmdReset.Text = "Reset extension sets to default";
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripOpts
            // 
            this.toolStripOpts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripOpts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opRegexSearch,
            this.opCaseSearch,
            this.cmdshowNotesPanel,
            this.optIgnoreTest,
            this.optIgnoreComments,
            this.optAutoSaveNotes,
            this.cmdMaxSearch});
            this.toolStripOpts.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpts.Image")));
            this.toolStripOpts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripOpts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpts.Name = "toolStripOpts";
            this.toolStripOpts.Size = new System.Drawing.Size(45, 36);
            this.toolStripOpts.Text = "Options";
            // 
            // opRegexSearch
            // 
            this.opRegexSearch.Checked = true;
            this.opRegexSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opRegexSearch.Name = "opRegexSearch";
            this.opRegexSearch.Size = new System.Drawing.Size(245, 24);
            this.opRegexSearch.Text = "&Regex Search";
            this.opRegexSearch.CheckedChanged += new System.EventHandler(this.opRegexSearch_CheckedChanged);
            this.opRegexSearch.Click += new System.EventHandler(this.opRegexSearch_Click);
            // 
            // opCaseSearch
            // 
            this.opCaseSearch.Checked = true;
            this.opCaseSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opCaseSearch.Name = "opCaseSearch";
            this.opCaseSearch.Size = new System.Drawing.Size(245, 24);
            this.opCaseSearch.Text = "&Case Sensitive Search";
            this.opCaseSearch.Click += new System.EventHandler(this.opCaseSearch_Click);
            // 
            // cmdshowNotesPanel
            // 
            this.cmdshowNotesPanel.Checked = true;
            this.cmdshowNotesPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmdshowNotesPanel.Name = "cmdshowNotesPanel";
            this.cmdshowNotesPanel.Size = new System.Drawing.Size(245, 24);
            this.cmdshowNotesPanel.Text = "&Show Notes Panel";
            this.cmdshowNotesPanel.Click += new System.EventHandler(this.cmdshowNotesPanel_Click);
            // 
            // optIgnoreTest
            // 
            this.optIgnoreTest.Checked = true;
            this.optIgnoreTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optIgnoreTest.Name = "optIgnoreTest";
            this.optIgnoreTest.Size = new System.Drawing.Size(245, 24);
            this.optIgnoreTest.Text = "&Ignore Test Files and Dirs";
            this.optIgnoreTest.Click += new System.EventHandler(this.optIgnoreTest_Click);
            // 
            // optIgnoreComments
            // 
            this.optIgnoreComments.Name = "optIgnoreComments";
            this.optIgnoreComments.Size = new System.Drawing.Size(245, 24);
            this.optIgnoreComments.Text = "Ignore &Hits in Comments";
            this.optIgnoreComments.Click += new System.EventHandler(this.optIgnoreComments_Click);
            // 
            // optAutoSaveNotes
            // 
            this.optAutoSaveNotes.Name = "optAutoSaveNotes";
            this.optAutoSaveNotes.Size = new System.Drawing.Size(245, 24);
            this.optAutoSaveNotes.Text = "&Auto Save Notes (5 Mins)";
            this.optAutoSaveNotes.Click += new System.EventHandler(this.optAutoSaveNotes_Click);
            // 
            // cmdMaxSearch
            // 
            this.cmdMaxSearch.Name = "cmdMaxSearch";
            this.cmdMaxSearch.Size = new System.Drawing.Size(245, 24);
            this.cmdMaxSearch.Text = "&Maximum Search Results";
            this.cmdMaxSearch.Click += new System.EventHandler(this.cmdMaxSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // cmdGrepifyScan
            // 
            this.cmdGrepifyScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdGrepifyScan.Image = ((System.Drawing.Image)(resources.GetObject("cmdGrepifyScan.Image")));
            this.cmdGrepifyScan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdGrepifyScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdGrepifyScan.Name = "cmdGrepifyScan";
            this.cmdGrepifyScan.Size = new System.Drawing.Size(36, 36);
            this.cmdGrepifyScan.Text = "Grepify scan with selected profiles";
            this.cmdGrepifyScan.Click += new System.EventHandler(this.cmdGrepifyScan_Click);
            // 
            // optGrepify
            // 
            this.optGrepify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optGrepify.Image = ((System.Drawing.Image)(resources.GetObject("optGrepify.Image")));
            this.optGrepify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optGrepify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optGrepify.Name = "optGrepify";
            this.optGrepify.Size = new System.Drawing.Size(45, 36);
            this.optGrepify.Text = "Grepify profiles to use";
            this.optGrepify.ToolTipText = "Grepify profiles to use";
            this.optGrepify.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.optGrepify_DropDownItemClicked);
            this.optGrepify.Click += new System.EventHandler(this.optGrepify_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolWindows
            // 
            this.toolWindows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdWinTile,
            this.cmdWinCascade});
            this.toolWindows.Image = ((System.Drawing.Image)(resources.GetObject("toolWindows.Image")));
            this.toolWindows.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolWindows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWindows.Name = "toolWindows";
            this.toolWindows.Size = new System.Drawing.Size(45, 36);
            this.toolWindows.Text = "Windows";
            // 
            // cmdWinTile
            // 
            this.cmdWinTile.Name = "cmdWinTile";
            this.cmdWinTile.Size = new System.Drawing.Size(133, 24);
            this.cmdWinTile.Text = "&Tile";
            this.cmdWinTile.ToolTipText = "Tile windows";
            this.cmdWinTile.Click += new System.EventHandler(this.cmdWinTile_Click);
            // 
            // cmdWinCascade
            // 
            this.cmdWinCascade.Name = "cmdWinCascade";
            this.cmdWinCascade.Size = new System.Drawing.Size(133, 24);
            this.cmdWinCascade.Text = "&Cascade";
            this.cmdWinCascade.ToolTipText = "Cascade windows";
            this.cmdWinCascade.Click += new System.EventHandler(this.cmdWinCascade_Click);
            // 
            // tabNotes
            // 
            this.tabNotes.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabNotes.Controls.Add(this.tabNotesPage);
            this.tabNotes.Controls.Add(this.tabNCCNews);
            this.tabNotes.Controls.Add(this.tabExclusions);
            this.tabNotes.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabNotes.Location = new System.Drawing.Point(1150, 39);
            this.tabNotes.Margin = new System.Windows.Forms.Padding(4);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.SelectedIndex = 0;
            this.tabNotes.Size = new System.Drawing.Size(579, 645);
            this.tabNotes.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabNotes.TabIndex = 3;
            // 
            // tabNotesPage
            // 
            this.tabNotesPage.Controls.Add(this.statusStrip1);
            this.tabNotesPage.Controls.Add(this.toolStripNotesTab);
            this.tabNotesPage.Controls.Add(this.richNotes);
            this.tabNotesPage.Location = new System.Drawing.Point(4, 28);
            this.tabNotesPage.Margin = new System.Windows.Forms.Padding(4);
            this.tabNotesPage.Name = "tabNotesPage";
            this.tabNotesPage.Padding = new System.Windows.Forms.Padding(4);
            this.tabNotesPage.Size = new System.Drawing.Size(571, 613);
            this.tabNotesPage.TabIndex = 0;
            this.tabNotesPage.Text = "Notes";
            this.tabNotesPage.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(4, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(563, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(196, 20);
            this.toolStripStatusLabel1.Text = "Welcome to NCC Code Navi";
            // 
            // toolStripNotesTab
            // 
            this.toolStripNotesTab.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripNotesTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdNotesTabSave,
            this.cmdSaveNotes,
            this.cmdDateStamp,
            this.cmdErase,
            this.toolStripSeparator1,
            this.cmdWordWrap,
            this.cmdFormatText,
            this.cmdFontColour});
            this.toolStripNotesTab.Location = new System.Drawing.Point(4, 4);
            this.toolStripNotesTab.Name = "toolStripNotesTab";
            this.toolStripNotesTab.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripNotesTab.Size = new System.Drawing.Size(563, 39);
            this.toolStripNotesTab.TabIndex = 1;
            this.toolStripNotesTab.Text = "toolStrip1";
            // 
            // cmdNotesTabSave
            // 
            this.cmdNotesTabSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdNotesTabSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdNotesTabSave.Image")));
            this.cmdNotesTabSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdNotesTabSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNotesTabSave.Name = "cmdNotesTabSave";
            this.cmdNotesTabSave.Size = new System.Drawing.Size(36, 36);
            this.cmdNotesTabSave.Text = "Saves notes";
            this.cmdNotesTabSave.Click += new System.EventHandler(this.cmdNotesTabSave_Click);
            // 
            // cmdSaveNotes
            // 
            this.cmdSaveNotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSaveNotes.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveNotes.Image")));
            this.cmdSaveNotes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSaveNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSaveNotes.Name = "cmdSaveNotes";
            this.cmdSaveNotes.Size = new System.Drawing.Size(36, 36);
            this.cmdSaveNotes.Text = "Export notes";
            this.cmdSaveNotes.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // cmdDateStamp
            // 
            this.cmdDateStamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdDateStamp.Image = ((System.Drawing.Image)(resources.GetObject("cmdDateStamp.Image")));
            this.cmdDateStamp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdDateStamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDateStamp.Name = "cmdDateStamp";
            this.cmdDateStamp.Size = new System.Drawing.Size(36, 36);
            this.cmdDateStamp.Text = "Insert date and time stamp";
            this.cmdDateStamp.Click += new System.EventHandler(this.cmdDateStamp_Click);
            // 
            // cmdErase
            // 
            this.cmdErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdErase.Image = ((System.Drawing.Image)(resources.GetObject("cmdErase.Image")));
            this.cmdErase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdErase.Name = "cmdErase";
            this.cmdErase.Size = new System.Drawing.Size(36, 36);
            this.cmdErase.Text = "Erase notes and start fresh";
            this.cmdErase.Click += new System.EventHandler(this.cmdErase_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // cmdWordWrap
            // 
            this.cmdWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdWordWrap.Image = ((System.Drawing.Image)(resources.GetObject("cmdWordWrap.Image")));
            this.cmdWordWrap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdWordWrap.Name = "cmdWordWrap";
            this.cmdWordWrap.Size = new System.Drawing.Size(36, 36);
            this.cmdWordWrap.Text = "Word wrap";
            this.cmdWordWrap.Click += new System.EventHandler(this.cmdWordWrap_Click);
            // 
            // cmdFormatText
            // 
            this.cmdFormatText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdFormatText.Image = ((System.Drawing.Image)(resources.GetObject("cmdFormatText.Image")));
            this.cmdFormatText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdFormatText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFormatText.Name = "cmdFormatText";
            this.cmdFormatText.Size = new System.Drawing.Size(36, 36);
            this.cmdFormatText.Text = "Change font size";
            this.cmdFormatText.Click += new System.EventHandler(this.cmdFormatText_Click);
            // 
            // cmdFontColour
            // 
            this.cmdFontColour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdFontColour.Image = ((System.Drawing.Image)(resources.GetObject("cmdFontColour.Image")));
            this.cmdFontColour.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdFontColour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFontColour.Name = "cmdFontColour";
            this.cmdFontColour.Size = new System.Drawing.Size(36, 36);
            this.cmdFontColour.Text = "Change font colour";
            this.cmdFontColour.Click += new System.EventHandler(this.cmdFontColour_Click);
            // 
            // richNotes
            // 
            this.richNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richNotes.ContextMenuStrip = this.ctxRichNotes;
            this.richNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richNotes.Location = new System.Drawing.Point(5, 55);
            this.richNotes.Margin = new System.Windows.Forms.Padding(4);
            this.richNotes.Name = "richNotes";
            this.richNotes.Size = new System.Drawing.Size(553, 449);
            this.richNotes.TabIndex = 0;
            this.richNotes.Text = "";
            this.richNotes.WordWrap = false;
            this.richNotes.SelectionChanged += new System.EventHandler(this.richNotes_SelectionChanged);
            this.richNotes.TextChanged += new System.EventHandler(this.richNotes_TextChanged);
            // 
            // ctxRichNotes
            // 
            this.ctxRichNotes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.ctxRichNotes.Name = "ctxRichNotes";
            this.ctxRichNotes.Size = new System.Drawing.Size(142, 52);
            this.ctxRichNotes.Opening += new System.ComponentModel.CancelEventHandler(this.ctxRichNotes_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.openFileToolStripMenuItem.Text = "&Open File";
            this.openFileToolStripMenuItem.Visible = false;
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // tabNCCNews
            // 
            this.tabNCCNews.Controls.Add(this.groupBox1);
            this.tabNCCNews.Location = new System.Drawing.Point(4, 28);
            this.tabNCCNews.Margin = new System.Windows.Forms.Padding(4);
            this.tabNCCNews.Name = "tabNCCNews";
            this.tabNCCNews.Size = new System.Drawing.Size(571, 613);
            this.tabNCCNews.TabIndex = 1;
            this.tabNCCNews.Text = "NCC Tweets";
            this.tabNCCNews.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.Controls.Add(this.richNCCNews);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(553, 606);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twiiter (@NCCGroupInfosec)";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(9, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(520, 574);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("https://twitter.com/nccgroupinfosec", System.UriKind.Absolute);
            // 
            // richNCCNews
            // 
            this.richNCCNews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richNCCNews.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richNCCNews.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richNCCNews.Location = new System.Drawing.Point(9, 25);
            this.richNCCNews.Margin = new System.Windows.Forms.Padding(4);
            this.richNCCNews.Name = "richNCCNews";
            this.richNCCNews.ReadOnly = true;
            this.richNCCNews.Size = new System.Drawing.Size(520, 579);
            this.richNCCNews.TabIndex = 0;
            this.richNCCNews.Text = "Loading...";
            this.richNCCNews.Visible = false;
            this.richNCCNews.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richNCCNews_LinkClicked);
            this.richNCCNews.TextChanged += new System.EventHandler(this.richNCCNews_TextChanged);
            // 
            // tabExclusions
            // 
            this.tabExclusions.Controls.Add(this.toolExcl);
            this.tabExclusions.Controls.Add(this.statusStrip2);
            this.tabExclusions.Controls.Add(this.lblIntro);
            this.tabExclusions.Controls.Add(this.richExclusions);
            this.tabExclusions.Location = new System.Drawing.Point(4, 28);
            this.tabExclusions.Margin = new System.Windows.Forms.Padding(4);
            this.tabExclusions.Name = "tabExclusions";
            this.tabExclusions.Size = new System.Drawing.Size(571, 613);
            this.tabExclusions.TabIndex = 2;
            this.tabExclusions.Text = "Search Exclusions";
            this.tabExclusions.UseVisualStyleBackColor = true;
            // 
            // toolExcl
            // 
            this.toolExcl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolExcl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdExlSave});
            this.toolExcl.Location = new System.Drawing.Point(0, 0);
            this.toolExcl.Name = "toolExcl";
            this.toolExcl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolExcl.Size = new System.Drawing.Size(571, 39);
            this.toolExcl.TabIndex = 4;
            this.toolExcl.Text = "toolStrip1";
            // 
            // cmdExlSave
            // 
            this.cmdExlSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdExlSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdExlSave.Image")));
            this.cmdExlSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdExlSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExlSave.Name = "cmdExlSave";
            this.cmdExlSave.Size = new System.Drawing.Size(36, 36);
            this.cmdExlSave.Text = "Save Exclusions";
            this.cmdExlSave.Click += new System.EventHandler(this.cmdExlSave_Click);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblExRegexCompile});
            this.statusStrip2.Location = new System.Drawing.Point(0, 588);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip2.Size = new System.Drawing.Size(571, 25);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lblExRegexCompile
            // 
            this.lblExRegexCompile.Name = "lblExRegexCompile";
            this.lblExRegexCompile.Size = new System.Drawing.Size(29, 20);
            this.lblExRegexCompile.Text = "OK";
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(4, 68);
            this.lblIntro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(466, 17);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "Each line should be a regular expression for paths or filenames to ignore";
            // 
            // richExclusions
            // 
            this.richExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richExclusions.Location = new System.Drawing.Point(5, 87);
            this.richExclusions.Margin = new System.Windows.Forms.Padding(4);
            this.richExclusions.Name = "richExclusions";
            this.richExclusions.Size = new System.Drawing.Size(557, 411);
            this.richExclusions.TabIndex = 0;
            this.richExclusions.Text = "";
            this.richExclusions.TextChanged += new System.EventHandler(this.richExclusions_TextChanged);
            // 
            // tabForms
            // 
            this.tabForms.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.Location = new System.Drawing.Point(0, 39);
            this.tabForms.Margin = new System.Windows.Forms.Padding(4);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.ShowToolTips = true;
            this.tabForms.Size = new System.Drawing.Size(1150, 32);
            this.tabForms.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabForms.TabIndex = 5;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
            this.tabForms.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabForms_Selecting);
            this.tabForms.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabForms_Selected);
            this.tabForms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseDown);
            // 
            // ctxTab
            // 
            this.ctxTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.ctxTab.Name = "ctxTab";
            this.ctxTab.Size = new System.Drawing.Size(115, 28);
            this.ctxTab.Opening += new System.ComponentModel.CancelEventHandler(this.ctxTab_Opening);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // timerSave
            // 
            this.timerSave.Enabled = true;
            this.timerSave.Interval = 3000000;
            this.timerSave.Tick += new System.EventHandler(this.timerSave_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1729, 684);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.tabNotes);
            this.Controls.Add(this.toolTop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCC Code Navi -";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.toolTop.ResumeLayout(false);
            this.toolTop.PerformLayout();
            this.tabNotes.ResumeLayout(false);
            this.tabNotesPage.ResumeLayout(false);
            this.tabNotesPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripNotesTab.ResumeLayout(false);
            this.toolStripNotesTab.PerformLayout();
            this.ctxRichNotes.ResumeLayout(false);
            this.tabNCCNews.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabExclusions.ResumeLayout(false);
            this.tabExclusions.PerformLayout();
            this.toolExcl.ResumeLayout(false);
            this.toolExcl.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ctxTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolTop;
        private System.Windows.Forms.ToolStripLabel lblPath;
        private System.Windows.Forms.ToolStripButton cmdCodePath;
        private System.Windows.Forms.ToolStripButton lblSearch;
        private System.Windows.Forms.ToolStripComboBox txtCodePath;
        private System.Windows.Forms.ToolStripComboBox txtSearch;
        private System.Windows.Forms.ToolStripDropDownButton toolStripOpts;
        private System.Windows.Forms.ToolStripMenuItem opRegexSearch;
        private System.Windows.Forms.ToolStripMenuItem opCaseSearch;
        private System.Windows.Forms.ToolStripLabel lblSearchTerm;
        private System.Windows.Forms.ToolStripLabel lblExts;
        private System.Windows.Forms.ToolStripComboBox txtExt;
        private System.Windows.Forms.ToolStripButton cmdRemember;
        private System.Windows.Forms.ToolStripButton cmdForget;
        private System.Windows.Forms.ToolStripButton cmdReset;
        private System.Windows.Forms.TabPage tabNotesPage;
        private System.Windows.Forms.RichTextBox richNotes;
        private System.Windows.Forms.ToolStrip toolStripNotesTab;
        private System.Windows.Forms.ToolStripButton cmdNotesTabSave;
        private System.Windows.Forms.ToolStripButton cmdSaveNotes;
        private System.Windows.Forms.ToolStripMenuItem cmdshowNotesPanel;
        private System.Windows.Forms.ToolStripButton cmdDateStamp;
        private System.Windows.Forms.ToolStripButton cmdErase;
        private System.Windows.Forms.ContextMenuStrip ctxRichNotes;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cmdCodeBrowser;
        private System.Windows.Forms.ToolStripMenuItem optIgnoreTest;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optIgnoreComments;
        private System.Windows.Forms.ToolStripButton cmdWordWrap;
        private System.Windows.Forms.ToolStripButton cmdFormatText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdFontColour;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cmdGrepifyScan;
        private System.Windows.Forms.ToolStripDropDownButton optGrepify;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripDropDownButton toolWindows;
        private System.Windows.Forms.ToolStripMenuItem optAutoSaveNotes;
        private System.Windows.Forms.Timer timerSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.TabControl tabNotes;
        private System.Windows.Forms.ToolStripMenuItem cmdWinTile;
        private System.Windows.Forms.ToolStripMenuItem cmdWinCascade;
        private System.Windows.Forms.TabPage tabNCCNews;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richNCCNews;
        private System.Windows.Forms.TabPage tabExclusions;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lblExRegexCompile;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.ToolStrip toolExcl;
        private System.Windows.Forms.ToolStripButton cmdExlSave;
        private System.Windows.Forms.RichTextBox richExclusions;
        private System.Windows.Forms.ToolStripMenuItem cmdMaxSearch;
        private System.Windows.Forms.ContextMenuStrip ctxTab;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

