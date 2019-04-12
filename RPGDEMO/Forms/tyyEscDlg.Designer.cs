namespace RPGDEMO
{
    partial class tyyEscDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tyyEscDlg));
            this.buttonExit = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Label();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.axButPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axButPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(150, 180);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(80, 47);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Exit";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(140, 115);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 47);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            // 
            // buttonContinue
            // 
            this.buttonContinue.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinue.Location = new System.Drawing.Point(115, 50);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(145, 47);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue";
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 1;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // axButPlayer
            // 
            this.axButPlayer.Enabled = true;
            this.axButPlayer.Location = new System.Drawing.Point(12, 246);
            this.axButPlayer.Name = "axButPlayer";
            this.axButPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axButPlayer.OcxState")));
            this.axButPlayer.Size = new System.Drawing.Size(218, 42);
            this.axButPlayer.TabIndex = 1;
            this.axButPlayer.Visible = false;
            // 
            // tyyEscDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.axButPlayer);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonExit);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "tyyEscDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "tyyEscDlg";
            this.Load += new System.EventHandler(this.tyyEscDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tyyEscDlg_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axButPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label buttonExit;
        private System.Windows.Forms.Label buttonSave;
        private System.Windows.Forms.Label buttonContinue;
        private System.Windows.Forms.Timer timerAnimation;
        private AxWMPLib.AxWindowsMediaPlayer axButPlayer;

    }
}