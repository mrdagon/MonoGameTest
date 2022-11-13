using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace POY;

public class TitleScene
{
    public static TitleScene This = new TitleScene();

    //サブ呼び出しするウィンドウ
    W_Config コンフィグウィンドウ = new W_Config();
    W_Credit クレジットウィンドウ = new W_Credit();
    W_Popup 削除確認ウィンドウ = new W_Popup();
    
    //ボタン
    List<UI_Button> buttons = new List<UI_Button>();

    int スクロール値 = 0;

    public void Init()
    {
        //オブジェクトの初期化
        //セーブスロット３つと削除ボタン３つ
        //コンフィグボタン
        //クレジットボタン
        //終了ボタン

        //サブウィンドウ初期化

    }

    public void Process()
    {
        //背景スクロール処理
    }

    public void Input()
    {
        //ボタンクリック処理

        //
        foreach(UI_Button button in buttons)
        {
            button.CheckInput(0, 0);//座標補正無し
        }
    }

    public void Draw()
    {
        Draw背景();

        //タイトル文字 - 画面中央に表示

        //ボタンの表示

        //著作者表示


        //テスト描画
        Rect.Draw(400, 100, 200, 200, Color.Green);
        Position.Draw(400, 100, Color.Black);

        Design.Green.Draw(UIType.明ボタン, 10, 10, 50, 50);
        Design.Blue.Draw(UIType.平ボタン, 10, 70, 50, 50);
        Design.Brown.Draw(UIType.暗ボタン, 10, 130, 50, 50);
        Design.Brown2.Draw(UIType.凸明ボタン, 10, 190, 50, 50);
        Design.Wood.Draw(UIType.凸ボタン, 10, 250, 50, 50);
        Design.BlueGrey.Draw(UIType.凸暗ボタン, 110, 10, 50, 50);
        Design.BlueGrey.Draw(UIType.凹ボタン, 110, 70, 50, 50);
        Design.Green.Draw(UIType.グループ明, 110, 130, 50, 50);
        Design.Blue.Draw(UIType.グループ中, 110, 190, 50, 50);
        Design.Brown.Draw(UIType.グループ暗, 110, 250, 50, 50);
        Design.Brown2.Draw(UIType.タイトル, 210, 10, 50, 50);
        Design.Wood.Draw(UIType.ウィンドウ, 210, 70, 50, 50);
        Design.BlueGrey.Draw(UIType.フレーム, 210, 130, 50, 50);

        for(int a=0;a<9;a++)
        {
            AImage.フレーム[a].Draw(10 + a / 3 * 50, 10 + a%3 * 50, 40, 40);
        }

        AFont.PM12.Draw(40, 40, Color.Black, "テスト描画\nMojiretu123");
    }

    public void Draw背景()
    {
    }

    public void LoadSaveTag()
    {
        //セーブデータのプレイ時間を表示
    }
}
