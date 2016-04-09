namespace SupervisorioIA2T1
{
    using System;
    using System.IO;
    using System.IO.Ports;
    using System.Threading;
    using System.Windows.Forms;

    public partial class FrmTreinamento : Form
    {
        #region Campos
        /// <summary>
        /// Thread para treinamento da rede
        /// </summary>
        private Thread threadTreinarRede;

        /// <summary>
        /// Arquivo que os pesos serão gravados
        /// </summary>
        FileInfo arqPesos;

        /// <summary>
        /// Arquivo que os dados do treinamento serão gravados
        /// </summary>
        FileInfo arqTreinamento;

        /// <summary>
        /// Arquivo que os pesos treinados serão gravados
        /// </summary>
        FileInfo arqPesosTreinados;

        /// <summary>
        /// Campo para utilização de funções de randomização
        /// </summary>
        Random randomize;

        /// <summary>
        /// Padrões de entrada da rede (sensores).
        /// </summary>
        float[] x = { 0f };

        /// <summary>
        /// Padrões de entrada da rede (sensores)
        /// </summary>
        float[,] p = new float[,] { { 0.0f }, { 0.33f }, { 0.66f }, { 1.0f } };

        /// <summary>
        /// Valores desejados dos padrões ao final do treinamento
        /// </summary>
        float[,] d = new float[,] { { 0.0f, 0.0f }, { 0.0f, 1.0f }, { 1.0f, 0.0f }, { 1.0f, 1.0f } };

        /// <summary>
        /// Camada de Entrada
        /// </summary>
        const int cx = 1;

        /// <summary>
        /// Camada Intermediária
        /// </summary>
        const int c1 = 5;

        /// <summary>
        /// Camada de Saída
        /// </summary>
        const int c2 = 2;

        /// <summary>
        /// Pesos camada 1
        /// </summary>
        float[] w1 = new float[cx * c1] { 0, 0, 0, 0, 0 };  //cx*c1

        /// <summary>
        /// Pesos camada 2
        /// </summary>
        float[] w2 = new float[c1 * c2] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };  //c1*c2

        /// <summary>
        /// Auxiliar camada 1
        /// </summary>
        float[] dw1 = new float[cx * c1] { 0, 0, 0, 0, 0 }; //cx*c1

        /// <summary>
        /// Auxiliar camada 2
        /// </summary>
        float[] dw2 = new float[c1 * c2] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //c1*c2

        // Documentar campos abaixo
        ulong contador = 0;
        ulong epocas = 0;
        int i = 0, j = 0, k = 0, padroes = 0, funcao = 0;
        float taxaAprendizado = 0, MOMENTUM = 0;
        float erroMedioQuadratico = 0, erroQuadratico = 0;
        float[] entradaCamada1 = new float[c1] { 0, 0, 0, 0, 0 };
        float[] saidaCamada1 = new float[c1] { 0, 0, 0, 0, 0 };
        float[] erroCamada1 = new float[c1] { 0, 0, 0, 0, 0 };
        float[] entradaCamada2 = new float[c2] { 0, 0 };
        float[] saidaCamada2 = new float[c2] { 0, 0 };
        float[] erroCamada2 = new float[c2] { 0, 0 };
        float[] saidas = new float[c2] { 0, 0 };
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém o valor da thread de treinamento da rede
        /// </summary>
        private Thread ThreadTreinarRede
        {
            get
            {
                if (this.threadTreinarRede == null)
                {
                    this.threadTreinarRede = new Thread(this.TreinarRede);
                }

                return this.threadTreinarRede;
            }

            set
            {
                this.threadTreinarRede = value;
            }
        }

        /// <summary>
        /// Obtém o arquivo que armazena os pesos iniciais da rede.
        /// </summary>
        FileInfo ArqPesos
        {
            get
            {
                // Verifica se o arquivo já foi inicializado
                if (this.arqPesos == null)
                {
                    this.arqPesos = new FileInfo(Path.Combine(Application.StartupPath, "PesosRandomizados.txt"));
                }

                // Verifica se o arquivo já está criado
                if (!this.arqPesos.Exists)
                {
                    this.arqPesos.Create();
                }

                // Atualiza as propriedades do campo
                this.arqPesos.Refresh();
                return this.arqPesos;
            }
        }

        /// <summary>
        /// Obtém o arquivo que armazena os pesos iniciais da rede.
        /// </summary>
        FileInfo ArqTreinamento
        {
            get
            {
                // Verifica se o arquivo já foi inicializado
                if (this.arqTreinamento == null)
                {
                    this.arqTreinamento = new FileInfo(
                        Path.Combine(Application.StartupPath, "Treinamento.txt"));
                }

                // Verifica se o arquivo já está criado
                if (!this.arqTreinamento.Exists)
                {
                    this.arqTreinamento.Create();
                }

                // Atualiza as propriedades do campo
                this.arqTreinamento.Refresh();
                return this.arqTreinamento;
            }
        }

        /// <summary>
        /// Obtém o arquivo que armazena os pesos treinados da rede.
        /// </summary>
        FileInfo ArqPesosTreinados
        {
            get
            {
                // Verifica se o arquivo já foi inicializado
                if (this.arqPesosTreinados == null)
                {
                    this.arqPesosTreinados = new FileInfo(
                        Path.Combine(Application.StartupPath, "PesosTreinados.txt"));
                }

                // Verifica se o arquivo já está criado
                if (!this.arqPesosTreinados.Exists)
                {
                    this.arqPesosTreinados.Create();
                }

                // Atualiza as propriedades do campo
                this.arqPesosTreinados.Refresh();
                return this.arqPesosTreinados;
            }
        }

        /// <summary>
        /// Obtém a classe de randomização
        /// </summary>
        Random Randomize
        {
            get
            {
                if (this.randomize == null)
                {
                    this.randomize = new Random(new System.DateTime().Millisecond);
                }

                return this.randomize;
            }

            set
            {
                this.randomize = value;
            }
        }

        /// <summary>
        /// String para atualização do editbox
        /// </summary>
        string StringAtualizacao { get; set; }

        /// <summary>
        /// Define se a thread está em execução
        /// </summary>
        private bool ThreadEmExecucao { get; set; }

        /// <summary>
        /// Coenxão com a porta serial
        /// </summary>
        SerialPort Conexao;
        #endregion

        #region Construtor
        /// <summary>
        /// Instancia uma instância da classe <see cref="FrmTreinamento"/>
        /// </summary>
        public FrmTreinamento(SerialPort conexao)
        {
            this.InitializeComponent();

            // Inicializa a conexão
            this.Conexao = conexao;

            // Botão de Envio de pesos
            this.btnEnviarPesos.Enabled = ((this.Conexao != null) && this.Conexao.IsOpen);
        }
        #endregion

        #region Métodos
        #region Métodos do Form
        /// <summary>
        /// Antes de finalizar o form fecha as threads abertas
        /// </summary>
        /// <param name="sender">Parâmetro sender</param>
        /// <param name="e">Parâmetro FormClosingEventArgs</param>
        private void FrmTreinamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if ((this.ThreadTreinarRede != null) && this.ThreadTreinarRede.IsAlive)
                {
                    this.ThreadTreinarRede.Abort();
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

        #region Métodos de Componentes do form
        /// <summary>
        /// Evento click do botão de programação do treino
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void btnIniciarTreinamento_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Valida o preenchimento dos campos
                this.ValidarCampos();

                // Interrompe a rede
                if (this.ThreadTreinarRede.ThreadState == ThreadState.Stopped)
                {
                    this.ThreadTreinarRede = null;
                }

                // Treina a rede
                this.ThreadTreinarRede.Start();
            }
            catch (Exception exp)
            {
                // Mostra a mensagem com o erro que ocorreu
                MessageBox.Show(
                    string.Format(
                        "Ocorreu o seguinte erro ao treinar a rede:{0}[Erro]{1}",
                        Environment.NewLine,
                        exp.Message),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento click do botão de apresentação do gráfico de treino
        /// </summary>
        /// <param name="sender">Objeto sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void btnApresentarGrafico_Click(object sender, EventArgs e)
        {
            // Abre a tela para apresentar o gráfico
            FrmChartTreinamento frmChartTreinamento = new FrmChartTreinamento();
            frmChartTreinamento.ShowDialog();
        }

        /// <summary>
        /// Evento Click do botão Enviar Pesos
        /// </summary>
        /// <param name="sender">Parâmetro sender</param>
        /// <param name="e">Parâmetro FormClosingEventArgs</param>
        private void btnEnviarPesos_Click(object sender, EventArgs e)
        {
            try
            {
                string pesosCamada1 = "C1";
                string pesosCamada2 = "C2";
                int tipoPesos = 0;

                // Atualiza o gráfico
                using (StreamReader sr = new StreamReader(
                    Path.Combine(Application.StartupPath, "PesosTreinados.txt")))
                {
                    while (true)
                    {
                        string valorLinha = sr.ReadLine();
                        if (string.IsNullOrEmpty(valorLinha))
                        {
                            break;
                        }

                        if (valorLinha == "PC1")
                        {
                            tipoPesos = 1;
                            continue;
                        }

                        if (valorLinha == "PC2")
                        {
                            tipoPesos = 2;
                            continue;
                        }

                        switch (tipoPesos)
                        {
                            case 1:
                                pesosCamada1 += string.Format(";{0}", Convert.ToString(valorLinha));
                                break;

                            case 2:
                                pesosCamada2 += string.Format(";{0}", Convert.ToString(valorLinha));
                                break;
                        }
                    }

                    sr.Close();
                }

                this.EscreverStringSerial(pesosCamada1 + Environment.NewLine);
                this.EscreverStringSerial(pesosCamada2 + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "[Erro]{0}{1}{0}{0}[StackTrace]{0}{2}",
                        Environment.NewLine,
                        ex.Message,
                        ex.StackTrace),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Privados
        /// <summary>
        /// Retorna o valor de e elevada a potência x
        /// </summary>
        /// <param name="x">Potência à qual e será elevado</param>
        /// <returns>Valor de e elevada a potência x</returns>
        private float ExpF(float x)
        {
            return (float)Math.Exp(x);
        }

        /// <summary>
        /// Eleva x à potência de y
        /// </summary>
        /// <param name="x">Base para o cálculo</param>
        /// <param name="y">Valor ao qual x será elevado</param>
        /// <returns>Valor de x elevado à potência de y</returns>
        private float PowF(float x, float y)
        {
            return (float)Math.Pow(x, y);
        }

        /// <summary>
        /// Função de ativação da rede neural
        /// </summary>
        /// <param name="net"></param>
        /// <param name="funcao">Função a ser utilizada (0 = Logística, 1 = Hiperbólica)</param>
        /// <param name="a"></param>
        /// <returns></returns>
        private float FuncaoAtivacao(float net, int funcao, float a)
        {
            // Função logística
            if (funcao == 0)
            {
                /*
                                1
                  y(n) = ---------------
                         1 + exp(-a.net)
                */
                return (1.0f / (1.0f + this.ExpF(-a * net)));

            }

            // Função Tangente Hiperbólica
            /*
                     exp(a.net) - exp(-a.net)
              y(n) = ------------------------
                     exp(a.net) + exp(-a.net)
            */
            return ((this.ExpF(a * net) - this.ExpF(-a * net)) / (this.ExpF(a * net) + this.ExpF(-a * net)));
        }

        /// <summary>
        /// Executa o cálculo da derivada
        /// </summary>
        /// <param name="net"></param>
        /// <param name="funcao"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private float Derivada(float net, int funcao, float a)
        {
            // Função logística
            if (funcao == 0)
            {

                /*
                                1                       1
                  y(n) = --------------- * ( 1 - --------------- )
                         1 - exp(-a.net)         1 - exp(-a.net)
                 */

                return ((1.0f / (1.0f + this.ExpF(-a * net))) *
                    (1.0f - (1.0f / (1.0f + this.ExpF(-a * net)))));

            }

            // Função Tangente Hiperbólica
            /*
                           exp(a.net) - exp(-a.net)
              y(n) = 1 - ( ------------------------ )²
                           exp(a.net) + exp(-a.net)

            */
            return (1.0f - this.PowF((this.ExpF(a * net) - this.ExpF(-a * net)) /
                (this.ExpF(a * net) + this.ExpF(-a * net)), 2));
        }

        /// <summary>
        /// Inicializa os campos da classe
        /// </summary>
        private void InicializarCampos()
        {
            // Número de padrões a treinar.
            this.padroes = 4;

            // Função Logística(0).
            this.funcao = 0;

            // Taxa de Aprendizado.
            this.taxaAprendizado = (float)this.nudTaxaAprendizado.Value;

            // Termo de momentum.
            this.MOMENTUM = 0.99f;

            // Número máximo de épocas de treinamento.
            this.epocas = Convert.ToUInt64(this.txtEpocas.Text);

            // Altera a barra de progresso
            this.Invoke(new EventHandler(this.AlteraMaximoPgrTreinamento));

            // Variável auxiliar do Erro médio quadrático.
            this.erroMedioQuadratico = 0;

            // Variável auxiliar do erro quadrático.
            this.erroQuadratico = 0;

            // Variável de controle do número de épocas.
            this.contador = 0;

            // String para controle do TextBox com o resultado do treino
            this.StringAtualizacao = string.Empty;
        }

        /// <summary>
        /// Treina a rede embarcada
        /// </summary>
        private void TreinarRede()
        {
            try
            {
                // Define que a thread está em execução
                this.ThreadEmExecucao = true;

                // Chama o evento de atualização dos componentes
                this.Invoke(new EventHandler(this.HabilitarDesabilitarCampos));

                // Inicializa os campos
                this.InicializarCampos();

                // Zera o vetor de pesos da camada de entrada da rede e da camada 1.
                for (j = 0; j < (cx * c1); j++)
                {
                    w1[j] = 0.0f;
                }

                // Zera o vetor de pesos da camada 1 e da camada 2.
                for (j = 0; j < (c1 * c2); j++)
                {
                    w2[j] = 0.0f;
                }

                // Zera os vetores envolvidos aos neurônios da camada 1.
                for (j = 0; j < c1; j++)
                {
                    entradaCamada1[j] = 0.0f;
                    saidaCamada1[j] = 0.0f;
                    erroCamada1[j] = 0.0f;
                }

                // Zera os vetores envolvidos aos neurônios da camada 2.
                for (j = 0; j < c2; j++)
                {
                    entradaCamada2[j] = 0.0f;
                    saidaCamada2[j] = 0.0f;
                    erroCamada2[j] = 0.0f;
                }

                // Randomização dos pesos para a camada 1. 
                for (j = 0; j < (cx * c1); j++)
                {
                    w1[j] = (float)(this.Randomize.NextDouble() % 100) / 1000;
                }

                // Randomização dos pesos para a camada 2.
                for (j = 0; j < (c1 * c2); j++)
                {
                    w2[j] = (float)(this.Randomize.NextDouble() % 100) / 1000;
                }

                // Grava os pesos
                this.GravarPesos();

                // Grava os erros do treinamento
                this.GravarDadosTreinamento();

                // Grava os pesos treinados
                this.GravarPesosTreinados();

                // Teste da rede treinada
                this.TestarRedeTreinada();

                // Define que a thread não está mais em execução
                this.ThreadEmExecucao = false;

                // Chama o evento de atualização dos componentes
                this.Invoke(new EventHandler(this.HabilitarDesabilitarCampos));
            }
            catch (Exception exp)
            {
                MessageBox.Show(
                    string.Format(
                        "[Erro]{0}{1}[StackTrace]{0}{2}",
                        Environment.NewLine,
                        exp.Message,
                        exp.StackTrace));
            }
        }

        /// <summary>
        /// Grava os pesos no arquivo
        /// </summary>
        private void GravarPesos()
        {
            // Grava o arquivo com os pesos
            using (StreamWriter sw = new StreamWriter(this.ArqPesos.FullName))
            {
                // Grava os pesos da camada 1.
                sw.Write(string.Format("PC1{0}", Environment.NewLine));
                for (j = 0; j < (cx * c1); j++)
                {
                    sw.Write(string.Format("{0}{1}", w1[j], Environment.NewLine));
                }

                // Grava os pesos da camada 2.
                sw.Write(string.Format("PC2{0}", Environment.NewLine));
                for (j = 0; j < (c1 * c2); j++)
                {
                    sw.Write(string.Format("{0}{1}", w2[j], Environment.NewLine));
                }

                // fecha o arquivo
                sw.Close();
            }
        }

        /// <summary>
        /// Grava os dados do treinamento
        /// </summary>
        private void GravarDadosTreinamento()
        {
            // Inicio da propagação dos padrões à rede neural.
            using (StreamWriter sw = new StreamWriter(this.ArqTreinamento.FullName))
            {
                // Inicio do treinamento da rede (propagação dos padrões pela rede).
                do
                {
                    // Altera o contador
                    this.contador++;

                    // Chama o evento de atualização da progress bar
                    this.Invoke(new EventHandler(this.AlteraPgrTreinamento));

                    // Propaga os k padrões pela rede.
                    for (k = 0; k < padroes; k++)
                    {
                        // Cálculo para camadas
                        this.CalcularCamadas();

                        // Cálculo do Erro Médio Quadrático
                        this.CalcularErroMedioQuadratico();

                        // Calculo do Erro Medio Quadratico (Criterio de Parada).
                        this.erroMedioQuadratico += (0.5f * this.erroQuadratico);

                        // Realiza a retropropagação do erro
                        this.RetropropagarErro();
                    }

                    // Cálculo do erro médio quadrático da época de treinamento.
                    erroMedioQuadratico = (1.0f / padroes) * this.erroMedioQuadratico;

                    // Grava o erro no arquivo
                    sw.Write(string.Format(
                        "{0}|{1}{2}", (int)contador, this.erroMedioQuadratico, Environment.NewLine));

                    // Atualiza o erro médio quadrático
                    erroMedioQuadratico = 0;
                } while (contador < epocas);

                // Fecha o ponteiro do arquivo de erros de treinamento.
                sw.Close();
            }
        }

        /// <summary>
        /// Realiza o calculo das camadas C1 e C2
        /// </summary>
        private void CalcularCamadas()
        {
            //Cálculo para camada C1.
            int n = 0;
            for (j = 0; j < c1; j++)
            {
                float soma = 0.0f;
                for (i = 0; i < cx; i++)
                {
                    soma += w1[n] * this.p[k, i];
                    n += 1;
                }
                entradaCamada1[j] = soma;
                saidaCamada1[j] = this.FuncaoAtivacao(entradaCamada1[j], funcao, 1.0f);
            }

            //Cálculo para camada C2.
            n = 0;
            for (j = 0; j < c2; j++)
            {
                float soma = 0.0f;
                for (i = 0; i < c1; i++)
                {
                    soma += w2[n] * saidaCamada1[i];
                    n += 1;
                }
                entradaCamada2[j] = soma;
                saidaCamada2[j] = this.FuncaoAtivacao(entradaCamada2[j], funcao, 1.0f);
            }
        }

        /// <summary>
        /// Realiza o cálculo do erro médio quadrático
        /// </summary>
        private void CalcularErroMedioQuadratico()
        {
            this.erroQuadratico = 0;
            for (j = 0; j < c2; j++)
            {
                this.erroQuadratico += this.PowF((d[k, j] - saidaCamada2[j]), 2);
            }
        }

        /// <summary>
        /// Faz o cálculo da retropropagação do erro
        /// </summary>
        private void RetropropagarErro()
        {
            //Calculo do erro para camada 2.
            for (i = 0; i < c2; i++)
            {
                erroCamada2[i] = (d[k, i] - saidaCamada2[i]) *
                    this.Derivada(entradaCamada2[i], funcao, 1.0f);
            }

            //Atualizacao dos pesos para camada 2.
            for (i = 0; i < c1; i++)
            {
                int n = 0;
                for (j = 0; j < c2; j++)
                {
                    dw2[n + i] =
                        taxaAprendizado * saidaCamada1[i] * erroCamada2[j] + (MOMENTUM * dw2[n + i]);
                    w2[n + i] = w2[n + i] + dw2[n + i];
                    n += c1;
                }
            }

            //Calculo do erro para camada 1.
            for (i = 0; i < c1; i++)
            {
                int n = 0;
                float soma = 0.0f;
                for (j = 0; j < c2; j++)
                {
                    soma += (erroCamada2[j] * w2[n + i]);
                    n += c1;
                }
                erroCamada1[i] = soma * this.Derivada(entradaCamada1[i], funcao, 1.0f);
            }

            //Atualizacao dos pesos para camada 1.
            for (i = 0; i < cx; i++)
            {
                int n = 0;
                for (j = 0; j < c1; j++)
                {
                    dw1[n + i] = taxaAprendizado * p[k, i] * erroCamada1[j] + (MOMENTUM * dw1[n + i]);
                    w1[n + i] = w1[n + i] + dw1[n + i];
                    n += cx;
                }
            }
        }

        /// <summary>
        /// Grava os pesos treinados no arquivo
        /// </summary>
        private void GravarPesosTreinados()
        {
            // Grava o arquivo com os pesos
            using (StreamWriter sw = new StreamWriter(this.ArqPesosTreinados.FullName))
            {
                // Grava os pesos da camada 1.
                sw.Write(string.Format("PC1{0}", Environment.NewLine));
                for (j = 0; j < (cx * c1); j++)
                {
                    sw.Write(string.Format("{0}{1}", w1[j], Environment.NewLine));
                }

                // Grava os pesos da camada 2.
                sw.Write(string.Format("PC2{0}", Environment.NewLine));
                for (j = 0; j < (c1 * c2); j++)
                {
                    sw.Write(string.Format("{0}{1}", w2[j], Environment.NewLine));
                }

                // Fecha o arquivo
                sw.Close();
            }
        }

        /// <summary>
        /// Apresenta o teste da rede treinada
        /// </summary>
        private void TestarRedeTreinada()
        {
            for (k = 0; k < padroes; k++)
            {
                // Mostra o padrão no textedit
                this.StringAtualizacao += string.Format("{0}{0}Padrão: {1}", Environment.NewLine, k);
                this.Invoke(new EventHandler(this.AlteraTxtResultadoPesos));

                //Cálculo para camada C1.
                int n = 0;
                for (j = 0; j < c1; j++)
                {
                    float soma = 0.0f;
                    for (i = 0; i < cx; i++)
                    {
                        soma += w1[n] * p[k, i];
                        n += 1;
                    }
                    entradaCamada1[j] = soma;
                    saidaCamada1[j] = this.FuncaoAtivacao(entradaCamada1[j], funcao, 1.0f);
                }

                //Cálculo para camada C2.
                n = 0;
                for (j = 0; j < c2; j++)
                {
                    float soma = 0.0f;
                    for (i = 0; i < c1; i++)
                    {
                        soma += w2[n] * saidaCamada1[i];
                        n += 1;
                    }

                    entradaCamada2[j] = soma;
                    saidaCamada2[j] = this.FuncaoAtivacao(entradaCamada2[j], funcao, 1.0f);
                    saidas[j] = saidaCamada2[j] < 0.5 ? 0 : 1;

                    this.StringAtualizacao += string.Format("{0}Saída: {1}", Environment.NewLine, j);
                    this.Invoke(new EventHandler(this.AlteraTxtResultadoPesos));

                    this.StringAtualizacao += string.Format("{0}Valor: {1}", Environment.NewLine, saidas[j]);
                    this.Invoke(new EventHandler(this.AlteraTxtResultadoPesos));

                }
            }
        }

        /// <summary>
        /// Valida o preenchimento dos campos
        /// </summary>
        private void ValidarCampos()
        {
            // Valida o campo de épocas
            if (string.IsNullOrEmpty(this.txtEpocas.Text))
            {
                this.txtEpocas.Focus();
                throw new Exception("Épocas. Preenchimento obrigatório.");
            }
        }

        /// <summary>
        /// Escreve uma string na porta serial
        /// </summary>
        /// <param name="dado">Dado à ser enviado para a serial</param>
        private void EscreverStringSerial(string dado)
        {
            if (!this.Conexao.IsOpen)
            {
                throw new Exception("Conexão não está aberta.");
            }

            this.Conexao.Write(dado);
        }
        #endregion

        #region Threads para Atualização dos Componentes
        /// <summary>
        /// Atualiza os campos conforme a disponibilidade de funcionamento da thread
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void HabilitarDesabilitarCampos(object sender, EventArgs e)
        {
            this.txtEpocas.Enabled = !this.ThreadEmExecucao;
            this.nudTaxaAprendizado.Enabled = !this.ThreadEmExecucao;
            this.btnApresentarGrafico.Enabled = !this.ThreadEmExecucao;
            this.btnIniciarTreinamento.Enabled = !this.ThreadEmExecucao;
        }

        /// <summary>
        /// Altera o ProgressBar com as informações do contador atual
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AlteraMaximoPgrTreinamento(object sender, EventArgs e)
        {
            this.pgrTreinamento.Maximum = Convert.ToInt32(this.epocas);
        }

        /// <summary>
        /// Altera o ProgressBar com as informações do contador atual
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AlteraPgrTreinamento(object sender, EventArgs e)
        {
            this.pgrTreinamento.Value = Convert.ToInt32(this.contador);
        }

        /// <summary>
        /// Altera o textbox com as informações do teste
        /// </summary>
        /// <param name="sender">Objeto Sender</param>
        /// <param name="e">Objeto EventArgs</param>
        private void AlteraTxtResultadoPesos(object sender, EventArgs e)
        {
            this.txtResultadoPesos.Text = this.StringAtualizacao;
        }
        #endregion
        #endregion
    }
}