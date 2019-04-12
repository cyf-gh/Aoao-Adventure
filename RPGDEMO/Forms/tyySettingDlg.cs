using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPGDEMO
{
    public partial class tyySettingDlg : Form
    {
        public tyySettingDlg()
        {
            InitializeComponent();
        }

        TYYCoreDataSav mySavement = new TYYCoreDataSav();
        TYYCoreDataLoc myLocData = new TYYCoreDataLoc();
        List<Label> buttonList = new List<Label>();
        int buttonChoseIndex = 0;
        int button1X;
        Boolean isNeedBgm = false;

        private void tyySettingDlg_Load(object sender, EventArgs e)
        {
            buttonList.Add(buttonBGM);
            this.buttonLocInit();

            isNeedBgm = myLocData.tyyGetIsBgmNeed();
            if (isNeedBgm)pictureCheck.Image = Properties.Resources.chc;
            else pictureCheck.Image = null;


            TYYCoreGUI.tyyButtonColorChange(buttonList[buttonChoseIndex], false);

            timerAnimation.Enabled = true;

            this.Size = new Size(400, 300);
            this.CenterToParent();
        }

        private void tyySettingDlg_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.Space:
                    if (buttonChoseIndex == 0)
                    {
                        if (isNeedBgm)
                        {
                            pictureCheck.Image = null;
                            isNeedBgm = false; 
                        }
                        else
                        {
                            pictureCheck.Image = Properties.Resources.chc;
                            isNeedBgm = true;
                        }
                    }
                    break;

                default :
                    return;
            }
        }

        private void buttonLocInit()
        {
            buttonList[0].Location = new Point(0 - buttonList[0].Width, buttonList[0].Location.Y);

            button1X = buttonList[0].Location.X;
        }

        private void tyySettingDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
                        mySavement.tyySaveBgm(isNeedBgm);
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (buttonList[0].Location.X != 35) buttonList[0].Location = new Point(button1X, buttonList[0].Location.Y);

            if (buttonList[0].Location.X == 35)
            {
                timerAnimation.Enabled = false;
            }

            button1X = button1X + 10;
        }
    }
}
