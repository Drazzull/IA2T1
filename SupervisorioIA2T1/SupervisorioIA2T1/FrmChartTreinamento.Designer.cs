﻿namespace SupervisorioIA2T1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grfTreinamento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.grfTreinamento)).BeginInit();
            this.SuspendLayout();
            // 
            // grfTreinamento
            // 
            this.grfTreinamento.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin1;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.Name = "ChartArea1";
            this.grfTreinamento.ChartAreas.Add(chartArea1);
            this.grfTreinamento.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.grfTreinamento.Legends.Add(legend1);
            this.grfTreinamento.Location = new System.Drawing.Point(0, 0);
            this.grfTreinamento.Name = "grfTreinamento";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Erro";
            this.grfTreinamento.Series.Add(series1);
            this.grfTreinamento.Size = new System.Drawing.Size(1054, 500);
            this.grfTreinamento.TabIndex = 0;
            this.grfTreinamento.Text = "Gráfico de treinamento";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title1.Name = "title1";
            title1.Text = "Gráfico de Treinamento";
            this.grfTreinamento.Titles.Add(title1);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChartTreinamento_FormClosing);
            this.Shown += new System.EventHandler(this.FrmChartTreinamento_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grfTreinamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grfTreinamento;
    }
}