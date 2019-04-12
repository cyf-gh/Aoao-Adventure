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
    public partial class tyyIndex : Form
    {
        public tyyIndex()
        {
            InitializeComponent();
        }

        List<Label>buttonList = new List<Label>();
        tyyMainFrame mainFrame = new tyyMainFrame();
        tyySettingDlg setFrame = new tyySettingDlg();
        TYYCoreDataLoc locData = new TYYCoreDataLoc();
        int buttonChoseIndex = 0;
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            mainFrame.Show();
            this.Hide();
        }

        private void tyyIndex_Load(object sender, EventArgs e)
        {
            //销毁鼠标
            this.Cursor.Dispose();
            this.CenterToScreen();

            buttonList.Add(buttonPlay);
            buttonList.Add(buttonSettings);
            buttonList.Add(buttonExit);

            tyyButtonColorChange(buttonList[buttonChoseIndex],false);
            this.Focus();

            axButPlayer.URL = locData.tyyButtonSound;
            axButPlayer.Ctlcontrols.stop();
        }

        private void tyyIndex_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (buttonChoseIndex == 0)
                    {
                        buttonChoseIndex = 2;
                        tyyButtonColorChange(buttonPlay, true);
                        tyyButtonColorChange(buttonExit, false);
                    }
                    else
                    {
                        buttonChoseIndex--;
                        tyyButtonColorChange(buttonList[buttonChoseIndex + 1], true);
                        tyyButtonColorChange(buttonList[buttonChoseIndex], false);
                    }
                    break;

                case Keys.Down:
                    if (buttonChoseIndex == 2)
                    {
                        buttonChoseIndex = 0;
                        tyyButtonColorChange(buttonExit, true);
                        tyyButtonColorChange(buttonPlay, false);
                    }
                    else
                    {
                        buttonChoseIndex++;
                        tyyButtonColorChange(buttonList[buttonChoseIndex - 1], true);
                        tyyButtonColorChange(buttonList[buttonChoseIndex], false);
                    }
                    break;

                case Keys.Space:
                    if (buttonChoseIndex == 0)
                    {
                        this.axButPlayer.Dispose();
                        this.CenterToScreen();
                        mainFrame.ShowDialog();
                    }
                    else if (buttonChoseIndex == 1)                  
                    {
                        TYYCoreGUI.tyyErrMsg("This game do not need any settings" + "\n" + "VWRD is terribly sorry");
                        //setFrame.ShowDialog();
                    }
                    else if (buttonChoseIndex == 2)
                    {
                        Application.Exit();
                    }
                    break;

                default: return;
            }
            try
            {
                axButPlayer.Ctlcontrols.stop();
                axButPlayer.Ctlcontrols.play();
            }
            catch
            {
                return;
            }
        }

        private void tyyButtonColorChange(Label buttonName,Boolean isChangeIntoWhite)
        {
            if (isChangeIntoWhite)
            {
                Label currentButton = buttonName;
                currentButton.ForeColor = Color.White;
            }
            else
            {
                Label currentButton = buttonName;
                currentButton.ForeColor = Color.Gray;
            }

        }

        private void tyyIndex_Deactivate(object sender, EventArgs e)
        {
        }

        private void tyyIndex_Activated(object sender, EventArgs e)
        {
        }


        //private void playMusic(AxWMPLib.AxWindowsMediaPlayer _player, String music)
        //{
        //    _player.URL = locData.tyyGetBgmUrl(music);//"min.mid");
        //    _player.Ctlcontrols.play();
        //    _player.settings.setMode("loop", true);
        //    isPlaying = true;
        //}
    }
}
