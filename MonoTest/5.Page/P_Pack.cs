/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//設定変更ウィンドウ
public class P_Pack : UI_Page
{
    public static P_Pack This = new P_Pack();


    List<UI_Button> 通常パック = new List<UI_Button>();
    List<UI_Button> 専用パック = new List<UI_Button>();
    UI_Button 戻るボタン = new UI_Button();

    public override void Init()
    {
        //パックと所持数一覧
        //通常パックT1～T8
        for(int a=0;a<8;a++)
        {
            通常パック.Add(new UI_Button());
            通常パック[a].フレーム = AImage.フレーム[2];
            通常パック[a].画像 = AImage.アイコン[9+a];
            通常パック[a].画像位置y = -10;
            通常パック[a].テキスト位置y = 15;
            通常パック[a].テキスト = "x99";
        }
        //専用カード人数分、16
        for (int a = 0; a < 16; a++)
        {
            専用パック.Add(new UI_Button());
            専用パック[a].フレーム = AImage.フレーム[2];
            専用パック[a].画像 = AImage.アイコン[8];
            専用パック[a].画像位置y = -10;
            専用パック[a].テキスト位置y = 15;
            専用パック[a].テキスト = "x99";
        }
        //開封中カードオブジェクト

        //戻るボタン
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

        戻るボタン.形状 = new(cx - 50, 230, 100, 30);
        戻るボタン.Draw();

        int n = 0;
        foreach (var it in 通常パック)
        {
            it.形状 = new Rect(n * 30 + 140, 40, 25, 50);
            it.Draw();
            n++;
        }

        n = 0;
        foreach (var it in 専用パック)
        {
            it.形状 = new Rect(n%8 * 30 + 140 , 100+n/8*60, 25, 50);
            it.Draw();
            n++;
        }
    }

    public override void Update()
    {
        戻るボタン.CheckInput();

        foreach(var it in 通常パック)
        {
            it.CheckInput();
        }

        foreach (var it in 専用パック)
        {
            it.CheckInput();
        }
    }
}
