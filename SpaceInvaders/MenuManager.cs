using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class MenuManager
    {
        private List<MenuItem> items;
        private List<BasicObjet> boToDraw;
        private int espace;

        private int currentChose;
        private double timeKeyPress;

        public MenuManager() {
            this.currentChose = 0;
            this.espace = 50;
            this.timeKeyPress = 0;
            this.items = new List<MenuItem>();
        }

        public void add(MenuItem mi) {
            
            this.items.Add(mi);
            
        }

        public void move(double deltaT, HashSet<Keys> keyPressed)
        {
            if (this.timeKeyPress > 0)
            {
                this.timeKeyPress -= deltaT;
                return;
            }
            if (keyPressed.Contains(Keys.Enter) )
            {
                keyPressed.Remove(Keys.Enter);
                this.items[this.currentChose].actionValidate();
                this.timeKeyPress = 1;
            }

            if (keyPressed.Contains(Keys.Up))
            {
                this.timeKeyPress = 0.3;
                this.currentChose = (this.currentChose - 1 + this.items.Count) % this.items.Count;
            }

            if (keyPressed.Contains(Keys.Down))
            {
                this.timeKeyPress = 0.3;
                this.currentChose = (this.currentChose + 1 + this.items.Count) % this.items.Count;
            }

            
        }

        public void draw(Graphics g)
        {
            Bitmap t = SpaceInvaders.Properties.Resources.titleMenu;

            g.DrawImage(t,Game.gameSize.Width/2-t.Width/2, 1,t.Width,t.Height);

            g.DrawImage(SpaceInvaders.Properties.Resources.ship1,new Point(200,200));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship2, new Point(500, 500));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship3, new Point(400, 50));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship4, new Point(100, 300));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship5, new Point(40, 40));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship6, new Point(50, 150));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship7, new Point(500, 400));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship8, new Point(100, 500));
            g.DrawImage(SpaceInvaders.Properties.Resources.ship9, new Point(300, 450));


            int x = Game.gameSize.Width / 2;
            int y = Game.gameSize.Height / 2 - (this.items.Count/2 * this.espace );
            int dx = 0;
            int dy = 0;
            g.DrawString(">", Game.defaultFont, Game.blackBrush, x-50 , y + this.espace *this.currentChose );
            foreach (MenuItem mi in items) {
                g.DrawString(mi.Name, Game.defaultFont, Game.blackBrush,x,y + dy);
                dy += this.espace; 

            }

        }

    }
}
