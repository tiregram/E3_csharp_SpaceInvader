﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    /// <summary>
    /// Dummy class for demonstration
    /// </summary>
    class BalleQuiTombe
    {
        #region Fields
        /// <summary>
        /// Position
        /// </summary>
        private double x, y;

        /// <summary>
        /// Radius
        /// </summary>
        private double radius = 10;

        /// <summary>
        /// Ball speed in pixel/second
        /// </summary>
        private double ballSpeed = 100;

        /// <summary>
        /// A shared black pen for drawing
        /// </summary>
        private static Pen pen = new Pen(Color.Red);

        /// <summary>
        /// The ball is alive if it is in the gaming area
        /// </summary>
        public bool Alive {
            get { return Game.gameSize.Height > y; }

        }
        #endregion

        #region Constructor
        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="x">start position x</param>
        /// <param name="y">start position y</param>
        public BalleQuiTombe(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Draw the object in a graphics
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.DrawEllipse(pen,(float)(x-radius),(float)(y-radius),(float)(2*radius),(float)(2*radius));
        }

        /// <summary>
        /// Move the object. Last call to move was deltaT seconds ago.
        /// </summary>
        /// <param name="deltaT">Tim ellapsed since last move.</param>
        public void Move(double deltaT, HashSet<Keys> keyPressed )
        {
            
            if (keyPressed.Contains(Keys.Left)){
                x-=1;}
            if (keyPressed.Contains(Keys.Right)){
                x+=1;}
            y += ballSpeed * deltaT;
        }
        
        #endregion
    }
}
