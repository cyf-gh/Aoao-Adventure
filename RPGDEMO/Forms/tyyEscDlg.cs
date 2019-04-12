using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RPGDEMO
{
    public partial class tyyEscDlg : Form
    {
        private Point _mapLoc;
        private String _mapPath;
        private TYYCoreDataLoc locData = new TYYCoreDataLoc();

        public tyyEscDlg(Point mapLoc, String mapPath)
        {
            _mapLoc = mapLoc;
            _mapPath = mapPath;
            InitializeComponent();
        }

        private List<Label> buttonList = new List<Label>();
        private int buttonChoseIndex = 0;

        private int button1X;
        private int button2X;
        private int button3X;

        private void tyyEscDlg_Load(object sender, EventArgs e)
        {
            buttonList.Add(buttonContinue);
            buttonList.Add(buttonSave);
            buttonList.Add(buttonExit);

            this.buttonLocInit();
            timerAnimation.Interval = 1;
            timerAnimation.Enabled = true;

            TYYCoreGUI.tyyButtonColorChange(buttonList[buttonChoseIndex], false);

            axButPlayer.URL = locData.tyyButtonSound;
            axButPlayer.Ctlcontrols.stop();

            this.Size = new Size(400, 300);
            this.CenterToParent();
        }

        private void tyyEscDlg_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (buttonChoseIndex == 0)
                    {
                        buttonChoseIndex = 2;
                        TYYCoreGUI.tyyButtonColorChange(buttonContinue, true);
                        TYYCoreGUI.tyyButtonColorChange(buttonExit, false);
                    }
                    else
                    {
                        buttonChoseIndex--;
                        TYYCoreGUI.tyyButtonColorChange(buttonList[buttonChoseIndex + 1], true);
                        TYYCoreGUI.tyyButtonColorChange(buttonList[buttonChoseIndex], false);
                    }
                    break;

                case Keys.Down:
                    if (buttonChoseIndex == 2)
                    {
                        buttonChoseIndex = 0;
                        TYYCoreGUI.tyyButtonColorChange(buttonExit, true);
                        TYYCoreGUI.tyyButtonColorChange(buttonContinue, false);
                    }
                    else
                    {
                        buttonChoseIndex++;
                        TYYCoreGUI.tyyButtonColorChange(buttonList[buttonChoseIndex - 1], true);
                        TYYCoreGUI.tyyButtonColorChange(buttonList[buttonChoseIndex], false);
                    }
                    break;

                case Keys.Space:
                    if (buttonChoseIndex == 0)//继续
                    {
                        this.Hide();
                    }
                    else if (buttonChoseIndex == 1)//保存
                    {
                        TYYCoreGUI.tyyErrMsg("So sorry that we don't offer Save Function in this game" + "\n" + "VWRD is terribly sorry");
                        //TYYCoreDataSav saveData = new TYYCoreDataSav();
                        //saveData.tyySaveMapInfo(_mapLoc, _mapPath);
                    }
                    else if (buttonChoseIndex == 2)//退出
                    {
                        Application.Exit();
                    }

                    break;

                case Keys.Escape:
                    this.Hide();
                    break;

                default: return;
            }
            axButPlayer.Ctlcontrols.stop();
            axButPlayer.Ctlcontrols.play();
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (buttonList[0].Location.X != 115) buttonList[0].Location = new Point(button1X, buttonList[0].Location.Y);
            if (buttonList[2].Location.X != 140) buttonList[2].Location = new Point(button2X, buttonList[2].Location.Y);
            if (buttonList[1].Location.X != 150) buttonList[1].Location = new Point(button3X, buttonList[1].Location.Y);

            if (buttonList[0].Location.X == 115 && buttonList[2].Location.X == 140 && buttonList[1].Location.X == 150)
            {
                timerAnimation.Enabled = false;
            }
            button1X = button1X + 10;
            button2X = button2X + 10;
            button3X = button3X - 10;
        }

        private void buttonLocInit()
        {
            buttonList[0].Location = new Point(0 - buttonList[0].Width, buttonList[0].Location.Y);
            buttonList[1].Location = new Point(this.Width + buttonList[1].Width, buttonList[1].Location.Y);
            buttonList[2].Location = new Point(0 - buttonList[2].Width, buttonList[2].Location.Y);

            button1X = buttonList[0].Location.X;
            button2X = buttonList[2].Location.X;
            button3X = buttonList[1].Location.X;
        }
    }
}