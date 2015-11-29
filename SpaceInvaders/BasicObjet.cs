using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    
    /// <summary>
    /// this class is use to manage all item
    ///     to draw 
    ///     to move 
    ///     etc
    /// inside the game
    /// </summary>
    class BasicObjet
    {
        public Vecteur2D position;
        public Double positionX { set { if (value > 0 && value < (double)(Game.gameSize.Width - img.Width)) this.position.x = value; } get { return this.position.x; } }
        public int live;
        public Bitmap img;
        public bool alive { get { return this.live > 0; } }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ppos">position to draw</param>
        /// <param name="plive">live to the item</param>
        /// <param name="pimg">image to draw</param>
        protected BasicObjet(Vecteur2D ppos, int plive, Bitmap pimg)
        {
            this.position = ppos;
            this.live = plive;
            img = pimg;
        }

        /// <summary>
        /// all item to draw pass here
        ///     exept 
        ///         the menu
        ///         the text
        /// </summary>
        /// <param name="g">graphics item thanx to pass the object create by the game player</param>
        public virtual void draw(Graphics g)
        {
            g.DrawImage(img, (int)position.x, (int)position.y, img.Width, img.Height);
        }

        public virtual void move() {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="s1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool colitionTest(BasicObjet b1, Size s1, BasicObjet b2)
        {
            return b2.position.x > b1.position.x + s1.Width         ||
                    b2.position.y > b1.position.y + s1.Height       ||
                    b1.position.x > b2.position.x + b2.img.Width    ||
                    b1.position.y > b2.position.y + b2.img.Height;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool colitionTest(BasicObjet b1, BasicObjet b2) {
                             ///see the PDF about the project                                    
            return  b2.position.x > b1.position.x + b1.img.Width    ||
                    b2.position.y > b1.position.y + b1.img.Height   ||
                    b1.position.x > b2.position.x + b2.img.Width    ||
                    b1.position.y > b2.position.y + b2.img.Height; 
    } }
}
