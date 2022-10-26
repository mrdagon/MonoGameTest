using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace MonoTest
{
    internal class Tab
    {
        static int ID = 0;
        static Rect メイン = new Rect();
        static Rect 製造タブ = new Rect();
        static Rect 金レシピタブ = new Rect();
        static Rect ステータスタブ = new Rect();
        static Rect コンフィグタブ = new Rect();
        static Rect 実績タブ = new Rect();

        public static void Draw()
        {
            InitUI();
        }

        public static void InitUI()
        {

        }

        public static void Input()
        {

        }
    }
}
