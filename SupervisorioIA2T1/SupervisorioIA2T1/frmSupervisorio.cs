namespace SupervisorioIA2T1
{
    using System;
    using System.IO.Ports;
    using System.Windows.Forms;

    public partial class FrmSupervisorio : Form
    {
        #region Propriedades
        /// <summary>
        /// Valor da string recebida
        /// </summary>
        string StringRx { get; set; }

        /// <summary>
        /// Variável com a saída 1 obtida
        /// </summary>
        float Saida1 { get; set; }

        /// <summary>
        /// Variável com a saída 2 obtida
        /// </summary>
        float Saida2 { get; set; }

        /// <summary>
        /// Variável com a temperatura obtida
        /// </summary>
        float Temperatura { get; set; }

        /// <summary>
        /// Variável com os controles dos ventiladores
        /// </summary>
        int VentiladoresLigados { get; set; }
        #endregion

        #region Construtor
        /// <summary>
        /// Instancia uma instância da classe <see cref="FrmSupervisorio"/>
        /// </summary>
        public FrmSupervisorio()
        {
            this.InitializeComponent();

            // Inicializa o combo com as portas disponíveis no sistema
            this.CarregarListaPortas();

            // Inicializa o estado dos componentes
            this.cmbVelocidade.SelectedIndex = 0;
            this.AlterarEstadoComponentes();
            this.btnLeituraDados.Enabled = false;

            lblVentilador1.Text = "Desativado";
            lblVentilador1.ForeColor = System.Drawing.Color.Red;
            lblVentilador2.Text = "Desativado";
            lblVentilador2.ForeColor = System.Drawing.Color.Red;
            lblVentilador3.Text = "Desativado";
            lblVentilador3.ForeColor = System.Drawing.Color.Red;
        }
        #endregion

        #region Métodos
        #region Componentes do Form
        /// <summary>
        /// Evento click do botão de treino
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void btnProgramarTreinamento_Click(object sender, EventArgs e)
        {
            FrmTreinamento frmTreinamento = new FrmTreinamento(this.Conexao);
            frmTreinamento.ShowDialog();
        }

        /// <summary>
        /// Evento Click do botão para Recarregar Portas
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void btnRecarregarPortas_Click(object sender, EventArgs e)
        {
            this.CarregarListaPortas();
        }

        /// <summary>
        /// Evento Click do botão de conexão
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.cmbPortas.SelectedItem == null) ||
                    string.IsNullOrEmpty(this.cmbPortas.SelectedItem.ToString()))
                {
                    throw new Exception("A porta selecionada é inválida.");
                }

                if (this.Conexao.IsOpen)
                {
                    this.Conexao.Close();
                    this.btnConectar.Text = "Conectar";
                    this.btnLeituraDados.Enabled = false;
                    MessageBox.Show(
                        "Desconectado com Sucesso.",
                        "Sucesso!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                this.Conexao.PortName = this.cmbPortas.SelectedItem.ToString();
                this.Conexao.BaudRate = int.Parse(this.cmbVelocidade.SelectedItem.ToString());
                this.Conexao.Open();
                this.btnConectar.Text = "Desconectar";
                this.btnLeituraDados.Enabled = true;
                MessageBox.Show(
                    "Conectado com Sucesso.",
                    "Sucesso!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "[Erro]{1}{0}{1}{1}[StackTrace]{1}{2}{1} Porta: {3}{1} Velocidade: {4}",
                        ex.Message,
                        Environment.NewLine,
                        ex.StackTrace,
                        this.cmbPortas.SelectedItem == null ? "Nulo" : this.cmbPortas.SelectedItem.ToString(),
                        this.cmbVelocidade.SelectedItem == null ? "Nulo" : this.cmbVelocidade.SelectedItem.ToString()),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inicia a leitura dos dados da serial
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void btnLeituraDados_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "[Erro]{1}{0}{1}{1}[StackTrace]{1}{2}{1}",
                        ex.Message,
                        Environment.NewLine,
                        ex.StackTrace),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento DataReceived da conexão serial
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto SerialDataReceivedEventArgs</param>
        private void Conexao_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Obtém os dados da porta serial
                this.StringRx = this.Conexao.ReadLine();
                string[] retorno = this.StringRx.Split(';');
                this.Saida1 = Convert.ToSingle(retorno[1].Replace('.', ','));
                this.Saida2 = Convert.ToSingle(retorno[3].Replace('.', ','));
                this.Temperatura = Convert.ToSingle(retorno[5].Replace('.', ','));
                this.VentiladoresLigados = Convert.ToInt32(retorno[7].Replace('.', ','));

                // Invoca os comandos para atualizar os campos
                this.Invoke(new EventHandler(this.AlteraTxtResultado));
                this.Invoke(new EventHandler(this.AlteraPgrTemperatura));
                this.Invoke(new EventHandler(this.AtualizaVentiladores));
            }
            catch
            {
            }
        }
        #endregion

        #region Privados
        /// <summary>
        /// Carrega a lista com as portas disponíveis no sistema
        /// </summary>
        private void CarregarListaPortas()
        {
            try
            {
                // Grava a porta selecionada
                string portaConectada = string.Empty;
                if (this.cmbPortas.SelectedValue != null)
                {
                    portaConectada = this.cmbPortas.SelectedValue.ToString();
                }

                // Limpa a lista das portas
                this.cmbPortas.Items.Clear();

                // Obtém a lista de portas do sistema
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    int convert = 0;
                    if (!int.TryParse(port.Substring(3), out convert))
                    {
                        continue;
                    }

                    this.cmbPortas.Items.Add("COM" + convert.ToString());
                }

                // Seleciona a porta que estava selecionada anteriormente
                for (int i = 0; i < this.cmbPortas.Items.Count; i++)
                {
                    if (this.cmbPortas.Items[i].ToString() == portaConectada)
                    {
                        this.cmbPortas.SelectedIndex = i;
                    }
                }

                // Atualiza o estado dos componentes
                this.AlterarEstadoComponentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Ocorreu o seguinte erro ao atualizar as portas:{0}[Erro]{1}{0}Tente novamente.",
                        Environment.NewLine,
                        ex.Message),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Altera o estado dos componentes conforme a lista de portas
        /// </summary>
        private void AlterarEstadoComponentes()
        {
            try
            {
                // Habilita o combo das portas e o botão de conexão apenas quando existirem portas no computador
                this.cmbPortas.Enabled = this.cmbPortas.Items.Count > 0;
                this.btnConectar.Enabled = this.cmbPortas.Items.Count > 0;
                if ((this.cmbPortas.Items.Count > 0) && (this.cmbPortas.SelectedValue == null))
                {
                    this.cmbPortas.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Ocorreu o seguinte erro ao atualizar os componentes:{0}[Erro]{1}{0}",
                        Environment.NewLine,
                        ex.Message),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Altera o textbox com as informações lidas da serial
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AlteraTxtResultado(object sender, EventArgs e)
        {
            this.txtResultadoSerial.Text += this.StringRx + Environment.NewLine;
        }

        /// <summary>
        /// Altera o textbox com as informações lidas da serial
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AlteraPgrTemperatura(object sender, EventArgs e)
        {
            this.pgrTemperatura.Value = (int)((this.Temperatura * 100) / 40);
        }


        /// <summary>
        /// Altera o textbox com as informações lidas da serial
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AtualizaVentiladores(object sender, EventArgs e)
        {
            switch (this.VentiladoresLigados)
            {
                case 0:
                    this.lblVentilador1.Text = "Desativado";
                    this.lblVentilador1.ForeColor = System.Drawing.Color.Red;
                    this.lblVentilador2.Text = "Desativado";
                    this.lblVentilador2.ForeColor = System.Drawing.Color.Red;
                    this.lblVentilador3.Text = "Desativado";
                    this.lblVentilador3.ForeColor = System.Drawing.Color.Red;
                    break;

                case 1:
                    this.lblVentilador1.Text = "Ativado";
                    this.lblVentilador1.ForeColor = System.Drawing.Color.ForestGreen;
                    this.lblVentilador2.Text = "Desativado";
                    this.lblVentilador2.ForeColor = System.Drawing.Color.Red;
                    this.lblVentilador3.Text = "Desativado";
                    this.lblVentilador3.ForeColor = System.Drawing.Color.Red;
                    break;

                case 2:
                    this.lblVentilador1.Text = "Ativado";
                    this.lblVentilador1.ForeColor = System.Drawing.Color.ForestGreen;
                    this.lblVentilador2.Text = "Ativado";
                    this.lblVentilador2.ForeColor = System.Drawing.Color.ForestGreen;
                    this.lblVentilador3.Text = "Desativado";
                    this.lblVentilador3.ForeColor = System.Drawing.Color.Red;
                    break;

                case 3:
                    this.lblVentilador1.Text = "Ativado";
                    this.lblVentilador1.ForeColor = System.Drawing.Color.ForestGreen;
                    this.lblVentilador2.Text = "Ativado";
                    this.lblVentilador2.ForeColor = System.Drawing.Color.ForestGreen;
                    this.lblVentilador3.Text = "Ativado";
                    this.lblVentilador3.ForeColor = System.Drawing.Color.ForestGreen;
                    break;
            }
        }
        #endregion
        #endregion
    }
}