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
        public MunitionManager munitionStock;

        private double playerSpeed;

        public Spaceship(Vecteur2D pos , int li): base(pos,li,SpaceInvaders.Properties.Resources.ship3) {
            playerSpeed = 200;
            this.munitionStock = new MunitionManager();
        }

        public   override void draw(Graphics g) {
           base.draw(g);
            g.DrawString("live:"+this.live, Game.defaultFont,Game.blackBrush, Game.gameSize.Width/2, Game.gameSize.Height - 30);
            this.munitionStock.draw(g); 
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


            this.munitionStock.move(deltaT, keyPressed, this);

           
            
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
