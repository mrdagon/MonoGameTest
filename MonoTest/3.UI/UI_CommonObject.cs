/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;


//ボタン
public class UI_Button : UI_Object
{
    public string テキスト = "";
    public Image 画像 = null;
    public Frame フレーム = null;

    public int テキスト位置 = 5;//1~9 テンキーの位置関係と対応
    public int 画像位置 = 5;//1~9 テンキーの位置関係と対応

    //Draw派生
    public override void Draw派生()
    {
        //フレームの描画
        フレーム.Draw(形状.x, 形状.y, 形状.w, 形状.h);

        //テキストの描画
        AFont.PM12.DrawRotate(形状.x + 形状.w /2, 形状.y + 形状.h / 2, 1, 0, Microsoft.Xna.Framework.Color.Black, テキスト);

        //画像アイコンの描画

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

    int テキスト位置 = 5;//1~9 テンキーの位置関係と対応
    int 画像位置 = 5;//1~9 テンキーの位置関係と対応

    //SetUI関数

    //Draw派生

    //Click
}