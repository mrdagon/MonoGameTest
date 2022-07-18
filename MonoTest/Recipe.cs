using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace MonoTest
{
    internal class Recipe
    {
        static List<Recipe> 一覧 = new List<Recipe>();
        static Recipe マウスON;

        bool is製造可能;//クリックで製造可能か
        bool is開放;

        Recipe[] 素材 = new Recipe[4];
        Recipe 製造設備;
        RecipeType レシピ種;
        double 制作時間;

        double 製造進行;
        double 所持数;
        double 自動製造数;

        Rect ボタン;

        static Rect 拡大ボタン;
        static Rect プラスボタンA;
        static Rect プラスボタンB;

        static void Init()
        {

        }

        static void InitUI()
        {

        }

        static void Set()
        {

        }

        static void DrawTab()
        {

        }

        void Draw()
        {

        }

        static void DrawMouseOver()
        {

        }

        static void 全製造()
        {

        }

        void 製造()
        {
        }

        static void Input()
        {

        }
    }
}
