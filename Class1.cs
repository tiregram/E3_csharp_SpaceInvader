using System;

public class Vecteur2D
{
    double x, y;
    double norme;

    public Vecteur2D():this(0,0) // to be sure
	{
	}

    public Vecteur2D(double x, double y)
    {
        this.x = x; this.y = y;
    }

    public static Vecteur2D operator +(Vecteur2D a,Vecteur2D b){
        return new Vecteur2D(a.x + b.x, a.y + b.y);
    }

    public static Vecteur2D operator -(Vecteur2D a, Vecteur2D b)
    {
        return new Vecteur2D(a.x - b.x, a.y - b.y);
    }

    public static Vecteur2D operator +(Vecteur2D a, Vecteur2D b)
    {
        return new Vecteur2D(a.x + b.x, a.y + b.y);
    }
}
