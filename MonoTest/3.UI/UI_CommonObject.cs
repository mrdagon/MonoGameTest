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

    bool is押下 = false;
    int 押下状態 = 0;
    int 押下アニメ = 0;

    int テキスト位置 = 5;//1~9 テンキーの位置関係と対応
    int 画像位置 = 5;//1~9 テンキーの位置関係と対応

    //SetUI関数

    //Draw派生

    //Click
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

    public bool is縁描画 = true;

    int テキスト位置 = 5;//1~9 テンキーの位置関係と対応
    int 画像位置 = 5;//1~9 テンキーの位置関係と対応

    //SetUI関数

    //Draw派生

    //Click
}