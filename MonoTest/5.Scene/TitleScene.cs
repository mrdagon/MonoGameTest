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
    List<UI_Button> buttonS = new List<UI_Button>();
    UI_Button セーブスロット1 = new UI_Button();
    UI_Button セーブスロット2 = new UI_Button();
    UI_Button セーブスロット3 = new UI_Button();
    UI_Button セーブ削除1 = new UI_Button();
    UI_Button セーブ削除2 = new UI_Button();
    UI_Button セーブ削除3 = new UI_Button();
    UI_Button コンフィグボタン = new UI_Button();
    UI_Button クレジットボタン = new UI_Button();
    UI_Button 終了ボタン = new UI_Button();

    int スクロール値 = 0;

    public void Init()
    {
        //オブジェクトの初期化//
        buttonS.Add(セーブスロット1);
        buttonS.Add(セーブスロット2);
        buttonS.Add(セーブスロット3);
        buttonS.Add(セーブ削除1);
        buttonS.Add(セーブ削除2);
        buttonS.Add(セーブ削除3);
        buttonS.Add(コンフィグボタン);
        buttonS.Add(クレジットボタン);
        buttonS.Add(終了ボタン);

        //関数定義

        //サブウィンドウ初期化
        コンフィグウィンドウ.Init();
        クレジットウィンドウ.Init();
        削除確認ウィンドウ.Init();
    }

    public void Process()
    {
        //背景スクロール処理
        スクロール値++;
        if( スクロール値 > GameManager.GetWindowWidth())
        {
            スクロール値 = 0;
        }
    }

    public void Input()
    {
        //ボタンクリック処理

        //
        foreach(UI_Button button in buttonS)
        {
            button.CheckInput(0, 0);//座標補正無し
        }
    }

    public void Draw()
    {
        Draw背景();
        //タイトル文字 - 画面中央に表示
        int tx = GameManager.GetWindowWidth() / 2;
        int ty = GameManager.GetWindowHeight() / 5;
        AImage.タイトルロゴ.DrawRotate( tx , ty ,0.5 , 0);

        //ボタンの表示
        foreach (UI_Button button in buttonS)
        {
            button.Draw();
        }

        //著作者表示
        AFont.PM12.Draw(GameManager.GetWindowWidth() / 2 , GameManager.GetWindowHeight() * 9 / 10 , Color.White, "(C) 2022 Dagon", Font.FontPosition.Mid);
    }

    public void Draw背景()
    {
        int w = GameManager.GetWindowWidth();
        int h = GameManager.GetWindowHeight();

        AImage.タイトル背景後.DrawExtend(スクロール値, 0 , w , h);
        AImage.タイトル背景後.DrawExtend(スクロール値 - w, 0 , w , h);
        AImage.タイトル背景前.DrawExtend(0, 0 , w, h);
    }

    public void LoadSaveTag()
    {
        //セーブデータのプレイ時間を表示
    }
}
