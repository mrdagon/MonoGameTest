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
    private static Point DrawFrame(int x, int y)
    {
        return new Point(x, y);
    }

    private static Point DrawFrame(Rect rect)
    {
        return new Point(x, y);
    }

    //テキストのみのヘルプ
    public static void Text(string テキスト)
    {

    }

    //●特殊なヘルプ
}
