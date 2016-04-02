using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupervisorioIA2T1
{
    public partial class FrmSupervisorio : Form
    {
        public FrmSupervisorio()
        {
            InitializeComponent();
        }

        private void btnTreino_Click(object sender, EventArgs e)
        {
            FrmChartTreinamento frmChartTreinamento = new FrmChartTreinamento();
            frmChartTreinamento.Show();
        }
    }
}
