using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWrap;

public struct Position
{
    public int x;
    public int y;

    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public bool Hit(Position 点)
    {
        return (点.x == x && 点.y == y);
    }

    public bool Hit(Rect 四角)
    {
        return (x >= 四角.x && x <= 四角.x + 四角.w && y >= 四角.y && y <= 四角.y + 四角.h);
    }

    static public void Draw(int x,int y, Color color)
    {
        x += GameManager._camera_x;
        y += GameManager._camera_y;

        Rect.Draw(x, y, GameManager._zoomRate, GameManager._zoomRate, color);

        //Line.Draw(x + GameManager._zoomRate, y + GameManager._zoomRate, x, y+ GameManager._zoomRate, color);
    }
}

public struct Line
{
    Position start;
    Position end;
    
    public Line(int start_x , int start_y , int end_x , int end_y)
    {
        this.start = new Position(start_x, start_y);
        this.end = new Position(end_x, end_y);
    }

    private static Texture2D _blankTexture;

    static public void Draw(int start_x , int start_y ,int end_x , int end_y, Color color)
    {
        if (_blankTexture == null)
        {
            _blankTexture = new Texture2D(GameManager._spriteBatch.GraphicsDevice, 1, 1);
            _blankTexture.SetData(new[] { Color.White });
        }

        start_x += GameManager._camera_x;
        start_y += GameManager._camera_y;
        end_x += GameManager._camera_x;
        end_y += GameManager._camera_y;

        if (GameManager._zoomRate != 1)
        {
            start_x *= GameManager._zoomRate;
            start_y *= GameManager._zoomRate;
            end_x *= GameManager._zoomRate;
            end_y *= GameManager._zoomRate;

            float angle = (float)Math.Atan2(end_y - start_x, end_x - start_x);
            float length = Vector2.Distance(new Vector2(start_x, start_y), new Vector2(end_x, end_y));

            GameManager._spriteBatch.Draw(
            _blankTexture,
            new Vector2(start_x, start_y),
            null, color,
            angle,
            new Vector2(0, 0.5f * GameManager._zoomRate),
            new Vector2(length, GameManager._zoomRate),
            SpriteEffects.None,
            0);
        }
        else
        {
            float angle = (float)Math.Atan2(end_y - start_x, end_x - start_x);
            float length = Vector2.Distance(new Vector2(start_x, start_y), new Vector2(end_x, end_y));

            GameManager._spriteBatch.Draw(
                _blankTexture,
                new Vector2(start_x, start_y),
                null, color,
                angle,
                new Vector2(0, 0.5f),
                new Vector2(length, 1),
                SpriteEffects.None,
                0);
        }
    }

    static public void VDraw(int start_x , int start_y, int 縦長さ, Color 色, int 太さ = 1)
    {
        if (縦長さ < 0)
        {
            縦長さ *= -1;
            start_y -= 縦長さ;
        }
        Rect.Draw(start_x, start_y, 太さ, 縦長さ, 色);
    }

    static public void HDraw(int start_x, int start_y, int 横長さ, Color 色, int 太さ = 1)
    {
        if (横長さ < 0)
        {
            横長さ *= -1;
            start_x -= 横長さ;
        }
        Rect.Draw(start_x, start_y, 横長さ, 太さ, 色);
    }


}


public struct Rect
{
    public int x = 0;
    public int y = 0;
    public int w = 0;
    public int h = 0;

    public Rect(int x,int y,int w,int h)
    {
        this.x = x;
        this.y = y;
        this.w = w;
        this.h = h;
    }

    public bool Hit(Position 点)
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

    static public void Draw(int x, int y, int w, int h ,Color color , bool is塗りつぶし = true)
    {
        if(_blankTexture == null )
        {
            _blankTexture = new Texture2D(GameManager._spriteBatch.GraphicsDevice, 1, 1);
            _blankTexture.SetData(new[] { Color.White });
        }

        x += GameManager._camera_x;
        y += GameManager._camera_y;

        if( GameManager._zoomRate != 1 && is塗りつぶし == true)
        {
            x *= GameManager._zoomRate;
            y *= GameManager._zoomRate;
            w *= GameManager._zoomRate;
            h *= GameManager._zoomRate;
        }

        if(is塗りつぶし == true)
        {
            GameManager._spriteBatch.Draw(_blankTexture, new Rectangle(x, y, w, h), color);
        }
        else
        {
            Line.HDraw(x, y, w, color);
            Line.HDraw(x, y+h-1, w, color);

            Line.VDraw(x, y, h, color);
            Line.VDraw(x+w-1, y, h, color);
        }
    }

}