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
    public partial class frmSearchLimit : Form
    {
        public frmSearchLimit()
        {
            InitializeComponent();
        }

        private void frmSearchLimit_Load(object sender, EventArgs e)
        {
            txtMax.Text = Properties.Settings.Default.MaxResults.ToString();
        }

        private void frmSearchLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
            else if (e.Control && e.KeyCode.ToString().Equals("W"))
            {
                this.Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                Properties.Settings.Default.MaxResults = Convert.ToInt32(txtMax.Text);
                this.Close();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Invalid number of maximum search results");
            }
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Enter))
            {
                Save();
            }
        }
    }
}
