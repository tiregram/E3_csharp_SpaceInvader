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
                    return new Level("first explorer", @"C:\Users\ruhtra\level1.lvl.txt", num);

                case 2:
                    return new Level("the WAR begin", @"C:\Users\ruhtra\level2.lvl.txt", num);

                case 3:
                    return new Level("space crusader", @"C:\Users\ruhtra\level3.lvl.txt", num);

                case 4:
                    return new Level("one day in space", @"C:\Users\ruhtra\level4.lvl.txt", num);

                case 5:
                    return new Level("never surrender", @"C:\Users\ruhtra\level5.lvl.txt", num);

                case 6:
                    return new Level("SURVIVE", @"C:\Users\ruhtra\level6.lvl.txt", num);
                default:
                    return new Level("level 1", @"C:\Users\ruhtra\level1.lvl.txt", 1);

            }

        }
    }
}
