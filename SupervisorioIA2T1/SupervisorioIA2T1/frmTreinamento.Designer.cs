namespace SupervisorioIA2T1
{
    partial class FrmTreinamento
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEpocas = new System.Windows.Forms.MaskedTextBox();
            this.pgrTreinamento = new System.Windows.Forms.ProgressBar();
            this.btnIniciarTreinamento = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTaxaAprendizado = new System.Windows.Forms.NumericUpDown();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.txtResultadoPesos = new System.Windows.Forms.TextBox();
            this.btnApresentarGrafico = new System.Windows.Forms.Button();
            this.btnEnviarPesos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxaAprendizado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Épocas";
            // 
            // txtEpocas
            // 
            this.txtEpocas.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEpocas.Location = new System.Drawing.Point(12, 30);
            this.txtEpocas.Mask = "00000";
            this.txtEpocas.Name = "txtEpocas";
            this.txtEpocas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEpocas.Size = new System.Drawing.Size(61, 23);
            this.txtEpocas.TabIndex = 6;
            // 
            // pgrTreinamento
            // 
            this.pgrTreinamento.Location = new System.Drawing.Point(12, 80);
            this.pgrTreinamento.Name = "pgrTreinamento";
            this.pgrTreinamento.Size = new System.Drawing.Size(919, 23);
            this.pgrTreinamento.TabIndex = 8;
            // 
            // btnIniciarTreinamento
            // 
            this.btnIniciarTreinamento.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarTreinamento.Location = new System.Drawing.Point(246, 28);
            this.btnIniciarTreinamento.Name = "btnIniciarTreinamento";
            this.btnIniciarTreinamento.Size = new System.Drawing.Size(183, 23);
            this.btnIniciarTreinamento.TabIndex = 9;
            this.btnIniciarTreinamento.Text = "Iniciar Treinamento";
            this.btnIniciarTreinamento.UseVisualStyleBackColor = true;
            this.btnIniciarTreinamento.Click += new System.EventHandler(this.btnIniciarTreinamento_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Taxa de aprendizado";
            // 
            // nudTaxaAprendizado
            // 
            this.nudTaxaAprendizado.DecimalPlaces = 1;
            this.nudTaxaAprendizado.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTaxaAprendizado.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTaxaAprendizado.Location = new System.Drawing.Point(80, 30);
            this.nudTaxaAprendizado.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudTaxaAprendizado.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTaxaAprendizado.Name = "nudTaxaAprendizado";
            this.nudTaxaAprendizado.Size = new System.Drawing.Size(160, 23);
            this.nudTaxaAprendizado.TabIndex = 12;
            this.nudTaxaAprendizado.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.lblProgresso.Location = new System.Drawing.Point(12, 60);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(200, 17);
            this.lblProgresso.TabIndex = 13;
            this.lblProgresso.Text = "Progresso do Treinamento";
            // 
            // txtResultadoPesos
            // 
            this.txtResultadoPesos.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.txtResultadoPesos.Location = new System.Drawing.Point(12, 110);
            this.txtResultadoPesos.Multiline = true;
            this.txtResultadoPesos.Name = "txtResultadoPesos";
            this.txtResultadoPesos.ReadOnly = true;
            this.txtResultadoPesos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultadoPesos.Size = new System.Drawing.Size(919, 233);
            this.txtResultadoPesos.TabIndex = 14;
            // 
            // btnApresentarGrafico
            // 
            this.btnApresentarGrafico.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApresentarGrafico.Location = new System.Drawing.Point(435, 28);
            this.btnApresentarGrafico.Name = "btnApresentarGrafico";
            this.btnApresentarGrafico.Size = new System.Drawing.Size(175, 23);
            this.btnApresentarGrafico.TabIndex = 15;
            this.btnApresentarGrafico.Text = "Apresentar Gráfico";
            this.btnApresentarGrafico.UseVisualStyleBackColor = true;
            this.btnApresentarGrafico.Click += new System.EventHandler(this.btnApresentarGrafico_Click);
            // 
            // btnEnviarPesos
            // 
            this.btnEnviarPesos.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnEnviarPesos.Location = new System.Drawing.Point(617, 28);
            this.btnEnviarPesos.Name = "btnEnviarPesos";
            this.btnEnviarPesos.Size = new System.Drawing.Size(126, 23);
            this.btnEnviarPesos.TabIndex = 16;
            this.btnEnviarPesos.Text = "Enviar Pesos";
            this.btnEnviarPesos.UseVisualStyleBackColor = true;
            this.btnEnviarPesos.Click += new System.EventHandler(this.btnEnviarPesos_Click);
            // 
            // FrmTreinamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 355);
            this.Controls.Add(this.btnEnviarPesos);
            this.Controls.Add(this.btnApresentarGrafico);
            this.Controls.Add(this.txtResultadoPesos);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.nudTaxaAprendizado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIniciarTreinamento);
            this.Controls.Add(this.pgrTreinamento);
            this.Controls.Add(this.txtEpocas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTreinamento";
            this.Text = "frmTreinamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTreinamento_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxaAprendizado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtEpocas;
        private System.Windows.Forms.ProgressBar pgrTreinamento;
        private System.Windows.Forms.Button btnIniciarTreinamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTaxaAprendizado;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.TextBox txtResultadoPesos;
        private System.Windows.Forms.Button btnApresentarGrafico;
        private System.Windows.Forms.Button btnEnviarPesos;
    }
}