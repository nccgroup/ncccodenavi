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
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace Win.CodeNavi
{

    /// <summary>
    /// 
    /// </summary>
    class FileToScan
    {
        private string strFile = null;
        private frmMain frmMaster = null;
        private frmSearch frmSearch = null;
        private string strTerm = null;
        private string[] strAPIs = null;
        List<Grepifyv2Check> lstChecks = null;
        private bool bCase = true;
        private bool bRegex = false;
        private bool bComments = false;
        private string[] strCommentsRegex = null;
        Scanner engineLocal = null;

        /// <summary>
        /// Scan a particular file
        /// </summary>
        /// <param name="strFile">the file we wish to scan</param>
        /// <param name="strAPIs">an array of regular expressions we've loaded</param>
        /// <returns></returns>
        private bool ScanFile(string strFile)
        {
            if (engineLocal.bStopped == true || engineLocal.intFinds > Properties.Settings.Default.MaxResults) 
            {
                engineLocal.LowerQueueCount();
                return false;
            }

            try
            {
                byte[] fileBytes = File.ReadAllBytes(strFile);
                Encoding encodingForFile = null;
                if (IsTextTester.IsText(out encodingForFile,strFile.ToString(),100) == false){
                    return false;
                }

                
                FileInfo fInfo = new FileInfo(strFile);

                int intCount = 0;

                foreach (string strLine in File.ReadLines(strFile, encodingForFile))
                {
                    intCount++;

                    if (engineLocal.bStopped == true)
                    {
                        engineLocal.LowerQueueCount();
                        return false;
                    }

                    try
                    {
                        Match commentregexMatch = null;
                        if (bComments == true)
                        {
                            try
                            {
                                foreach (string strComRegex in strCommentsRegex)
                                {
                                    commentregexMatch = Regex.Match(strLine, strComRegex);
                                    if (commentregexMatch.Success == true)
                                    {
                                        break;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                  
                            }
                        }

                        if (bComments != true || commentregexMatch == null || (commentregexMatch != null && commentregexMatch.Success == false))
                        {
                            if (strAPIs != null || lstChecks != null) // We're doing a grepify scan
                            {
                                // V1
                                if (strAPIs != null)
                                {
                                    foreach (string strRegex in strAPIs)
                                    {
                                        if (engineLocal.bStopped == true)
                                        {
                                            engineLocal.LowerQueueCount();
                                            return false;
                                        }
                                        else
                                        {

                                            Match regexMatch = null;
                                            if (bCase == false)
                                            {
                                                regexMatch = Regex.Match(strLine, strRegex, RegexOptions.IgnoreCase);
                                            }
                                            else
                                            {
                                                regexMatch = Regex.Match(strLine, strRegex);
                                            }


                                            if (regexMatch != null && regexMatch.Success)
                                            {
                                                if (frmSearch.IsDisposed == false) frmSearch.UpdateList(fInfo.DirectoryName, fInfo.Name, fInfo.Extension, intCount, strLine, strRegex, null);
                                                lock (engineLocal.objCount)
                                                {
                                                    engineLocal.intFinds++;
                                                    if (engineLocal.intFinds == Properties.Settings.Default.MaxResults)
                                                    {
                                                        MessageBox.Show("Maximum results found stopping scan", "Stopping scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                            }
                                        }


                                    }
                                }


                                // V2
                                if (lstChecks != null)
                                {
                                    foreach (Grepifyv2Check gv2Check in lstChecks)
                                    {
                                        string[] strExts = gv2Check.strExts.Split(';');
                                        bool bFound = false;

                                        foreach(string strExt in strExts){
                                            try
                                            {
                                                if (Path.GetExtension(strFile).EndsWith(strExt.Split('.')[1]) == true) bFound = true;
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                        
                                        if (engineLocal.bStopped == true)
                                        {
                                            engineLocal.LowerQueueCount();
                                            return false;
                                        }
                                        else if(bFound == true)
                                        {

                                            Match regexMatch = null;
                                            if (bCase == false)
                                            {
                                                regexMatch = Regex.Match(strLine, gv2Check.strRegex, RegexOptions.IgnoreCase);
                                            }
                                            else
                                            {
                                                regexMatch = Regex.Match(strLine, gv2Check.strRegex);
                                            }


                                            if (regexMatch != null && regexMatch.Success)
                                            {
                                                if (frmSearch.IsDisposed == false) frmSearch.UpdateList(fInfo.DirectoryName, fInfo.Name, fInfo.Extension, intCount, strLine, null, gv2Check);
                                                lock (engineLocal.objCount)
                                                {
                                                    engineLocal.intFinds++;
                                                    if (engineLocal.intFinds == Properties.Settings.Default.MaxResults)
                                                    {
                                                        MessageBox.Show("Maximum results found stopping scan", "Stopping scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                            }
                                        }


                                    }
                                }
                            }
                            else if (bRegex == true && strAPIs == null && lstChecks == null) // Standard term search but with regex
                            {
                                Match regexMatch = null;
                                if (bCase == false)
                                {
                                    regexMatch = Regex.Match(strLine, strTerm, RegexOptions.IgnoreCase);
                                }
                                else
                                {
                                    regexMatch = Regex.Match(strLine, strTerm);
                                }


                                if (regexMatch != null && regexMatch.Success)
                                {
                                    // Update the GUI   
                                    frmSearch.UpdateList(fInfo.DirectoryName, fInfo.Name, fInfo.Extension, intCount, strLine);
                                    lock (engineLocal.objCount)
                                    {
                                        engineLocal.intFinds++;
                                        if (engineLocal.intFinds == Properties.Settings.Default.MaxResults)
                                        {
                                            MessageBox.Show("Maximum results found stopping scan", "Stopping scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                            else if (strAPIs == null) // Standard term search without regex
                            {
                                if (bCase == true && strLine.Contains(strTerm) && frmSearch.IsDisposed == false)
                                {
                                    frmSearch.UpdateList(fInfo.DirectoryName, fInfo.Name, fInfo.Extension, intCount, strLine);
                                    lock (engineLocal.objCount)
                                    {
                                        engineLocal.intFinds++;
                                        if (engineLocal.intFinds == Properties.Settings.Default.MaxResults)
                                        {
                                            MessageBox.Show("Maximum results found stopping scan", "Stopping scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                else if (bCase == false && strLine.ToLower().Contains(strTerm.ToLower()) && frmSearch.IsDisposed == false)
                                {
                                    frmSearch.UpdateList(fInfo.DirectoryName, fInfo.Name, fInfo.Extension, intCount, strLine);
                                    lock (engineLocal.objCount)
                                    {
                                        engineLocal.intFinds++;
                                        if (engineLocal.intFinds == Properties.Settings.Default.MaxResults)
                                        {
                                            MessageBox.Show("Maximum results found stopping scan", "Stopping scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                } 
                                else if (frmSearch.IsDisposed == true)
                                {
  
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                      
                    }
                }

                fInfo = null;
            }
            catch (Exception)
            {
                
            }
            finally
            {
                engineLocal.LowerQueueCount();
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFile"></param>
        public FileToScan(string strFile, Scanner scanEngine)
        {
            this.strTerm = scanEngine.strTerm;
            this.strAPIs = scanEngine.strAPIs;
            this.strFile = strFile;
            this.bCase = scanEngine.bCase;
            this.bRegex = scanEngine.bRegex;
            this.bComments = scanEngine.bComments;
            this.frmMaster = scanEngine.frmMain;
            this.frmSearch = scanEngine.frmSearch;
            this.engineLocal = scanEngine;
            this.strCommentsRegex = scanEngine.strCommentsRegex;
            this.lstChecks = scanEngine.lstChecks;
        }

        // Wrapper method for use with thread pool.
        public void ThreadPoolCallback(Object threadContext)
        {
            if (this.engineLocal.bStopped == true)
            {
                engineLocal.LowerQueueCount();
                return;
            }
             ScanFile(this.strFile);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Scanner
    {
        public frmSearch frmSearch = null;
        public frmMain frmMain = null;
        private String strPath = null;
        public String strTerm = null;
        public Boolean bRegex = false;
        public Boolean bCase = false;
        public Boolean bIgnoreTest = true;
        private Thread trdEnum = null;
        private int intMaxThreads = 10;
        public Boolean bStopped = false;
        public Boolean bComments = false;
        public string[] strCommentsRegex = null;
        public string[] strExRegex = null;
        private static object objQueue = new object();
        public object objCount = new object();
        private static int intQueue;
        string[] strExts = null;
        public string[] strAPIs = null;
        public List<Grepifyv2Check> lstChecks = null;
        public int intFinds = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public Scanner(frmSearch frmSearch, String strPath, String strTerm, Boolean bComments, Boolean bRegex, Boolean bCase, Boolean bIgnoreTest, String strExtsText, string[] strExRegex)
        {
            this.frmSearch = frmSearch;
            this.strPath = strPath;
            this.strTerm = strTerm;
            this.bRegex = bRegex;
            this.bCase = bCase;
            this.bComments = bComments;
            this.bIgnoreTest = bIgnoreTest;
            this.strExRegex = strExRegex;
            this.strExts = strExtsText.Split(';'); // has already been error checked before getting here
         
            try
            {
                this.strCommentsRegex = File.ReadAllLines(frmMain.AssemblyDirectory + "\\Grepify.Comments\\Comments.grepify");
               
            }
            catch (Exception)
            {
                if (bComments) MessageBox.Show("Failed to load comments regular expressons", "Failed to load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (bComments)
            {
                foreach (string strRegex in this.strCommentsRegex)
                {
                    try
                    {
                        Match regexMatch = Regex.Match("Mooo", strRegex);
                    }
                    catch (ArgumentException rExcp)
                    {
                        MessageBox.Show("Regex looks broken, Regex is '" + strRegex + "'. Error is '" + rExcp.Message + "'.", "Regex error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public Scanner(frmSearch frmSearch, String strPath, string[] strAPIs, List<Grepifyv2Check> lstChecks, Boolean bComments, Boolean bRegex, Boolean bCase, Boolean bIgnoreTest, String strExtsText, string[] strExRegex)
        {
            this.frmSearch = frmSearch;
            this.strPath = strPath;
            this.strAPIs = strAPIs;
            this.lstChecks = lstChecks;
            this.bRegex = bRegex;
            this.bCase = bCase;
            this.bComments = bComments;
            this.bIgnoreTest = bIgnoreTest;
            this.strExRegex = strExRegex;
            this.strExts = strExtsText.Split(';'); // has already been error checked before getting here

            try
            {
                this.strCommentsRegex = File.ReadAllLines(frmMain.AssemblyDirectory + "\\Grepify.Comments\\Comments.grepify");
            }
            catch (Exception)
            {
                if (bComments) MessageBox.Show("Failed to load comments regular expressons", "Failed to load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        public bool Start(frmMain frmMain, frmSearch frmSearch)
        {
            this.frmMain = frmMain;
            this.frmSearch = frmSearch;

            try
            {
                ThreadPool.SetMaxThreads(intMaxThreads, intMaxThreads * 2);
                trdEnum = new Thread(this.ThreadFunction);
                trdEnum.IsBackground = true;
                trdEnum.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            bStopped = true;
            return true;
        }

        /// <summary>
        /// Enumerate the files in a given path
        /// </summary>
        /// <param name="strPath"></param>
        private void EnumerateFiles(string strPath, string strExts)
        {
            try
            {
                foreach (string strFile in Directory.GetFiles(strPath, strExts))
                {
                    if (bStopped == true) return;

                    int intCount = 0;
                    Match regexMatch = null;
                    foreach (string strLine in strExRegex)
                    {
                        if (strLine.Length == 0) continue;
                        intCount++;
                        try
                        {
                            regexMatch = Regex.Match(strFile, strLine);
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Exclusion regex compiliation failed on line " + intCount + ", stopping scan", "Regex error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bStopped = true;
                            return;
                        }
                    }

                    if (((bIgnoreTest == true && strFile.ToLower().Contains("test") == false) || bIgnoreTest == false) && (regexMatch == null || (regexMatch != null && regexMatch.Success == false)))
                    {
                        FileToScan file2Scan = new FileToScan(strFile, this);
                        lock (objQueue) intQueue++;
                        ThreadPool.QueueUserWorkItem(file2Scan.ThreadPoolCallback);
                    }
                }

                foreach (string strDir in Directory.GetDirectories(strPath))
                {
                    if (bStopped == true) return;

                    if ((bIgnoreTest == true && strDir.ToLower().Contains("test") == false) || bIgnoreTest == false)
                    {
                        EnumerateFiles(strDir, strExts);
                    }
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

        /// <summary>
        /// 
        /// </summary>
        private void ThreadFunction()
        {

            try
            {
                frmSearch.UpdateStatus("Search running...");
                foreach (string strExt in strExts)
                {
                    EnumerateFiles(this.strPath, strExt);
                }

                while (intQueue > 0)
                {
                    Thread.Sleep(1000);
                }

                frmSearch.UpdateStatus("Search complete");
            }
            catch (ThreadAbortException)
            {
                while (intQueue > 0)
                {
                    Thread.Sleep(1000);
                }
                frmSearch.UpdateStatus("Search thread crashed");
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LowerQueueCount()
        {
            lock (objQueue) --intQueue;
        }

    }
}
