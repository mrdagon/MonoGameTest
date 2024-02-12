/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//マウスオーバーヘルプウィンドウ
public class UIHelp
{
    private UIHelp(){}

    //マウス位置とウィンドウサイズから、上下左右どちらの方向にウィンドウ出すか計算
    private static Position DrawFrame(int x, int y)
    {
        return new Position(x, y);
    }

    private static Position DrawFrame(Rect rect)
    {
        return new Position(rect.x, rect.y);
    }

    //テキストのみのヘルプ
    public static void Text(string テキスト)
    {

    }

    //●特殊なヘルプ
}
