using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace MonoTest
{
    internal class Relic
    {
        static List<Relic> 一覧 = new List<Relic>();
        string 名前;
        string 説明;
        double 所持数;
        double 限界所持数;
        double 抽選率;

        RelicType レリック種;
        RecipeType 対応レシピ;

        static void Init()
        {

        }

        static void InitUI()
        {

        }

        static void Set(string 名前,string 説明,double 抽選率,RelicType レリック種 , RecipeType 対応レシピ = RecipeType.COUNT)
        {

        }

        static void DrawTab()
        {

        }

        void Draw()
        {

        }

        void Input()
        {

        }

    }



}
