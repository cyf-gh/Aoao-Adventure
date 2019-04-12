using System;
using System.Drawing;
using System.Windows.Forms;

/////////VWRD 2014
namespace RPGDEMO
{
    public class TYYCoreGUI
    {

        //rpg游戏的对话框基本设置
        public static void tyyRPGDlgProcess(Form mainForm, Form rpgDlg)
        {

                rpgDlg.Show();
                rpgDlg.Size = new Size(TYYCoreDataDyn.tyyInitRPGDlgSize);
                rpgDlg.Location = new Point(mainForm.Location.X,
                                            mainForm.Location.Y + mainForm.Size.Height - rpgDlg.Size.Height);
                mainForm.Focus();
        }

        public static void tyyRPGDlgSetText(Label _CharacterName, Label _CharacterDlgText, String CCname, String CCText)
        {
            _CharacterName.Text = CCname;
            _CharacterDlgText.Text = CCText;
        }

        //错误对话框
        public static void tyyErrMsg(String errorInfo)
        {
            MessageBox.Show(errorInfo, "VWRD Software", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //设置按钮颜色
        public static void tyyButtonColorChange(Label buttonName, Boolean isChangeIntoWhite)
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
    }
}