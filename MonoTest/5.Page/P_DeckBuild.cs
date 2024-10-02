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
public class P_DeckBuild : UI_Page
{
    class UI_デッキ : UI_Object
    {
        public override void Draw派生()
        {
            //台座とカード
            //AImage.フレーム[2].Draw(形状);
            AImage.台座[0].Draw(形状.x+2, 形状.y);
            AImage.カード[0].Draw(形状.x + 10, 形状.y + 5);
        }
    }

    public static P_DeckBuild This = new P_DeckBuild();
    public static int page = 0;//0デッキ選択中 1編集中 2アイコン変更
    public static int deckID = -1;//未選択-1,0～選択デッキ

    List<UI_デッキ> デッキ = new List<UI_デッキ>(16);
    UI_Button デッキ詳細 = new UI_Button();

    //所持カードリストオブジェクト

    //デッキ内カードリストオブジェクト

    //ソート用、コスト(0-10+)、ミニオン、スペル、エンチャント

    //編集ボタン
    UI_Button 編集ボタン = new UI_Button();
    //アイコン変更ボタン
    UI_Button アイコン変更ボタン = new UI_Button();
    //戦績リセットボタン
    UI_Button 戦績リセットボタン = new UI_Button();
    //戻るボタン
    UI_Button 戻るボタン = new UI_Button();

    public override void Init()
    {
        //使用デッキオブジェクト
        for (int a = 0; a < 16; a++)
        {
            デッキ.Add(new UI_デッキ());
        }

        戻るボタン.テキスト = "戻る";
        戻るボタン.フレーム = AImage.フレーム[4];

        デッキ詳細.テキスト = "戦績とか表示";
        デッキ詳細.フレーム = AImage.フレーム[2];

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

        switch (page)//0デッキ選択中 1編集中 2アイコン変更
        {
            case 0:
                for (int a = 0; a < 16; a++)
                {
                    デッキ[a].形状 = new Rect( a%4*40 + 80, a/4*40 +40, 35 , 35);
                    デッキ[a].Draw();
                }
                戻るボタン.形状 = new(cx - 50, 230, 100, 30);
                戻るボタン.Draw();

                デッキ詳細.形状 = new( 280 , 38, 160, 160);
                デッキ詳細.Draw();
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

    public override void Update()
    {
        switch (page)//0デッキ選択中 1編集中 2アイコン変更
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
