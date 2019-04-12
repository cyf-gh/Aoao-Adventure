using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RPGDEMO
{
    public partial class tyyMainFrame : Form
    {
        public tyyMainFrame()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        public String curMapName;

        private int Count = 30;

        private String type;

        private Boolean isEnterLoad = true;

        private TYYCoreLevel ObjLevel = new TYYCoreLevel();
        private TYYCoreMapCharger ObjMapCharger;// = new TYYCoreMapCharger("map_g");
        private TYYCoreDataSav ObjDataSav = new TYYCoreDataSav();
        private TYYCoreAnimation ObjAnimation = new TYYCoreAnimation(70);
        private TYYCoreDataLoc ObjDataLoc = new TYYCoreDataLoc();
        private TYYDynAnimation ObjWaterAnimation = new TYYDynAnimation(true);
        private TYYCoreDataDyn ObjDataDyn = new TYYCoreDataDyn();

        private String recentKey = null;
        private String recentHit = null;

        //地图上物体初始化
        private List<PictureBox> ObjectsTre = new List<PictureBox>();

        private List<PictureBox> ObjectsWat = new List<PictureBox>();

        private List<PictureBox> ObjectsNpc = new List<PictureBox>();

        private List<PictureBox> ObjectsGen = new List<PictureBox>();

        //
        private bool isEcho = false;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //// //窗口初始化
        private void MainFrame_Load(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer.Visible = false;
            //window frame init work
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(800, 600);
            ObjDataDyn.tyyWindowSize = new Point(800, 600);
            this.CenterToScreen();
            this.BackColor = Color.Black;
            //走路声效
            this.axWalkPlayer.URL = ObjDataLoc.tyyWalkSound;
            this.axWalkPlayer.Ctlcontrols.stop();
            this.tyyFreshTask();
            axWalkPlayer.settings.setMode("loop", true);
            //debug con
            _referencePrint.Location = new Point(5, 30);
            tyyInitMapFrame(null);
        }

        //键盘响应事件
        private void MainFrame_KeyDown(object sender, KeyEventArgs e)
        {
            //esc窗口弹出
            if (e.KeyCode == Keys.Escape)
            {
                String mapName;
                if (curMapName == null)
                { mapName = ObjDataSav.tyyMapName; }
                else
                { mapName = curMapName; }
                tyyEscDlg tyyEDlg = new tyyEscDlg(_mainMap.Location, mapName);
                tyyEDlg.Owner = this;
                tyyEDlg.ShowDialog();
                return;
            }
            //rpg窗口弹出
            if (e.KeyCode == Keys.Space)
            {
                bool isEnd = false;

                if ((recentHit != null || ObjAnimation.tyyHitObjName != null))
                {
                    TYYCoreGUI.tyyRPGDlgProcess(this, ObjAnimation.tyyDlg);
                    List<String> info = new List<String>();
                    if (ObjAnimation.tyyHitObjName == TYYObjectName.tyyTree || recentHit == TYYObjectName.tyyTree)
                    {
                        info = TYYDlgInfo.tyyStaticInfo(TYYObjectName.tyyTree);
                        this.tyyDlgShow(info[0], info[1]);
                    }
                    if (ObjAnimation.tyyHitObjName == TYYObjectName.tyyWater || recentHit == TYYObjectName.tyyWater)
                    {
                        info = TYYDlgInfo.tyyStaticInfo(TYYObjectName.tyyWater);
                        this.tyyDlgShow(info[0], info[1]);
                    }
                    if (ObjAnimation.tyyHitObjName == TYYObjectName.tyyNpc || recentHit == TYYObjectName.tyyNpc)
                    {
                        if (ObjAnimation.LEVEL_INDEX == 99)
                        {
                            recentHit = ObjAnimation.tyyHitObjName;
                            ObjAnimation.tyyDlg.tyySetList(ObjAnimation.tyyNpcNames, ObjAnimation.tyyNpcDlgs, false, 0);
                            ObjAnimation.tyyDlg.Visible = false;
                            ObjAnimation.tyyDlg.ShowDialog();
                            return;
                        }
                        if (ObjAnimation.LEVEL_INDEX != ObjLevel.I_LEVEL)
                        {
                            this.tyyDlgShow("……", "请先完成当前任务");
                        }

                        else
                        {
                            recentHit = ObjAnimation.tyyHitObjName;
                            ObjAnimation.tyyDlg.tyySetList(ObjAnimation.tyyNpcNames, ObjAnimation.tyyNpcDlgs, false, 0);
                            ObjAnimation.tyyDlg.Visible = false;
                            ObjAnimation.tyyDlg.ShowDialog();
                            //level up
                            isEnd = this.ObjLevel.tyyLevelUp();
                            //set level name
                            this.tyyFreshTask();
                        }
                    }
                    //
                    if (ObjAnimation.tyyHitObjName == TYYObjectName.tyyGen || recentHit == TYYObjectName.tyyGen)
                    {
                        recentHit = ObjAnimation.tyyHitObjName;
                        this.tyyLevelUp("老王的桌子");
                            
                            ObjAnimation.tyyDlg.tyySetList(ObjAnimation.tyyGenNames, ObjAnimation.tyyGenDlgs[ObjAnimation.tyyIndexInt], true, ObjAnimation.tyyIndexInt);
                            ObjAnimation.tyyDlg.Visible = false;
                            ObjAnimation.tyyDlg.ShowDialog();
                    }

                    ObjAnimation.tyyHitObjName = null;
                    this.tyyImStop();
                    if (isEnd) { this.Dispose();/*Extend*/ }
                    else return;
                }
            }
            recentHit = null;
            //人物移动
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (!isEcho) { ObjAnimation.tyyCharacterImEcho(0); isEcho = true; }
                ObjAnimation.tyyCharacterMove[0].Start();
                ObjAnimation.tyyFlag = 0;
                recentKey = "S";
                ObjAnimation.tyyKeys = e.KeyCode;
            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                if (!isEcho) { ObjAnimation.tyyCharacterImEcho(1); isEcho = true; }
                ObjAnimation.tyyCharacterMove[1].Start();
                ObjAnimation.tyyFlag = 1;
                recentKey = "W";
                ObjAnimation.tyyKeys = e.KeyCode;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                if (!isEcho) { ObjAnimation.tyyCharacterImEcho(2); isEcho = true; }
                ObjAnimation.tyyCharacterMove[2].Start();
                ObjAnimation.tyyFlag = 2;
                recentKey = "D";
                ObjAnimation.tyyKeys = e.KeyCode;
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if (!isEcho) { ObjAnimation.tyyCharacterImEcho(3); isEcho = true; }
                ObjAnimation.tyyCharacterMove[3].Start();
                ObjAnimation.tyyFlag = 3;
                recentKey = "A";
                ObjAnimation.tyyKeys = e.KeyCode;
            }
            else { return; }

            //坐标移动
            ObjAnimation.tyyMapMove1.Enabled = true;
            ObjAnimation.tyyMapMove1.Start();
            if (ObjAnimation.tyyDlg.isVisiable == true) ObjAnimation.tyyDlg.Visible = false;

            //地图转化
            if (ObjAnimation.tyyNeedTr == true)
            {
                curMapName = ObjMapCharger.tyyMapTrName[ObjAnimation.tyyMapIndex];
                this.tyyInitMapFrame(curMapName);
                ObjAnimation.tyyNeedTr = false;
                return;
            }

            //Bgm Play
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down || e.KeyCode == Keys.W || e.KeyCode == Keys.Up || e.KeyCode == Keys.D || e.KeyCode == Keys.Right || e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if (this.Count == 30)
                {
                    try
                    {
                        axWalkPlayer.Ctlcontrols.stop();
                        axWalkPlayer.Ctlcontrols.play();
                        Count = 0;
                    }
                    catch
                    {
                        return;
                    }
                }
                else Count++;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                ObjAnimation.tyyCharacterMove[i].Stop();
            }
            ObjAnimation.tyyMapMove1.Stop();
            ObjAnimation.tyyMapMove2.Stop();

            axWalkPlayer.Ctlcontrols.stop();
            this.Count = 30;

            isEcho = false;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                ObjAnimation.tyyCharacterMove[0].Stop();
                ObjAnimation.tyyCharacterImFresh(0);
            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                ObjAnimation.tyyCharacterMove[1].Stop();
                ObjAnimation.tyyCharacterImFresh(1);
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                ObjAnimation.tyyCharacterMove[2].Stop();
                ObjAnimation.tyyCharacterImFresh(2);
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                ObjAnimation.tyyCharacterMove[3].Stop();
                ObjAnimation.tyyCharacterImFresh(3);
            }
            else if (e.KeyCode == Keys.Space)
            {
                this.tyyImStop();
            }
            else { return; }

            this.Refresh();
        }

        //开发者专用工具栏-
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_referencePrint.Visible) _referencePrint.Visible = false;
            else _referencePrint.Visible = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tyyAboutBox aboutBoxDlg = new tyyAboutBox();
            aboutBoxDlg.ShowDialog();
        }

        private void rPGDlgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjAnimation.tyyDlg.Owner = this;
            //启动rpg对话框
            TYYCoreGUI.tyyRPGDlgProcess(this, ObjAnimation.tyyDlg);
        }

        //窗口失去焦点时进行维护操作
        private void MainFrame_Deactivate(object sender, EventArgs e)
        {
            this.tyyImStop();
            if (ObjAnimation.tyyMapMove1.Enabled) ObjAnimation.tyyMapMove1.Stop();
            isEcho = false;
        }

        private void tyyMainFrame_LocationChanged(object sender, EventArgs e)
        {
            TYYCoreGUI.tyyRPGDlgProcess(this, ObjAnimation.tyyDlg);
        }

        private void tyyMainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tyyMainFrame_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Position = new Point(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);
        }

        //private define functions
        private void tyyInitMapFrame(String mapName)
        {
            this._mainCharacter.Visible = false;
            this._mainMap.Visible = false;
            //储存之前读取地图坐标
            Point prevMapLoc = new Point();
            //dispose resource - ok
            TYYCoreProcess.tyyProcessDisposeImg(ObjectsGen);
            TYYCoreProcess.tyyProcessDisposeImg(ObjectsTre);
            TYYCoreProcess.tyyProcessDisposeImg(ObjectsWat);
            TYYCoreProcess.tyyProcessDisposeImg(ObjectsNpc);
            ObjAnimation.tyyWatNums = 0;
            //init map - ok
            //main character&map
            if (isEnterLoad && mapName == null)
            {
                //保存地图名称
                mapName = ObjDataLoc.tyyGetMapName();
                ObjMapCharger = new TYYCoreMapCharger(mapName);
                //初始化资源
                isEnterLoad = false;
                //初始化地图
                TYYCoreInit.tyyInitCharacterWithMap(_mainCharacter, _mainMap, ObjMapCharger.tyyMapImage, false);
            }
            else if (mapName != null && isEnterLoad == false)
            {
                Point formSize = new Point(this.Size);
                prevMapLoc = ObjMapCharger.tyyMapTrCharacterNxt[ObjAnimation.tyyMapIndex];
                ObjMapCharger = new TYYCoreMapCharger(ObjMapCharger.tyyMapTrName[ObjAnimation.tyyMapIndex]);
                _mainCharacter.Location = prevMapLoc;

                _mainMap.Location = TYYCoreProcess.tyyProcessCenterPosition(_mainCharacter.Location, formSize, true);
                //初始化地图
                TYYCoreInit.tyyInitCharacterWithMap(_mainCharacter, _mainMap, ObjMapCharger.tyyMapImage, true);
            }

            //double buffer
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            ObjAnimation.mainMap = _mainMap;
            ObjAnimation.mainCharacter = _mainCharacter;
            ObjAnimation.referencePrint = _referencePrint;
            ObjAnimation.mainForm = this;
            ObjAnimation.dlgForm = ObjAnimation.tyyDlg;
            ObjAnimation.mapSize = new Point(ObjMapCharger.tyyMapImage.Size);
            //这里增加额外代码
            ObjMapCharger = new TYYCoreMapCharger(mapName, TYYObjectName.tyyTree);
            tyyInitObjects(TYYObjectName.tyyTree);

            ObjMapCharger = new TYYCoreMapCharger(mapName, TYYObjectName.tyyNpc);
            tyyInitObjects(TYYObjectName.tyyNpc);

            ObjMapCharger = new TYYCoreMapCharger(mapName, TYYObjectName.tyyWater);
            tyyInitObjects(TYYObjectName.tyyWater);

            ObjMapCharger = new TYYCoreMapCharger(mapName, TYYObjectName.tyyGen);
            tyyInitObjects(TYYObjectName.tyyGen);
            //initObjcts is not been fix

            //请在这上面增加代码
            ObjMapCharger = new TYYCoreMapCharger(mapName, TYYObjectName.tyyTr);
            ObjAnimation.pointStart = ObjMapCharger.tyyPointStart;
            ObjAnimation.pointEnd = ObjMapCharger.tyyPointEnd;
            ObjAnimation.LEVEL_INDEX = ObjMapCharger.LEVEL_INDEX;
            this._MapLoc.Text = ObjMapCharger.tyyMapLocName;

            tyyLevelUp(this._MapLoc.Text);
            this._mainMap.Refresh();
            this._mainCharacter.Visible = true;
            this._mainMap.Visible = true;
        }

        private void tyyInitObjects(String objectType)
        {
            int index = 0;
            type = objectType;
            if (objectType != TYYObjectName.tyyGen)
            {
                while (index < ObjMapCharger.tyyMapObjectNum)
                {
                    PictureBox objPic = new PictureBox();
                    if (objectType == TYYObjectName.tyyTree)
                    {
                        ObjectsTre.Add(objPic);
                        ObjectsTre[index].Parent = _mainMap;
                        ObjectsTre[index].BackColor = Color.Transparent;
                        ObjectsTre[index].Image = TYYCoreDataDyn.tyyObjectTree;
                        ObjectsTre[index].Size = TYYCoreDataDyn.tyyObjectTreeSize;
                        ObjectsTre[index].Location = ObjMapCharger.tyyMapObjectLoc[index];
                        //Clean when first time run these code
                    }

                    if (objectType == TYYObjectName.tyyWater)
                    {
                        ObjectsWat.Add(objPic);
                        ObjectsWat[index].Size = TYYCoreDataDyn.tyyObjectWaterSize;
                        ObjectsWat[index].Parent = _mainMap;
                        ObjectsWat[index].BackColor = Color.Transparent;
                        ObjectsWat[index].Location = ObjMapCharger.tyyMapObjectLoc[index];
                    }

                    if (objectType == TYYObjectName.tyyNpc)
                    {
                        ObjectsNpc.Add(objPic);
                        ObjectsNpc[index].Parent = _mainMap;
                        ObjectsNpc[index].BackColor = Color.Transparent;
                        ObjectsNpc[index].Image = ObjMapCharger.tyyNpcImg[index];
                        ObjectsNpc[index].Size = new Size(TYYCoreDataDyn.tyyInitCharacterSize);
                        ObjectsNpc[index].Location = ObjMapCharger.tyyNpcloc[index];
                    }
                    index++;
                }
            }
            else
            {
                try
                {
                    while (index < ObjMapCharger.tyyGenObjName.Count)
                    {
                        PictureBox objPic = new PictureBox();
                        ObjectsGen.Add(objPic);
                        ObjectsGen[index].Parent = _mainMap;
                        ObjectsGen[index].BackColor = Color.Transparent;
                        ObjectsGen[index].Image = ObjMapCharger.tyyGenObjImg[index];
                        ObjectsGen[index].Size = ObjMapCharger.tyyGenObjImg[index].Size;
                        ObjectsGen[index].Location = ObjMapCharger.tyyGenObjLoc[index];
                        index++;
                    }
                }
                catch
                {
                    TYYCoreGUI.tyyErrMsg("Bad Error:Gen Obj init fail!");
                    return;
                }
            }

            if (objectType == TYYObjectName.tyyWater)
            {
                ObjAnimation.tyyObjWat.Clear();
                ObjWaterAnimation.tyyDynSource = ObjDataDyn.tyyWaterImages;
                ObjWaterAnimation.tyyDynList = ObjectsWat;
                ObjAnimation.tyyObjWat.AddRange(ObjectsWat);
                ObjAnimation.tyyWatNums = ObjMapCharger.tyyMapObjectNum;
                return;
            }
            else if (objectType == TYYObjectName.tyyTree)
            {
                ObjAnimation.tyyObjTre.Clear();
                ObjAnimation.tyyObjTre.AddRange(ObjectsTre);
                ObjAnimation.tyyTreNums = ObjMapCharger.tyyMapObjectNum;
            }
            else if (objectType == TYYObjectName.tyyNpc)
            {
                ObjAnimation.tyyObjNpc.Clear();
                ObjAnimation.tyyObjNpc.AddRange(ObjectsNpc);
                //dlgs
                ObjAnimation.tyyNpcDlgs = ObjMapCharger.tyyObjNpcDlg;
                // inside name
                ObjAnimation.tyyNpcNamesIns = ObjMapCharger.tyyNpcNamIns;
                // correct name
                ObjAnimation.tyyNpcNames = ObjMapCharger.tyyNpcNam;
                ObjAnimation.tyyNpcNums = ObjMapCharger.tyyMapObjectNum;
            }
            else if (objectType == TYYObjectName.tyyGen)
            {
                ObjAnimation.tyyObjGen.Clear();
                ObjAnimation.tyyObjGen.AddRange(ObjectsGen);
                ObjAnimation.tyyGenDlgs = ObjMapCharger.tyyGenDlgList;
                ObjAnimation.tyyGenNames = ObjMapCharger.tyyGenObjName;
                ObjAnimation.tyyGenNums = ObjMapCharger.tyyGenObjName.Count;
            }
        }

        private void tyyDlgShow(String cName, String cWords)
        {
            recentHit = ObjAnimation.tyyHitObjName;
            ObjAnimation.tyyDlg.tyySetText(cName, cWords);
            ObjAnimation.tyyDlg.Visible = false;
            ObjAnimation.tyyDlg.Hide();
            ObjAnimation.tyyDlg.ShowDialog();
        }

        private void tyyImStop()
        {
            if (recentKey == "S")
            {
                ObjAnimation.tyyCharacterImFresh(0);
            }
            else if (recentKey == "D")
            {
                ObjAnimation.tyyCharacterImFresh(2);
            }
            else if (recentKey == "W")
            {
                ObjAnimation.tyyCharacterImFresh(1);
            }
            else if (recentKey == "A")
            {
                ObjAnimation.tyyCharacterImFresh(3);
            }
        }

        private void tyyFreshTask()
        {
            this._taskName.Text = this.ObjLevel.LEVEL_NAME_LIST[ObjLevel.I_LEVEL];
        }

        private void tyyShowVedio(bool isEnd)
        {
            this.axWindowsMediaPlayer.Location = new Point(0, 0);
            this.axWindowsMediaPlayer.Size = new Size(800, 645);
            if (isEnd) this.axWindowsMediaPlayer.URL = "";
            else this.axWindowsMediaPlayer.URL = "";
            this.axWindowsMediaPlayer.settings.playCount = 1;
            this.axWindowsMediaPlayer.Ctlcontrols.play();
        }

        private void axWindowsMediaPlayer_StatusChange(object sender, EventArgs e)
        {
            if (this.axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                axWindowsMediaPlayer.Visible = false;
            }
        }

        private void tyyLevelUp(String placeName)
        {
            if (ObjLevel.I_LEVEL == 0 && placeName == "老王的寝室")
            {
                this.ObjLevel.tyyLevelUp();
                this.tyyFreshTask();
            }
            else if (ObjLevel.I_LEVEL == 1 && placeName == "老王的桌子")
            {
                this.ObjLevel.tyyLevelUp();
                this.tyyFreshTask();
            }
        }
    }
}