using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;

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
