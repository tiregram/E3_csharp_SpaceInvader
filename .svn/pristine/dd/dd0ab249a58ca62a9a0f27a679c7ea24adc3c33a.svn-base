using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
   

    class IndirectVecteur2D:Vecteur2D
    {
        private int decnx;
        private int decny;

        public  override  double x { get { return this.refe.x + decnx; } }
        public  override  double y { get { return this.refe.y + decny; } }
        

        private Vecteur2D refe;
        
        public IndirectVecteur2D(Vecteur2D v,int decX, int decY){
            refe = v;
            this.decnx = decX;
            this.decny = decY;
        }
        


    }
}