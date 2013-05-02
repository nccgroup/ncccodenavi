/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/ncccodenavi

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using ScintillaNET;
using System.Collections;

namespace Win.CodeNavi
{
    public partial class frmMain : Form
    {
        private bool bNotesPending = false;
        private string[] profileLines = null;
        public SourceCodeMarkUp scmMine = new SourceCodeMarkUp(AssemblyDirectory);
        private Thread workerThreadV = null;
        private Thread workerThread = null;
        private TabPage PreviousTab;
        private bool bClosingTab = false;

        static public string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            if (Directory.Exists(AssemblyDirectory + "\\Grepify.Profiles"))
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = AssemblyDirectory + "\\Grepify.Profiles";
                /* Watch for changes in LastAccess and LastWrite times, and
                   the renaming of files.*/
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName;
                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(WatcherUpdateGrepifyProfiles);
                watcher.Created += new FileSystemEventHandler(WatcherUpdateGrepifyProfiles);
                watcher.Deleted += new FileSystemEventHandler(WatcherUpdateGrepifyProfiles);
                watcher.Renamed += new RenamedEventHandler(WatcherRenameUpdateGrepifyProfiles);

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            
            }
        }

        /// <summary>
        /// Key handler for the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString().Equals("F"))
            {
                DoSearch();
                e.SuppressKeyPress = true; // this stops the annoying ding
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode.ToString().Equals("S"))
            {
                DoSearch();
                e.SuppressKeyPress = true; // this stops the annoying ding
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode.Equals(System.Windows.Forms.Keys.Space))
            {
                /*
                if (this.MdiChildren.Count() == 0)
                {
                    e.SuppressKeyPress = true; // this stops the annoying ding
                    e.Handled = true;
                    return;
                }

                int intCurrent = 0;
                int intCount = 0;

                foreach (Form frmTest in this.MdiChildren)
                {
                    if (frmTest.Text.Equals(this.ActiveMdiChild.Text))
                    {
                        intCurrent = intCount;
                        break;
                    }
                    intCount++;
                }

                int intTotal = this.MdiChildren.Count();
                if (intCurrent == intTotal-1)
                {
                    this.SuspendLayout();
                    this.MdiChildren[0].BringToFront();
                    this.ResumeLayout();
                }
                else
                {
                    this.SuspendLayout();
                    this.MdiChildren[intCurrent + 1].BringToFront();
                    this.ResumeLayout();
                }

                e.SuppressKeyPress = true; // this stops the annoying ding
                e.Handled = true;
                 */
                MessageBox.Show("Use Ctrl-Tab instead", "Depreciated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Load handler for the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Pretty...
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            // So our key handler will see them
            KeyPreview = true;
            
            // Setup a handler for the exit
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            // Correct version
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string strVersion = fvi.FileVersion;
            this.Text = "NCC Group Code Navi - " + strVersion;


            // Load the previously search code paths and search terms
            // This saves the paths so they are persistent over runs
            if (Properties.Settings.Default.CodeFolders != null && Properties.Settings.Default.CodeFolders.Count > 0)
            {
                StringCollection strCodePathCollection = new StringCollection();
                foreach (String strPath in Properties.Settings.Default.CodeFolders)
                {
                    txtCodePath.Items.Add(strPath);
                }
            }
            if (Properties.Settings.Default.SearchStrings != null && Properties.Settings.Default.SearchStrings.Count > 0)
            {
                StringCollection strSearchStringCollection = new StringCollection();
                foreach (String strSearchString in Properties.Settings.Default.SearchStrings)
                {
                    txtSearch.Items.Add(strSearchString);
                }
            }
            
            if (Properties.Settings.Default.CaseSensitive == true) opCaseSearch.Checked = true;
            else opCaseSearch.Checked = false;
            if (Properties.Settings.Default.Regex == true) opRegexSearch.Checked = true;
            else opRegexSearch.Checked = false;
            if (Properties.Settings.Default.IgnoreTest == true) optIgnoreTest.Checked = true;
            else optIgnoreTest.Checked = false;
            if (Properties.Settings.Default.IgnoreComments == true) optIgnoreComments.Checked = true;
            else optIgnoreComments.Checked = false;
            if (Properties.Settings.Default.NotesWordWrap == true)
            {
                cmdWordWrap.Checked = true;
                richNotes.WordWrap = true;
            }
            else
            {
                cmdWordWrap.Checked = false;
                richNotes.WordWrap = false;
            }
            if (Properties.Settings.Default.AutoSaveNotes == true)
            {
                optAutoSaveNotes.Checked = true;
                timerSave.Start();
            }
            else
            {
                timerSave.Stop();
            }

            if (Properties.Settings.Default.ExtensionSets != null && Properties.Settings.Default.ExtensionSets.Count > 0)
            {
                foreach (String strExt in Properties.Settings.Default.ExtensionSets)
                {
                    txtExt.Items.Add(strExt);
                }
            }
            else
            {
                doExtensionReset();
            }
            if (Properties.Settings.Default.Extensions != null) {
                if (Properties.Settings.Default.Extensions.Count() == 0)
                {
                    txtExt.Text = "*.*";
                }
                else
                {
                    txtExt.Text = Properties.Settings.Default.Extensions;

                }
            }
            else txtExt.Text = "*.*";

            if (Properties.Settings.Default.CodeFolders != null && Properties.Settings.Default.CodeFolders.Count > 0)
            {
                txtCodePath.Text = txtCodePath.Items[0].ToString();
                frmBrowser frmBStart = null;

                if (Directory.Exists(txtCodePath.Text))
                {
                    frmBStart = new frmBrowser(txtCodePath.Text, "*.*", this);
                    frmBStart.MdiParent = this;

                    //initialBrowser = new Thread(new ThreadStart(frmBStart.Show));
                    //initialBrowser.Start();
                    frmBStart.Show();
                }
                else
                {
                    //frmBStart = new frmBrowser("C:\\","*.*",this);
                }
            }

            if (Properties.Settings.Default.SearchStrings != null && Properties.Settings.Default.SearchStrings.Count > 0) txtSearch.Text = txtSearch.Items[0].ToString();

            if (Properties.Settings.Default.ShowNotesPanel == true)
            {
                tabNotes.Visible = true;
                cmdshowNotesPanel.Checked = true;
            }
            else
            {
                tabNotes.Visible = false;
                cmdshowNotesPanel.Checked = false;
            }

            if (Properties.Settings.Default.NotesFont != null) richNotes.SelectionFont = Properties.Settings.Default.NotesFont;
            try
            {
                if (Properties.Settings.Default.NotesColour != null)
                {
                    richNotes.SelectionColor = Properties.Settings.Default.NotesColour;
                }
                   
            }
            catch (Exception)
            {

            }

            try
            {
                richNotes.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NCCCodeNavi.rtf");
                bNotesPending = false;
            }
            catch (Exception)
            {
                bNotesPending = false;
            }

            
            if(Directory.Exists(AssemblyDirectory + "\\Grepify.Profiles")){
                foreach(string strFile in Directory.GetFiles(AssemblyDirectory + "\\Grepify.Profiles")){
                    optGrepify.DropDownItems.Add(Path.GetFileNameWithoutExtension(strFile));
                }
            } else {
                optGrepify.DropDownItems.Add("Profile directory does not exist - " + AssemblyDirectory + "\\Grepify.Profiles");
            }


            if (File.Exists(AssemblyDirectory + "\\NCCCodeNavi.Exclusions\\NCCCodeNavi.exclusions"))
            {
                richExclusions.LoadFile(AssemblyDirectory + "\\NCCCodeNavi.Exclusions\\NCCCodeNavi.exclusions");
            }

            Twitter twTemp = new Twitter();
            twTemp.SetRT(this.richNCCNews,this.tabNCCNews);
            workerThread = new Thread(new ThreadStart(twTemp.Get));

            VersionCheck vCheck = new VersionCheck();
            workerThreadV = new Thread(new ThreadStart(vCheck.Get));

            // Start the worker thread.
            workerThread.Start();
            workerThreadV.Start();
            
        }

        /// <summary>
        /// Regex menu option click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opRegexSearch_Click(object sender, EventArgs e)
        {
            if (opRegexSearch.Checked == false)
            {
                opRegexSearch.Checked = true;
                Properties.Settings.Default.Regex = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                opRegexSearch.Checked = false;
                Properties.Settings.Default.Regex = false;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Case insensitive meny option click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opCaseSearch_Click(object sender, EventArgs e)
        {
            if (opCaseSearch.Checked == false)
            {
                opCaseSearch.Checked = true;
                Properties.Settings.Default.CaseSensitive = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                opCaseSearch.Checked = false;
                Properties.Settings.Default.CaseSensitive = false;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Folder icon in toolbar click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCodePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdCodePath = new FolderBrowserDialog(); 
            fbdCodePath.Description = "Select folder which contains the source code";

            if (fbdCodePath.ShowDialog() == DialogResult.OK)
            {
                txtCodePath.Text = fbdCodePath.SelectedPath;
            }
        }

        /// <summary>
        /// Code path combo text box changing event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodePath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtCodePath.Text))
            {
                txtCodePath.ForeColor = Color.Green;
            }
            else
            {
                txtCodePath.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Search icon in toolbar click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        /// <summary>
        /// Main search entry point
        /// </summary>
        private void DoSearch()
        {
            // Error checking
            if (Directory.Exists(txtCodePath.Text) == false) // does the directory exist?
            {
                MessageBox.Show("You need to specify a valid path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else  if (txtSearch.Text.Length == 0) // if the search term > 0
            {
                MessageBox.Show("You need to specify a valid search term", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            string[] strExts = txtExt.Text.Split (';'); // is the defined extensions list the correct format?
            foreach (string strExt in strExts)
            {
                if (strExt.StartsWith("*.") == false)
                {
                    MessageBox.Show(txtExt.Text + " is not in the correct format\nPlease use *.ext1;*.ext2\n", "Incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // So we first the new path and search term to the history
            // we then prune the oldist
            txtCodePath.Items.Insert(0,txtCodePath.Text);
            if (txtCodePath.Items.Count > 20)
            {
                while (txtCodePath.Items.Count > 20)
                {
                    txtCodePath.Items.RemoveAt(20);
                }
            }
            txtSearch.Items.Insert(0,txtSearch.Text);
            if (txtSearch.Items.Count > 20)
            {
                while (txtSearch.Items.Count > 20)
                {
                    txtSearch.Items.RemoveAt(20);
                }
            }

            // This saves the paths so they are persistent over runs
            StringCollection strCodePathCollection = new StringCollection();
            foreach (String strPath in txtCodePath.Items)
            {
                strCodePathCollection.Add(strPath);
            }
            Properties.Settings.Default.CodeFolders = strCodePathCollection;

            // This saves the search strings so they are persistent over runs
            StringCollection strSearchStringCollection = new StringCollection();
            foreach (String strSearchString in txtSearch.Items)
            {
                strSearchStringCollection.Add(strSearchString);
            }
            Properties.Settings.Default.SearchStrings = strSearchStringCollection;
            Properties.Settings.Default.Extensions = txtExt.Text;

            Properties.Settings.Default.Save();

            // ISSUE 1: https://github.com/nccgroup/ncccodenavi/issues/1
            // Prompt the user to automatically escape
            string strSearchText = null;
            if (opRegexSearch.Checked == true)
            {

                //if (MessageBox.Show("You have regex search enabled. Do you want me to escape your search term automatically to result in a literal search?", "Regex escape?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                    //if (opRegexSearch.Checked == true)
                    //{
                        strSearchText = Regex.Escape(txtSearch.Text);
                    //}
                //}
                //else
                //{
                    strSearchText = txtSearch.Text;
                //}
            }
            else
            {
                strSearchText = txtSearch.Text;
            }

            // Now initalize a search form
            frmSearch frmSearch = new frmSearch(strSearchText + " in " + txtCodePath.Text + " (Regex:"+opRegexSearch.Checked+",Case:"+opCaseSearch.Checked+",Ignore Test:" + optIgnoreTest.Checked+",Ignore Comments:"+ optIgnoreComments.Checked+") - " + txtExt.Text, this);
            frmSearch.MdiParent = this;
            frmSearch.Visible = true;

            // Now initialize the object and start a scan
            Scanner scanYoink = new Scanner(frmSearch, txtCodePath.Text, strSearchText, optIgnoreComments.Checked, opRegexSearch.Checked, opCaseSearch.Checked, optIgnoreTest.Checked, txtExt.Text, richExclusions.Lines);
            frmSearch.SetScanEngine(scanYoink);
            scanYoink.Start(this, frmSearch);
        }

        /// <summary>
        /// This is called by the frmCodeView class to initiate a search
        /// from outside
        /// </summary>
        /// <param name="strText"></param>
        public void DoSearchFromCode(string strText){
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { DoSearchFromCode(strText); }));
            }
            else
            {
                txtSearch.Text = strText;
                DoSearch();
            }
        }


        private void UpdateNotesStatus(string strText)
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.Invoke(new MethodInvoker(() => { UpdateNotesStatus(strText); }));
            }
            else
            {
                toolStripStatusLabel1.Text = strText;
            }
        }
        /// <summary>
        /// This catches someone pressing enter to start a search in the search text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)System.Windows.Forms.Keys.Enter)
            {
                DoSearch();
                e.Handled = true;
            }

        }

        /// <summary>
        /// This catches the escape to exist the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)System.Windows.Forms.Keys.Escape)
            {
                if (this.MdiChildren.Count() == 0)
                {
                    if (MessageBox.Show("Are you sure you wish to exit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                        e.Handled = true;
                    }
                }   
            }
        }

        private void toolTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)System.Windows.Forms.Keys.Escape)
            {
                if (MessageBox.Show("Are you sure you wish to exit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                    e.Handled = true;
                }
            }
        }

        private void txtCodePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)System.Windows.Forms.Keys.Escape)
            {
                if (MessageBox.Show("Are you sure you wish to exit?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                    e.Handled = true;
                }
            }
        }

        private void opRegexSearch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to reset the extensions list?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                doExtensionReset();
            }
        }

        private void doExtensionReset()
        {
            // http://msdn.microsoft.com/en-us/library/8k0zafxb(v=vs.71).aspx
            // http://msdn.microsoft.com/en-us/library/3awe4781.aspx
            // Populate the extensions combo box
            txtExt.Items.Clear();
            txtExt.Items.Add("*.*"); // Everything
            txtExt.Items.Add("*.cpp;*.hpp;*.c;*.h;*.a;*.asm;*.mm;*.m"); // Generic native
            txtExt.Items.Add("*.php;*.java;*.py;*.rb"); // Generic non native / web
            txtExt.Items.Add("*.aspx;*.cs;*.asax;*.config;*.xml;*.js;*.ascx;*.asmx;*.ashx;*.axd;*.browser;*.csproj;*.cshtml;*.htm;*.html;*.resx;*.vb;*.master;*.sitemap;*.skin;*.asp;*.xsp;*.htc;*.hta");
            txtExt.Items.Add("*.xml;*.java;*.cpp;*.hpp;*.c;*.c"); // Android
            txtExt.Items.Add("*.m;*.mm;*.h;*.plist;*.pch;*.strings"); // iOS
            txtExt.SelectedIndex = 0;

            SaveExtensions();
            
        }

        void SaveExtensions()
        {
            // Save it
            if (Properties.Settings.Default.ExtensionSets != null) Properties.Settings.Default.ExtensionSets.Clear();
            StringCollection strExtSet = new StringCollection();
            foreach (String strExt in txtExt.Items)
            {
                strExtSet.Add(strExt);
            }
            Properties.Settings.Default.ExtensionSets = strExtSet;
            Properties.Settings.Default.Save();
        }
        private void txtExt_TextChanged(object sender, EventArgs e)
        {
            if (txtExt.Items.Contains(txtExt.Text))
            {
                cmdRemember.Enabled = false;
                cmdForget.Enabled = true;
            }
            else
            {
                cmdRemember.Enabled = true;
                cmdForget.Enabled = false;
            }
        }

        private void cmdshowNotesPanel_Click(object sender, EventArgs e)
        {
            if (cmdshowNotesPanel.Checked == false)
            {
                tabNotes.Visible = true;
                cmdshowNotesPanel.Checked = true;
                Properties.Settings.Default.ShowNotesPanel = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                tabNotes.Visible = false;
                cmdshowNotesPanel.Checked = false;
                Properties.Settings.Default.ShowNotesPanel= false;
                Properties.Settings.Default.Save();
            }
        }


        public void SendToNotes(String strNote)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { SendToNotes(strNote); }));
            }
            else
            {
                String strNoteFinal = DateTime.Now + Environment.NewLine + "----------------------------------------------" + Environment.NewLine + Environment.NewLine + strNote + Environment.NewLine + Environment.NewLine;

                richNotes.Text = strNoteFinal + richNotes.Text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDateStamp_Click(object sender, EventArgs e)
        {
            String strNoteFinal = DateTime.Now + Environment.NewLine + "----------------------------------------------" + Environment.NewLine + Environment.NewLine;
            richNotes.Text = strNoteFinal + richNotes.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdErase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to erase all your notes, including those saved?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                richNotes.Clear();
                try
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NCCCodeNavi.rtf");
                    UpdateNotesStatus("Deleted " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NCCCodeNavi.rtf");
                    richNotes.Clear();
                    bNotesPending = false;
                }
                catch (Exception)
                {
                    UpdateNotesStatus("Error deleting file");
                }
            }
        }

        private void cmdNotesTabSave_Click(object sender, EventArgs e)
        {
            if (richNotes.InvokeRequired)
            {
                richNotes.Invoke(new MethodInvoker(() => { cmdNotesTabSave_Click(sender,e); }));
            }
            else
            {
                try
                {
                    if (bNotesPending == true)
                    {
                        richNotes.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NCCCodeNavi.rtf");
                        UpdateNotesStatus("Saved to " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NCCCodeNavi.rtf at " + DateTime.Now);
                        bNotesPending = false;
                    }
                    else
                    {
                        UpdateNotesStatus("No changes to save");
                    }
                }
                catch (Exception)
                {
                    UpdateNotesStatus("Error saving file");
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fdExport = new SaveFileDialog();
            fdExport.AddExtension = true;
            fdExport.CheckPathExists = true;
            fdExport.Filter = "Code Navi Notes (*.rtf)|*.rtf";
            fdExport.DefaultExt = "rtf";
            fdExport.OverwritePrompt = true;
            fdExport.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fdExport.Title = "Choose where to export your notes to";
            if(fdExport.ShowDialog() == DialogResult.OK){
                try
                {
                    richNotes.SaveFile(fdExport.FileName);
                    UpdateNotesStatus("Exported to " + fdExport.FileName + " at " + DateTime.Now);
                    bNotesPending = false;
                }
                catch (Exception)
                {
                    UpdateNotesStatus("Error saving file");
                }
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richNotes.SelectedText.Length > 0)
            {
                System.Windows.Forms.Clipboard.SetText(richNotes.SelectedText);
                UpdateNotesStatus("Copied to clipboard");
            }
            else if(richNotes.Text != null)
            {
                if (MessageBox.Show("No text selected do you want to copy everything to the clipboard?", "Copy everything?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        System.Windows.Forms.Clipboard.SetText(richNotes.Text);
                        UpdateNotesStatus("Copied to clipboard");
                    }
                    catch (Exception)
                    {
                        UpdateNotesStatus("Failed to copy to clipboard");
                    }

                }
            }
        }


        /// <summary>
        /// Flag we have pending changes that need saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richNotes_TextChanged(object sender, EventArgs e)
        {
            bNotesPending = true;
            if (optAutoSaveNotes.Enabled == true) timerSave.Start();
        }


        /// <summary>
        /// Handle the application exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
                     

        }

        /// <summary>
        /// Handle the form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // When the application is exiting, write the application data to the 
            // user file and close it.

            if (this.MdiChildren.Count() > 0)
            {
                if (MessageBox.Show("You have open windows, are you sure you wish to exit?", "Do you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    try
                    {
                        e.Cancel = true;       
                    }
                    catch (Exception)
                    {

                    }
                }
            } 
            
            if (bNotesPending == true)
            {
                if (MessageBox.Show("There are unsaved changes to your notes would you like to save them now?", "Do you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        richNotes.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NCCCodeNavi.rtf");
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            if(workerThread.IsAlive){
                workerThread.Abort();
            }
            if (workerThreadV.IsAlive)
            {
                workerThreadV.Abort();
            }
        }

        private void cmdRemember_Click(object sender, EventArgs e)
        {
            string[] strExts = txtExt.Text.Split(';'); // is the defined extensions list the correct format?
            foreach (string strExt in strExts)
            {
                if (strExt.StartsWith("*.") == false)
                {
                    MessageBox.Show(txtExt.Text + " is not in the correct format\nPlease use *.ext1;*.ext2\n", "Incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            txtExt.Items.Insert(0, txtExt.Text);

            Properties.Settings.Default.Extensions = txtExt.Text;
            Properties.Settings.Default.Save();

            SaveExtensions();
        }

        private void cmdForget_Click(object sender, EventArgs e)
        {
            if (txtExt.SelectedIndex == -1) return;
            txtExt.Items.RemoveAt(txtExt.SelectedIndex);
            SaveExtensions();
        }

        private void cmdCodeBrowser_Click(object sender, EventArgs e)
        {
            frmBrowser frmB = new frmBrowser(txtCodePath.Text, "*.*",this);
            frmB.MdiParent = this;
            frmB.Visible = true;
        }

        private void optIgnoreTest_Click(object sender, EventArgs e)
        {
            if(optIgnoreTest.Checked == false)
            {
                optIgnoreTest.Checked = true;
                Properties.Settings.Default.IgnoreTest = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                optIgnoreTest.Checked = false;
                Properties.Settings.Default.IgnoreTest = false;
                Properties.Settings.Default.Save();
            }
        }

        private void ctxRichNotes_Opening(object sender, CancelEventArgs e)
        {

            if(richNotes.SelectedText.Count() > 4){

                if (richNotes.SelectedText.Trim().Substring(3, richNotes.SelectedText.Trim().Count() - 3).Contains(':') == true)
                {
                    string[] strBits = richNotes.SelectedText.Trim().Split(':');

                    if (strBits.Count() == 3)
                    {
                        try
                        {
                            int.Parse(strBits[2]); // check it is not over selected

                            if (File.Exists(strBits[0] + ":" + strBits[1]))
                            {
                                openFileToolStripMenuItem.Visible = true;
                            }
                        }
                        catch (Exception)
                        {
                            // Shrink the selection down to just the filename
                            richNotes.SelectionStart = richNotes.SelectionStart;
                            richNotes.SelectionLength = strBits[0].Length + 1 + strBits[1].Length;
                            openFileToolStripMenuItem.Visible = true;
                        }
                        
                    }
                }
                else if (File.Exists(richNotes.SelectedText) == true)
                {
                    openFileToolStripMenuItem.Visible = true;
                }
               
            }
        }

        /// <summary>
        /// Opens a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string strFile = null;
            int intLine = 0;

            if (richNotes.SelectedText.Count() > 0)
            {
                if (richNotes.SelectedText.Trim().Substring(3, richNotes.SelectedText.Trim().Count() - 3).Contains(':') == true)
                {
                    string[] strBits = richNotes.SelectedText.Trim().Split(':');

                    if (strBits.Count() == 3 && strBits[2].Count() > 0)
                    {
                        if (File.Exists(strBits[0] + ":" + strBits[1]))
                        {
                            strFile = strBits[0] + ":" + strBits[1];
                            intLine = Convert.ToInt32(strBits[2]);
                        }
                        else
                        {
                            UpdateNotesStatus("File not found " + richNotes);
                        }
                    }
                }
                else if (File.Exists(richNotes.SelectedText) == true)
                {
                    strFile = richNotes.SelectedText;
                }
                else
                {
                    UpdateNotesStatus("File not found " + richNotes);
                }
            }

            frmCodeViewNew frmSearch = new frmCodeViewNew(strFile, intLine, this);
            frmSearch.MdiParent = this;
            frmSearch.Visible = true;
        }

        private void optIgnoreComments_Click(object sender, EventArgs e)
        {

            if (optIgnoreComments.Checked == false)
            {
                optIgnoreComments.Checked = true;
                Properties.Settings.Default.IgnoreComments = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                optIgnoreComments.Checked = false;
                Properties.Settings.Default.IgnoreComments = false;
                Properties.Settings.Default.Save();
            }
        }

        private void cmdWordWrap_Click(object sender, EventArgs e)
        {
            if (cmdWordWrap.Checked == true)
            {
                cmdWordWrap.Checked = false;
                richNotes.WordWrap = false;
                Properties.Settings.Default.NotesWordWrap = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                cmdWordWrap.Checked = true;
                richNotes.WordWrap = true;
                Properties.Settings.Default.NotesWordWrap = true;
                Properties.Settings.Default.Save();
            }
        }

        private void cmdFormatText_Click(object sender, EventArgs e)
        {
            FontDialog fntDiag = new FontDialog();

            fntDiag.Font = richNotes.SelectionFont;

            if (fntDiag.ShowDialog() == DialogResult.OK)
            {
                richNotes.SelectionFont = fntDiag.Font;
                Properties.Settings.Default.NotesFont = fntDiag.Font;
                Properties.Settings.Default.Save();
            }

        }

        private void cmdFontColour_Click(object sender, EventArgs e)
        {
            ColorDialog clrDiag = new ColorDialog();

            clrDiag.Color = richNotes.SelectionColor;

            if (clrDiag.ShowDialog() == DialogResult.OK)
            {
                richNotes.SelectionColor = clrDiag.Color;
                //richNotes.ForeColor = clrDiag.Color;

                Properties.Settings.Default.NotesColour = clrDiag.Color;
                Properties.Settings.Default.Save();
            }
        }

        private void optGrepify_Click(object sender, EventArgs e)
        {
            if (optGrepify.DropDown.AutoClose == false) optGrepify.DropDown.AutoClose = true;
        }

        private void optGrepify_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            
            
            foreach(ToolStripMenuItem tsiTarget in optGrepify.DropDownItems){
                if (tsiTarget.Text.Equals(e.ClickedItem.Text))
                {
                    if (tsiTarget.CheckState == CheckState.Checked)
                    {
                        tsiTarget.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        tsiTarget.CheckState = CheckState.Checked;
                    }
                }
            }

            optGrepify.DropDown.Show();
        }

        private void cmdGrepifyScan_Click(object sender, EventArgs e)
        {
            // Error checking
            if (Directory.Exists(txtCodePath.Text) == false) // does the directory exist?
            {
                MessageBox.Show("You need to specify a valid path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            string[] strExts = txtExt.Text.Split(';'); // is the defined extensions list the correct format?
            foreach (string strExt in strExts)
            {
                if (strExt.StartsWith("*.") == false)
                {
                    MessageBox.Show(txtExt.Text + " is not in the correct format\nPlease use *.ext1;*.ext2\n", "Incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            profileLines = null; // reset
            int intProfileCount=0;

            foreach (ToolStripMenuItem tsiTarget in optGrepify.DropDownItems)
            {
                string[] strNewLines = null;
                bool bError = false;
                List<string> strRegexs = new List<string>();

                if (tsiTarget.CheckState == CheckState.Checked)
                {
                    intProfileCount++;

                    string strFilename = AssemblyDirectory + "\\Grepify.Profiles\\" + tsiTarget.Text + ".txt";

                    // Load the file
                    if (!File.Exists(strFilename))
                    {
                        MessageBox.Show("File " + strFilename + " does not exist. Aborting scan!", "File does not exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        try
                        {
                            strNewLines = File.ReadAllLines(strFilename);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("File " + strFilename + " could not be read. Aborting scan!", "Could not read file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    // Sanity check the regex
                    int intCount = 0;
                    foreach (string strRegex in strNewLines)
                    {

                        intCount++;

                        if (strRegex.StartsWith("#")) continue;

                        try
                        {
                            Match regexMatch = Regex.Match("Mooo", strRegex);
                            strRegexs.Add(strRegex);
                        }
                        catch (ArgumentException rExcp)
                        {
                            MessageBox.Show("Regex looks broken on line " + intCount + ". Regex is '" + strRegex + "'. Error is '" + rExcp.Message + "' in file " + strFilename + ".", "Regex error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            profileLines = null;
                            bError = true;
                            break;
                        }
                    }

                    if (profileLines == null && bError == false)
                    {
                        profileLines = strRegexs.ToArray();
                    }
                    else if (bError == false)
                    {
                        profileLines = profileLines.Concat(strRegexs).ToArray();
                    }
                }
            }


            if (intProfileCount == 0 || profileLines == null)
            {
                if (intProfileCount == 0)
                {
                    MessageBox.Show("No Grepify profiles selected for scan. Aborting scan!", "No Grepify profiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("No Grepify regexes in selected files. Aborting scan!", "No Grepify regexes in selected files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }

            // Now do the scan

            // Now initalize a search (aka results) form
            frmSearch frmSearch = new frmSearch("Grepify scan of " + txtCodePath.Text + " (Regex:True,Case:" + opCaseSearch.Checked + ",Ignore Test:" + optIgnoreTest.Checked + ",Ignore Comments:"+ optIgnoreComments.Checked+") - " + txtExt.Text, this);
            frmSearch.AddRegexColumn(); // Adds the extra column
            frmSearch.MdiParent = this;
            frmSearch.Visible = true;

            // Now initialize the object and start a scan
            Scanner scanYoink = new Scanner(frmSearch, txtCodePath.Text, profileLines, optIgnoreComments.Checked, true, opCaseSearch.Checked, optIgnoreTest.Checked, txtExt.Text,richExclusions.Lines);
            frmSearch.SetScanEngine(scanYoink);
            scanYoink.Start(this, frmSearch);

        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            
        }

        // http://www.codeproject.com/Articles/17640/Tabbed-MDI-Child-Forms
        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            //this.SuspendLayout();
            //DrawingControl.SuspendUpdate.Suspend(this);
      
            // First set the previous TabPage
            PreviousTab = tabForms.SelectedTab;
            // If child form is new and no has tabPage, 
            // create new tabPage 
            if (this.MdiChildren.Count() > 0)
            {
                if (this.ActiveMdiChild != null && this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 
                    // form caption 
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.ToolTipText = this.ActiveMdiChild.Text;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;
                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                    //this.ActiveMdiChild.SizeChanged += new EventHandler(ActiveMdiChild_SizeChanged);   
                }
                else
                {
                    //tabForms.TabPages.Clear();
                }
            }
            else
            {
                tabForms.TabPages.Clear();
            }
            //this.ResumeLayout();
            //DrawingControl.SuspendUpdate.Resume(this);
            if (this.ActiveMdiChild != null ) this.ActiveMdiChild.Refresh();
            else tabForms.TabPages.Clear();
            //SourceCodeMarkUp.SendMessage(this.Handle, SourceCodeMarkUp.WM_NCPAINT, 0, IntPtr.Zero);
            tabForms.Update();


        }

        private void ActiveMdiChild_FormClosed(object sender,
                                    FormClosedEventArgs e)
        {
            if (PreviousTab != null)
            {
                try
                {
                    bClosingTab = true;
                    tabForms.SelectTab(PreviousTab);
                }
                catch (Exception) // if the previous tab isn't valid
                {

                }
                finally
                {
                    tabForms.Update();
                    bClosingTab = false;
                }
            }
            ActivateMdiChild(null);
            ((sender as Form).Tag as TabPage).Parent = null;
            ((sender as Form).Tag as TabPage).Dispose();
   
        }

        private void ActiveMdiChild_SizeChanged(object sender, EventArgs e)
        {
         
        }


        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Selected " + tabForms.SelectedIndex);

            if ((tabForms.SelectedTab != null) && (tabForms.SelectedTab.Tag != null))
            {
                (tabForms.SelectedTab.Tag as Form).Select();
                //(tabForms.SelectedTab.Tag as Form).Refresh();
            }
            
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void tabForms_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //e.TabPage
            //Console.WriteLine("Selecting " + e.TabPageIndex + " - " + (e.TabPage.Parent as TabControl).SelectedIndex);
            //this.SuspendLayout();
            //DrawingControl.SuspendUpdate.Suspend(this);
        }

        private void tabForms_Selected(object sender, TabControlEventArgs e)
        {
            //DrawingControl.SuspendUpdate.Resume(this);
            //fthis.ResumeLayout();
        }

        private void tabForms_Deselected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null && !bClosingTab) // null probably means a tab was closed
            {
                PreviousTab = e.TabPage;
            }
        }

        private void optAutoSaveNotes_Click(object sender, EventArgs e)
        {
            if (optAutoSaveNotes.Checked == true)
            {
                optAutoSaveNotes.Checked = false;
                timerSave.Stop();
                Properties.Settings.Default.AutoSaveNotes= false;
                Properties.Settings.Default.Save();
            }
            else
            {
                optAutoSaveNotes.Checked = true;
                timerSave.Start();
                Properties.Settings.Default.AutoSaveNotes = true;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSave_Tick(object sender, EventArgs e)
        {

            cmdNotesTabSave_Click(null, null);
            timerSave.Stop();
        }

        private void cmdWinTile_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);

            
        }

        private void cmdWinCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void cmdIgnoreComments_Click(object sender, EventArgs e)
        {

        }

        private void richNCCNews_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string strTarget = e.LinkText;

            try
            {
                System.Diagnostics.Process.Start(strTarget);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259) MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void richExclusions_TextChanged(object sender, EventArgs e)
        {
            int intCount = 0;
            foreach (string strLine in richExclusions.Lines)
            {
                intCount++;
                try
                {
                    Match regexMatch = Regex.Match("Mooo", strLine);
                    lblExRegexCompile.Text = "Regex compiled OK";
                }
                catch (ArgumentException)
                {
                    lblExRegexCompile.Text = "Regex compiliation failed on line " + intCount;
                }
            }
            
            
        }

        private void cmdExlSave_Click(object sender, EventArgs e)
        {
            try
            {
                richExclusions.SaveFile(AssemblyDirectory + "\\NCCCodeNavi.Exclusions\\NCCCodeNavi.exclusions");
                lblExRegexCompile.Text = "Exclusions saved";
            }
            catch (Exception)
            {
                lblExRegexCompile.Text = "Failed to sve exclusions";
            }
        }

        

        private void cmdExperiment_Click(object sender, EventArgs e)
        {
            frmCodeView frmFoo = new frmCodeView();
            frmCodeViewNew docForm = new frmCodeViewNew("C:\\Data\\NCC\\!Code\\Git.Public\\ncccodenavi\\Win.CodeNavi\\Win.CodeNavi\\Scanner.cs", 0, this);
            docForm.MdiParent = this;
            docForm.Show();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void cmdMaxSearch_Click(object sender, EventArgs e)
        {
            frmSearchLimit frmSL = new frmSearchLimit();
            frmSL.MdiParent = this;
            frmSL.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            (tabForms.SelectedTab.Tag as Form).Dispose();
            try
            {
                tabForms.SelectedTab.Dispose();
            }
            catch (Exception)
            {

            }
            tabForms.Invalidate();
        }

        private void UpdateGrepifyProfiles()
        {
            optGrepify.DropDownItems.Clear();
            if (Directory.Exists(AssemblyDirectory + "\\Grepify.Profiles"))
            {
                foreach (string strFile in Directory.GetFiles(AssemblyDirectory + "\\Grepify.Profiles"))
                {
                    optGrepify.DropDownItems.Add(Path.GetFileNameWithoutExtension(strFile));
                }
            }
            else
            {
                optGrepify.DropDownItems.Add("Profile directory does not exist - " + AssemblyDirectory + "\\Grepify.Profiles");
            }
        }
        private void WatcherUpdateGrepifyProfiles(object e, FileSystemEventArgs a)
        {
            UpdateGrepifyProfiles();
        }
        private void WatcherRenameUpdateGrepifyProfiles(object e, RenamedEventArgs a)
        {
            UpdateGrepifyProfiles();
        }
    }
}
