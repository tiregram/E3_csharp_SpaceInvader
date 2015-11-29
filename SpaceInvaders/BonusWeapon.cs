using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    
    class BonusWeapon:Bonus
    {
        private static Random chanceToDrop;

        public BonusWeapon(Vecteur2D pos) : base(pos)
        {
            
        }
    }
}
