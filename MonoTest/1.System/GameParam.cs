using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;

//各種グローバル変数
public class GameParam
{
    public static double プレイ時間;
    public static bool isヘルプ = true;
    public static bool isゲーム終了 = false;
    public static int セーブスロット = 0;
    public static SceneType シーンタイプ = SceneType.タイトル;

    public static void InitData()
    {

    }
}
