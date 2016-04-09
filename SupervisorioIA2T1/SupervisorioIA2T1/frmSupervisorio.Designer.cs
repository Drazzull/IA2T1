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
            this.components = new System.ComponentModel.Container();
            this.btnProgramarTreinamento = new System.Windows.Forms.Button();
            this.btnLeituraDados = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRecarregarPortas = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.cmbVelocidade = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPortas = new System.Windows.Forms.ComboBox();
            this.Conexao = new System.IO.Ports.SerialPort(this.components);
            this.verticalProgressBar1 = new VerticalProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProgramarTreinamento
            // 
            this.btnProgramarTreinamento.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnProgramarTreinamento.Location = new System.Drawing.Point(429, 26);
            this.btnProgramarTreinamento.Name = "btnProgramarTreinamento";
            this.btnProgramarTreinamento.Size = new System.Drawing.Size(120, 31);
            this.btnProgramarTreinamento.TabIndex = 1;
            this.btnProgramarTreinamento.Text = "Treinar Rede";
            this.btnProgramarTreinamento.UseVisualStyleBackColor = true;
            this.btnProgramarTreinamento.Click += new System.EventHandler(this.btnProgramarTreinamento_Click);
            // 
            // btnLeituraDados
            // 
            this.btnLeituraDados.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnLeituraDados.Location = new System.Drawing.Point(555, 25);
            this.btnLeituraDados.Name = "btnLeituraDados";
            this.btnLeituraDados.Size = new System.Drawing.Size(207, 31);
            this.btnLeituraDados.TabIndex = 2;
            this.btnLeituraDados.Text = "Iniciar Leitura Serial";
            this.btnLeituraDados.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.InitialImage = global::SupervisorioIA2T1.Properties.Resources.Cooler;
            this.pictureBox3.Location = new System.Drawing.Point(475, 99);
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
            this.pictureBox2.Location = new System.Drawing.Point(240, 99);
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
            this.pictureBox1.Location = new System.Drawing.Point(5, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 217);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRecarregarPortas
            // 
            this.btnRecarregarPortas.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnRecarregarPortas.Image = global::SupervisorioIA2T1.Properties.Resources.refresh_128;
            this.btnRecarregarPortas.Location = new System.Drawing.Point(139, 30);
            this.btnRecarregarPortas.Name = "btnRecarregarPortas";
            this.btnRecarregarPortas.Size = new System.Drawing.Size(31, 24);
            this.btnRecarregarPortas.TabIndex = 19;
            this.btnRecarregarPortas.UseVisualStyleBackColor = true;
            this.btnRecarregarPortas.Click += new System.EventHandler(this.btnRecarregarPortas_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.btnConectar.Location = new System.Drawing.Point(303, 26);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(120, 31);
            this.btnConectar.TabIndex = 18;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // cmbVelocidade
            // 
            this.cmbVelocidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVelocidade.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.cmbVelocidade.FormattingEnabled = true;
            this.cmbVelocidade.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbVelocidade.Location = new System.Drawing.Point(176, 30);
            this.cmbVelocidade.Name = "cmbVelocidade";
            this.cmbVelocidade.Size = new System.Drawing.Size(121, 23);
            this.cmbVelocidade.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.label2.Location = new System.Drawing.Point(176, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Velocidade:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Portas:";
            // 
            // cmbPortas
            // 
            this.cmbPortas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortas.Font = new System.Drawing.Font("Consolas", 7.8F);
            this.cmbPortas.FormattingEnabled = true;
            this.cmbPortas.Location = new System.Drawing.Point(5, 30);
            this.cmbPortas.Name = "cmbPortas";
            this.cmbPortas.Size = new System.Drawing.Size(128, 23);
            this.cmbPortas.TabIndex = 14;
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.Location = new System.Drawing.Point(710, 99);
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Size = new System.Drawing.Size(52, 218);
            this.verticalProgressBar1.TabIndex = 20;
            // 
            // FrmSupervisorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 329);
            this.Controls.Add(this.verticalProgressBar1);
            this.Controls.Add(this.btnRecarregarPortas);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.cmbVelocidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPortas);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnProgramarTreinamento;
        private System.Windows.Forms.Button btnLeituraDados;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnRecarregarPortas;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.ComboBox cmbVelocidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPortas;
        private System.IO.Ports.SerialPort Conexao;
        private VerticalProgressBar verticalProgressBar1;
    }
}

