namespace SupervisorioIA2T1
{
    partial class FrmChartTreinamento
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grfTreinamento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.grfTreinamento)).BeginInit();
            this.SuspendLayout();
            // 
            // grfTreinamento
            // 
            this.grfTreinamento.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin1;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.Name = "ChartArea1";
            this.grfTreinamento.ChartAreas.Add(chartArea2);
            this.grfTreinamento.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.grfTreinamento.Legends.Add(legend2);
            this.grfTreinamento.Location = new System.Drawing.Point(0, 0);
            this.grfTreinamento.Name = "grfTreinamento";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Erro";
            this.grfTreinamento.Series.Add(series2);
            this.grfTreinamento.Size = new System.Drawing.Size(1054, 500);
            this.grfTreinamento.TabIndex = 0;
            this.grfTreinamento.Text = "Gráfico de treinamento";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title2.Name = "title1";
            title2.Text = "Gráfico de Treinamento";
            this.grfTreinamento.Titles.Add(title2);
            // 
            // FrmChartTreinamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 500);
            this.Controls.Add(this.grfTreinamento);
            this.Name = "FrmChartTreinamento";
            this.Text = "FrmChartTreinamento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.grfTreinamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grfTreinamento;
    }
}