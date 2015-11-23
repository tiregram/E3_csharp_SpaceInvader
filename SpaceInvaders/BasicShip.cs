using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    

    class BasicShip:BasicObjet
    {
        private int chanceFire =30;
        

        public BasicShip(Vecteur2D v, int live, Bitmap bi) : base(v, live, bi) { }

        public BasicShip(BasicShip bs, Vecteur2D dec):this( dec, bs.live, bs.img) {  
            
        }
        public bool bonusPOP(Random num)
        {
            new Bonus(this.position);
            return true;
        }
        public void move(double deltaT)
        {
            if (Game.rnd.Next(0,500) < this.chanceFire*deltaT)
            {
                new Missile(new Vecteur2D(this.position)+new Vecteur2D(base.img.Width/2,-base.img.Height), new Vecteur2D(0, 200), 3,false);

            }
       
    }

        public bool bonusPOP()
        {   
            if(Game.rnd.Next(0, 100) < this.chanceFire)
                new Bonus(this.position);
            return true;
        }
    }
}
