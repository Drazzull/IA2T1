﻿namespace SupervisorioIA2T1
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    public partial class FrmChartTreinamento : Form
    {
        #region Campos
        /// <summary>
        /// Thread para processamento do arquivo;
        /// </summary>
        private Thread threadConfigurarGrafico;
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém o valor do eixo Y para atualização do gráfico
        /// </summary>
        double EixoY { get; set; }

        /// <summary>
        /// Obtém o valor do salto que o gráfico dará a cada update
        /// </summary>
        double Salto { get; set; }

        /// <summary>
        /// Obtém o valor do tamanho do eixo X
        /// </summary>
        double TamanhoEixoX { get; set; }

        /// <summary>
        /// Obtém o valor da thread de treinamento da rede
        /// </summary>
        private Thread ThreadConfigurarGrafico
        {
            get
            {
                if (this.threadConfigurarGrafico == null)
                {
                    this.threadConfigurarGrafico = new Thread(this.PublicarGrafico);
                }

                return this.threadConfigurarGrafico;
            }
        }
        #endregion

        #region Construtor
        /// <summary>
        /// Instancia uma instância da classe <see cref="FrmChartTreinamento"/>
        /// </summary>
        public FrmChartTreinamento()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Métodos
        #region Métodos do Form
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmChartTreinamento_Shown(object sender, EventArgs e)
        {
            this.ThreadConfigurarGrafico.Start();
        }

        /// <summary>
        /// Antes de finalizar o form fecha as threads abertas
        /// </summary>
        /// <param name="sender">Parâmetro sender</param>
        /// <param name="e">Parâmetro FormClosingEventArgs</param>
        private void FrmChartTreinamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((this.ThreadConfigurarGrafico != null) && this.ThreadConfigurarGrafico.IsAlive)
                {
                    this.ThreadConfigurarGrafico.Abort();
                }
            }
            catch (Exception ex)
            {
                // Mostra a mensagem com o erro que ocorreu
                e.Cancel = true;
                MessageBox.Show(
                    string.Format(
                        "Ocorreu o seguinte erro ao fechar a tela:{0}[Erro]{1}{0}Tente novamente.",
                        Environment.NewLine,
                        ex.Message),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Privados
        /// <summary>
        /// Realiza o povoamento dos dados do gráfico
        /// </summary>
        private void PublicarGrafico()
        {
            try
            {
                // Número de linhas
                int lineCount = 0;
                using (StreamReader sr = new StreamReader(
                    Path.Combine(Application.StartupPath, "treinamento.txt")))
                {
                    while (sr.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }

                // Limpa os pontos do gráfico
                this.TamanhoEixoX = lineCount;
                this.Invoke(new EventHandler(this.AtualizarGrafico));

                // Ajusta o salto
                this.Salto = lineCount * 0.25;

                // Atualiza o gráfico
                this.Invoke(new EventHandler(this.UpdateGrafico));

                // Atualiza o gráfico
                using (StreamReader sr = new StreamReader(
                    Path.Combine(Application.StartupPath, "treinamento.txt")))
                {
                    int contador = 0;
                    while (true)
                    {
                        contador++;
                        if (contador > this.Salto)
                        {
                            this.Invoke(new EventHandler(this.UpdateGrafico));
                            contador = 0;
                        }

                        string valorLinha = sr.ReadLine();
                        if (string.IsNullOrEmpty(valorLinha))
                        {
                            this.Invoke(new EventHandler(this.UpdateGrafico));
                            break;
                        }

                        string[] pontos = valorLinha.Split('|');
                        this.EixoY = Convert.ToDouble(pontos[1].Replace('.', ','));
                        this.Invoke(new EventHandler(this.AdicionaPontoGrafico));
                    }

                    sr.Close();
                }
            }
            catch (Exception exp)
            {
                // Mostra a mensagem com o erro que ocorreu
                MessageBox.Show(
                    string.Format(
                        "Ocorreu o seguinte erro durante a publicação do gráfico:{0}[Erro]{1}StackTrace{2}.",
                        Environment.NewLine,
                        exp.Message,
                        exp.StackTrace),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Threads para Atualização dos Componentes
        /// <summary>
        /// Acrescenta o ponto ao gráfico
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AdicionaPontoGrafico(object sender, EventArgs e)
        {
            this.grfTreinamento.Series[0].Points.AddY(this.EixoY);
        }

        /// <summary>
        /// Limpa os dados do gráfico
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AtualizarGrafico(object sender, EventArgs e)
        {
            this.grfTreinamento.Series[0].Points.Clear();
            this.grfTreinamento.ChartAreas[0].AxisX.Maximum = this.TamanhoEixoX;
        }

        /// <summary>
        /// Dá o refresh no gráfico
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void UpdateGrafico(object sender, EventArgs e)
        {
            this.grfTreinamento.Series.ResumeUpdates();
            this.grfTreinamento.Series.Invalidate();
            this.grfTreinamento.Series.SuspendUpdates();
        }
        #endregion
        #endregion
    }
}