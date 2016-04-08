namespace SupervisorioIA2T1
{
    using System;
    using System.Windows.Forms;

    public partial class FrmSupervisorio : Form
    {
        #region Construtor
        /// <summary>
        /// Instancia uma instância da classe <see cref="FrmSupervisorio"/>
        /// </summary>
        public FrmSupervisorio()
        {
            InitializeComponent();
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
            FrmTreinamento frmTreinamento = new FrmTreinamento();
            frmTreinamento.ShowDialog();
        }
        #endregion
        #endregion
    }
}
