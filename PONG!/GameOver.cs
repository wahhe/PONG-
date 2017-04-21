using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace PONG_
{
    public partial class GameOver : UserControl
    {
        public GameOver()
        {
            InitializeComponent();

            SoundPlayer player3 = new SoundPlayer(Properties.Resources.gameover);
            player3.Play();
            goscLabel.Text = mainScreen.score + " PONGS left to success"; 
        }

        //start new game
        private void startButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameControl gc = new GameControl();
            f.Controls.Add(gc);

            gc.Focus(); 
        }

        //close the game
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Enter(object sender, EventArgs e)
        {
            startButton.BackColor = Color.DarkViolet;
            exitButton.BackColor = Color.Black;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            startButton.BackColor = Color.Black;
            exitButton.BackColor = Color.DarkViolet;
        }

        //  private void gamoverLabel_Click(object sender, EventArgs e)

    }
}
