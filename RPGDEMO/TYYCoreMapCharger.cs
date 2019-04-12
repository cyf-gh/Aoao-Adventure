using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace RPGDEMO
{
    public class TYYCoreMapCharger
    {
        /// <summary>
        /// 参数_fileToget请使用TYYObjectName类成员
        /// </summary>
        /// <param name="_mapName"></param>
        /// <param name="_fileToget"></param>
        //初始化物体构造函数
        public TYYCoreMapCharger(String _mapName, String _fileToget)
        {
            this.tyyCurrentToget = _fileToget;

            String currentPathForGen = currentPath + @_mapName + TYYSpecialSymbol.tyySeparator;
            currentPath = currentPathForGen + @_mapName;//@"\maps\**map\**map+"?""
            String[] mapObjectloc;
            try
            {
                mapObjectloc = File.ReadAllLines(currentPath + /*@"_obj"*/_fileToget + TYYSpecialSymbol.tyyTxt, Encoding.ASCII);
            }//获取物体&地图转化坐标
            catch
            {
                mapObjectloc = new String[1];
            }
            //
            //////    ///////
            if (_fileToget == TYYObjectName.tyyTree || _fileToget == TYYObjectName.tyyWater)
            {
                tyyMapObjectLoc = tyyConvertToPoint(mapObjectloc, null/*objs*/);
                tyyMapObjectNum = mapObjectloc.Length / 2;
            }
            //////    ///////
            //地图转化
            else if (_fileToget == TYYObjectName.tyyTr)
            {
                int index = 0;
                List<Point> trPoints = tyyConvertToPoint(mapObjectloc, TYYObjectName.tyyTr);
                int trLength = trPoints.Count;
                for (int i = 0; i < trLength / 3; i++)
                {
                    this.tyyPointStart.Add(trPoints[index]);
                    index++;
                    this.tyyPointEnd.Add(trPoints[index]);
                    index++;
                    this.tyyMapTrCharacterLocCur.Add(trPoints[index]);
                    index++;
                }
                //获取转化地图的角色生成坐标
                try
                {
                    String[] trNxtPoints = File.ReadAllLines(currentPath + "_trN" + TYYSpecialSymbol.tyyTxt, Encoding.ASCII);
                    this.tyyMapTrCharacterNxt = this.tyyConvertToPoint(trNxtPoints, null);
                }
                catch
                {
                    TYYCoreGUI.tyyErrMsg("Bad Error");
                }
                this.tyyMapLocName = File.ReadAllText(currentPathForGen + "info" + TYYSpecialSymbol.tyyTxt,Encoding.Default);
                //设置任务
                try
                {
                    this.LEVEL_INDEX = Convert.ToInt32(File.ReadAllText(currentPathForGen + "level" + TYYSpecialSymbol.tyyTxt, Encoding.Default));
                }
                catch
                {
                    this.LEVEL_INDEX = 99;
                }
                //进入地图时说的话
            }
            //////    ///////
            //NPC
            else if (_fileToget == TYYObjectName.tyyNpc)
            {
                String[] mapNpcLoc;
                try
                {
                    String[] getNam = File.ReadAllLines(currentPath + "_npc_n" + TYYSpecialSymbol.tyyTxt, Encoding.ASCII);
                    this.tyyNpcNamIns = new List<String>(getNam);
                    mapNpcLoc = File.ReadAllLines(currentPath + "_npc_loc" + TYYSpecialSymbol.tyyTxt, Encoding.Default);
                }
                catch
                {
                    return;
                }
                //获取坐标
                this.tyyNpcloc = this.tyyConvertToPoint(mapNpcLoc, TYYObjectName.tyyNpc);

                //加载图片
                foreach (String img in tyyNpcNamIns)
                {
                    Image curImg = Image.FromFile(currentPath + "_" + img + TYYSpecialSymbol.tyyPng);
                    this.tyyNpcImg.Add(curImg);
                }
                //
                try
                {
                    for (int n_index = 0; n_index <= this.tyyObjNpcInfo.Count; n_index = n_index + 2)
                    {
                        this.tyyNpcNam.Add(this.tyyObjNpcInfo[n_index]);
                    }
                }
                catch
                {
 
                }
                //
                try
                {
                    for (int d_index = 1; d_index <= this.tyyObjNpcInfo.Count; d_index = d_index + 2)
                    {
                        this.tyyObjNpcDlg.Add(this.tyyObjNpcInfo[d_index]);
                    }
                }
                catch
                {
 
                }
                tyyMapObjectNum = this.tyyNpcloc.Count;
            }
            //////    ///////
            //泛型物体
            else if (_fileToget == TYYObjectName.tyyGen)
            {
                String[] ObjNames;
                try
                {
                    ObjNames = File.ReadAllLines(currentPath + /*@"_obj"*/_fileToget + TYYSpecialSymbol.tyyTxt, Encoding.Default);
                    if (ObjNames.Length == 0) return;
                }
                catch
                {
                    return;
                }
                this.tyyGenObjName = new List<String>(ObjNames);
                
                int N_Index = -1;
                foreach (String names in tyyGenObjName)
                {
                    N_Index++;
                    Image GenObj = Image.FromFile(currentPathForGen + names + TYYSpecialSymbol.tyyPng);
                        this.tyyGenObjImg.Add(GenObj);

                        String[] GenObjPoint = File.ReadAllLines(currentPathForGen + names +TYYSpecialSymbol.tyyTxt,Encoding.Default);
                        this.tyyGenObjLoc.AddRange(this.tyyConvertToPoint(GenObjPoint, TYYObjectName.tyyGen));
                        
                        this.tyyGenDlgList[N_Index] = new List<string>(this.tyyObjGenDlg);
                }
            }
        }

        //初始化地图构造函数
        public TYYCoreMapCharger(String _mapName)
        {
            //获取地图图片
            currentPath = currentPath + @_mapName + TYYSpecialSymbol.tyySeparator + @_mapName;//@"\maps\**map\**map+"?""
            try
            {
                tyyMapImage = Image.FromFile(/*@"\maps\**map\**map.png"*/@currentPath + TYYSpecialSymbol.tyyPng);
            }
            catch
            {
                tyyMapImage = Image.FromFile(/*@"\maps\**map\**map.png"*/@currentPath + TYYSpecialSymbol.tyyJpg);
            }
        }

        //当前路径封装
        private String currentPath = Environment.CurrentDirectory + @"\dat\maps\";

        //
        public String tyyCurrentToget = "";

        //地图图片
        public Image tyyMapImage { get; set; }
        public String tyyMapLocName { get; set; }
        //地图中所有物体坐标集合
        public int tyyMapObjectNum { get; set; }

        private List<String> tyyObjNpcInfo = new List<String>();
        //NPC对话
        public List<String> tyyObjNpcDlg = new List<String>();
        //NPC名字
        public List<String> tyyNpcNamIns = new List<String>();
        //NPC对话名字
        public List<String> tyyNpcNam = new List<String>();

        public List<Image> tyyNpcImg = new List<Image>();

        //地图切换的名字
        public List<String> tyyMapTrName = new List<string>();

        //本张地图时角色位置
        public List<Point> tyyMapTrCharacterLocCur = new List<Point>();

        //下一张地图的生成坐标
        public List<Point> tyyMapTrCharacterNxt = new List<Point>();

        //
        //点集合
        public List<Point> tyyPointStart = new List<Point>();

        public List<Point> tyyPointEnd = new List<Point>();

        public List<Point> tyyNpcloc = new List<Point>();

        public List<Point> tyyMapObjectLoc { get; set; }

        //
        public List<String> tyyGenObjName = new List<String>();

        public List<Point> tyyGenObjLoc = new List<Point>();
        public List<Image> tyyGenObjImg = new List<Image>();
        public List<String> tyyObjGenDlg = new List<String>();
        public List<string>[] tyyGenDlgList = new List<string>[99];

        public int LEVEL_INDEX;
        //转化字符串到坐标点
        private List<Point> tyyConvertToPoint(String[] stringInfo, String type)
        {
            List<Point> resultPoints = new List<Point>();
            this.tyyObjGenDlg.Clear();
            int index = 0;
            while (index < stringInfo.Length)
            {
                Point everyLinePoint = new Point();
                try
                {
                    everyLinePoint.X = Convert.ToInt32(stringInfo[index]);
                    index++;
                    everyLinePoint.Y = Convert.ToInt32(stringInfo[index]);
                    index++;
                    resultPoints.Add(everyLinePoint);
                }
                catch
                {
                    if (type == TYYObjectName.tyyTr)
                    {
                        this.tyyMapTrName.Add(stringInfo[index]);
                    }
                    else if (type == TYYObjectName.tyyNpc)
                    {
                        this.tyyObjNpcInfo.Add(stringInfo[index]);
                    }
                    else if (type == TYYObjectName.tyyGen)
                    {
                        this.tyyObjGenDlg.Add(stringInfo[index]);
                    }
                    index++;
                    continue;
                }
            }
            return resultPoints;
        }
    }

    public class TYYObjectName
    {
        //树木
        public static String tyyTree = "_tre";

        //石头
        public static String tyyStone = "_sto";

        //水
        public static String tyyWater = "_wat";

        //NPC
        public static String tyyNpc = "_npc";

        //切换地图后缀
        public static String tyyTr = "_trf";

        //BGM
        public static String tyyBgm = "_bgm";

        //鸡
        public static String tyyGen = "_gen";
    }
}