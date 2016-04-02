namespace SupervisorioIA2T1
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public partial class FrmChartTreinamento : Form
    {
        #region Construtor
        public FrmChartTreinamento()
        {
            this.InitializeComponent();
            this.PublicarGrafico();
        }
        #endregion

        #region Métodos
        #region Privados
        private void PublicarGrafico()
        {
            try
            {
                grfTreinamento.Series[0].Points.Clear();

                using (StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, "treinamento.txt")))
                {
                    while(true)
                    {
                        string valorLinha = sr.ReadLine();
                        if (string.IsNullOrEmpty(valorLinha))
                        {
                            break;
                        }

                        string[] pontos = valorLinha.Split('\t');
                        double x = Convert.ToDouble(pontos[0].Replace('.', ','));
                        double y = Convert.ToDouble(pontos[1].Replace('.', ','));
                        grfTreinamento.Series[0].Points.AddY(y);
                    }
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(
                    string.Format("Erro{0}{1}StackTrace:{2}",
                    exp.Message,
                    Environment.NewLine,
                    exp.StackTrace));
            }
        }
        #endregion
        #endregion
    }
}
