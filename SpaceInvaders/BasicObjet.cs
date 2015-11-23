using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    

    class BasicObjet
    {
        public Vecteur2D position;
        public Double positionX { set { if (value > 0 && value < (double)(Game.gameSize.Width - img.Width)) this.position.x = value; } get { return this.position.x; } }
        public int live;
        public Bitmap img;
        public bool alive { get { return this.live > 0; } }

        

        protected BasicObjet(Vecteur2D pos, int li, Bitmap imga)
        {
            this.position = pos;
            this.live = li;
            img = imga;
        }

        public virtual void draw(Graphics g)
        {
            g.DrawImage(img, (int)position.x, (int)position.y, img.Width, img.Height);
        }

        public virtual void move() {
        }
        public static bool colitionTest(BasicObjet b1, Size s1, BasicObjet b2)
        {
            return b2.position.x > b1.position.x + s1.Width ||
                    b2.position.y > b1.position.y + s1.Height ||
                    b1.position.x > b2.position.x + b2.img.Width ||
                    b1.position.y > b2.position.y + b2.img.Height;

        }
        public static bool colitionTest(BasicObjet b1, BasicObjet b2) {
                                                                 
            return  b2.position.x > b1.position.x + b1.img.Width    ||
                    b2.position.y > b1.position.y + b1.img.Height   ||
                    b1.position.x > b2.position.x + b2.img.Width    ||
                    b1.position.y > b2.position.y + b2.img.Height; 
    } }
}
