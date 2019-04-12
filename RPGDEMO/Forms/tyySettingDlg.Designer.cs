namespace RPGDEMO
{
    partial class tyySettingDlg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tyySettingDlg));
            this.buttonBGM = new System.Windows.Forms.Label();
            this.pictureCheck = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBGM
            // 
            this.buttonBGM.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold);
            this.buttonBGM.Location = new System.Drawing.Point(35, 27);
            this.buttonBGM.Name = "buttonBGM";
            this.buttonBGM.Size = new System.Drawing.Size(255, 47);
            this.buttonBGM.TabIndex = 0;
            this.buttonBGM.Text = "Backgrand Music";
            // 
            // pictureCheck
            // 
            this.pictureCheck.BackColor = System.Drawing.Color.White;
            this.pictureCheck.Image = ((System.Drawing.Image)(resources.GetObject("pictureCheck.Image")));
            this.pictureCheck.Location = new System.Drawing.Point(292, 27);
            this.pictureCheck.Name = "pictureCheck";
            this.pictureCheck.Size = new System.Drawing.Size(48, 48);
            this.pictureCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureCheck.TabIndex = 1;
            this.pictureCheck.TabStop = false;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 1;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // tyySettingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.pictureCheck);
            this.Controls.Add(this.buttonBGM);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "tyySettingDlg";
            this.ShowInTaskbar = false;
            this.Text = "tyySettingDlg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.tyySettingDlg_FormClosing);
            this.Load += new System.EventHandler(this.tyySettingDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tyySettingDlg_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label buttonBGM;
        private System.Windows.Forms.PictureBox pictureCheck;
        private System.Windows.Forms.Timer timerAnimation;
    }
}