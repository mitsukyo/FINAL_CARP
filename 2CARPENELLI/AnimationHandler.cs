using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2CARPENELLI
{
    public class AnimationHandler
    {
        public AnimationHandler() {
        }

        public bool MoveAnimation(PictureBox start, PictureBox end, int axis, int direction, int startposX, int startposY, Timer timer)
        {
            int animSpeed = 2;

            int currentLocation = axis == 0 ? start.Location.X : start.Location.Y;
            int targetLocation = axis == 0 ? end.Location.X : end.Location.Y;

            bool isMoving = direction == 0 ? currentLocation < targetLocation : currentLocation > targetLocation;

            if (isMoving)
            {
                start.Show();

                int movement = direction == 0 ? animSpeed : -animSpeed;

                if (axis == 0)
                    start.Location = new Point(start.Location.X + movement, start.Location.Y);
                else
                    start.Location = new Point(start.Location.X, start.Location.Y + movement);
            }
            else
            {
                start.Hide();
                timer.Stop();
                start.Location = new Point(startposX, startposY);
            }

            return !isMoving;
        }

    }
}
