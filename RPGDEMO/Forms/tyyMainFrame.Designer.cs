namespace RPGDEMO
{
    partial class tyyMainFrame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tyyMainFrame));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rPGDlgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._referencePrint = new System.Windows.Forms.Label();
            this.axWalkPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this._MapLoc = new System.Windows.Forms.Label();
            this._taskName = new System.Windows.Forms.Label();
            this._signal = new System.Windows.Forms.PictureBox();
            this._mainMap = new System.Windows.Forms.PictureBox();
            this._mainCharacter = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWalkPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._signal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mainMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mainCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.developerToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(85, 21);
            this.applicationToolStripMenuItem.Text = "&Application";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // developerToolStripMenuItem
            // 
            this.developerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.rPGDlgToolStripMenuItem});
            this.developerToolStripMenuItem.Name = "developerToolStripMenuItem";
            this.developerToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.developerToolStripMenuItem.Text = "D&eveloper";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.consoleToolStripMenuItem.Text = "R&eference";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // rPGDlgToolStripMenuItem
            // 
            this.rPGDlgToolStripMenuItem.Name = "rPGDlgToolStripMenuItem";
            this.rPGDlgToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.rPGDlgToolStripMenuItem.Text = "RPG&Dlg";
            this.rPGDlgToolStripMenuItem.Click += new System.EventHandler(this.rPGDlgToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "Abou&t";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // _referencePrint
            // 
            this._referencePrint.AutoSize = true;
            this._referencePrint.ForeColor = System.Drawing.Color.White;
            this._referencePrint.Location = new System.Drawing.Point(78, 105);
            this._referencePrint.Name = "_referencePrint";
            this._referencePrint.Size = new System.Drawing.Size(65, 12);
            this._referencePrint.TabIndex = 3;
            this._referencePrint.Text = "Waiting...";
            this._referencePrint.Visible = false;
            // 
            // axWalkPlayer
            // 
            this.axWalkPlayer.Enabled = true;
            this.axWalkPlayer.Location = new System.Drawing.Point(0, 199);
            this.axWalkPlayer.Name = "axWalkPlayer";
            this.axWalkPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWalkPlayer.OcxState")));
            this.axWalkPlayer.Size = new System.Drawing.Size(220, 50);
            this.axWalkPlayer.TabIndex = 5;
            this.axWalkPlayer.Visible = false;
            // 
            // _MapLoc
            // 
            this._MapLoc.AutoSize = true;
            this._MapLoc.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._MapLoc.ForeColor = System.Drawing.Color.White;
            this._MapLoc.Location = new System.Drawing.Point(12, 9);
            this._MapLoc.Name = "_MapLoc";
            this._MapLoc.Size = new System.Drawing.Size(168, 35);
            this._MapLoc.TabIndex = 6;
            this._MapLoc.Text = "Place Name";
            // 
            // _taskName
            // 
            this._taskName.AutoSize = true;
            this._taskName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._taskName.ForeColor = System.Drawing.Color.White;
            this._taskName.Location = new System.Drawing.Point(13, 44);
            this._taskName.Name = "_taskName";
            this._taskName.Size = new System.Drawing.Size(57, 28);
            this._taskName.TabIndex = 6;
            this._taskName.Text = "Task";
            // 
            // _signal
            // 
            this._signal.BackColor = System.Drawing.Color.Silver;
            this._signal.Location = new System.Drawing.Point(700, 600);
            this._signal.Name = "_signal";
            this._signal.Size = new System.Drawing.Size(30, 30);
            this._signal.TabIndex = 4;
            this._signal.TabStop = false;
            // 
            // _mainMap
            // 
            this._mainMap.Location = new System.Drawing.Point(0, 123);
            this._mainMap.Name = "_mainMap";
            this._mainMap.Size = new System.Drawing.Size(72, 93);
            this._mainMap.TabIndex = 2;
            this._mainMap.TabStop = false;
            this._mainMap.WaitOnLoad = true;
            // 
            // _mainCharacter
            // 
            this._mainCharacter.Location = new System.Drawing.Point(0, 38);
            this._mainCharacter.Name = "_mainCharacter";
            this._mainCharacter.Size = new System.Drawing.Size(72, 79);
            this._mainCharacter.TabIndex = 0;
            this._mainCharacter.TabStop = false;
            this._mainCharacter.WaitOnLoad = true;
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(145, 94);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer.TabIndex = 7;
            this.axWindowsMediaPlayer.StatusChange += new System.EventHandler(this.axWindowsMediaPlayer_StatusChange);
            // 
            // tyyMainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this._taskName);
            this.Controls.Add(this._MapLoc);
            this.Controls.Add(this.axWalkPlayer);
            this.Controls.Add(this._signal);
            this.Controls.Add(this._referencePrint);
            this.Controls.Add(this._mainMap);
            this.Controls.Add(this._mainCharacter);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "tyyMainFrame";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrame_Beta";
            this.Deactivate += new System.EventHandler(this.MainFrame_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tyyMainFrame_FormClosed);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFrame_KeyUp);
            this.Leave += new System.EventHandler(this.MainFrame_Deactivate);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tyyMainFrame_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWalkPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._signal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mainMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mainCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _mainCharacter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label _referencePrint;
        private System.Windows.Forms.ToolStripMenuItem rPGDlgToolStripMenuItem;
        private System.Windows.Forms.PictureBox _signal;
        public System.Windows.Forms.PictureBox _mainMap;
        private AxWMPLib.AxWindowsMediaPlayer axWalkPlayer;
        private System.Windows.Forms.Label _MapLoc;
        private System.Windows.Forms.Label _taskName;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;


    }
}

