using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Spaceship :BasicObjet
    {
        public Missile fireMisile;
        private double playerSpeed;

        public Spaceship(Vecteur2D pos , int li): base(pos,li,SpaceInvaders.Properties.Resources.ship3) {
            playerSpeed = 100;
            
        }

        public   override void draw(Graphics g) {
            if (this.fireMisile != null)
            {
                this.fireMisile.draw(g);
            }
           base.draw(g);

            g.DrawString("live:"+this.live, Game.defaultFont,Game.blackBrush, Game.gameSize.Width/2, Game.gameSize.Height - 30);

        }

        public virtual  void move(double deltaT, HashSet<Keys> keyPressed)
        {
            base.move();

           

            if (keyPressed.Contains(Keys.Left))
            {
                this.positionX += (deltaT) * playerSpeed;
            }

            if (keyPressed.Contains(Keys.Right))
            {
                this.positionX -= (deltaT) * playerSpeed;
            }
            if (fireMisile !=null && !fireMisile.alive) { fireMisile = null; }
            if (keyPressed.Contains(Keys.Space) && (this.fireMisile == null) )
            {
                this.fireMisile = new Missile(new Vecteur2D(this.position) + new Vecteur2D(base.img.Width / 2, -base.img.Height), new Vecteur2D(0, -500), 5,true);
            }
            foreach(Missile m in Missile.misileList)
                if (!BasicShip.colitionTest(this,m))
                {
                    int old = this.live;
                    this.live -= m.live;
                    m.live -= old;
        
                }
        }
        
    }
}
