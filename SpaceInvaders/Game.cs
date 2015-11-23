using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace SpaceInvaders
{
    enum gameState{
        pause,
        start,
        startlevel,
        win,
        lost
    }

    class Game
    {
        public double counterTime;
        private Level lvl;
        public static Random rnd = new Random(42);
        public Spaceship playerShip;
        public List<Bunker> listBunger;
        private gameState currentState = gameState.start;

        #region fields and properties

        #region gameplay elements

        #endregion

        #region game technical elements
        /// <summary>
        /// Size of the game area
        /// </summary>
        public static Size gameSize;
        public EnnemiBlock ennemis;

        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed = new HashSet<Keys>();

        #endregion

        #region static fields (helpers)

        /// <summary>
        /// Singleton for easy access
        /// </summary>
        public static Game game { get; private set; }

        /// <summary>
        /// A shared black brush
        /// </summary>
        public static Brush blackBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// A shared simple font
        /// </summary>
        public static Font defaultFont = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
        #endregion

        #endregion

        #region constructors
        /// <summary>
        /// Singleton constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        /// 
        /// <returns></returns>
        public static Game CreateGame(Size gameSize)
        {
            if (game == null)
                game = new Game(gameSize);
            return game;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        private Game(Size gameSize)
        {
            //ennemis= EnnemiBlock.BUILDER_EnnemiBlock();
            // ennemis = new EnnemiBlock(new Vecteur2D(0, 0), new Vecteur2D(30,5));
            Game.gameSize = gameSize;
            // ennemis.addLine(400, 5 , new BasicShip(new Vecteur2D(0,0),  4, SpaceInvaders.Properties.Resources.ship1));
            //ennemis.addLine(400, 5 , new BasicShip(new Vecteur2D(0,0), 4, SpaceInvaders.Properties.Resources.ship2));
            //ennemis.addLine(400, 5 , new BasicShip(new Vecteur2D(0, 0), 4, SpaceInvaders.Properties.Resources.ship2));
            this.currentState = gameState.startlevel;
            this.counterTime=0;
            


        }

        #endregion

        #region methods

        /// <summary>
        /// Draw the whole game
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public void Draw(Graphics g)
        {
            
            
            switch (currentState) {
                case gameState.pause:
                g.DrawString("PAUSE", defaultFont, blackBrush, 30, 30);
            break;
                case gameState.startlevel:
                    if (this.lvl == null) return;
                    g.DrawString("Level:" + this.lvl.num + " " + this.lvl.name , defaultFont, blackBrush, 30, 30);
                    g.DrawString("Wait   "+(int) this.counterTime, defaultFont, blackBrush, gameSize.Width/2, Game.gameSize.Height/2);
                    break;

                case gameState.win:
                    g.DrawString("win", defaultFont, blackBrush, 30, 30);
                    g.DrawString("press N", defaultFont, blackBrush, 30,100);
                    break;
           case gameState.lost:
                    g.DrawString("lost", defaultFont, blackBrush, 30, 30);
                    g.DrawString("press R", defaultFont, blackBrush, 30, 100);
                    break;

                case gameState.start:
                    
                    playerShip.draw(g);
                    ennemis.draw(g);
                    foreach (Bunker a in listBunger)
                        a.draw(g);
                    foreach (Missile a in Missile.misileList)
                        a.draw(g);

                    foreach (Bonus a in Bonus.bonusList)
                    {
                        a.draw(g);
                    }
                    break;
               
            }
        }

        /// <summary>
        /// Update game
        /// </summary>
        public void Update(double deltaT)
        {
            bool init = false;
            switch (currentState)
            {

                case gameState.startlevel:

                    if (this.lvl == null) {
                        this.counterTime = 3;
                        this.lvl = Level.Builder_getLevel(1); init = true;
                        this.playerShip = new Spaceship(new Vecteur2D(gameSize.Width / 2 - SpaceInvaders.Properties.Resources.ship5.Width / 2, gameSize.Height - 50), 5);
                        listBunger = new List<Bunker>();
                        for (int i = 0; i < 3; i++)
                        {
                            listBunger.Add(new Bunker(new Vecteur2D(Game.gameSize.Width * i / 3 + 30, (Game.gameSize.Height - 120))));
                        }
                        this.ennemis = EnnemiBlock.BUILDER_EnnemiBlock(this.lvl);
                    }



                    this.counterTime -= deltaT;

                    if (this.counterTime < 0) {
                        this.currentState = gameState.start;
                    }
                    

                    break;

                case gameState.start:

                    Missile.misileList.RemoveAll(a => !a.alive);
                    ennemis.move(deltaT);
                    this.playerShip.move(deltaT, keyPressed);
                    foreach (Bunker a in listBunger)
                    {
                        foreach (Missile b in Missile.misileList)
                        {
                            a.collision(b);
                        }

                    }

                    foreach (Bonus a in Bonus.bonusList)
                    {
                        a.bonusFor = this.playerShip;
                        a.move(deltaT);

                    }
                    Bonus.bonusList.RemoveAll(pi => !pi.alive);
                    foreach (Missile a in Missile.misileList)
                    {
                        
                        a.move(deltaT);
                    }

                    if (keyPressed.Contains(Keys.P))
                    {
                        currentState = gameState.pause;
                    }
                    if (ennemis.alive)
                    {
                        currentState = gameState.win;
                    }
                    if (!playerShip.alive  )
                    {
                        currentState = gameState.lost;
                    }
                    break;

                case gameState.pause:

                    if (keyPressed.Contains(Keys.P))
                    {
                        currentState = gameState.start;
                    }
            break;

                case gameState.lost:


                    if (keyPressed.Contains(Keys.R))
                    {
                        this.currentState = gameState.startlevel;
                        this.lvl = null;
                        Missile.misileList.RemoveAll( pi => true);
                        Bonus.bonusList.RemoveAll(bo => true);

                    }

                    break;

                case gameState.win:

                    if (keyPressed.Contains(Keys.N))
                    {
                        this.currentState = gameState.startlevel;
                        this.lvl = Level.Builder_getLevel(this.lvl.num+1);
                        this.ennemis = EnnemiBlock.BUILDER_EnnemiBlock(this.lvl);
                        this.counterTime = 3;
                    }
                    break;/*
                case gameState.restart:
                    break;
                case gameState.nextLevel:
                    break;
                case gameState.menu:
                    break;*/
            }
        }
        #endregion


    }
}
