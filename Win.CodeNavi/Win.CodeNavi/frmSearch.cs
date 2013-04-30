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

namespace Win.CodeNavi
{
    public partial class frmSearch : Form
    {

        private ListViewColumnSorter lvwColumnSorter;
        private frmMain frmMaster = null;
        private Scanner scanEngine = null;

        public frmSearch(String strTerm, frmMain frmMaster)
        {
            InitializeComponent();
            this.Text = "Search Results - " + strTerm;
            this.frmMaster = frmMaster;
            
        }

        public void SetScanEngine(Scanner scanEngine)
        {
            this.scanEngine = scanEngine;
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                if (MessageBox.Show("Are you sure you wish to close these results?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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

        private void frmSearch_Load(object sender, EventArgs e)
        {
            ListViewHelper.EnableDoubleBuffer(lstResults);
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstResults.ListViewItemSorter = lvwColumnSorter;
            this.Select();
        }

        public void UpdateStatus(string strStatus)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    lstResults.Invoke(new MethodInvoker(() => { UpdateStatus(strStatus); }));
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                lblStatus.Text = strStatus;
            }
        }

        /// <summary>
        /// Update the results list
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="strFile"></param>
        /// <param name="strExt"></param>
        /// <param name="strHit"></param>
        /// <param name="intLineNumber"></param>
        /// <param name="strLine"></param>
        public void UpdateList(string strPath, string strFile, string strExt, int intLineNumber, string strLine)
        {

            if (this.InvokeRequired)
            {
                lstResults.Invoke(new MethodInvoker(() => { UpdateList(strPath, strFile, strExt, intLineNumber, strLine); }));
            }
            else
            {
                ListViewItem itemNew = new ListViewItem();

                itemNew.Text = strPath;
                itemNew.SubItems.Add(strFile);
                itemNew.SubItems.Add(strExt);
                itemNew.SubItems.Add(intLineNumber.ToString());
                itemNew.SubItems.Add(strLine);

                lstResults.Items.Add(itemNew);
            }

        }

        public void UpdateList(string strPath, string strFile, string strExt, int intLineNumber, string strLine, string strRegex)
        {

            if (this.InvokeRequired)
            {
                lstResults.Invoke(new MethodInvoker(() => { UpdateList(strPath, strFile, strExt, intLineNumber, strLine,strRegex); }));
            }
            else
            {
                ListViewItem itemNew = new ListViewItem();

                itemNew.Text = strPath;
                itemNew.SubItems.Add(strFile);
                itemNew.SubItems.Add(strExt);
                itemNew.SubItems.Add(intLineNumber.ToString());
                itemNew.SubItems.Add(strLine);
                itemNew.SubItems.Add(strRegex);

                lstResults.Items.Add(itemNew);
            }

        }

        public void AddRegexColumn()
        {
            if (this.InvokeRequired)
            {
                lstResults.Invoke(new MethodInvoker(() => { AddRegexColumn(); }));
            }
            else
            {
                ColumnHeader colHdr = new ColumnHeader();
                colHdr.Text = "Grepify Regex";
                colHdr.Width = 150;

                this.Width = this.Width + 150;
                lstResults.Columns.Add(colHdr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            OpenFiles();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenFiles()
        {
            for (int intCount = 0; intCount < lstResults.SelectedItems.Count; intCount++)
            {
                // Now initalize a search form
                frmCodeViewNew frmSearch = new frmCodeViewNew(lstResults.SelectedItems[intCount].SubItems[0].Text + "\\" + lstResults.SelectedItems[intCount].SubItems[1].Text, Convert.ToInt32(lstResults.SelectedItems[intCount].SubItems[3].Text),frmMaster);
                frmSearch.MdiParent = this.MdiParent;
                frmSearch.Visible = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void lstResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)System.Windows.Forms.Keys.Enter)
            {
                OpenFiles();
                e.Handled = true;
            }
        }

        private void cmdSendToNotes_Click(object sender, EventArgs e)
        {
            StringBuilder strNote = new StringBuilder();

            if(lstResults.SelectedItems.Count == 0) return;

            for (int intCount = 0; intCount < lstResults.SelectedItems.Count; intCount++)
            {
                strNote.Append(lstResults.SelectedItems[intCount].SubItems[0].Text + "\\" + lstResults.SelectedItems[intCount].SubItems[1].Text+":"+lstResults.SelectedItems[intCount].SubItems[3].Text + " - " + lstResults.SelectedItems[intCount].SubItems[4].Text.Trim() + Environment.NewLine);
            }
            frmMaster.SendToNotes(strNote.ToString());
        }

        private void cmdSendLineToNotes_Click(object sender, EventArgs e)
        {
            StringBuilder strNote = new StringBuilder();
            for (int intCount = 0; intCount < lstResults.SelectedItems.Count; intCount++)
            {
                strNote.Append(lstResults.SelectedItems[intCount].SubItems[4].Text.Trim() + Environment.NewLine);
            }
            frmMaster.SendToNotes(strNote.ToString());
        }

        private void cmdSendFilenameAndPathToNotes_Click(object sender, EventArgs e)
        {
            StringBuilder strNote = new StringBuilder();
            for (int intCount = 0; intCount < lstResults.SelectedItems.Count; intCount++)
            {
                strNote.Append(lstResults.SelectedItems[intCount].SubItems[0].Text + "\\" + lstResults.SelectedItems[intCount].SubItems[1].Text + Environment.NewLine);
            }
            frmMaster.SendToNotes(strNote.ToString());
        }

        private void cmdSearchSend_Click(object sender, EventArgs e)
        {
            cmdSendToNotes_Click(null, null);
        }

        private void cmdSearchSendCodeLine_Click(object sender, EventArgs e)
        {
            cmdSendLineToNotes_Click(null, null);
        }

        private void cmdSearchSendFileandPath_Click(object sender, EventArgs e)
        {
            cmdSendFilenameAndPathToNotes_Click(null, null);
        }

        private void cmdSearchOpen_Click(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cmdSearchAlwaysOnTop_Click(object sender, EventArgs e)
        {
            if (cmdSearchAlwaysOnTop.Checked == true)
            {
                cmdSearchAlwaysOnTop.Checked = false;
                this.ParentForm.TopMost = false;
                
            }
            else
            {
                cmdSearchAlwaysOnTop.Checked = true;
                this.ParentForm.TopMost = true;
            }
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lstResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstResults.Sort();
        }

        private void cmdShowInExplorer_Click(object sender, EventArgs e)
        {
            int intCount = 0;

            if (lstResults.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select an item", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (lstResults.SelectedItems.Count > 1)
            {
                MessageBox.Show("Ensure only a single item is selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (intCount = 0; intCount < lstResults.SelectedItems.Count; intCount++)
                {
                    ListViewItem selItem = lstResults.SelectedItems[intCount];
                    string strFoo = selItem.SubItems[0].Text.ToString() + "\\" + selItem.SubItems[1].Text.ToString(); // filename
                    if (strFoo == "N/A")
                    {
                        MessageBox.Show("No filename for this file", "No Manifest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    strFoo.Replace(@"\", @"\\");
                    ShowSelectedInExplorer.FileOrFolder(strFoo, false);
                }
            }
        }

        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(scanEngine!=null)scanEngine.Stop();
        }

        private void cmdGraphResults_Click(object sender, EventArgs e)
        {
            frmCharts thisChart = new frmCharts(this.lstResults);
            thisChart.MdiParent = frmMaster;
            thisChart.Show();
        }

        private void cmdMark_Click(object sender, EventArgs e)
        {
            for (int intCount = 0; intCount < lstResults.SelectedItems.Count; intCount++)
            {
                lstResults.SelectedItems[intCount].BackColor = Color.Green;
                lstResults.SelectedItems[intCount].ForeColor = Color.White;
            }
        }

        private void cmdUnMark_Click(object sender, EventArgs e)
        {
            for (int intCount = 0; intCount < lstResults.SelectedItems.Count; intCount++)
            {
                lstResults.SelectedItems[intCount].BackColor = Color.White;
                lstResults.SelectedItems[intCount].ForeColor = Color.Black;
            }
        }

    }
}
