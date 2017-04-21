using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PONG_
{
    public partial class gameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.Black);

        //list to hold balls            
        List<Ball> Ball = new List<Ball>();

        //hero Character
        Bar hero;

        //bar values
        int barSize, barSpeed;

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(boxBrush, hero.x, hero.y, hero.size, hero.size);
        }




        public gameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            barSize = 20;
            barSpeed = 15;
          
            hero = new Bar(this.Width / 2 - barSize / 2, 300, barSize, barSpeed);

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
               
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
               
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball b2 in Ball)
            {
                b2.x = b2.x + b2.xSpeed;
                b2.y = b2.y + b2.ySpeed;
                 
                //check for bar collision
               
            }
            //move our hero
            if (leftArrowDown)
            {
                hero.Move("left");
            }

            if (rightArrowDown)
            {
                hero.Move("right");
            }

            if (upArrowDown)
            {
                hero.Move("up");
            }

            if (downArrowDown)
            {
                hero.Move("down");
            }

            Refresh();
        }

        
    }
}
