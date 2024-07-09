using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class frmRapor : Form
    {
        public frmRapor()
        {
            InitializeComponent();
        }

        private void frmRapor_Load(object sender, EventArgs e)
        {
            CrystalReport1 rapor = new CrystalReport1();
            crystalReportViewer1.ReportSource = rapor;
        }
    }
}
