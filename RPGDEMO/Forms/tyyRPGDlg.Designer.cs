namespace RPGDEMO
{
    partial class TYYRPGDlg
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
            this._CharacterName = new System.Windows.Forms.Label();
            this._CharacterDlgText = new System.Windows.Forms.Label();
            this.ccHeadPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ccHeadPic)).BeginInit();
            this.SuspendLayout();
            // 
            // _CharacterName
            // 
            this._CharacterName.AutoSize = true;
            this._CharacterName.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._CharacterName.ForeColor = System.Drawing.Color.White;
            this._CharacterName.Location = new System.Drawing.Point(12, 9);
            this._CharacterName.Name = "_CharacterName";
            this._CharacterName.Size = new System.Drawing.Size(239, 36);
            this._CharacterName.TabIndex = 0;
            this._CharacterName.Text = "_CharacterName";
            // 
            // _CharacterDlgText
            // 
            this._CharacterDlgText.AutoSize = true;
            this._CharacterDlgText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CharacterDlgText.ForeColor = System.Drawing.Color.White;
            this._CharacterDlgText.Location = new System.Drawing.Point(12, 47);
            this._CharacterDlgText.Name = "_CharacterDlgText";
            this._CharacterDlgText.Size = new System.Drawing.Size(149, 21);
            this._CharacterDlgText.TabIndex = 0;
            this._CharacterDlgText.Text = "_CharacterDlgText";
            // 
            // ccHeadPic
            // 
            this.ccHeadPic.Location = new System.Drawing.Point(660, 10);
            this.ccHeadPic.Name = "ccHeadPic";
            this.ccHeadPic.Size = new System.Drawing.Size(130, 180);
            this.ccHeadPic.TabIndex = 1;
            this.ccHeadPic.TabStop = false;
            // 
            // TYYRPGDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RPGDEMO.Properties.Resources.dlg_bg;
            this.ClientSize = new System.Drawing.Size(802, 201);
            this.Controls.Add(this.ccHeadPic);
            this.Controls.Add(this._CharacterDlgText);
            this.Controls.Add(this._CharacterName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TYYRPGDlg";
            this.ShowInTaskbar = false;
            this.Text = "tyyRPGDlg";
            this.Load += new System.EventHandler(this.tyyRPGDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tyyRPGDlg_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ccHeadPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label _CharacterDlgText;
        public System.Windows.Forms.Label _CharacterName;
        private System.Windows.Forms.PictureBox ccHeadPic;

    }
}