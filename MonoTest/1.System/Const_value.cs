using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace MonoTest
{
    //転生ボタンなど
    internal class Config
    {
        static Config This = new Config();

        int 表示倍率 = 2;

        int BGM音量 = 5;
        int SE音量 = 5;

        //UI座標パラメータ
        Rect BGM音量プラス;
        Rect SE音量プラス;

        static void Init()
        {

        }

        static void InitUI()
        {

        }

        static void DrawTab()
        {

        }

        static void Input()
        {

        }
    }
}
