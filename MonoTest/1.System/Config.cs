/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//各種設定値
public class Config
{
    public static bool isウィンドウ;//固定

    public static int BGM音量;//0-10
    public static int SE音量;//0-10

    public static int 解像度W = 512;//固定
    public static int 解像度H = 288;//固定
    public static int 解像度X倍 = 2;//1-4倍
    public static int 解像度上限 = 4;//1-4倍

    public static int 言語設定 = 0;//0 日本語,1英語 ,2その他

}
