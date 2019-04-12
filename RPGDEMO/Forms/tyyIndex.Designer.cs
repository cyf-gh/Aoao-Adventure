namespace RPGDEMO
{
    partial class tyyIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tyyIndex));
            this.buttonExit = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Label();
            this.axButPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axButPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Black;
            this.buttonExit.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(306, 364);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 45);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Exit";
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.Black;
            this.buttonPlay.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.ForeColor = System.Drawing.Color.White;
            this.buttonPlay.Location = new System.Drawing.Point(306, 235);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(96, 45);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.Black;
            this.buttonSettings.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.Location = new System.Drawing.Point(280, 299);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(141, 45);
            this.buttonSettings.TabIndex = 0;
            this.buttonSettings.Text = "Settings";
            // 
            // axButPlayer
            // 
            this.axButPlayer.Enabled = true;
            this.axButPlayer.Location = new System.Drawing.Point(12, 364);
            this.axButPlayer.Name = "axButPlayer";
            this.axButPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axButPlayer.OcxState")));
            this.axButPlayer.Size = new System.Drawing.Size(238, 47);
            this.axButPlayer.TabIndex = 1;
            this.axButPlayer.Visible = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(595, 440);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(77, 12);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Beta 0.0.0.1";
            // 
            // tyyIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.ControlBox = false;
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.axButPlayer);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "tyyIndex";
            this.Text = "VW RPG Creator beta";
            this.Activated += new System.EventHandler(this.tyyIndex_Activated);
            this.Deactivate += new System.EventHandler(this.tyyIndex_Deactivate);
            this.Load += new System.EventHandler(this.tyyIndex_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tyyIndex_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axButPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label buttonExit;
        private System.Windows.Forms.Label buttonPlay;
        private System.Windows.Forms.Label buttonSettings;
        private AxWMPLib.AxWindowsMediaPlayer axButPlayer;
        private System.Windows.Forms.Label labelVersion;
    }
}