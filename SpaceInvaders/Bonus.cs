using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Bonus:BasicObjet {
        public Spaceship bonusFor { set; get; }
        
        public static List<Bonus> bonusList = new List<Bonus>();
        private Vecteur2D speed;

        public Bonus(Vecteur2D pos) : base(pos, 1, SpaceInvaders.Properties.Resources.bonus) {
            bonusList.Add(this);
            this.speed = new Vecteur2D(0, 50);
        }

        public virtual void move(double udelta)
        {
            this.position += this.speed * udelta;
            if (!BasicObjet.colitionTest(this, this.bonusFor)) {
                this.bonusFor.live += this.live;
                this.live = -1;
            }

        }



    }
}
