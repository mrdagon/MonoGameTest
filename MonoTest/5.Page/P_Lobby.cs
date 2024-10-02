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
public class P_Lobby : UI_Page
{

    class UI_敵デッキ : UI_Object
    {
        public override void Draw派生()
        {
            //台座とカード
            //AImage.フレーム[2].Draw(形状);
            AImage.台座[0].Draw(形状.x + 2, 形状.y);
            AImage.カード[4].Draw(形状.x + 10, 形状.y + 5);
        }
    }

    class UI_マイデッキ : UI_Object
    {
        public override void Draw派生()
        {
            //台座とカード
            //AImage.フレーム[2].Draw(形状);
            AImage.台座[0].Draw(形状.x + 2, 形状.y);
            AImage.カード[0].Draw(形状.x + 10, 形状.y + 5);
        }
    }


    public static P_Lobby This = new P_Lobby();
    public int page = 0;//0 対戦相手選択、1デッキ選択、2対戦中
    public static int 敵DeckID = -1;//未選択-1,0～選択デッキ
    public static int MyDeckID = -1;//未選択-1,0～選択デッキ

    List<UI_敵デッキ> 敵デッキ = new List<UI_敵デッキ>(16);
    UI_Button デッキ詳細 = new UI_Button();

    //戻るボタン
    UI_Button 戻るボタン = new UI_Button();

    public override void Init()
    {
        //対戦相手オブジェクト
        for (int a = 0; a < 16; a++)
        {
            敵デッキ.Add(new UI_敵デッキ());
        }

        戻るボタン.テキスト = "戻る";
        戻るボタン.フレーム = AImage.フレーム[4];

        デッキ詳細.テキスト = "カードリストとか表示";
        デッキ詳細.フレーム = AImage.フレーム[2];

        戻るボタン.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.メインメニュー;
        };

        //使用デッキオブジェクト


        //デッキリストと戦績表示オブジェクト


        //対戦状況オブジェクト
    }

    public override void Draw()
    {
        int cx = GameManager.GetWindowWidth() / 2;
        int cy = GameManager.GetWindowHeight() / 2;

        AImage.チェック背景.DrawRotate(cx + GameParam.タイマー / 2 % 72, cy, 36, 0);
        switch (page)
        {
            case 0:
                for (int a = 0; a < 16; a++)
                {
                    敵デッキ[a].形状 = new Rect(a % 4 * 40 + 80, a / 4 * 40 + 40, 35, 35);
                    敵デッキ[a].Draw();
                }
                戻るボタン.形状 = new(cx - 50, 230, 100, 30);
                戻るボタン.Draw();

                デッキ詳細.形状 = new(280, 38, 160, 160);
                デッキ詳細.Draw();
                break;
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

    public override void Update()
    {
        switch (page)
        {
            case 0:
                戻るボタン.CheckInput();
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
