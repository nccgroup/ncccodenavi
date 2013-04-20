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
    public partial class frmNotes : Form
    {
        private Form frmMain = null;

        public frmNotes(Form frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;
        }

        private void frmNotes_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Send a note to the RichText
        /// </summary>
        /// <param name="strText"></param>
        public void SendToNotes(String strText)
        {
            if (this.InvokeRequired)
            {
                //this.Invoke(new MethodInvoker(() => { UpdateStatus(strStatus); }));
            }
            else
            {
                
            }
        }
    }
}
