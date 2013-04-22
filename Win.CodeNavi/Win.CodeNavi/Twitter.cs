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
using System.Xml.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Win.CodeNavi
{

    class Twitter
    {
        // http://stackoverflow.com/questions/4575693/how-do-i-read-a-public-twitter-feed-using-net-on-windows-phone

        private RichTextBox richTwitter = null;
        private TabPage tabNews = null;

        public void SetRT(RichTextBox richTwitter, TabPage tabNews)
        {
            this.richTwitter = richTwitter;
            this.tabNews = tabNews;
        }

        public void Get()
        {
            
            WebClient twitter = new WebClient();
            try
            {
                twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_DownloadStringCompleted);
                twitter.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=nccgroupinfosec"));
            }
            catch (Exception)
            {
                updateNews("Couldn't get twitter feed...");
            }

        }

        void enableNews()
        {
            if (tabNews.InvokeRequired)
            {
                tabNews.Invoke(new MethodInvoker(() => { enableNews();}));
            }
            else
            {
                
            }
        }
        void clearNews()
        {
            if (richTwitter.InvokeRequired)
            {
                richTwitter.Invoke(new MethodInvoker(() => { clearNews(); }));
            }
            else
            {
                richTwitter.Clear();
            }
        }

        void updateNews(string strNews)
        {
            try
            {
                if (richTwitter.InvokeRequired)
                {
                    richTwitter.Invoke(new MethodInvoker(() => { updateNews(strNews); }));
                }
                else
                {
                    try
                    {
                        richTwitter.AppendText(strNews + Environment.NewLine + Environment.NewLine);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        void twitter_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                XElement xmlTweets = XElement.Parse(e.Result); //exception thrown here!

                var message = from tweet in xmlTweets.Descendants("status")
                              select tweet.Element("text").Value;

                clearNews();
                foreach (string strMessage in message)
                {
                    updateNews(strMessage);
                    enableNews();
                }
            }
            catch (Exception)
            {

            }
            
        }
    }
}
