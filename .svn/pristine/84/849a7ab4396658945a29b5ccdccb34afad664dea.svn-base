using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Missile : BasicObjet
    {
        public static List<Missile> misileList = new List<Missile>();
        public int liveOnFire { get; }
        public Vecteur2D avit;
        public bool UserMisile { get; set; }

        public Missile() : base(new Vecteur2D(0, 0), 0, SpaceInvaders.Properties.Resources.shoot1) {
            this.UserMisile = true;
            this.liveOnFire = 2;
            this.avit= new Vecteur2D(0, -100);

        }

        public Missile(Vecteur2D pos, Vecteur2D vit, int li, bool user,Bitmap img) : base(pos, 0, img)
        {
            this.liveOnFire = li;
            this.avit = vit;
            this.UserMisile = user;
        }

        public Missile( Vecteur2D vit, int li, bool user, Bitmap img) : base(new Vecteur2D(0,0), 0, img)
        {
            this.liveOnFire = li;
            this.avit = vit;
            this.UserMisile = user;
        }

        public Missile(Vecteur2D pos, Vecteur2D vit,int li,bool user):base(pos,0,SpaceInvaders.Properties.Resources.shoot1)
        {
           
            this.liveOnFire = li;
            this.avit = vit;
            this.UserMisile = user;
        }



        public virtual void Draw(Graphics g)
        {
            if (this.alive)
                base.draw(g);
        }

        public virtual void move(double deltaT)
        {
            if (!alive)
                return;

            base.move();
            if (position.y < Game.gameSize.Height && position.y+base.img.Height > 0)
            {
                base.position += this.avit * deltaT;
            }
            else
            {
                this.live = -1;
            }


        }

        public virtual void fire(BasicObjet fireShip) {
            this.live = this.liveOnFire;
            this.position = new Vecteur2D(
                fireShip.position.x-this.img.Width/2 +fireShip.img.Width/2
               ,fireShip.position.y - this.img.Height -1);

            misileList.Add(this);
        }
    }
}
