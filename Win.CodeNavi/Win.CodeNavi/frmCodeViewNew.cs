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
using System.Text.RegularExpressions;
using System.Threading;
using ScintillaNET;

namespace Win.CodeNavi
{
    public partial class frmCodeViewNew : Form
    {
        private string strFilePath = null;
        private int intLine = 0;
        private frmMain frmMaster = null;
        private bool _iniLexer;
        private string _filePath;

        public bool IniLexer
        {
            get { return _iniLexer; }
            set { _iniLexer = value; }
        }

        private void AddOrRemoveAsteric()
        {
            if (scintilla.Modified)
            {
                if (!Text.EndsWith(" *"))
                    Text += " *";
            }
            else
            {
                if (Text.EndsWith(" *"))
                    Text = Text.Substring(0, Text.Length - 2);
            }
        }

        private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            Console.WriteLine("Style");
            // Style the _text
            if (_iniLexer)
                Win.CodeNavi.IniLexer.StyleNeeded((Scintilla)sender, e.Range);
        }

        public Scintilla Scintilla
        {
            get
            {
                return scintilla;
            }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        // 
        // http://social.msdn.microsoft.com/forums/en-US/csharpgeneral/thread/5bbac0e3-437e-495e-9680-b8349ec5f428
        //
        private void Goto(Scintilla myRichTextBox, Int32 lineToGo)
        {

            Int32 intLine = 0;
            Int32 intNineLinesPast = 0;
            Int32 intTwoLinesPast = 0;
            String text = myRichTextBox.Text;

            if (lineToGo > myRichTextBox.Lines.Count) lineToGo = myRichTextBox.Lines.Count;

            for (Int32 i = 1; i < lineToGo; i++)
            {
                intLine = text.IndexOf('\n', intLine + 1);
                if (intLine == -1) break;
            }

            for (Int32 i = 1; i < lineToGo + 9; i++)
            {
                intNineLinesPast = text.IndexOf('\n', intNineLinesPast + 1);
                if (intNineLinesPast == -1) break;
            }

            for (Int32 i = 1; i < lineToGo + 2; i++)
            {
                intTwoLinesPast = text.IndexOf('\n', intTwoLinesPast + 1);
                if (intTwoLinesPast == -1) break;
            }

            try
            {

                //myRichTextBox.GoTo.Position(intLine;
                if (lineToGo > 1 && intNineLinesPast != -1)
                {
                    //myRichTextBox.GoTo.Position(intLine);
                    myRichTextBox.GoTo.Position(intNineLinesPast);
                    //myRichTextBox.Markers.AddInstanceSet(intLine, 0);
                    myRichTextBox.Lines[lineToGo-1].AddMarker(99);
                    //.myRichTextBox.
                    //myRichTextBox.Select(intNineLinesPast + 1, 0);
                    //myRichTextBox.Select(intLine + 1, text.IndexOf('\n', intLine + 1) - (intLine + 1));
                }
                else if (lineToGo > 1 && intTwoLinesPast != -1)
                {
                    //myRichTextBox.Select(intTwoLinesPast + 1, 0);
                    myRichTextBox.GoTo.Position(intTwoLinesPast);
                    myRichTextBox.Lines[lineToGo-1].AddMarker(99);
                    //myRichTextBox.Select(intLine + 1, text.IndexOf('\n', intLine + 1) - (intLine + 1));
                }
                else if (lineToGo > 1 && intLine != -1)
                {
                    //myRichTextBox.Select(intLine + 1, text.IndexOf('\n', intLine + 1) - (intLine + 1));
                    myRichTextBox.GoTo.Position(intLine);
                    myRichTextBox.Lines[lineToGo-1].AddMarker(99);
                }
                else
                {
                    //myRichTextBox.Select(intLine, 0);
                    myRichTextBox.GoTo.Position(intLine);
                    //myRichTextBox.Lines[lineToGo-1].AddMarker(99);
                }
            }
            catch (Exception)
            {

            }

        }


        public frmCodeViewNew()
        {
            InitializeComponent(); 
        }

        public frmCodeViewNew(String strFile,int intLine, frmMain frmMaster)
        {
            InitializeComponent();
            this.Text = "Code View - " + strFile;
            strFilePath = strFile;
            this.intLine = intLine;
            this.frmMaster = frmMaster;
            
        }

        private void frmCodeViewNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                if (MessageBox.Show("Are you sure you wish to close this file?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Visible = false;
                    this.Close();
                }
            }
            else if (e.Control && e.KeyCode.ToString().Equals("W"))
            {
                if (MessageBox.Show("Are you sure you wish to close this file?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //this.Visible = false;
                    this.Close();
                }
            }
        }

        private const int LINE_NUMBERS_MARGIN_WIDTH = 35; // TODO Don't hardcode this

        private void frmCodeViewNew_Load(object sender, EventArgs e)
        {
            if (File.Exists(strFilePath) == false)
            {
                MessageBox.Show("File not found " + strFilePath, "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            this.Scintilla.Text = File.ReadAllText(strFilePath);

            try
            {
                this.Scintilla.ConfigurationManager.Language = Path.GetExtension(strFilePath).Substring(1);
                if (Path.GetExtension(strFilePath).Substring(1).ToLower().Equals("cs")) this.Scintilla.Indentation.SmartIndentType = SmartIndent.CPP;
            }
            catch (Exception)
            {

            }

            this.IniLexer = false;
            this.Scintilla.UndoRedo.EmptyUndoBuffer();
            this.Scintilla.Modified = false;
            this.FilePath = strFilePath;
            this.Scintilla.IsReadOnly = true;
            this.Scintilla.Modified = false;
            this.Scintilla.Margins.Margin0.Width = LINE_NUMBERS_MARGIN_WIDTH;

            Goto(Scintilla, intLine);
          
            this.Select();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Scintilla.Selection.Text.Length > 0)
            {
                frmMaster.DoSearchFromCode(Scintilla.Selection.Text.TrimEnd(' '));
            }
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string strTarget = "http://www.google.com/search?q=" + Scintilla.Selection.Text.TrimEnd(' ');
            
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

        private void frmCodeViewNew_Shown(object sender, EventArgs e)
        {

        }

        private void cmdCERTSearch_Click(object sender, EventArgs e)
        {
            string strTarget = "http://search.cert.org/search?client=default_frontend&site=default_collection&output=xml_no_dtd&proxystylesheet=default_frontend&ie=UTF-8&oe=UTF-8&as_q=" + Scintilla.Selection.Text.TrimEnd(' ') + "&num=10&btnG=Search&as_epq=&as_oq=&as_eq=&lr=&as_ft=i&as_filetype=&as_occt=any&as_dt=i&as_sitesearch=www.securecoding.cert.org&sort=&as_lq=";
            
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

        private void ctxCodeView_Opening(object sender, CancelEventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(this.Scintilla.Selection.Text);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            searchToolStripMenuItem_Click(null, null);
        }

        private void cmdGoogle_Click(object sender, EventArgs e)
        {
            googleToolStripMenuItem_Click(null, null);
        }

        private void cmdCERT_Click(object sender, EventArgs e)
        {
            cmdCERTSearch_Click(null, null);
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(null, null);
        }

        private void HandleSelectionChange()
        {
            /*
            if (bHighlighting == false)
            {
                frmMaster.scmMine.HighlightWord(richText, richText.SelectedText.ToString(), lineNumbersForRichText);
                richText.Invalidate();
            }
             */
        }


        private void cmdSendFileNamePathToNotes_Click(object sender, EventArgs e)
        {
            StringBuilder strNote = new StringBuilder();
            string strTmp = this.Text.Substring(this.Text.IndexOf("-")+1).TrimStart();

            strNote.Append(strTmp + Environment.NewLine);
            frmMaster.SendToNotes(strNote.ToString());
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
 
    }
}
