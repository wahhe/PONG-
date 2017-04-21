using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace PONG_
{
    public partial class GameControl : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        //add sound player
        SoundPlayer player1 = new SoundPlayer(Properties.Resources.hit_sound);
        SoundPlayer player2 = new SoundPlayer(Properties.Resources.coin);
        

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.Green);
        SolidBrush ballBrush = new SolidBrush(Color.Purple);

        //list to hold balls            
        List<Ball> ballList = new List<Ball>();

        //hero Character
        Bar hero;

        //bar values
        int barSize, barSpeed;

        private void GameControl_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;

                case Keys.Right:
                    rightArrowDown = false;
                    break;


                default:
                    break;
            }
        }

        private void GameControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;

                case Keys.Right:
                    rightArrowDown = true;
                    break;


                default:
                    break;
            }
        }

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(boxBrush, hero.x, hero.y, hero.size, hero.size);
            foreach (Ball b1 in ballList)
            {

                e.Graphics.FillEllipse(ballBrush, b1.x, b1.y, b1.size, b1.size);
            }

        }

        public GameControl()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            Ball b1 = new PONG_.Ball(5, 10, 20, 5, 10);  //xSpeed and ySpeed: left is negative and right is positive
            Ball b2 = new PONG_.Ball(30, 15, 20, -3, 5);
            Ball b3 = new PONG_.Ball(500, 20, 20, -5, -7);
            Ball b4 = new PONG_.Ball(350, 25, 20, -2, -3);
            Ball b5 = new PONG_.Ball(100, 10, 20, -10, 10);


            ballList.Add(b1);
            ballList.Add(b2);
            ballList.Add(b3);
            ballList.Add(b4);
            ballList.Add(b5);
           
            barSize = 120;
            barSpeed = 8;

            hero = new Bar(this.Width / 2 - barSize / 2, this.Height - 50, barSize, barSpeed);

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            foreach (Ball b1 in ballList)
            {               
                b1.x = b1.x + b1.xSpeed;
                b1.y = b1.y + b1.ySpeed;
              
                //check for wall collision
                if (b1.x < 0 || b1.x > this.Width - b1.size)
                {
                    player1.Play();
                    b1.xSpeed *= -1;
                }
                if (b1.y < 0 )
                {
                    player1.Play();
                    b1.ySpeed *= -1;
                }

                //check for collision between bar and balls
                if (hero.Collision(b1))
                {
                    player2.Play();
                    ballList.Remove(b1);
                    break;

                }


                if ( b1.y > this.Height - b1.size - 30)
                {
                    timer1.Stop();
                    
                    Thread.Sleep(400);

                    //go to the gameover screen                        
                    
                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    GameOver go = new GameOver();
                    f.Controls.Add(go);

                    return;
                    
                }
                //move the hero
                if (leftArrowDown)
                {
                    if (hero.x > 0)
                    {
                        hero.Move("left");
                    }
                }

                if (rightArrowDown)
                {
                    if (hero.x < this.Width - hero.size)
                    {
                        hero.Move("right");
                    }
                }
            }
            mainScreen.score = ballList.Count();
            scoreLabel.Text = mainScreen.score + "";

            if (ballList.Count == 0)
            {
                timer1.Stop();

                Thread.Sleep(400);

                //go to the gameover screen                        

                Form f = this.FindForm();
                f.Controls.Remove(this);

                GameOver go = new GameOver();
                f.Controls.Add(go);

                return;

            }
            Refresh();
        }
    }
}

    

    /// <summary>
    /// Set initial game values here
    /// </summary>
   // public void OnStart()
   

   // private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
   

   // private void GameControl_KeyUp(object sender, KeyEventArgs e)
   
      
            
          

