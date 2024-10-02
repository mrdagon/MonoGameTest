/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//各種グローバル変数
public class GameParam
{
    public static bool isゲーム終了 = false;
    public static PageType ページタイプ = PageType.タイトル;//現在のページ

    public static int セーブスロット = 0;//選択セーブスロット
    public static double プレイ時間;//トータルプレイ時間
    public static int タイマー=0;//起動してからのフレーム数

    //所持カード
    //実績フラグ
    //所持パック

    public static void InitData()
    {

    }
}
