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
    public static double プレイ時間;
    public static bool isヘルプ = true;
    public static bool isゲーム終了 = false;
    public static int セーブスロット = 0;
    public static SceneType シーンタイプ = SceneType.タイトル;

    public static void InitData()
    {

    }
}
