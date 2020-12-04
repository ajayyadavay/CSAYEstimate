using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAY_Estimate
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCompoundWall_Click(object sender, EventArgs e)
        {
            FrmSelectCompoundWallType fscwt = new FrmSelectCompoundWallType();
            fscwt.Show();
        }
    }
}
