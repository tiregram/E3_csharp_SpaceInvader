using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Bunker:BasicObjet
    {
        public Bunker (Vecteur2D pos) :base(pos,1, SpaceInvaders.Properties.Resources.bunker) {

        }

        public virtual void draw(Graphics g)
        {
            base.draw(g);
        }


        public void collision(Missile m) {

            if (!BasicObjet.colitionTest(this, m))
            {
                int decX = (int)(m.position.x - this.position.x);   //  _|_    
                int decY = (int)(m.position.y - this.position.y);

                bool firstTouch=false;

                for (int i = 0; i < m.img.Width; i++)
                    for (int ip = 0; ip < m.img.Height; ip++)
                    {
                        if (Color.Black.B == m.img.GetPixel(i, ip).B)
                        {
                            
                              if (0 <= (i + decX) && (i + decX) < img.Width &&
                                          0 <= (ip + decY) && (ip + decY) < img.Height &&
                                          img.GetPixel(i + decX, ip + decY).B == Color.Black.B)
                              {
                                if (!firstTouch)
                                {
                                    m.live--;
                                    firstTouch = !firstTouch;
                                }
                                    this.img.SetPixel(i + decX, ip + decY, Color.White);

                                    
                                

                              }
                        }
                    }


            }

        }
    }
}
