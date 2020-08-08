using System.Collections.Generic;

namespace myapp
{
    class Point
    {
        public int X;
        public int Y;
        
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Point newLocation)
        {
            if(newLocation == null)
                throw new System.ArgumentNullException("Something");
            Move(newLocation.X, newLocation.Y);
        }
    }
}