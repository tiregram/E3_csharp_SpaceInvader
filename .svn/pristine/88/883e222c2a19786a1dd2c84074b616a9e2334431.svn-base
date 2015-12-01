using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Level
    {
        public string name { get; set; }
        public string nameFile { get; set; }
        public int num { get; }
        public Level(string pname, string pnamefile, int lvlNum)
        {
            this.name = pname; this.nameFile = pnamefile; this.num = lvlNum;
        }

        public static Level Builder_getLevel(int num)
        {
            switch (num)
            {
                case 1:
                    return new Level("first explorer",SpaceInvaders.Properties.Resources.level1_lvl, num);

                case 2:
                    return new Level("the WAR begin", SpaceInvaders.Properties.Resources.level2_lvl, num);

                case 3:
                    return new Level("space crusader", SpaceInvaders.Properties.Resources.level3_lvl, num);

                case 4:
                    return new Level("one day in space", SpaceInvaders.Properties.Resources.level4_lvl, num);

                case 5:
                    return new Level("never surrender", SpaceInvaders.Properties.Resources.level5_lvl, num);

                case 6:
                    return new Level("SURVIVE", SpaceInvaders.Properties.Resources.level6_lvl, num);
                default:
                    return new Level("DIE", @"C:\Users\ruhtra\level1.lv6.txt", 1);

            }

        }
    }
}
