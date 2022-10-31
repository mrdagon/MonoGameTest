using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWrap
{
    public class Point
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

        static public void Draw(int x,int y, Color color)
        {
            Line.Draw(x, y, x+1, y+1, color);
        }
    }

    public class Line
    {
        Point start;
        Point end;
        
        public Line(int start_x , int start_y , int end_x , int end_y)
        {
            this.start = new Point(start_x, start_y);
            this.end = new Point(end_x, end_y);
        }

        private static Texture2D _blankTexture;

        static public void Draw(int start_x , int start_y ,int end_x , int end_y, Color color)
        {
            if (_blankTexture == null)
            {
                _blankTexture = new Texture2D(GameManager._spriteBatch.GraphicsDevice, 1, 1);
                _blankTexture.SetData(new[] { Color.White });
            }

            float angle = (float)Math.Atan2(end_y - start_x, end_x - start_x);
            float length = Vector2.Distance( new Vector2(start_x,start_y), new Vector2(end_x, end_y));

            GameManager._spriteBatch.Draw(
                _blankTexture,
                new Vector2(start_x,start_y),
                null,color,
                angle,
                new Vector2(0,0.5f),
                new Vector2(length , 1),
                SpriteEffects.None,
                0);
        }
    }


    public class Rect
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

        private static Texture2D _blankTexture;

        static public void Draw(int x, int y, int w, int h ,Color color)
        {
            if(_blankTexture == null )
            {
                _blankTexture = new Texture2D(GameManager._spriteBatch.GraphicsDevice, 1, 1);
                _blankTexture.SetData(new[] { Color.White });
            }

            GameManager._spriteBatch.Draw(_blankTexture, new Rectangle(x, y, w, h), color);

        }
    }
}
