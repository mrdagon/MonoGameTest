/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CARD_IDLE;

public class P_Title : UI_Page
{
    public static P_Title This = new P_Title();

    
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

    public override void Init()
    {
        buttonS.Add(セーブスロット1);
        buttonS.Add(セーブスロット2);
        buttonS.Add(セーブスロット3);
        //buttonS.Add(セーブ削除1);//とりあえずアルファでは未実装
        //buttonS.Add(セーブ削除2);
        //buttonS.Add(セーブ削除3);
        buttonS.Add(コンフィグボタン);
        buttonS.Add(クレジットボタン);
        buttonS.Add(終了ボタン);

        //テキスト設定
        セーブスロット1.テキスト = "Save Slot A";
        セーブスロット2.テキスト = "Save Slot B";
        セーブスロット3.テキスト = "Save Slot C";
        セーブ削除1.テキスト = "Del";
        セーブ削除2.テキスト = "Del";
        セーブ削除3.テキスト = "Del";
        コンフィグボタン.テキスト = "Config";
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
            GameParam.ページタイプ = PageType.メインメニュー;
            ASound.効果音[SoundType.決定].Play();
        };
        セーブスロット2.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.メインメニュー;
            ASound.効果音[SoundType.決定].Play();
        };
        セーブスロット3.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.メインメニュー;
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
            GameParam.ページタイプ = PageType.コンフィグ;
            ASound.効果音[SoundType.決定].Play();
        };
        クレジットボタン.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.クレジット;
            ASound.効果音[SoundType.決定].Play();
        };
        終了ボタン.leftClickEvent = () =>
        {
            ASound.効果音[SoundType.決定].Play();
            GameParam.isゲーム終了 = true;
        };
    }

    public override void Update()
    {
        int tx = GameManager.GetWindowWidth() / 2;
        int ty = GameManager.GetWindowHeight() / 4;

        //ボタン位置とサイズ補正
        セーブスロット1.SetUI(new Rect(tx-75, ty       , 150, 30));
        セーブスロット2.SetUI(new Rect(tx-75, ty + 35  , 150, 30));
        セーブスロット3.SetUI(new Rect(tx-75, ty + 70  , 150, 30));
        セーブ削除1.SetUI(new Rect(tx + 45, ty + 3 , 24, 24));
        セーブ削除2.SetUI(new Rect(tx + 45, ty + 38, 24, 24));
        セーブ削除3.SetUI(new Rect(tx + 45, ty + 73, 24, 24));

        コンフィグボタン.SetUI(new Rect(tx-50, ty+110, 100, 30));
        クレジットボタン.SetUI(new Rect(tx-50, ty+145, 100, 30));
        終了ボタン.SetUI(new Rect(tx-50, ty+180, 100, 30));

        //ボタンの更新-操作処理
        foreach (var it in buttonS)
        {
            it.CheckInput();
        }
    }

    public override void Draw()
    {
        //タイトル文字 - 画面中央に表示
        int cx = GameManager.GetWindowWidth() / 2;
        int cy = GameManager.GetWindowHeight() / 2;
        int ty = GameManager.GetWindowHeight() / 8;

        AImage.チェック背景.DrawRotate(cx + GameParam.タイマー / 2 % 72, cy, 36, 0);

        AFont.PM12.DrawRotate(cx, ty, 2 , 0 ,Color.Black, "Card Idle!");

        //ボタンの表示
        foreach (UI_Button button in buttonS)
        {
            button.Draw();
        }

        //著作者表示
        AFont.PM12.DrawEdge( 100 , GameManager.GetWindowHeight() * 9 / 10, Color.White,Color.Black, "(C) 2024 Wonderful Game", Font.FontPosition.Mid);
    }

    public void LoadSaveTag()
    {
        //セーブデータのプレイ時間を表示
    }
}
