﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
   

    
    class EnnemiBlock:BasicObjet
    {
        
        private List<BasicShip> listSpaceship;
        public Vecteur2D speed;
        private Size s;
        private  Vecteur2D decalageBox;

        public new bool alive {
            get { return listSpaceship.Count == 0; }
        }



        public static EnnemiBlock BUILDER_EnnemiBlock(Level lvl) {

            EnnemiBlock en = null;
            try {
               
                System.IO.StreamReader file = new System.IO.StreamReader(lvl.nameFile);

                string[] tab = file.ReadLine().Split(' ');

                 en = new EnnemiBlock(new Vecteur2D(int.Parse(tab[0]), int.Parse(tab[1])), new Vecteur2D(30, 10));
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    tab = line.Split(' ');
                    en.addLine(
                       int.Parse(tab[0]),
                       int.Parse(tab[1]),
                       new BasicShip(
                           new Vecteur2D(),
                           int.Parse(tab[2]),
                           stringtoBitmap(tab[3])
                           )
                       );
                }
            }
            catch (Exception a)
            { System.Console.WriteLine("fileerror"+a.StackTrace);}
            return en;
        }
        
        private static Bitmap stringtoBitmap(string a)
        {
            switch (a) {
                case "ship1":
                    return SpaceInvaders.Properties.Resources.ship1;
                case "ship2":
                    return SpaceInvaders.Properties.Resources.ship2;
                case "ship3":
                    return SpaceInvaders.Properties.Resources.ship3;
                case "ship4":
                    return SpaceInvaders.Properties.Resources.ship4;
                case "ship5":
                    return SpaceInvaders.Properties.Resources.ship5;
                case "ship6":
                    return SpaceInvaders.Properties.Resources.ship6;
                case "ship7":
                    return SpaceInvaders.Properties.Resources.ship7;
                case "ship8":
                    return SpaceInvaders.Properties.Resources.ship8;
                case "ship9":
                    return SpaceInvaders.Properties.Resources.ship9;
                

            }
            return null;
            
        }

        public EnnemiBlock(Vecteur2D pos,Vecteur2D pspeed) : base(pos, 1, null) {

            this.speed = pspeed;
            this.s = new Size(0,0);
            this.listSpaceship = new List<BasicShip>();
            this.decalageBox = new Vecteur2D();
            
        }

        public void addLine(int width, int nbShips,BasicShip bs)
        {
            if (bs == null) {
                return;
            }

            int positionYToDaw=  s.Height ;
            
            int toutLes = width / nbShips;


            for (int i = 0; i < nbShips; i++) {
                listSpaceship.Add(new BasicShip(bs , new IndirectVecteur2D(this.position,i*toutLes,positionYToDaw)));
            }

            s.Height +=   20 + bs.img.Height;
            if (s.Width < width)
                 s.Width= width;

        }

        public  void move(double deltaT)
        {
            
            if ( this.position.x + this.decalageBox.x + this.s.Width > Game.gameSize.Width || this.position.x + this.decalageBox.x < 0.0)
            {
                this.position.y += this.speed.y;

                if (this.position.x <= 0) {
                    this.speed.x = -(this.speed.x) + 5;
                    this.position.x = 0 + 1 - this.decalageBox.x ;
                }else {
                    this.speed.x = -(this.speed.x) - 5;
                    this.position.x = Game.gameSize.Width - 1 - this.s.Width - decalageBox.x;
                }
            }
               
            this.position.x += speed.x* deltaT;
            
            
            foreach (BasicShip a in listSpaceship)
            {   
                a.move(deltaT);
            }

            foreach (Missile m in Missile.misileList) { 
                        if ( m.UserMisile && !BasicObjet.colitionTest(this,this.s + new Size((int)this.decalageBox.x,(int)this.decalageBox.y), m))
                        {
                            foreach (BasicShip a in listSpaceship)
                            {
                                if (!BasicShip.colitionTest(m,a)) {
                                    int old = m.live;
                                    m.live -= a.live;
                                    a.live -= old;
                                }
                            }
                        }
                }

            // si !pi.alive alors on fais pi.bonusPOP()
            listSpaceship.RemoveAll(pi => !pi.alive && pi.bonusPOP());
               

               updateBox();
           

           // this.s. = maxL;
           // this.position.x = maxL;

        }

        

        public void updateBox()
        {
            int maxT = (int) (this.position.y + this.s.Height);

            int maxB = (int) (this.position.y +  this.decalageBox.y);

            int maxL = (int) (this.position.x + this.s.Width);

            int maxR = (int) (this.position.x + this.decalageBox.x);

            foreach (BasicShip a in listSpaceship)
            {
                if (maxT >= (int) a.position.y )
                { maxT =(int) a.position.y;  }

                if (maxL >= (int) a.position.x)
                { maxL = (int) a.position.x; }

                if (maxR <= (int)a.position.x + a.img.Width )
                { maxR = (int)a.position.x + a.img.Width; }

                if (maxB <= (int) a.position.y + a.img.Height)
                { maxB = (int) a.position.y + a.img.Height; }
            }

            this.decalageBox.x = maxL - this.position.x;
            this.decalageBox.y = maxT - this.position.y;
            this.s.Width = maxR - maxL;
            this.s.Height = maxB - maxT;
            

        }

        public override void draw(Graphics g) {
            g.DrawRectangle(new Pen(Color.Red,3),new Rectangle((int)( this.position.x + this.decalageBox.x), (int)( this.position.y + this.decalageBox.y), this.s.Width, this.s.Height));
            foreach (BasicShip a in listSpaceship) {
                a.draw(g);
            }
        }

    }
}
