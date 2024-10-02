/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;


//ボタン
public class UI_Button : UI_Object
{
    public string テキスト = "";
    public Image 画像 = null;
    public Frame フレーム = null;

    public int テキスト位置x = 0;
    public int テキスト位置y = 0;

    public int 画像位置x = 0;
    public int 画像位置y = 0;

    //Draw派生
    public override void Draw派生()
    {
        //フレームの描画
        if (フレーム != null)
        {
            フレーム.Draw(形状.x, 形状.y, 形状.w, 形状.h);
        }

        //画像アイコンの描画
        if(画像 != null)
        {
            画像.DrawRotate(形状.x + 形状.w / 2 + 画像位置x , 形状.y + 形状.h / 2 + 画像位置y, 1, 0);
        }

        //テキストの描画
        AFont.PM12.DrawRotate(形状.x + 形状.w / 2 + テキスト位置x, 形状.y + 形状.h / 2 + テキスト位置y , 1, 0, Microsoft.Xna.Framework.Color.Black, テキスト);
    }
}

//テキスト
public class UI_TextFrame
{
    public string テキスト = "";

    //SetUI

    //Draw派生
}

//タブ
public class UI_Tab
{
    public int tabID;
    public Image 画像 = null;
    public string テキスト = "";
    public Frame フレーム = null;

    public bool is縁描画 = true;

    //SetUI関数

    //Draw派生

    //Click
}