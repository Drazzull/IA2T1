namespace SupervisorioIA2T1
{
    partial class FrmSupervisorio
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
            this.btnProgramarTreinamento = new System.Windows.Forms.Button();
            this.btnLeituraDados = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProgramarTreinamento
            // 
            this.btnProgramarTreinamento.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnProgramarTreinamento.Location = new System.Drawing.Point(377, 236);
            this.btnProgramarTreinamento.Name = "btnProgramarTreinamento";
            this.btnProgramarTreinamento.Size = new System.Drawing.Size(201, 31);
            this.btnProgramarTreinamento.TabIndex = 1;
            this.btnProgramarTreinamento.Text = "Programar Treinamento";
            this.btnProgramarTreinamento.UseVisualStyleBackColor = true;
            this.btnProgramarTreinamento.Click += new System.EventHandler(this.btnProgramarTreinamento_Click);
            // 
            // btnLeituraDados
            // 
            this.btnLeituraDados.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnLeituraDados.Location = new System.Drawing.Point(584, 236);
            this.btnLeituraDados.Name = "btnLeituraDados";
            this.btnLeituraDados.Size = new System.Drawing.Size(127, 31);
            this.btnLeituraDados.TabIndex = 2;
            this.btnLeituraDados.Text = "Leitura Dados";
            this.btnLeituraDados.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.InitialImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox3.Location = new System.Drawing.Point(482, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(229, 218);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.InitialImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox2.Location = new System.Drawing.Point(247, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(229, 218);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 218);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmSupervisorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 277);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLeituraDados);
            this.Controls.Add(this.btnProgramarTreinamento);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSupervisorio";
            this.Text = "Supervisório - IA2 - T1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnProgramarTreinamento;
        private System.Windows.Forms.Button btnLeituraDados;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

