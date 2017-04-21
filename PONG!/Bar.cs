using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PONG_
{
    public class Bar
    {
        public int x, y, size, speed;

        /// <summary>
        /// Constructor method for a bar object
        /// </summary>
        /// <param name="_x">sets the initial x coordinate</param>
        /// <param name="_y">sets the initial y coordinate</param>
        /// <param name="_size">sets the initial size</param>
        /// <param name="_xSpeed">sets the initial horizontal speed</param>
        /// <param name="_ySpeed">sets the initial vertical speed</param>

        public Bar(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }

        public void Move()
        {
            y = y + speed;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x = x - speed;
            }

            if (direction == "right")
            {
                x = x + speed;
            }

        }

        public Boolean Collision(Ball b)
        {
            Rectangle ballRec = new Rectangle(b.x, b.y, b.size, b.size);
            Rectangle heroRec = new Rectangle(x, y, size, size);

            return ballRec.IntersectsWith(heroRec);

        }

    }
}
