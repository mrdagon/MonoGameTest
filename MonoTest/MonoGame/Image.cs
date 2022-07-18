using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;


namespace MonoWrap
{
    internal class Image
    {
        private Texture2D _texture;
        private Rectangle _使用範囲;

        static public Image[] LoadDivGraph(string リソース名, int 横分割 , int 縦分割 , int 総数)
        {
            Image[] imageS = new Image[総数];
            Texture2D texture2D = GameManager._game.Content.Load<Texture2D>(リソース名);
            int w = texture2D.Width / 横分割;
            int h = texture2D.Height / 縦分割;

            for (int i = 0; i < 総数; i++)
            {
                imageS[i] = new Image();
                imageS[i]._texture = texture2D;
                imageS[i]._使用範囲 = new Rectangle(( i % 横分割) * w, (i / 縦分割) * h, w, h);
            }

            return imageS;
        }

        public void Load(string リソース名)
        {
            _texture = GameManager._game.Content.Load<Texture2D>(リソース名);
            _使用範囲 = new Rectangle(0, 0, _texture.Width, _texture.Height);
        }

        public void Draw( Point 座標 , bool is反転 = false)
        {
            //DrawRotate(座標, 1, 0, is反転);
            Draw(座標.x,座標.y , is反転);
        }

        public void Draw(int 座標X, int 座標Y, bool is反転 = false)
        {
            if( GameManager._zoomRate != 1)
            {
                座標X *= GameManager._zoomRate;
                座標Y *= GameManager._zoomRate;
            }

            GameManager._spriteBatch.Draw(_texture, new Vector2(座標X, 座標Y), _使用範囲, GameManager._drawingColor,0,new Vector2(0,0), GameManager._zoomRate , is反転 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }

        public void DrawRotate( Point 座標, double 拡大率 , double 角度 , bool is反転 = false)
        {
            DrawRotate(座標.x, 座標.y, 拡大率, 角度, is反転);
        }

        public void DrawRotate(int 座標X ,int 座標Y, double 拡大率, double 角度, bool is反転 = false)
        {
            if (GameManager._zoomRate != 1)
            {
                座標X *= GameManager._zoomRate;
                座標Y *= GameManager._zoomRate;
                拡大率 *= GameManager._zoomRate;
            }

            GameManager._spriteBatch.Draw(_texture, new Vector2(座標X, 座標Y), _使用範囲, GameManager._drawingColor, (float)角度, new Vector2(_使用範囲.Width / 2, _使用範囲.Height / 2), (float)拡大率, is反転 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }

        public void DrawExtend(int 座標X, int 座標Y , int 幅 , int 高さ)
        {
            if (GameManager._zoomRate != 1)
            {
                座標X *= GameManager._zoomRate;
                座標Y *= GameManager._zoomRate;
                幅 *= GameManager._zoomRate;
                高さ *= GameManager._zoomRate;
            }

            GameManager._spriteBatch.Draw(_texture, new Vector2(座標X, 座標Y), _使用範囲, GameManager._drawingColor, 0, new Vector2(0, 0), new Vector2((float)幅 / _使用範囲.Width, (float)高さ / _使用範囲.Height),  SpriteEffects.None, 0);
        }

        public int GetWidth()
        {
            return _使用範囲.Width;
        }

        public int GetHeight()
        {
            return _使用範囲.Height;
        }
    }
}
