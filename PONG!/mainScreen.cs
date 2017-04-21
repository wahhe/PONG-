using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//create by He Yuanhua
//create time: 20170420

namespace PONG_
{
    public partial class mainScreen : UserControl
    {
        public static int score = 0;

        public mainScreen()
        {
            InitializeComponent();
        }

        //start new game
        private void startButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            // Create an instance of the SecondScreen
            GameControl gc = new GameControl();

            // Add the User Control to the Form
            f.Controls.Add(gc);
        }

        //close the game
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Enter(object sender, EventArgs e)
        {
            startButton.BackColor = Color.DarkGreen;
            exitButton.BackColor = Color.Black;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            startButton.BackColor = Color.Black;
            exitButton.BackColor = Color.DarkGreen;
        }

        // private void timer1_Tick(object sender, EventArgs e)



    }
}
