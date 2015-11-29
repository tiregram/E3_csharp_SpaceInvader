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
        public double speedMisile { set; get; }
        
        

        public BasicShip(Vecteur2D v, int live, Bitmap bi,double spd) : base(v, live, bi) 
{ this.speedMisile = spd; }

        public BasicShip(BasicShip bs, Vecteur2D dec):this( dec, bs.live, bs.img,bs.speedMisile) {
            
            
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
                new Missile(new Vecteur2D(0, speedMisile), 3, false, SpaceInvaders.Properties.Resources.shoot1).fire(this);
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
