using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/////////VWRD 2014
namespace RPGDEMO
{
    //初始化类
    public class TYYCoreInit
    {
        private static TYYCoreDataDyn DynData = new TYYCoreDataDyn();

        //地图角色初始化函数
        public static void tyyInitCharacterWithMap(PictureBox _mainCharacter, PictureBox _mainMap, Image mapImage, Boolean isMapTr)
        {
            //contect
            _mainCharacter.Parent = _mainMap;

            _mainMap.Image = mapImage;

            _mainCharacter.Size = new Size(TYYCoreDataDyn.tyyInitCharacterSize);

            _mainMap.Size = mapImage.Size;
            //error happens
            if (!isMapTr)
            {
                Point sizeofWin = new Point(800, 600);
                _mainCharacter.Location = DynData.tyyCharacterLocation;
                _mainMap.Location = TYYCoreProcess.tyyProcessCenterPosition(_mainCharacter.Location, sizeofWin, true);
            }
            //重定义窗口大小


            _mainCharacter.Image = TYYCoreDataDyn.tyyCharacterImage;

            _mainCharacter.BackColor = Color.Transparent;
        }
    }

    //检查碰撞类
    public class TYYCoreCollision
    {
        //防止走出地图函数
        public static string tyyCheckMapCollision(Point characterLoc, Point mapLoc, Point mapSize)
        {
            if (characterLoc.X <= 0)
            {
                return "FROZ_L";
            }
            else if (characterLoc.Y <= 0)
            {
                return "FROZ_U";
            }
            else if (characterLoc.X >= mapSize.X - TYYCoreDataDyn.tyyInitCharacterSize.X)
            {
                return "FROZ_R";
            }
            else if (characterLoc.Y >= mapSize.Y - TYYCoreDataDyn.tyyInitCharacterSize.Y)
            {
                return "FROZ_D";
            }
            return "MOVE";
        }

        public static string tyyCheckMapCollisionD(Point characterLoc, Point mapLoc, Point mapSize)
        {
            if (characterLoc.X <= 0 && characterLoc.Y <= 0)
            {
                return "FROZ_LU";
            }
            else if (characterLoc.Y <= 0 && characterLoc.X >= mapSize.X - TYYCoreDataDyn.tyyInitCharacterSize.X)
            {
                return "FROZ_RU";
            }
            else if (characterLoc.X >= mapSize.X - TYYCoreDataDyn.tyyInitCharacterSize.X && characterLoc.Y >= mapSize.Y - TYYCoreDataDyn.tyyInitCharacterSize.Y)
            {
                return "FROZ_RD";
            }
            else if (characterLoc.X <= 0 && characterLoc.Y >= mapSize.Y - TYYCoreDataDyn.tyyInitCharacterSize.Y)
            {
                return "FROZ_LD";
            }
            return "MOVE";
        }

        //防止穿过物体函数
        public static string tyyCheckHitObject(PictureBox Character, PictureBox Object, Keys keyCode, String objectName)
        {
            Point c_imageTopLeft = new Point(Character.Location.X, Character.Location.Y);
            Point c_imageTopRight = new Point(Character.Location.X + Character.Width, Character.Location.Y);
            Point c_imageButLeft = new Point(Character.Location.X, Character.Location.Y + Character.Height);
            Point c_imageButRight = new Point(Character.Location.X + Character.Width, Character.Location.Y + Character.Height);

            Point o_imageTopLeft = new Point(Object.Location.X, Object.Location.Y);
            Point o_imageTopRight = new Point(Object.Location.X + Object.Width, Object.Location.Y);
            Point o_imageButLeft = new Point(Object.Location.X, Object.Location.Y + Object.Height);
            Point o_imageButRight = new Point(Object.Location.X + Object.Width, Object.Location.Y + Object.Height);
            if ((/*向左*/c_imageTopRight.X == o_imageButLeft.X && (c_imageButRight.Y > o_imageTopLeft.Y && c_imageTopRight.Y < o_imageButRight.Y) && (keyCode == Keys.D || keyCode == Keys.Right)) ||
                (/*向右*/c_imageTopLeft.X == o_imageButRight.X && (c_imageButRight.Y > o_imageTopLeft.Y && c_imageTopRight.Y < o_imageButRight.Y) && (keyCode == Keys.A || keyCode == Keys.Left)) ||
                (/*向下*/c_imageButRight.Y == o_imageTopLeft.Y && (c_imageButRight.X > o_imageTopLeft.X && c_imageButLeft.X < o_imageTopRight.X) && (keyCode == Keys.S || keyCode == Keys.Down)) ||
                (/*向上*/c_imageTopLeft.Y == o_imageButRight.Y && (c_imageTopRight.X > o_imageButLeft.X && c_imageButLeft.X < o_imageTopRight.X) && (keyCode == Keys.W || keyCode == Keys.Up)))
            {
                return objectName;
            }
            return "";
        }

        //场景转化
        public static int tyyCheckMapTrans(PictureBox Character, PictureBox Map, Keys keyCode, List<Point> trStartList, List<Point> trEndList)
        {
            if (trStartList.Count != trEndList.Count) return 99;

            for (int i = 0; i < trStartList.Count; i++)
            {
                Point trStart = trStartList[i];
                Point trEnd = trEndList[i];
                Point c_imageTopLeft = new Point(Character.Location.X, Character.Location.Y);
                Point c_imageTopRight = new Point(Character.Location.X + Character.Width, Character.Location.Y);
                Point c_imageButLeft = new Point(Character.Location.X, Character.Location.Y + Character.Height);
                Point c_imageButRight = new Point(Character.Location.X + Character.Width, Character.Location.Y + Character.Height);
                if (trStart.X == 0)//trEnd.X == 0
                {
                    if (Character.Location.X == 0 && c_imageTopLeft.Y >= trStart.Y && c_imageButLeft.Y <= trEnd.Y && (keyCode == Keys.A || keyCode == Keys.Left))
                    {
                        return i;
                    }
                }
                else if (trStart.Y == 0)//trEnd.Y == 0
                {
                    if (Character.Location.Y == 0 && c_imageTopLeft.X >= trStart.X && c_imageTopRight.X <= trEnd.X && (keyCode == Keys.W || keyCode == Keys.Up))
                    {
                        return i;
                    }
                }
                else if (trStart.X == Map.Width - 36)
                {
                    if (c_imageButRight.X == Map.Width && c_imageTopRight.Y >= trStart.Y && c_imageButRight.Y <= trEnd.Y && (keyCode == Keys.D || keyCode == Keys.Right))
                    {
                        return i;
                    }
                }
                else if (trStart.Y == Map.Height - 60)
                {
                    if (c_imageButRight.Y == Map.Height && c_imageButLeft.X >= trStart.X && c_imageButRight.X <= trEnd.X && (keyCode == Keys.S || keyCode == Keys.Down))
                    {
                        return i;
                    }
                }
                else
                {
                    //res error;
                }
            }
            return 99;
        }
    }

    public class TYYCoreProcess
    {
        public static Point tyyPointNull = new Point(0, 0);
        //使得人物图片在以父图片的情况下显示在中央
        public static Point tyyProcessCenterPosition(Point _mainMapLocation, Point windowSize)
        {
            Point ccCurrentLocation = new Point(windowSize.Y / 2 - _mainMapLocation.X - TYYCoreDataDyn.tyyInitCharacterSize.X / 2,
                                                windowSize.X / 2 - _mainMapLocation.Y - TYYCoreDataDyn.tyyInitCharacterSize.Y / 2);
            return ccCurrentLocation;
        }

        public static Point tyyProcessCenterPosition(Point _mainCharacterLocation, Point windowSize, Boolean isMap)
        {
            Point mapCurrentLocation = new Point(windowSize.X / 2 - TYYCoreDataDyn.tyyInitCharacterSize.X / 2 - _mainCharacterLocation.X,
                                                 windowSize.Y / 2 - TYYCoreDataDyn.tyyInitCharacterSize.Y / 2 - _mainCharacterLocation.Y);
            return mapCurrentLocation;
        }

        public static void tyyProcessDisposeImg(List<PictureBox> list)
        {
            foreach (PictureBox pic in list)
            {
                pic.Dispose();
            }
            list.Clear();
        }
    }
}