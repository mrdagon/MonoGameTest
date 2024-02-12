/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;


namespace MONO_WRAP;

public class Frame
{
    Image[] フレーム画像;

    //ファイルを９分割で読み込む
    public void LoadFile(string ファイル名)
    {
        フレーム画像 = Image.LoadDivGraphFile(ファイル名, 3, 3, 9);
    }

    //読み込んだファイルを元にフレームを描画する
    public void Draw(Rect 形状)
    {
        Draw(形状.x, 形状.y, 形状.w, 形状.h);
    }

    public void Draw(int x,int y, int w,int h)
    {
        int WW = フレーム画像[0].GetWidth();
        int HH = フレーム画像[0].GetHeight();

        フレーム画像[0].Draw(x, y);
        フレーム画像[1].DrawExtend(x+WW, y , w-WW*2 , HH);
        フレーム画像[2].Draw(x+w-WW, y);

        フレーム画像[3].DrawExtend(x, y+HH, WW, h-HH*2);
        フレーム画像[4].DrawExtend(x+WW, y+HH, w-WW*2, h - HH * 2);
        フレーム画像[5].DrawExtend(x+w-WW, y+HH, WW, h - HH * 2);

        フレーム画像[6].Draw(x, y+h-HH);
        フレーム画像[7].DrawExtend(x+WW, y+ h - HH, w-WW*2, HH);
        フレーム画像[8].Draw(x+w-WW, y+ h - HH);
    }

}
