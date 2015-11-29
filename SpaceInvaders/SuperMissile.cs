using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceInvaders
{
    class SuperMissile:Missile
    {
        private Missile brotherLeft;
        private Missile brotherRight;
        public new bool alive { get { return this.alive && this.brotherLeft.alive && this.brotherRight.alive; } }

        public SuperMissile(Vecteur2D vit, int li, bool user,Bitmap img) : base(new Vecteur2D(0,0), vit, li, user, img) {
            
            this.brotherRight = new Missile( vit + new Vecteur2D(30, 30), li, user, img);
            this.brotherLeft  = new Missile( vit + new Vecteur2D(-30, 30), li, user, img);
        }

        public override void fire(BasicObjet fireShip)
        {
           
            base.fire(fireShip);
            this.brotherLeft.fire(fireShip);
            this.brotherRight.fire(fireShip);
        }

    }
}
