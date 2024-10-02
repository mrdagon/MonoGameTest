/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;
using Microsoft.Xna.Framework;

namespace CARD_IDLE;

//設定変更ウィンドウ
public class P_Credit : UI_Page
{
    public static P_Credit This = new P_Credit();

    public override void Init()
    {
        //特に初期化しない
    }

    public override void Update()
    {
        //右or左クリックでタイトルに戻る
        if (Input.mouseRight.on == true || Input.mouseLeft.on == true)
        {
            GameParam.ページタイプ = PageType.タイトル;
        }
    }

    public override void Draw()
    {
        //タイトル文字 - 画面中央に表示
        int cx = GameManager.GetWindowWidth() / 2;
        int cy = GameManager.GetWindowHeight() / 2;
        int ty = GameManager.GetWindowHeight() / 8;

        AImage.チェック背景.DrawRotate(cx + GameParam.タイマー / 2 % 72, cy, 36, 0);

        AFont.PM12.DrawRotate(cx, ty, 2, 0, Color.Black, "Credit");

        AFont.PM12.Draw(50, ty+15, Color.Black, "Main Works    （´・＠・）");
        AFont.PM12.Draw(50, ty+35, Color.Black, "Pixelart Asset 猫屋 Pixerelia");
        AFont.PM12.Draw(50, ty+55, Color.Black, "Music Asset    PANICPUMPKIN");
        AFont.PM12.Draw(50, ty+75, Color.Black, "Sound Asset    OSA");
        AFont.PM12.Draw(50, ty+95, Color.Black, "Test Play & Special thanks");




    }

}
