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
using System.Windows.Forms.DataVisualization.Charting;


namespace Win.CodeNavi
{


    public partial class frmCharts : Form
    {
        private ListView lstResults = null;
        private List<string> lstNames = new List<string>();
        private List<int> lstCounts = new List<int>();

        public frmCharts(ListView lstResults)
        {
            InitializeComponent();
            this.lstResults = lstResults;
        }

        private void frmCharts_Load(object sender, EventArgs e)
        {

            foreach (SeriesChartType scType in Enum.GetValues(typeof(SeriesChartType)).Cast<SeriesChartType>())
            {
                chartCombo.Items.Add(scType.ToString());
                chartCombo.SelectedIndex = 0;
            }
            
            foreach(ListViewItem lstItem in this.lstResults.Items){
                
                if (lstItem.SubItems.Count == 6)
                {
                    string strTemp = lstItem.SubItems[5].Text.Replace("\\s*", "").Replace("\\s", "");

                    if (lstNames.Contains(strTemp))
                    {
                        lstCounts[lstNames.IndexOf(strTemp)]++;
                    } else {
                        lstNames.Add(strTemp);
                        lstCounts.Add(1);
                    }
                } else {
                    MessageBox.Show("Can't share a non Grepify set of results","Can't graph",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
                      

            // Populate series data
            int[] yValues = lstCounts.ToArray();
            string[] xValues = lstNames.ToArray();
            this.chartMain.Series["Default"].Points.DataBindXY(xValues, yValues);

            // Set Doughnut chart type
            this.chartMain.Series["Default"].ChartType = SeriesChartType.Doughnut;

            // Set labels style
            this.chartMain.Series["Default"]["PieLabelStyle"] = "Outside";

            this.chartMain.Series["Default"].IsValueShownAsLabel = true;

            // Set Doughnut radius percentage
            this.chartMain.Series["Default"]["DoughnutRadius"] = "60";

            // Enable 3D
            this.chartMain.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            // Set drawing style
            this.chartMain.Series["Default"]["PieDrawingStyle"] = "SoftEdge";

            this.chartMain.Visible = true;
            this.chartMain.Invalidate();
        }

        private void cmdSaveChart_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfDiag = new SaveFileDialog();

            sfDiag.AddExtension = true;
            sfDiag.Filter = "Portable Network Graphic (*.png)|*.png";
            sfDiag.DefaultExt = "png";
            sfDiag.CheckPathExists = true;
            sfDiag.Title = "Select where to save the image";

            if (sfDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.chartMain.SaveImage(sfDiag.FileName, ChartImageFormat.Png);
            }

        }

        private void chartCombo_TextChanged(object sender, EventArgs e)
        {
            foreach (SeriesChartType scType in Enum.GetValues(typeof(SeriesChartType)).Cast<SeriesChartType>())
            {
                if(scType.ToString().Equals(chartCombo.Text)){
                    this.chartMain.Series["Default"].ChartType = scType;
                }
            }           
        }
    }
}
