namespace Win.CodeNavi
{
    partial class frmCharts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCharts));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolChart = new System.Windows.Forms.ToolStrip();
            this.cmdSaveChart = new System.Windows.Forms.ToolStripButton();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolChart
            // 
            this.toolChart.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSaveChart});
            this.toolChart.Location = new System.Drawing.Point(0, 0);
            this.toolChart.Name = "toolChart";
            this.toolChart.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolChart.Size = new System.Drawing.Size(508, 39);
            this.toolChart.TabIndex = 0;
            this.toolChart.Text = "toolStrip1";
            // 
            // cmdSaveChart
            // 
            this.cmdSaveChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSaveChart.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveChart.Image")));
            this.cmdSaveChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSaveChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSaveChart.Name = "cmdSaveChart";
            this.cmdSaveChart.Size = new System.Drawing.Size(36, 36);
            this.cmdSaveChart.Text = "Save chart as image";
            this.cmdSaveChart.Click += new System.EventHandler(this.cmdSaveChart_Click);
            // 
            // chartMain
            // 
            this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "Default";
            this.chartMain.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMain.Legends.Add(legend1);
            this.chartMain.Location = new System.Drawing.Point(12, 53);
            this.chartMain.Name = "chartMain";
            series1.ChartArea = "Default";
            series1.Legend = "Legend1";
            series1.Name = "Default";
            this.chartMain.Series.Add(series1);
            this.chartMain.Size = new System.Drawing.Size(484, 271);
            this.chartMain.TabIndex = 1;
            // 
            // frmCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 336);
            this.Controls.Add(this.chartMain);
            this.Controls.Add(this.toolChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCharts";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.frmCharts_Load);
            this.toolChart.ResumeLayout(false);
            this.toolChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.ToolStripButton cmdSaveChart;
    }
}