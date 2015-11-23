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
        private Vecteur2D avit;
        public bool UserMisile { get; set; }

        

        public Missile(Vecteur2D pos, Vecteur2D vit,int li,bool user):base(pos,li,SpaceInvaders.Properties.Resources.shoot1)
        {
            misileList.Add(this);
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
            else {
                this.live = -1;
            }
        }
    }
}
