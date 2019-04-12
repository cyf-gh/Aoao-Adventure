using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/////////VWRD 2014
namespace RPGDEMO
{
    internal class TYYCoreAnimation
    {
        public int LEVEL_INDEX;

        private int currentPic = 3;

        private TYYCoreDataDyn tyyData = new TYYCoreDataDyn();
        public TYYRPGDlg tyyDlg = new TYYRPGDlg();

        //获取物体所有坐标
        public List<PictureBox> tyyObjTre = new List<PictureBox>();

        public List<PictureBox> tyyObjWat = new List<PictureBox>();

        public List<PictureBox> tyyObjNpc = new List<PictureBox>();

        public List<PictureBox> tyyObjGen = new List<PictureBox>();

        public int tyyWatNums;

        public int tyyTreNums;

        public int tyyNpcNums;

        public int tyyGenNums;
        //接受键盘代码
        public int tyyFlag;

        public int tyyIndexInt;

        public Keys tyyKeys;

        public Boolean tyyNeedTr = false;

        public Form mainForm;
        public Form dlgForm;

        public String tyyHitObjName = null;

        public Label referencePrint;
        public PictureBox mainCharacter;
        public PictureBox mainMap;

        public int tyyMapIndex;
        
        public List<Point> pointStart = new List<Point>();
        public List<Point> pointEnd = new List<Point>();

        public List<String> tyyNpcNamesIns = new List<String>();
        public List<String> tyyNpcNames = new List<String>();
        public List<String> tyyNpcDlgs = new List<String>();

        public List<String> tyyGenNames = new List<String>();
        public List<String>[] tyyGenDlgs = new List<string>[99];
        public Point mapSize;

        //
        public List<System.Windows.Forms.Timer> tyyCharacterMove = new List<System.Windows.Forms.Timer>();

        public System.Windows.Forms.Timer tyyMapMove1 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tyyMapMove2 = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer tyyCharacterTowardsMove = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tyyCharacterBackMove = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tyyCharacterLeftMove = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer tyyCharacterRightMove = new System.Windows.Forms.Timer();

        //构造函数
        public TYYCoreAnimation(int _Interval)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            //将计时器们合并为集合
            tyyCharacterMove.Add(tyyCharacterTowardsMove);
            tyyCharacterMove.Add(tyyCharacterBackMove);
            tyyCharacterMove.Add(tyyCharacterRightMove);
            tyyCharacterMove.Add(tyyCharacterLeftMove);

            //添加时间间隔
            for (int i = 0; i < 4; i++)
            {
                tyyCharacterMove[i].Interval = _Interval;
            }

            //人物动作变化
            //为时间器们添加响应事件
            tyyCharacterMove[0].Tick += tyyCharacterTowardsMove_Tick;
            tyyCharacterMove[1].Tick += tyyCharacterBackMove_Tick;
            tyyCharacterMove[2].Tick += tyyCharacterRightMove_Tick;
            tyyCharacterMove[3].Tick += tyyCharacterLeftMove_Tick;

            //设置帧数为一毫秒一帧
            tyyMapMove1.Interval = 1;
            tyyMapMove2.Interval = 1;
            //地图滚轴移动
            tyyMapMove1.Tick += tyyMapMove1_Tick;
            tyyMapMove2.Tick += tyyMapMove1_Tick;
        }

        private void tyyMapMove1_Tick(object sender, EventArgs e)
        {
            int index = 0;
            while (index < tyyWatNums)
            {
                if (TYYCoreCollision.tyyCheckHitObject(mainCharacter, tyyObjWat[index],
                                                       tyyKeys, TYYObjectName.tyyWater) == TYYObjectName.tyyWater)
                {
                    tyyHitObjName = TYYObjectName.tyyWater;
                    return;
                }
                index++;
            }
            index = 0;
            while (index < tyyTreNums)
            {
                if (TYYCoreCollision.tyyCheckHitObject(mainCharacter, tyyObjTre[index],
                                                       tyyKeys, TYYObjectName.tyyTree) == TYYObjectName.tyyTree)
                {
                    tyyHitObjName = TYYObjectName.tyyTree;
                    return;
                }
                index++;
            }
            index = 0;
            while (index < tyyNpcNums)
            {
                if (TYYCoreCollision.tyyCheckHitObject(mainCharacter, tyyObjNpc[index],
                                                       tyyKeys, TYYObjectName.tyyNpc) == TYYObjectName.tyyNpc)
                {
                    tyyIndexInt = index;
                    tyyHitObjName = TYYObjectName.tyyNpc;
                    return;
                }
                index++;
            }
            index = 0;
            while (index < tyyGenNums)
            {
                if (TYYCoreCollision.tyyCheckHitObject(mainCharacter, tyyObjGen[index],
                                                       tyyKeys, TYYObjectName.tyyGen) == TYYObjectName.tyyGen)
                {
                    tyyIndexInt = index;
                    tyyHitObjName = TYYObjectName.tyyGen;
                    return;
                }
                index++;
            }

            tyyHitObjName = null;
            int getNumber = TYYCoreCollision.tyyCheckMapTrans(mainCharacter, mainMap, tyyKeys, this.pointStart, this.pointEnd);

            if (getNumber != 99)
            {
                this.tyyMapIndex = getNumber;
                this.tyyNeedTr = true;
                return;
            }
            if (TYYCoreCollision.tyyCheckMapCollision(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_U" && tyyFlag == 1) return;
            else if (TYYCoreCollision.tyyCheckMapCollision(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_L" && tyyFlag == 3) return;
            else if (TYYCoreCollision.tyyCheckMapCollision(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_D" && tyyFlag == 0) return;
            else if (TYYCoreCollision.tyyCheckMapCollision(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_R" && tyyFlag == 2) return;
            //解决当坐标重合时走出地图的bug
            if (TYYCoreCollision.tyyCheckMapCollisionD(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_RD" && (tyyFlag == 2 || tyyFlag == 0)) return;
            else if (TYYCoreCollision.tyyCheckMapCollisionD(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_RU" && (tyyFlag == 2 || tyyFlag == 1)) return;
            else if (TYYCoreCollision.tyyCheckMapCollisionD(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_LD" && (tyyFlag == 3 || tyyFlag == 0)) return;
            else if (TYYCoreCollision.tyyCheckMapCollisionD(mainCharacter.Location, mainMap.Location, mapSize) == "FROZ_LU" && (tyyFlag == 3 || tyyFlag == 1)) return;
            //检测地图转化

            //动画基本操作
            {
                int myMapLocationX = mainMap.Location.X;
                int myMapLocationY = mainMap.Location.Y;
                int myCCLocationX = mainCharacter.Location.X;
                int myCCLocationY = mainCharacter.Location.Y;
                switch (tyyFlag)
                {
                    //往下移动
                    case 0: mainMap.Location = new System.Drawing.Point(myMapLocationX, myMapLocationY - 1);
                        mainCharacter.Location = new System.Drawing.Point(myCCLocationX, myCCLocationY + 1);
                        break;
                    //往上移动
                    case 1: ;
                        mainMap.Location = new System.Drawing.Point(myMapLocationX, myMapLocationY + 1);
                        mainCharacter.Location = new System.Drawing.Point(myCCLocationX, myCCLocationY - 1);
                        break;
                    //往右移动
                    case 2: ;
                        mainMap.Location = new System.Drawing.Point(myMapLocationX - 1, myMapLocationY);
                        mainCharacter.Location = new System.Drawing.Point(myCCLocationX + 1, myCCLocationY);
                        break;
                    //往左移动
                    case 3: ;
                        mainMap.Location = new System.Drawing.Point(myMapLocationX + 1, myMapLocationY);
                        mainCharacter.Location = new System.Drawing.Point(myCCLocationX - 1, myCCLocationY);
                        break;
                }
                this.tyyMapMove2.Enabled = true;
                this.tyyMapMove2.Start();
                //工作人员开发工具函数调用
                tyyPrintReference(mainMap.Location, mainCharacter.Location);
            }
        }

        //这个函数使得人物开始行走时不会动作延迟
        public void tyyCharacterImEcho(int num)
        {
            switch (num)
            {
                case 0: mainCharacter.Image = tyyData.tyyCharacterImageTowardsImages[1];
                    break;

                case 1: mainCharacter.Image = tyyData.tyyCharacterImageBackImages[1];
                    break;

                case 2: mainCharacter.Image = tyyData.tyyCharacterImageRightImages[1];
                    break;

                case 3: mainCharacter.Image = tyyData.tyyCharacterImageLeftImages[1];
                    break;
            }
        }

        //这个函数使得动作结束后回到站立动作
        public void tyyCharacterImFresh(int num)
        {
            switch (num)
            {
                case 0: mainCharacter.Image = tyyData.tyyCharacterImageTowardsImages[0];
                    break;

                case 1: mainCharacter.Image = tyyData.tyyCharacterImageBackImages[0];
                    break;

                case 2: mainCharacter.Image = tyyData.tyyCharacterImageRightImages[0];
                    break;

                case 3: mainCharacter.Image = tyyData.tyyCharacterImageLeftImages[0];
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        ////// //一系列动画操作
        private void tyyCharacterTowardsMove_Tick(object sender, EventArgs e)
        {
            mainCharacter.Image = tyyData.tyyCharacterImageTowardsImages[currentPic];
            currentPicNum();
        }

        private void tyyCharacterBackMove_Tick(object sender, EventArgs e)
        {
            mainCharacter.Image = tyyData.tyyCharacterImageBackImages[currentPic];
            currentPicNum();
        }

        private void tyyCharacterLeftMove_Tick(object sender, EventArgs e)
        {
            mainCharacter.Image = tyyData.tyyCharacterImageLeftImages[currentPic];
            currentPicNum();
        }

        private void tyyCharacterRightMove_Tick(object sender, EventArgs e)
        {
            mainCharacter.Image = tyyData.tyyCharacterImageRightImages[currentPic];
            currentPicNum();
        }

        //用来判断当前播放帧数的函数
        private void currentPicNum()
        {
            if (currentPic != 3) currentPic++;
            else currentPic = 0;
        }

        //初始化dlg窗口

        //辅助函数*
        private void tyyPrintReference(Point MapReference, Point CharacterReference)
        {
            String OutPutString = "Map X:" + MapReference.X.ToString() + "\n" +
                                  "Map Y:" + MapReference.Y.ToString() + "\n" +
                                  "Cha X:" + CharacterReference.X.ToString() + "\n" +
                                  "Cha Y:" + CharacterReference.Y.ToString() + "\n";
            referencePrint.Text = OutPutString;
        }
    }

    //动态物体类
    public class TYYDynAnimation
    {
        public TYYCoreDataDyn ObjDynData = new TYYCoreDataDyn();

        public List<PictureBox> tyyDynList = new List<PictureBox>();

        public List<Image> tyyDynSource = new List<Image>();

        private System.Windows.Forms.Timer dynAnimationTimer = new System.Windows.Forms.Timer();

        //

        private int tyyFlag = 0;

        public TYYDynAnimation(Boolean isStart)
        {
            dynAnimationTimer.Tick += dynAnimationTimer_Tick;
            dynAnimationTimer.Interval = 1000;
            if (isStart == true) { dynAnimationTimer.Start(); }
            else return;
        }

        private void dynAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (tyyFlag == 7)
            {
                tyyFlag = 0;
            }

            foreach (PictureBox currentImg in tyyDynList)
            {
                currentImg.Image = tyyDynSource[tyyFlag];
            }
            tyyFlag++;
        }
    }
}