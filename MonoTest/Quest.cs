using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace MonoTest
{
    internal class Quest
    {
        static List<Quest> 一覧 = new List<Quest>();
        static int 現在クエスト;
        int ID;
        Recipe 要求アイテム;
        int 要求数;

        static void Init()
        {
            
        }

        static void Set(Recipe 要求アイテム , int 要求数)
        {

        }

        static void Draw()
        {
            //現在のクエストを表示

        }

        static void Check()
        {
            //現在のクエストの状態を更新
        }

    }
}
