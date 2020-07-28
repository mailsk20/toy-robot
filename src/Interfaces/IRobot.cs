using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Interfaces
{
    public interface IRobot
    {
        void Place(int x, int y, string direction);
        void Move();
        void Left();
        void Right();
        string Report();
    }
}
