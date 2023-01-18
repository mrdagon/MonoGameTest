using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

namespace MonoWrap;

public class Font
{
    public enum FontPosition
    {
        Left,
        Mid,
        Right        
    }

    SpriteFont font;

    public void LoadTTF(string リソース名 , int 高さ)
    {
        TtfFontBakerResult fontBakeResult;

        using (var stream = File.OpenRead(リソース名))
        {
            //CJK漢字
            CharacterRange kanji = new CharacterRange((char)0x4e00, (char)0x9fff);

            fontBakeResult = TtfFontBaker.Bake(stream,
                高さ,
                2048,
                2048,
                new[]
                {
                CharacterRange.BasicLatin,
                CharacterRange.Latin1Supplement,
                CharacterRange.LatinExtendedA,
                CharacterRange.Cyrillic,
                CharacterRange.Katakana,
                CharacterRange.Hiragana,
                kanji,
                }
            );

            font = fontBakeResult.CreateSpriteFont(GameManager._game.GraphicsDevice);
        }


    }

    //読み込むfntファイルを指定tgaファイルは同じフォルダに置く
    //https://www.angelcode.com/products/bmfont/
    public void LoadFNT( string フォルダ名 , string リソース名)
    {
        string fontData;
        using (var stream = TitleContainer.OpenStream($"{フォルダ名}/{リソース名}"))
        {
            using (var reader = new StreamReader(stream))
            {
                fontData = reader.ReadToEnd();
            }
        }

        font = BMFontLoader.Load(fontData, name => TitleContainer.OpenStream($"{フォルダ名}/" + name), GameManager._game.GraphicsDevice);
    }

    public void Draw(int 座標X , int 座標Y, Color 描画色 , string 描画する文字列 , FontPosition 文字寄せ = FontPosition.Left)
    {
        if(文字寄せ == FontPosition.Mid )
        {
            座標X -= GetDrawWidth(描画する文字列) / 2;
        }
        else if (文字寄せ == FontPosition.Right)
        {
            座標X -= GetDrawWidth(描画する文字列);
        }

        座標X += GameManager._camera_x;
        座標Y += GameManager._camera_y;

        if (GameManager._zoomRate != 1)
        {
            座標X *= GameManager._zoomRate;
            座標Y *= GameManager._zoomRate;
        }

        Color c = new Color(
            GameManager._drawingColor.R * 描画色.R / 255,
            GameManager._drawingColor.G * 描画色.G / 255,
            GameManager._drawingColor.B * 描画色.B / 255,
            GameManager._drawingColor.A * 描画色.A / 255
            );

        GameManager._spriteBatch.DrawString(font, 描画する文字列, new Vector2(座標X, 座標Y), c, 0, new Vector2(0, 0), GameManager._zoomRate, SpriteEffects.None, 0);
    }

    public void DrawRotate(int 座標X, int 座標Y, double 拡大率, double 角度, Color 描画色, string 描画する文字列)
    {
        var ms = font.MeasureString(描画する文字列);

        座標X += GameManager._camera_x;
        座標Y += GameManager._camera_y;

        if (GameManager._zoomRate != 1)
        {
            座標X *= GameManager._zoomRate;
            座標Y *= GameManager._zoomRate;
            拡大率 *= GameManager._zoomRate;
            ms *= GameManager._zoomRate;
        }

        Color c = new Color(
            GameManager._drawingColor.R * 描画色.R / 255,
            GameManager._drawingColor.G * 描画色.G / 255,
            GameManager._drawingColor.B * 描画色.B / 255,
            GameManager._drawingColor.A * 描画色.A / 255
            );


        GameManager._spriteBatch.DrawString(font, 描画する文字列, new Vector2(座標X, 座標Y), c, (float)角度, new Vector2(ms.X/2/GameManager._zoomRate, ms.Y/ 2/GameManager._zoomRate), (float)拡大率, SpriteEffects.None, 0);
    }

    public int GetDrawWidth(string 描画する文字列)
    {
        return (int)font.MeasureString(描画する文字列).X;
    }

}
