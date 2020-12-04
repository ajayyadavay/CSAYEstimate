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
    public partial class FrmSelectCompoundWallType : Form
    {
        public FrmSelectCompoundWallType()
        {
            InitializeComponent();
        }

        private void Btn_CW_Type1_Click(object sender, EventArgs e)
        {
            FrmCompoundWall fcwall = new FrmCompoundWall();
            fcwall.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
