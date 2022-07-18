using System;
using System.Collections.Generic;
using System.Text;

namespace MonoWrap
{
    internal class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool Hit(Point 点)
        {
            return (点.x == x && 点.y == y);
        }

        public bool Hit(Rect 四角)
        {
            return (x >= 四角.x && x <= 四角.x + 四角.w && y >= 四角.y && y <= 四角.y + 四角.h);
        }
    }

    internal class Rect
    {
        public int x = 0;
        public int y = 0;
        public int w = 0;
        public int h = 0;

        public bool Hit(Point 点)
        {
            return 点.Hit(this);
        }

        public bool Hit(Rect 四角)
        {
            if (x + w >= 四角.x && x <= 四角.x + 四角.w)
            {
                // y軸
                if (y + h >= 四角.y && y <= 四角.y + 四角.h)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
