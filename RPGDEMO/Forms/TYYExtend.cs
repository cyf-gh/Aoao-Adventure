using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RPGDEMO
{
    internal class TYYExtend : Form
    {
        public TYYExtend(Form parentForm)
        {
            this.Size = new Size(800, 600);
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.TopMost = true;
            WebBrowser EXTENDWEB = new WebBrowser();
            EXTENDWEB.Parent = this;
            EXTENDWEB.Size = this.Size;
            EXTENDWEB.Url = new Uri("http://www.bilibili.tv");
            EXTENDWEB.ScriptErrorsSuppressed = true;
            Button EXTENDBUT = new Button();
            EXTENDBUT.Text = "Close";
            EXTENDBUT.Location = new Point(0, 0);
            EXTENDBUT.Parent = EXTENDWEB;
            EXTENDBUT.Click += EXTENDBUT_Click;
            this.Show();
        }

        void EXTENDBUT_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
    }
}