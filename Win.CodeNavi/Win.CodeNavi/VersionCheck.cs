/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/ncccodenavi

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace Win.CodeNavi
{
    public class VersionCheck
    {
        public void Get()
        {

            WebClient verCheck = new WebClient();

            try
            {
                verCheck.DownloadStringCompleted += new DownloadStringCompletedEventHandler(verCheck_DownloadStringCompleted);
                verCheck.DownloadStringAsync(new Uri("https://raw.github.com/nccgroup/ncccodenavi/master/Version.Check/Version.txt"));
            }
            catch (Exception)
            {

            }

        }

        void verCheck_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            try
            {
                if (e.Result.ToString().Equals(fvi.FileVersion) == false)
                {
                    if (MessageBox.Show("New version availible - " + e.Result.ToString() + ", do you want to visit the download site?", "Download new version?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strTarget = "https://github.com/nccgroup/ncccodenavi";

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
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
