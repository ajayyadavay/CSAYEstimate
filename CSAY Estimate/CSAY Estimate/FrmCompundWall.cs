using System;
using System.IO;
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
    public partial class FrmCompoundWall : Form
    {
        public float Nc, TL,Final_TL, Lw, Lj, Col_L, Col_B, Beam_B, Beam_H,Coping_B,Coping_H;
        public float TotalWall_beam_Len;
        public float  UBrick_Ht, LBrick_Ht, LWall_H, UWall_H;
        public int UWallLayer_No, LWallLayer_No;
        public int a, b, Nj, ANc, Nw;
        public float Foot_PCC_H, Foot_Sol_H, Foot_Proj_PCC;
        public float Brick_PCC_H, Brick_Sol_H, Brick_Proj_PCC;
        public float Foot_Length_L, Foot_Breadth_B, Foot_Rect_H, Foot_Trap_H, Foot_Trap_Proj;
        public float Trap_LArea, Trap_UArea, TotalFinal_Wall_Beam_Len;

        public float Foot_H, WallBelowGL_H;
        public float Upper_Wall_Th, Lower_Wall_Th;
        public int n_row = 54, n_col = 9;

        public float[,] Earthwork = new float[2, 5];
        public float[,] Concretework = new float[7, 5];
        public float[,] Masonrywork = new float[4, 5];
        public float InfoBoard, LabReport, EW_Filling, Reinf;
        public float[] TotalEachQuantity = new float[11];

        private void nLBHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateDimensions();
        }

        

        public void GenerateDetailEstimateRows(int rows)
        {
            for(int i = 1; i< rows; i++)
            {
                dataGridViewDetEst.Rows.Add();
            }
        }
        public void LoadDetailEstimateFormat_CompoundWall()
        {
            try
            {
                string filepath = @".\Format\CompoundWall\CompoundWall.txt";

                string[] lines = System.IO.File.ReadAllLines(filepath);
                string[] rowdata;
                //MessageBox.Show("before for loop i");
                for (int i = 1; i < n_row; i++) //row; i=0 is header in *.txt file so read data from i=1
                {
                    rowdata = lines[i].Split('\t');
                    for (int j = 0; j < n_col; j++)
                    {
                        dataGridViewDetEst.Rows[i-1].Cells[j].Value = rowdata[j];
                    }

                }
                dataGridViewDetEst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells; // Resizes height changes to all cells for Text to fit
                dataGridViewDetEst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch
            {

            }
        }
        public void GenerateDimensions()
        {
            try
            {
                int r,m,n;
                Foot_H = Foot_Sol_H + Foot_PCC_H + Foot_Rect_H + Foot_Trap_H;
                WallBelowGL_H = Brick_Sol_H + Brick_PCC_H + LWall_H; 
                TotalFinal_Wall_Beam_Len = Final_TL - ANc * Col_L + Nj * Lj;
                //1.General------------------------------------------------------------------
                //1.1 Information board
                InfoBoard = 1;
                TotalEachQuantity[0] = InfoBoard;

                //1.2 Lab report
                LabReport = 1;
                TotalEachQuantity[1] = LabReport;

                //2. Earth work------------------------------------------------------------------
                //2.1 Excavation for Column Foundation
                r = 0;
                Earthwork[r, 0] = ANc;
                Earthwork[r, 1] = Foot_Length_L + Foot_Proj_PCC;
                Earthwork[r, 2] = Foot_Breadth_B + Foot_Proj_PCC;
                Earthwork[r, 3] = Foot_H + WallBelowGL_H + Beam_H;
                Earthwork[r, 4] = Earthwork[r, 0] * Earthwork[r, 1] * Earthwork[r, 2] * Earthwork[r, 3];

                //Excavation for Wall Foundation
                r = 1;
                Earthwork[r, 0] = 1;
                Earthwork[r, 1] = TotalFinal_Wall_Beam_Len + Col_L * Nw - (Foot_Length_L + Foot_Proj_PCC) * Nw;
                Earthwork[r, 2] = Lower_Wall_Th + Brick_Proj_PCC * 2;
                Earthwork[r, 3] = WallBelowGL_H + Beam_H;
                Earthwork[r, 4] = Earthwork[r, 0] * Earthwork[r, 1] * Earthwork[r, 2] * Earthwork[r, 3];

                TotalEachQuantity[2] = Earthwork[0, 4] + Earthwork[1, 4];

                //2.2 Earth fill
                EW_Filling = Convert.ToSingle(2.0 / 3.0) * TotalEachQuantity[2];
                TotalEachQuantity[3] = EW_Filling;
                
                //3. Concrete Work------------------------------------------------------------------
                //3.1 PCC for footing
                r = 0;
                Concretework[r, 0] = ANc;
                Concretework[r, 1] = Foot_Length_L + Foot_Proj_PCC;
                Concretework[r, 2] = Foot_Breadth_B + Foot_Proj_PCC;
                Concretework[r, 3] = Foot_PCC_H;
                Concretework[r, 4] = Concretework[r, 0] * Concretework[r, 1] * Concretework[r, 2] * Concretework[r, 3];

                //PCC for Wall
                r = 1;
                Concretework[r, 0] = 1;
                Concretework[r, 1] = TotalFinal_Wall_Beam_Len;
                Concretework[r, 2] = Lower_Wall_Th + Brick_Proj_PCC * 2;
                Concretework[r, 3] = Brick_PCC_H;
                Concretework[r, 4] = Concretework[r, 0] * Concretework[r, 1] * Concretework[r, 2] * Concretework[r, 3];

                //Coping
                r = 2;
                Concretework[r, 0] = 1;
                Concretework[r, 1] = Final_TL;
                Concretework[r, 2] = Coping_B; // Upper_Wall_Th 
                Concretework[r, 3] = Coping_H;
                Concretework[r, 4] = Concretework[r, 0] * Concretework[r, 1] * Concretework[r, 2] * Concretework[r, 3];

                TotalEachQuantity[4] = Concretework[0, 4] + Concretework[1, 4] + Concretework[2, 4];

                //3.2 Column foundation base (Rectangular)
                r = 3;
                Concretework[r, 0] = ANc;
                Concretework[r, 1] = Foot_Length_L;
                Concretework[r, 2] = Foot_Breadth_B;
                Concretework[r, 3] = Foot_Rect_H;
                Concretework[r, 4] = Concretework[r, 0] * Concretework[r, 1] * Concretework[r, 2] * Concretework[r, 3];

                //Slope Part Top of Trapezoidal
                r = 4;
                Concretework[r, 0] = ANc;
                Concretework[r, 1] = Col_L + Foot_Trap_Proj * 2;
                Concretework[r, 2] = Col_B + Foot_Trap_Proj * 2;
                Concretework[r, 3] = Foot_Trap_H;
                Trap_LArea = Foot_Length_L * Foot_Breadth_B;
                Trap_UArea = Concretework[r, 1] * Concretework[r, 2];
                float sumArea, SqrRt;
                sumArea = Trap_LArea + Trap_UArea;
                SqrRt = Convert.ToSingle(Math.Sqrt(Trap_LArea * Trap_UArea));
                float Trap_Volume = Concretework[r, 3] / 3 * (sumArea + SqrRt);
                Concretework[r, 4] = Trap_Volume * ANc;

                //Tie Beam
                r = 5;
                Concretework[r, 0] = 1;
                Concretework[r, 1] = TotalFinal_Wall_Beam_Len;
                Concretework[r, 2] = Beam_B;
                Concretework[r, 3] = Beam_H;
                Concretework[r, 4] = Concretework[r, 0] * Concretework[r, 1] * Concretework[r, 2] * Concretework[r, 3];

                //Column
                r = 6;
                Concretework[r, 0] = ANc;
                Concretework[r, 1] = Col_L;
                Concretework[r, 2] = Col_B;
                Concretework[r, 3] = WallBelowGL_H + Beam_H + UWall_H;
                Concretework[r, 4] = Concretework[r, 0] * Concretework[r, 1] * Concretework[r, 2] * Concretework[r, 3];

                TotalEachQuantity[5] = Concretework[3, 4] + Concretework[4, 4] + Concretework[5, 4] + Concretework[6, 4];

                //3.3 Reiforcement
                Reinf = 4000;
                TotalEachQuantity[6] = Reinf;

                //4. Masonry------------------------------------------------------------------
                //4.1 Column Foundation soling
                r = 0;
                Masonrywork[r, 0] = ANc;
                Masonrywork[r, 1] = Foot_Length_L + Foot_Proj_PCC;
                Masonrywork[r, 2] = Foot_Breadth_B + Foot_Proj_PCC;
                Masonrywork[r, 3] = Foot_Sol_H;
                Masonrywork[r, 4] = Masonrywork[r, 0] * Masonrywork[r, 1] * Masonrywork[r, 2] * Masonrywork[r, 3];

                //Wall Foundation soling
                r = 1;
                Masonrywork[r, 0] = 1;
                Masonrywork[r, 1] = TotalFinal_Wall_Beam_Len;
                Masonrywork[r, 2] = Lower_Wall_Th + Brick_Proj_PCC * 2;
                Masonrywork[r, 3] = Brick_Sol_H;
                Masonrywork[r, 4] = Masonrywork[r, 0] * Masonrywork[r, 1] * Masonrywork[r, 2] * Masonrywork[r, 3];

                TotalEachQuantity[7] = Masonrywork[0, 4] + Masonrywork[1, 4];

                //4.2 Lower brick work
                r = 2;
                Masonrywork[r, 0] = 1;
                Masonrywork[r, 1] = TotalFinal_Wall_Beam_Len;
                Masonrywork[r, 2] = Lower_Wall_Th;
                Masonrywork[r, 3] = LWall_H;
                Masonrywork[r, 4] = Masonrywork[r, 0] * Masonrywork[r, 1] * Masonrywork[r, 2] * Masonrywork[r, 3];

                TotalEachQuantity[8] = Masonrywork[2, 4];

                //4.3 Upper brick work
                r = 3;
                Masonrywork[r, 0] = 1;
                Masonrywork[r, 1] = TotalFinal_Wall_Beam_Len;
                Masonrywork[r, 2] = Upper_Wall_Th;
                Masonrywork[r, 3] = UWall_H;
                Masonrywork[r, 4] = Masonrywork[r, 0] * Masonrywork[r, 1] * Masonrywork[r, 2] * Masonrywork[r, 3];

                TotalEachQuantity[9] = Masonrywork[3, 4];

                //Write Dimension and product to Datagridview of Detail Estimate
                dataGridViewDetEst.Rows[1].Cells[6].Value = InfoBoard.ToString("0.000"); //1.1
                dataGridViewDetEst.Rows[4].Cells[6].Value = LabReport.ToString("0.000"); //1.2

                WriteToDataGridViewOfDetEst(9, 10, 0, Earthwork); //2.1 Earthwork
                dataGridViewDetEst.Rows[14].Cells[6].Value = EW_Filling.ToString("0.000"); //2.2

                WriteToDataGridViewOfDetEst(19, 21, 0, Concretework); //3.1 Concrete work
                WriteToDataGridViewOfDetEst(25, 28, 3, Concretework); //3.2 Concrete work
                dataGridViewDetEst.Rows[32].Cells[6].Value = Reinf.ToString("0.000"); //3.3

                WriteToDataGridViewOfDetEst(37, 38, 0, Masonrywork); //4.1 Masonry work
                WriteToDataGridViewOfDetEst(42, 42, 2, Masonrywork); //4.2 Masonry work
                WriteToDataGridViewOfDetEst(46, 46, 3, Masonrywork); //4.3 Masonry work

                //Write Total of each quantity to Datagridview of Detail Estimate
                dataGridViewDetEst.Rows[2].Cells[6].Value = TotalEachQuantity[0].ToString("0.000");
                dataGridViewDetEst.Rows[5].Cells[6].Value = TotalEachQuantity[1].ToString("0.000");

                dataGridViewDetEst.Rows[11].Cells[6].Value = TotalEachQuantity[2].ToString("0.000");
                dataGridViewDetEst.Rows[15].Cells[6].Value = TotalEachQuantity[3].ToString("0.000");

                dataGridViewDetEst.Rows[22].Cells[6].Value = TotalEachQuantity[4].ToString("0.000");
                dataGridViewDetEst.Rows[29].Cells[6].Value = TotalEachQuantity[5].ToString("0.000");
                dataGridViewDetEst.Rows[33].Cells[6].Value = TotalEachQuantity[6].ToString("0.000");

                dataGridViewDetEst.Rows[39].Cells[6].Value = TotalEachQuantity[7].ToString("0.000");
                dataGridViewDetEst.Rows[43].Cells[6].Value = TotalEachQuantity[8].ToString("0.000");
                dataGridViewDetEst.Rows[47].Cells[6].Value = TotalEachQuantity[9].ToString("0.000");
            }
            catch
            {

            }
        }
        public void WriteToDataGridViewOfDetEst(int StartRow, int EndRow, int StartIndex, float[,] Work)
        {
            int m, n;
            m = StartIndex;
            for (int i = StartRow; i <= EndRow; i++)
            {
                n = 0;
                for (int j = 2; j <= 6; j++)
                {
                    dataGridViewDetEst.Rows[i].Cells[j].Value = Work[m, n].ToString("0.000");
                    n++;
                }
                m++;
            }
        }
        public void ProductOfDimensions()
        {
            try
            {

            }
            catch
            {

            }
        }
        public void TotalSumOfEachWork()
        {
            try
            {

            }
            catch
            {

            }
        }
        private void TxtUpperWall_UTh_TextChanged(object sender, EventArgs e)
        {
            TxtCoping_B.Text = TxtUpperWall_UTh.Text;
        }

        private void TxtUpperLayer_UNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateTotalUpperWallHeight();
            }
            catch
            {

            }
        }
        public void CalculateTotalLowerWallHeight()
        {
            LWallLayer_No = Convert.ToInt32(TxtLowerLayer_LNo.Text);
            LBrick_Ht = Convert.ToSingle(TxtBrickTh_BL_Ht.Text);
            LWall_H = LWallLayer_No * LBrick_Ht;

            TxtL_Wall_H.Text = LWall_H.ToString("0.000");
        }
        public void CalculateTotalUpperWallHeight()
        {
            UWallLayer_No = Convert.ToInt32(TxtUpperLayer_UNo.Text);
            UBrick_Ht = Convert.ToSingle(TxtBrickTh_BU_Ht.Text);
            UWall_H = UWallLayer_No * UBrick_Ht;

            TxtU_Wall_H.Text = UWall_H.ToString("0.000");
        }

        private void TxtLowerLayer_LNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateTotalLowerWallHeight();
            }
            catch
            {

            }
        }

        private void TxtBrickTh_BLTh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateTotalLowerWallHeight();
            }
            catch
            {

            }
        }

        private void TxtBrickTh_BUTh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateTotalUpperWallHeight();
            }
            catch
            {

            }
        }

       

        private void TxtActualColNo_ANc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Input();
                ANc = Convert.ToInt32(TxtActualColNo_ANc.Text);

                Nw = ANc - a - (b - 1);
                Final_TL = ANc * Col_L + Nw * Lw + Nj * Lj;
                TotalWall_beam_Len = Nw * Lw;

                TxtFinal_TL.Text = Final_TL.ToString("0.000");
                Txt_No_Wall_bet_Col_Nw.Text = Nw.ToString();
                TxtTotalLen_wall_Beam.Text = TotalWall_beam_Len.ToString();
            }
            catch
            {

            }
        }

        public FrmCompoundWall()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCompoundWall_Load(object sender, EventArgs e)
        {
            ComboBoxWallType.Items.Add("OPEN");
            ComboBoxWallType.Items.Add("CLOSE");

            GenerateDetailEstimateRows(n_row);
            LoadDetailEstimateFormat_CompoundWall();
        }

        private void ComboBoxWallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBoxWallType.Text == "OPEN")
            {
                TxtWallType_a.Text = "1";
            }
            if (ComboBoxWallType.Text == "CLOSE")
            {
                TxtWallType_a.Text = "0";
            }
        }

        private void TxtColumn_B_TextChanged(object sender, EventArgs e)
        {
            TxtJunction_Lj.Text = TxtColumn_B.Text;
        }

        private void Txt_Wall_bet_Col_Lw_TextChanged(object sender, EventArgs e)
        {
            TxtBrickwallPCC_L.Text = Txt_Wall_bet_Col_Lw.Text;
        }

        private void BtnGenerateColumnNo_Click(object sender, EventArgs e)
        {
            try
            {
                Input();
                Nc = (TL - Nj * Lj + a * Lw + (b - 1) * Lw) / (Col_L + Lw);
                //Nw = Nc - a - (b - 1);
                TxtCol_Nc.Text = Nc.ToString("0.000");
                //Txt_No_Wall_bet_Col_Nw.Text = Nw.ToString("0.00");
            }
            catch
            {

            }
            
        }
        public void Input()
        {
            //PCC and soling for footing
            Foot_PCC_H = Convert.ToSingle(TxtFootingPCC_H.Text);
            Foot_Sol_H = Convert.ToSingle(TxtFootingSoling_H.Text);
            Foot_Proj_PCC = Convert.ToSingle(TxtFootingProjectionPCC.Text);

            //PCC and soling for brick wall
            Brick_PCC_H = Convert.ToSingle(TxtBrickwallPCC_H.Text);
            Brick_Sol_H = Convert.ToSingle(TxtBrickwallSoling_H.Text);
            Brick_Proj_PCC = Convert.ToSingle(TxtBrickwallPCC_Proj.Text);

            //Footing Dimension
            Foot_Length_L = Convert.ToSingle(TxtFooting_L.Text);
            Foot_Breadth_B = Convert.ToSingle(TxtFooting_B.Text);
            Foot_Rect_H = Convert.ToSingle(TxtFooting_H_Rect.Text);
            Foot_Trap_H = Convert.ToSingle(TxtFooting_H_Trap.Text);
            Foot_Trap_Proj = Convert.ToSingle(TxtFooting_Proj_trap.Text);

            //Tie beam, column and coping section
            Beam_B = Convert.ToSingle(TxtBeam_B.Text);
            Beam_H = Convert.ToSingle(TxtBeam_H.Text);
            Col_L = Convert.ToSingle(TxtColumn_L.Text);
            Col_B = Convert.ToSingle(TxtColumn_B.Text);
            Coping_B = Convert.ToSingle(TxtCoping_B.Text);
            Coping_H = Convert.ToSingle(TxtCoping_H.Text);

            //General
            a = Convert.ToInt32(TxtWallType_a.Text); //wall type a = 1 for open, a = 0 for close
            b = Convert.ToInt32(TxtIndividualCWallNo_b.Text); //no. of individual walls
            Lw = Convert.ToSingle(Txt_Wall_bet_Col_Lw.Text); //length of wall between two columns
            Nj = Convert.ToInt32(TxtJunction_Nj.Text); //no. of junction
            TL = Convert.ToSingle(TxtTotalCompoundWall_TL.Text); //total length initially
            Lj = Convert.ToSingle(TxtJunction_Lj.Text); // length of junction

            //Input for wall
            Upper_Wall_Th = Convert.ToSingle(TxtUpperWall_UTh.Text);//0.23
            Lower_Wall_Th = Convert.ToSingle(TxtLowerWall_LTh.Text);//0.23
            UWallLayer_No = Convert.ToInt32(TxtUpperLayer_UNo.Text);//22
            UBrick_Ht = Convert.ToSingle(TxtBrickTh_BU_Ht.Text);//0.067
            LWallLayer_No = Convert.ToInt32(TxtLowerLayer_LNo.Text);//5
            LBrick_Ht = Convert.ToSingle(TxtBrickTh_BL_Ht.Text);//0.067 = 57mm + 10mm (10mm for mortar)
        }
    }
}
