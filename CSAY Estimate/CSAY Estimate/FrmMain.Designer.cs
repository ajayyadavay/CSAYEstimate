namespace CSAY_Estimate
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnCompoundWall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.White;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Black;
            this.BtnExit.Location = new System.Drawing.Point(771, 390);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(129, 33);
            this.BtnExit.TabIndex = 60;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnCompoundWall
            // 
            this.BtnCompoundWall.BackColor = System.Drawing.Color.White;
            this.BtnCompoundWall.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnCompoundWall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.BtnCompoundWall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.BtnCompoundWall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCompoundWall.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCompoundWall.ForeColor = System.Drawing.Color.Black;
            this.BtnCompoundWall.Location = new System.Drawing.Point(339, 181);
            this.BtnCompoundWall.Name = "BtnCompoundWall";
            this.BtnCompoundWall.Size = new System.Drawing.Size(221, 33);
            this.BtnCompoundWall.TabIndex = 61;
            this.BtnCompoundWall.Text = "Compound Wall";
            this.BtnCompoundWall.UseVisualStyleBackColor = false;
            this.BtnCompoundWall.Click += new System.EventHandler(this.BtnCompoundWall_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(912, 435);
            this.Controls.Add(this.BtnCompoundWall);
            this.Controls.Add(this.BtnExit);
            this.Name = "FrmMain";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnCompoundWall;
    }
}

