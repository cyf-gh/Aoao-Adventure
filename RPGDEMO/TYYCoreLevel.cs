using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//这个类在不同游戏中将会不同（为减少开发难度）
namespace RPGDEMO
{
    public class TYYCoreLevel
    {
        public List<string> LEVEL_NAME_LIST = new List<string>();
        //Current Game MAX
        public int LEVEL_MAX = 7;
        //End Flag
        public static bool END = true;
        //Continue Flg
        private bool UN_END = false;

        public List<bool> LIST_LEVEL = new List<bool>();
        public int I_LEVEL;

        public TYYCoreLevel()
        {
            this.LEVEL_NAME_LIST.Add("-前往老王的房间");
            this.LEVEL_NAME_LIST.Add("-调查老王的寝室");
            this.LEVEL_NAME_LIST.Add("-询问食堂大妈");
            this.LEVEL_NAME_LIST.Add("-询问扫地阿伯");
            this.LEVEL_NAME_LIST.Add("-询问王尼玛");
            this.LEVEL_NAME_LIST.Add("-询问保安叔叔");
            this.LEVEL_NAME_LIST.Add("-去大街上寻找线索");
            this.LEVEL_NAME_LIST.Add("-回到老王房间");
            //init data
            I_LEVEL = 0;
            for (int index = 0; index < this.LEVEL_MAX; index++)
            {
                LIST_LEVEL.Add(false);
            }
        }

        public bool tyyLevelUp()
        {
            if (I_LEVEL == LEVEL_MAX) return END;
            //set current level(if can reach these code)
            LIST_LEVEL[I_LEVEL] = true;
            I_LEVEL++;
            return UN_END;
        }
    }
}
