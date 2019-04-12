using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/////////VWRD 2014
namespace RPGDEMO
{
    public class TYYCoreDataDyn
    {
        //初始化本地资源的类
        private static TYYCoreDataSav savData = new TYYCoreDataSav();

        ///这里包含陈旧算法,部分代码需要报废
        //窗口大小
        public Point tyyWindowSize = new Point(800,600);

        //初始化rpg对话框永久大小
        public static Point tyyInitRPGDlgSize = new Point(800, 200);

        //资源定义
        public static Image tyyCharacterImage = RPGDEMO.Properties.Resources.toward_stop;

        //定义人物图片大小
        public static Point tyyInitCharacterSize = new Point(36,60);

        //物体资源的封装
        public static Image tyyObjectTree = Properties.Resources.tre_1;

        public static Size tyyObjectTreeSize = new Size(tyyObjectTree.Height, tyyObjectTree.Width);

        //水面定义
        public List<Image> tyyWaterImages = new List<Image>();

        public static Size tyyObjectWaterSize = new Size(66, 66);

        /////以上为静态字段/////
        //定义化人物坐标
        public Point tyyCharacterLocation = new Point();

        //地图资源
        public Point tyyMapLocation = new Point();

        /// ///////////////////////////////////////////////////////////////////////////////////////////////
        /// 前方大量高能数据，非战斗人员迅速撤离

        public List<Image> tyyCharacterImageTowardsImages = new List<Image>();

        //--
        private Image towardStop = RPGDEMO.Properties.Resources.toward_stop;

        private Image towardWalk1 = RPGDEMO.Properties.Resources.toward_walk1;
        private Image towardWalk2 = RPGDEMO.Properties.Resources.toward_walk2;

        /// <summary>
        /// //init Back images
        /// </summary>
        public List<Image> tyyCharacterImageBackImages = new List<Image>();

        //--
        private Image backStop = RPGDEMO.Properties.Resources.back_stop;

        private Image backWalk1 = RPGDEMO.Properties.Resources.back_walk1;
        private Image backWalk2 = RPGDEMO.Properties.Resources.back_walk2;

        /// <summary>
        /// //init left images
        /// </summary>
        public List<Image> tyyCharacterImageLeftImages = new List<Image>();

        //--
        private Image leftStop = RPGDEMO.Properties.Resources.left_stop;

        private Image leftWalk1 = RPGDEMO.Properties.Resources.left_walk1;
        private Image leftWalk2 = RPGDEMO.Properties.Resources.left_walk2;

        /// <summary>
        /// //init right images
        /// </summary>
        public List<Image> tyyCharacterImageRightImages = new List<Image>();

        //--
        private Image rightStop = RPGDEMO.Properties.Resources.right_stop;

        private Image rightWalk1 = RPGDEMO.Properties.Resources.right_walk1;
        private Image rightWalk2 = RPGDEMO.Properties.Resources.right_walk2;
        /// ///////////////////////////////////////////////////////////////////////////////////////////////

        //构造函数,初始化资源
        public TYYCoreDataDyn()
        {
            try
            {
                //资源初始化

                //角色
                tyyCharacterLocation = TYYCoreProcess.tyyProcessCenterPosition(savData.tyyMapLoc, this.tyyWindowSize);
                //地图
                tyyMapLocation = savData.tyyMapLoc;
                //TOWARDS
                tyyCharacterImageTowardsImages.Add(towardStop);
                tyyCharacterImageTowardsImages.Add(towardWalk1);
                tyyCharacterImageTowardsImages.Add(towardStop);
                tyyCharacterImageTowardsImages.Add(towardWalk2);
                //BACK
                tyyCharacterImageBackImages.Add(backStop);
                tyyCharacterImageBackImages.Add(backWalk1);
                tyyCharacterImageBackImages.Add(backStop);
                tyyCharacterImageBackImages.Add(backWalk2);
                //LEFT
                tyyCharacterImageLeftImages.Add(leftStop);
                tyyCharacterImageLeftImages.Add(leftWalk1);
                tyyCharacterImageLeftImages.Add(leftStop);
                tyyCharacterImageLeftImages.Add(leftWalk2);
                //RIGHT
                tyyCharacterImageRightImages.Add(rightStop);
                tyyCharacterImageRightImages.Add(rightWalk1);
                tyyCharacterImageRightImages.Add(rightStop);
                tyyCharacterImageRightImages.Add(rightWalk2);

                //water
                tyyWaterImages.Add(Properties.Resources.wat_1);
                tyyWaterImages.Add(Properties.Resources.wat_2);
                tyyWaterImages.Add(Properties.Resources.wat_3);
                tyyWaterImages.Add(Properties.Resources.wat_4);
                tyyWaterImages.Add(Properties.Resources.wat_5);
                tyyWaterImages.Add(Properties.Resources.wat_6);
                tyyWaterImages.Add(Properties.Resources.wat_7);
                tyyWaterImages.Add(Properties.Resources.wat_8);
            }
            catch
            {
                TYYCoreGUI.tyyErrMsg("Game Frame Init Failed!");
            }
        }

        //////only for demo
    }

    //导入本地资源类
    public class TYYCoreDataLoc
    {
        public String tyyCurrentPathUri { get; set; }

        public String tyyCurrentMapsUri { get; set; }

        //获取按钮声音
        public String tyyButtonSound { get; set; }

        //获取地图名字路径

        public String tyyWalkSound { get; set; }
        //
        public String tyyMapNamePathUri { get; set; }

        //获取是否播放bgm文件路径
        public String tyySaveFilePathUri { get; set; }

        //获取地图名字
        public String tyyGetMapName()
        {
            String mapName = File.ReadAllText(tyyMapNamePathUri, Encoding.ASCII);
            return mapName;
        }

        //获取地图所在屏幕位置
        //public Point tyyGetMapLoc(String fileName)
        //{
        //    string uri = tyyCurrentMapsUri + fileName;
        //    try
        //    {
        //        String[] mapLocPoint = File.ReadAllLines(uri, Encoding.ASCII);

        //        int x = Convert.ToInt32(mapLocPoint[0]);
        //        int y = Convert.ToInt32(mapLocPoint[1]);
        //        Point mapLoc = new Point(x,y);
        //        return mapLoc;
        //    }
        //    catch
        //    {
        //        TYYCoreGUI.tyyErrMsg("File read failed!");
        //        Point nullPoint = new Point(0, 0);
        //        return nullPoint;
        //    }

        //}
        //获取背景音乐
        public string tyyGetBgmUrl(String fileName)
        {
            return tyyCurrentPathUri + @"\muc\" + @fileName;
        }

        //获取背景音乐是否需要开启
        public Boolean tyyGetIsBgmNeed()
        {
            String isBGM = File.ReadAllText(tyySaveFilePathUri, Encoding.ASCII);

            Boolean isNbGM = false;
            try
            {
                isNbGM = Convert.ToBoolean(isBGM);
            }
            catch
            {
                TYYCoreGUI.tyyErrMsg("Your Save File Error!" + "\n" + "But We've repaired it!");
                File.WriteAllText(tyySaveFilePathUri, "true", Encoding.ASCII);
                return true;
            }

            if (isNbGM) return true;
            else return false;
        }

        public TYYCoreDataLoc()
        {
            tyyCurrentPathUri = @Environment.CurrentDirectory;

            tyyCurrentMapsUri = tyyCurrentPathUri + @"\dat\maps\";

            tyyButtonSound = tyyCurrentPathUri + @"\muc\BTN.wav";

            tyyWalkSound = tyyCurrentPathUri + @"\muc\WAK.wav";

            tyySaveFilePathUri = tyyCurrentPathUri + @"\dat\sav\rec_set.txt";

            tyyMapNamePathUri = tyyCurrentPathUri + @"\dat\sav\rec_map.txt";
        }

        ////////////////////////////////////////
        ///// //本地地图资源封装

        /// <summary>
        /// 调用这个函数来封装本地地图资源
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>

        //获取地图所在绝对路径
    }

    //保存数据类
    public class TYYCoreDataSav
    {
        private List<String> tyyCurrentSavePath = new List<string>();
        private TYYCoreDataLoc locData = new TYYCoreDataLoc();
        public String tyyMapName;
        public Point tyyMapLoc;

        //保存当前地图信息
        public void tyySaveMapInfo(Point mapLoc, String mapPngPath)
        {
            String[] mapLocS = new String[2];
            mapLocS[0] = mapLoc.X.ToString();
            mapLocS[1] = mapLoc.Y.ToString();
            File.WriteAllLines(tyyCurrentSavePath[0], mapLocS, Encoding.ASCII);
            File.WriteAllText(tyyCurrentSavePath[1]/*@"\dat\sav\rec_map.txt"*/, mapPngPath);
        }

        //保存是否需要背景音乐
        public void tyySaveBgm(Boolean isNeedPlay)
        {
            try
            {
                File.WriteAllText(locData.tyySaveFilePathUri, isNeedPlay.ToString(), Encoding.ASCII);
            }
            catch
            {
                TYYCoreGUI.tyyErrMsg("File Save Error!");
                return;
            }
        }

        //构造函数
        public TYYCoreDataSav()
        {
            tyyCurrentSavePath.Add(@Environment.CurrentDirectory + @"\dat\sav\rec_loc.txt");
            tyyCurrentSavePath.Add(@Environment.CurrentDirectory + @"\dat\sav\rec_map.txt");

            String[] mapLoc = File.ReadAllLines(tyyCurrentSavePath[0], Encoding.ASCII);

            int x = Convert.ToInt32(mapLoc[0]);
            int y = Convert.ToInt32(mapLoc[1]);

            tyyMapName = File.ReadAllText(tyyCurrentSavePath[1], Encoding.ASCII);
            if (tyyMapName == "")
            {
                TYYCoreGUI.tyyErrMsg("Application Crash cause your Save File Broken!");
                Application.Exit();
            }

            tyyMapLoc = new Point(x, y);
        }


    } 
    public class TYYDlgInfo 
       {
            public static String tyyAochangzhang = "敖厂长";

            public static List<String> tyyStaticInfo(String obj)
            {
                List<String> result = new List<string>();
                if(obj == TYYObjectName.tyyTree)
                {
                    result.Add("……");
                    result.Add("树");
                }
                else if (obj == TYYObjectName.tyyWater)
                {
                    result.Add("……");
                    result.Add("水");
                }
                return result;
            }
       }
}