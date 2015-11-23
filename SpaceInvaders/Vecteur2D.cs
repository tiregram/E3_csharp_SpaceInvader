using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Vecteur2D
    {
        //private double x, y;
        public virtual double x { set; get; }
        public virtual double y { set; get; }
        public double Norme {
        get{return Math.Sqrt(x*x+y*y);}
        }
        
        public Vecteur2D()
            : this(0.0, 0.0) // to be sure
        {
        }
        public Vecteur2D(Vecteur2D v) : this(v.x,v.y) { }

        public Vecteur2D(double x, double y)
        {
            this.x = x; this.y = y;
        }

        public static Vecteur2D operator +(Vecteur2D a, Vecteur2D b)
        {
            return new Vecteur2D(a.x + b.x , a.y + b.y);
        }

        public static Vecteur2D operator -(Vecteur2D a, Vecteur2D b)
        {
            return new Vecteur2D(a.x - b.x, a.y - b.y);
        }
        public static Vecteur2D operator -(Vecteur2D a)
        {
            return new Vecteur2D(-a.x,-a.y);
        }
        public static Vecteur2D operator *(Vecteur2D a, double b)
        {
            return new Vecteur2D(a.x * b, a.y * b);
        }
        public static Vecteur2D operator *( double b,Vecteur2D a)
        {
            return a * b;
        }
        public static Vecteur2D operator /( Vecteur2D a,double b)
        {
            return new Vecteur2D(a.x/b,a.y/b);
        }

    }
}
