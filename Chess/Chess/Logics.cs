using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
   
    public struct Node
    {
        public int x;
        public int y;
        public int power;
        public bool initial;
        public char player;
    }
    class Logics
    {
        public Logics()
        { }
        public bool islegel(Point start, Point end)
        {
            bool isit=false;
            if (start.X + 1 < 8 && start.X + 1 == end.X)
            {
                if (start.Y + 2 < 8 && start.Y + 2 == end.Y)
                    isit = true;
                if (start.Y - 2 >= 0 && start.Y - 2 == end.Y)
                    isit = true;
            }
            if (start.X - 1 >= 0 && start.X - 1 == end.X)
            {
                if (start.Y + 2 < 8 && start.Y + 2 == end.Y)
                    isit = true;
                if (start.Y - 2 >= 0 && start.Y - 2 == end.Y)
                    isit = true;
            }
            if (start.X + 2 < 8 && start.X + 2 == end.Y)
            {
                if (start.Y + 1 < 8 && start.Y + 1 == end.Y)
                    isit = true;
                if (start.Y - 1 >= 0 && start.Y - 1 == end.Y)
                    isit = true;
            }
            if (start.X - 2 >= 0 && start.X - 2 == end.Y)
            {
                if (start.Y + 1 < 8 && start.Y + 1 == end.Y)
                    isit = true;
                if (start.Y - 1 >= 0 && start.Y - 1 == end.Y)
                    isit = true;
            }
            return isit;
 
        }
    }
}
