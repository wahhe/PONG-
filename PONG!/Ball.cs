using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PONG_
{
    public class Ball
    {
        public int x, y, size, xSpeed, ySpeed;
        /// <summary>
        /// constructor method for a Ball object
        /// </summary>
        /// <param name="_x">sets the initial x coordinate </param>
        /// <param name="_y">sets the initial y coordinate</param>
        /// <param name="_size"> sets the initial size</param>
        /// <param name="_xSpeed"> sets the initial xSpeed</param>
        /// <param name="_ySpeed"> sets the initial ySpeed</param>
        public Ball(int _x, int _y, int _size, int _xSpeed, int _ySpeed)  //the name is same as the class u created
        {
            x = _x;
            y = _y;
            size = _size;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }              
    }
}
