using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace POY;

public class TitleScene : Scene
{
    public static TitleScene This = new TitleScene();

    //サブ呼び出しするウィンドウ
    List<UI_Window> windows = new List<UI_Window>();
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
        コンフィグウィンドウ.Init();
        クレジットウィンドウ.Init();
        削除確認ウィンドウ.Init();

        buttonS.Add(セーブスロット1);
        buttonS.Add(セーブスロット2);
        buttonS.Add(セーブスロット3);
        buttonS.Add(セーブ削除1);
        buttonS.Add(セーブ削除2);
        buttonS.Add(セーブ削除3);
        buttonS.Add(コンフィグボタン);
        buttonS.Add(クレジットボタン);
        buttonS.Add(終了ボタン);

        //テキスト設定
        セーブスロット1.テキスト = "Save Slot 1";
        セーブスロット2.テキスト = "Save Slot 2";
        セーブスロット3.テキスト = "Save Slot 3";
        セーブ削除1.テキスト = "Delete";
        セーブ削除2.テキスト = "Delete";
        セーブ削除3.テキスト = "Delete";
        コンフィグボタン.テキスト = "Setting";
        クレジットボタン.テキスト = "Credit";
        終了ボタン.テキスト = "Exit";

        //フレーム設定
        foreach (UI_Button button in buttonS)
        {
            button.フレーム = AImage.フレーム[4];
        }

        //クリック関数定義
        セーブスロット1.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
        };
        セーブスロット2.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
        };
        セーブスロット3.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
        };
        セーブ削除1.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
        };
        セーブ削除2.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
        };
        セーブ削除3.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
        };
        コンフィグボタン.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
            コンフィグウィンドウ.OpenPopup();
        };
        クレジットボタン.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
            クレジットウィンドウ.OpenPopup();
        };
        終了ボタン.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
            GameParam.isゲーム終了 = true;
        };

        //サブウィンドウ初期化
        コンフィグウィンドウ.Init();
        クレジットウィンドウ.Init();
        削除確認ウィンドウ.Init();
    }

    public void Process()
    {
        int tx = GameManager.GetWindowWidth() / 2 - 50;
        int ty = GameManager.GetWindowHeight() / 4;

        //ボタン位置とサイズ補正
        セーブスロット1.SetUI(new Rect(tx-50, ty       , 150, 30));
        セーブスロット2.SetUI(new Rect(tx-50, ty + 35  , 150, 30));
        セーブスロット3.SetUI(new Rect(tx-50, ty + 70  , 150, 30));
        セーブ削除1.SetUI(new Rect(tx + 105, ty      , 60, 30));
        セーブ削除2.SetUI(new Rect(tx + 105, ty + 35 , 60, 30));
        セーブ削除3.SetUI(new Rect(tx + 105, ty + 70, 60, 30));

        コンフィグボタン.SetUI(new Rect(tx, ty+110, 100, 30));
        クレジットボタン.SetUI(new Rect(tx, ty+145, 100, 30));
        終了ボタン.SetUI(new Rect(tx, ty+180, 100, 30));

        //背景スクロール処理
        スクロール値++;
        if( スクロール値 > GameManager.GetWindowWidth())
        {
            スクロール値 = 0;
        }

        //ウィンドウの更新
        foreach (var it in UI_Window.ポップアップウィンドウ)
        {
            it.Update();
        }
    }

    public void Input()
    {
        //ポップアップある時はポップアップウィンドウのみ操作可能
        if( UI_Window.ポップアップウィンドウ.Count != 0 )
        {
            UI_Window.ポップアップウィンドウ[UI_Window.ポップアップウィンドウ.Count - 1].Input();
            return;
        }

        //ボタンクリック処理
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
        int ty = GameManager.GetWindowHeight() / 8;
        //AImage.タイトルロゴ.DrawRotate( tx , ty ,0.5 , 0);
        AFont.PM12.DrawRotate(tx, ty, 3, 0, Color.Black, "Kari Title");

        //ボタンの表示
        foreach (UI_Button button in buttonS)
        {
            button.Draw();
        }

        //著作者表示
        AFont.PM12.Draw(GameManager.GetWindowWidth() / 2, GameManager.GetWindowHeight() * 9 / 10, Color.White, "(C) 2022 Dagon", Font.FontPosition.Mid);

        //ポップアップウィンドウの表示
        if (UI_Window.ポップアップウィンドウ.Count > 0)
        {
            GameManager.SetDrawMode(GameManager.DrawMode.AlphaBlend);
            Rect.Draw(0, 0, GameManager.GetWindowWidth(), GameManager.GetWindowHeight(), new Color(0, 0, 0, 128));
            GameManager.SetDrawMode();

            foreach ( var it in UI_Window.ポップアップウィンドウ)
            {
                it.Draw();
            }
        }
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
