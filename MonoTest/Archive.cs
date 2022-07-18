using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace MonoTest
{
    internal class Archive
    {
        static List<Archive> 一覧 = new List<Archive>();

        static double 転生回数;
        static double 敵撃破数;
        static double 累計宝箱;
        static double 累計製造;
        static double 最大DPS;

        int ID;
        string 名前;
        string 説明;
        int 報酬の数;
        bool is獲得;

        //UI座標パラメータ
        Rect ボタン;

        static void Init()
        {
            
        }

        static void InitUI()
        {

        }

        //最後に実績を追加
        static void Set(string 名前 , string 説明 , int 報酬の数)
        {

        }

        void Check()
        {
            bool isClear = false;

            switch (ID)
            {
                case 0:
                    break;
            }

            if( isClear )
            {
                //報酬獲得＆実績解除メッセージ
            }

        }

        void Draw()
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
