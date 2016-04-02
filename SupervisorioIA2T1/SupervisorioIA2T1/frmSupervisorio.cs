namespace SupervisorioIA2T1
{
    using System;
    using System.Windows.Forms;

    public partial class FrmSupervisorio : Form
    {
        public FrmSupervisorio()
        {
            InitializeComponent();
        }

        private void btnTreino_Click(object sender, EventArgs e)
        {
            FrmChartTreinamento frmChartTreinamento = new FrmChartTreinamento();
            frmChartTreinamento.ShowDialog();
        }
    }
}
