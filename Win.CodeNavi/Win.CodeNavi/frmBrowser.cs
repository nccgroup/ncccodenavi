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
using ScintillaNET;

namespace Win.CodeNavi
{
   
    public partial class frmBrowser : Form
    {

        static ImageList _imageList;
        frmMain frmMaster = null;
        private string strCurrFile = null;

        public static ImageList ImageList
        {
            get
            {
                if (_imageList == null)
                {
                    _imageList = new ImageList();
                    _imageList.Images.Add("folder", Properties.Resources.folder);
                    _imageList.Images.Add("ascii", Properties.Resources.ascii);
                    _imageList.Images.Add("binary", Properties.Resources.binary);
                }
                return _imageList;
            }
        }

        public frmBrowser(string strPath, string strExts, frmMain frmMaster)
        {
            InitializeComponent();
            this.frmMaster = frmMaster;
            treeFiles.ImageList = frmBrowser.ImageList;
            TreeNode rootNode = new TreeNode();
            rootNode.Text = strPath;
            rootNode.Expand();

            treeFiles.Nodes.Add(rootNode);
            EnumerateFiles(strPath, strExts, rootNode);
        }

        private void richText_TextChanged(object sender, EventArgs e)
        {
            if (strCurrFile == null || File.Exists(strCurrFile) == false) return;
            if (this.scintilla.Text.Length < 10240)
            {
                try
                {
                    //frmMaster.scmMine.MakeUpRichText(this.richText, Path.GetExtension(strCurrFile).Substring(1), this.lineNumbersForRichText);
                }
                catch (Exception)
                {

                }
            }
        }

        private const int LINE_NUMBERS_MARGIN_WIDTH = 35; // TODO Don't hardcode this

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            // Pretty...
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            this.scintilla.UndoRedo.EmptyUndoBuffer();
            //this.scintilla.Modified = false;
            this.scintilla.IsReadOnly = true;
            this.scintilla.Modified = false;
            this.scintilla.Margins.Margin0.Width = LINE_NUMBERS_MARGIN_WIDTH;
            this.Select();
        }

        /// <summary>
        /// Enumerate the files in a given path
        /// </summary>
        /// <param name="strPath"></param>
        private void EnumerateFiles(string strPath, string strExts, TreeNode treeNode)
        {
            try
            {

                foreach (string strFile in Directory.GetFiles(strPath, strExts))
                {
                    TreeNode treeNodeFile = new TreeNode();
                    treeNodeFile.Text = Path.GetFileName(strFile);

                    treeNodeFile.ImageKey = "ascii";
                    treeNodeFile.SelectedImageKey = "ascii";
                    treeNode.Nodes.Add(treeNodeFile);
                }

                foreach (string strDir in Directory.GetDirectories(strPath))
                {
                    TreeNode treeNodeChild = new TreeNode();
                    DirectoryInfo dirInfo = new DirectoryInfo(strDir);
                    treeNodeChild.Text = dirInfo.Name;
                    treeNodeChild.ImageKey = "folder";
                    treeNodeChild.SelectedImageKey = "folder";
                    treeNode.Nodes.Add(treeNodeChild);
                    EnumerateFiles(strDir, strExts, treeNodeChild);
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                return;
            }
            catch (System.Exception)
            {
                return;
            }

            return;
        }

        private void splitMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeFiles_Click(object sender, EventArgs e)
        {

        }

        private void treeFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            StringBuilder sbTemp = new StringBuilder();

            sbTemp.Append(treeFiles.SelectedNode.Text);
            TreeNode treeNodeTmp = treeFiles.SelectedNode;

            while(true){
                if (treeNodeTmp.Parent == null) break;
                treeNodeTmp = treeNodeTmp.Parent;
                sbTemp.Insert(0, treeNodeTmp.Text + "\\");
            }
            this.scintilla.IsReadOnly = false;

            if (File.Exists(sbTemp.ToString()) == true)
            {
                byte[] fileBytes = null;

                try
                {
                    strCurrFile = sbTemp.ToString() ;
                    fileBytes = File.ReadAllBytes(sbTemp.ToString());
                }
                catch (Exception)
                {

                }

                Encoding encodingForFile = null;

                if (IsTextTester.IsText(out encodingForFile,sbTemp.ToString(),100) == true && fileBytes != null)
                {
                    this.scintilla.Text = File.ReadAllText(sbTemp.ToString(), encodingForFile);
                    try
                    {
                        this.scintilla.ConfigurationManager.Language = Path.GetExtension(sbTemp.ToString()).Substring(1);
                        if (Path.GetExtension(sbTemp.ToString()).Substring(1).ToLower().Equals("c"))
                        {
                            this.scintilla.ConfigurationManager.Language = "cpp";
                            this.scintilla.Indentation.SmartIndentType = SmartIndent.CPP;
                        }
                        if (Path.GetExtension(sbTemp.ToString()).Substring(1).ToLower().Equals("py")) this.scintilla.ConfigurationManager.Language = "python";
                        if (Path.GetExtension(sbTemp.ToString()).Substring(1).ToLower().Equals("rb")) this.scintilla.ConfigurationManager.Language = "ruby";
                        //if (Path.GetExtension(sbTemp.ToString()).Substring(1).ToLower().Equals("php")) this.scintilla.ConfigurationManager.Language = "xml";
                        //this.scintilla.ConfigurationManager.CustomLocation = 
                    }
                    catch (Exception)
                    {

                    }
                }
                else if (IsTextTester.IsText(out encodingForFile, sbTemp.ToString(), 100) == false && fileBytes != null)
                {
                    this.scintilla.Text = sbTemp.ToString() + " is binary and can't be displayed";
                }
                else if (fileBytes == null)
                {
                    this.scintilla.Text = sbTemp.ToString() + " could not be opened";
                }
            }
            else if(Directory.Exists(sbTemp.ToString()))
            {
                this.scintilla.Text = sbTemp.ToString() + " is a directory";
            }
            else 
            {
                this.scintilla.Text = sbTemp.ToString() + " is unknown";
            }
            this.scintilla.IsReadOnly = true;
        }

        // http://stackoverflow.com/questions/840899/how-can-i-programmatically-click-a-treeview-treenode-so-it-appears-highlighted-i
        // recursively move through the treeview nodes
        private bool FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().Equals(txtSearch.Text.ToLower()))
                {
                    if (treeFiles.SelectedNode.Equals(tn) == false)
                    {
                        treeFiles.SelectedNode = tn;
                        treeFiles.Select();
                        return true;
                    }
                    else
                    {

                    }
                } 

                if (FindRecursive(tn) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            foreach (TreeNode treeNode in treeFiles.Nodes)
            {
                if (FindRecursive(treeNode) == true)
                {
                    return;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)System.Windows.Forms.Keys.Enter)
            {
                cmdFind_Click(null, null);
                e.Handled = true;
            }
        }

        private void ctxFile_Opening(object sender, CancelEventArgs e)
        {
            StringBuilder sbTemp = new StringBuilder();

            sbTemp.Append(treeFiles.SelectedNode.Text);
            TreeNode treeNodeTmp = treeFiles.SelectedNode;

            while (true)
            {
                if (treeNodeTmp.Parent == null) break;
                treeNodeTmp = treeNodeTmp.Parent;
                sbTemp.Insert(0, treeNodeTmp.Text + "\\");
            }

            if (File.Exists(sbTemp.ToString()) == false)
            {
                ctxFile.Close();
            }
            
        }

        private void cmdOpeninCodeView_Click(object sender, EventArgs e)
        {
            StringBuilder sbTemp = new StringBuilder();

            if (treeFiles.SelectedNode == null) return;

            sbTemp.Append(treeFiles.SelectedNode.Text);
            TreeNode treeNodeTmp = treeFiles.SelectedNode;

            while (true)
            {
                if (treeNodeTmp.Parent == null) break;
                treeNodeTmp = treeNodeTmp.Parent;
                sbTemp.Insert(0, treeNodeTmp.Text + "\\");
            }

            if (File.Exists(sbTemp.ToString()) == true)
            {
                byte[] fileBytes = null;

                try
                {
                    fileBytes = File.ReadAllBytes(sbTemp.ToString());
                }
                catch (Exception)
                {

                }

                Encoding encodingForFile = null;

                if (IsTextTester.IsText(out encodingForFile, sbTemp.ToString(), 1000) == true && fileBytes != null)
                {
                    // Now initalize a search form
                    frmCodeViewNew frmSearch = new frmCodeViewNew(sbTemp.ToString(), 0 , frmMaster);
                    frmSearch.MdiParent = this.MdiParent;
                    frmSearch.Visible = true;
                }
                else if (IsTextTester.IsText(out encodingForFile, sbTemp.ToString(), 100) == false && fileBytes != null)
                {
                    this.scintilla.Text = sbTemp.ToString() + " is binary and can't be displayed";
                }
                else if (fileBytes == null)
                {
                    this.scintilla.Text = sbTemp.ToString() + " could not be opened";
                }
            }
            
        }

        private void frmBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                if (MessageBox.Show("Are you sure you wish to close this file browser?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Visible = false;
                    this.Close();
                }
            }
            else if (e.Control && e.KeyCode.ToString().Equals("W"))
            {
                if (MessageBox.Show("Are you sure you wish to close this file browser??", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Visible = false;
                    this.Close();
                }
            }
        }

        private void treeFiles_DoubleClick(object sender, EventArgs e)
        {
            cmdOpeninCodeView_Click(null, null);
        }

        private void treeFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)System.Windows.Forms.Keys.Enter)
            {
                cmdOpeninCodeView_Click(null, null);
                e.Handled = true;
            }
        }

        private void cmdShowInExplorer_Click(object sender, EventArgs e)
        {
            StringBuilder sbTemp = new StringBuilder();

            if (treeFiles.SelectedNode == null) return;

            sbTemp.Append(treeFiles.SelectedNode.Text);
            TreeNode treeNodeTmp = treeFiles.SelectedNode;

            while (true)
            {
                if (treeNodeTmp.Parent == null) break;
                treeNodeTmp = treeNodeTmp.Parent;
                sbTemp.Insert(0, treeNodeTmp.Text + "\\");
            }

            ShowSelectedInExplorer.FileOrFolder(sbTemp.ToString(), false);
            
        }

        private void cmdSendFilenameAndPathToNotes_Click(object sender, EventArgs e)
        {
            StringBuilder sbTemp = new StringBuilder();

            if (treeFiles.SelectedNode == null) return;

            sbTemp.Append(treeFiles.SelectedNode.Text);
            TreeNode treeNodeTmp = treeFiles.SelectedNode;

            while (true)
            {
                if (treeNodeTmp.Parent == null) break;
                treeNodeTmp = treeNodeTmp.Parent;
                sbTemp.Insert(0, treeNodeTmp.Text + "\\");
            }

            frmMaster.SendToNotes(sbTemp.ToString());
        }

    }
}
