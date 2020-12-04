namespace CSAY_Estimate
{
    partial class FrmSelectCompoundWallType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectCompoundWallType));
            this.Btn_CW_Type1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_CW_Type1
            // 
            this.Btn_CW_Type1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_CW_Type1.BackgroundImage")));
            this.Btn_CW_Type1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_CW_Type1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Btn_CW_Type1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_CW_Type1.ForeColor = System.Drawing.Color.Black;
            this.Btn_CW_Type1.ImageKey = "(none)";
            this.Btn_CW_Type1.Location = new System.Drawing.Point(107, 67);
            this.Btn_CW_Type1.Name = "Btn_CW_Type1";
            this.Btn_CW_Type1.Size = new System.Drawing.Size(293, 236);
            this.Btn_CW_Type1.TabIndex = 0;
            this.Btn_CW_Type1.UseVisualStyleBackColor = true;
            this.Btn_CW_Type1.Click += new System.EventHandler(this.Btn_CW_Type1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(213, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type 1";
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.BackColor = System.Drawing.Color.White;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Black;
            this.BtnExit.Location = new System.Drawing.Point(356, 389);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(126, 32);
            this.BtnExit.TabIndex = 61;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FrmSelectCompoundWallType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 433);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_CW_Type1);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "FrmSelectCompoundWallType";
            this.Text = "Compound Wall Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_CW_Type1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExit;
    }
}