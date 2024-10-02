﻿/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//設定変更ウィンドウ
public class P_Archive : UI_Page
{
    public static P_Archive This = new P_Archive();

    UI_Button 内容テキスト = new UI_Button();
    UI_Button 戻るボタン = new UI_Button();
    List<UI_Button> 実績ボタン = new List<UI_Button>(50);

    public override void Init()
    {
        //実績アイコンが並ぶ、クリックで詳細表示
        for (int a = 0; a < 50; a++)
        {
            実績ボタン.Add(new UI_Button());
            実績ボタン[a].画像 = AImage.アイコン[0];
            //実績ボタン[a].フレーム = AImage.フレーム[2];
        }

        内容テキスト.フレーム = AImage.フレーム[2];
        内容テキスト.テキスト = "ここに概要を表示します";

        戻るボタン.テキスト = "戻る";
        戻るボタン.フレーム = AImage.フレーム[4];

        戻るボタン.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.メインメニュー;
        };
    }

    public override void Draw()
    {
        int cx = GameManager.GetWindowWidth() / 2;
        int cy = GameManager.GetWindowHeight() / 2;

        AImage.チェック背景.DrawRotate(cx + GameParam.タイマー / 2 % 72, cy, 36, 0);

        int n = 0;
        foreach (var it in 実績ボタン)
        {
            it.形状 = new Rect(n % 10 * 30 + cx - 150, n / 10 * 30 + 70, 25, 25);
            it.Draw();
            n++;
        }

        戻るボタン.形状 = new(cx - 50, 230, 100, 30);
        戻るボタン.Draw();

        内容テキスト.形状 = new(cx - 100, 20, 200, 30);
        内容テキスト.Draw();
    }

    public override void Update()
    {
        戻るボタン.CheckInput();

        foreach (var it in 実績ボタン)
        {
            it.CheckInput();
        }
    }
}
