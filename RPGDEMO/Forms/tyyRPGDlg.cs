using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RPGDEMO
{
    public partial class TYYRPGDlg : Form
    {
        private TYYExtend MY_EXTEND;

        //威严
        private bool isEnd = false;

        private bool OB_MOD = false;

        //LEVEL
        public List<String> tyyNpcNameList = new List<string>();

        public List<String> tyyNpcDlgList = new List<string>();

        public bool isVisiable = false;

        private int dlgIndex;
        private int nameIndex;
        public TYYRPGDlg()
        {
            InitializeComponent();
            this.Hide();
        }

        public void tyySetText(String _cname, String _cdlgtext)
        {
            this._CharacterName.Text = _cname;//access input
            this._CharacterDlgText.Text = _cdlgtext;//access input
            if (_cname == "敖厂长")
            {
                this.ccHeadPic.Location = new Point(660, 10);
                this.ccHeadPic.Image = Properties.Resources.ao_h;
                this.ccHeadPic.Visible = true;
            }
            else if (_cname == "王尼玛")
            {
                this.ccHeadPic.Location = new Point(660, 10);

                this.ccHeadPic.Visible = true;
            }
            else
            {
                this.ccHeadPic.Visible = false;
            }
        }

        public void tyySetList(List<String> nameList, List<String> dlgList, bool isGen, int num)
        {
            this.Focus();
            this.tyyNpcDlgList = dlgList;
            this.tyyNpcNameList = nameList;
            this.OB_MOD = isGen;
            this.dlgIndex = 0;

            if (!isGen)
            {
                this.tyySetText(this.tyyNpcNameList[this.dlgIndex], this.tyyNpcDlgList[this.dlgIndex]);
            }
            else
            {
                this.nameIndex = num;
                this.tyySetText(this.tyyNpcNameList[nameIndex], this.tyyNpcDlgList[this.dlgIndex]);
            }
        }

        private void tyyRPGDlg_Load(object sender, EventArgs e)
        {
            this.Cursor.Dispose();
            this._CharacterDlgText.Parent = this;
            this._CharacterName.Parent = this;
            this._CharacterDlgText.BackColor = Color.Transparent;
            this._CharacterName.BackColor = Color.Transparent;
            this._CharacterName.Location = new Point(100, 0);
            this._CharacterDlgText.Location = new Point(100, _CharacterName.Height + 10);
            this.Focus();
            isVisiable = true;
        }

        private void tyyRPGDlg_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.dlgIndex == this.tyyNpcDlgList.Count && (e.KeyCode == Keys.Escape || e.KeyCode == Keys.A || e.KeyCode == Keys.Up || e.KeyCode == Keys.D || e.KeyCode == Keys.Down || e.KeyCode == Keys.S || e.KeyCode == Keys.Right || e.KeyCode == Keys.E || e.KeyCode == Keys.Left))
            {
                this.Visible = false;
            }
            else if (e.KeyCode == Keys.Space)
            {
                this.dlgIndex++;
                    try
                    {
                        if (this.OB_MOD == false)
                            this.tyySetText(this.tyyNpcNameList[this.dlgIndex], this.tyyNpcDlgList[this.dlgIndex]);
                        else
                            this.tyySetText(this.tyyNpcNameList[this.nameIndex],this.tyyNpcDlgList[this.dlgIndex]);    
                    }
                    catch
                    {
                        this.Visible = false;
                    }            
            }
            else if (this._CharacterDlgText.Text == "敖厂长工作用的桌子，上面有些盆栽和一台电脑" && e.KeyCode == Keys.Q)
            {
                MY_EXTEND = new TYYExtend(this);
            }
        }
    }
}