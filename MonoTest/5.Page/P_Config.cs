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
public class P_Config : UI_Page
{
    public static P_Config This = new P_Config();

    class UI_BGM音量 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[4].Draw(形状);
            AFont.PM12.DrawEdge(形状.x+20, 形状.y + 8, Color.White, Color.Black, "BGM");
            AFont.PM12.DrawEdge(形状.x+75, 形状.y + 8, Color.White, Color.Black, Config.BGM音量.ToString() ,Font.FontPosition.Mid);
        }
    }

    class UI_SE音量 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[4].Draw(形状);
            AFont.PM12.DrawEdge(形状.x + 25, 形状.y + 8, Color.White, Color.Black, "SE");
            AFont.PM12.DrawEdge(形状.x + 75, 形状.y + 8, Color.White, Color.Black, Config.SE音量.ToString(), Font.FontPosition.Mid);
        }
    }

    class UI_解像度 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[4].Draw(形状);
            AFont.PM12.DrawEdge(形状.x + 20, 形状.y + 8, Color.White, Color.Black, "Zoom");
            AFont.PM12.DrawEdge(形状.x + 75, 形状.y + 8, Color.White, Color.Black, "x " + Config.解像度X倍.ToString() , Font.FontPosition.Mid);
        }
    }

    class UI_言語 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[4].Draw(形状);
            AFont.PM12.DrawEdge(形状.x+10, 形状.y+8, Color.White, Color.Black, "Language");

            string text = "";
            switch (Config.言語設定)
            {
                case 0: text = " JP"; break;
                case 1: text = " EN"; break;
                case 2: text = "USER"; break;
            }

            AFont.PM12.DrawEdge(形状.x+75, 形状.y+8, Color.White, Color.Black, text, Font.FontPosition.Mid);
        }
    }

    UI_BGM音量 BGM音量 = new UI_BGM音量();
    UI_SE音量 SE音量 = new UI_SE音量();
    UI_解像度 解像度 = new UI_解像度();
    UI_言語 言語 = new UI_言語();

    UI_Button BGMプラスボタン = new UI_Button();
    UI_Button BGMマイナスボタン = new UI_Button();
    UI_Button 効果音プラスボタン = new UI_Button();
    UI_Button 効果音マイナスボタン = new UI_Button();
    UI_Button 解像度プラスボタン = new UI_Button();
    UI_Button 解像度マイナスボタン = new UI_Button();
    UI_Button 言語プラスボタン = new UI_Button();
    UI_Button 言語マイナスボタン = new UI_Button();

    UI_Button 決定ボタン = new UI_Button();


    public override void Init()
    {
        ResetItem();

        AddItem(BGMプラスボタン);
        AddItem(BGMマイナスボタン);
        AddItem(効果音プラスボタン);
        AddItem(効果音マイナスボタン);
        AddItem(解像度プラスボタン);
        AddItem(解像度マイナスボタン);
        AddItem(言語プラスボタン);
        AddItem(言語マイナスボタン);

        AddItem(決定ボタン);

        //フレーム設定
        BGMプラスボタン.フレーム = AImage.フレーム[4];
        BGMマイナスボタン.フレーム = AImage.フレーム[4];
        効果音プラスボタン.フレーム = AImage.フレーム[4];
        効果音マイナスボタン.フレーム = AImage.フレーム[4];
        解像度プラスボタン.フレーム = AImage.フレーム[4];
        解像度マイナスボタン.フレーム = AImage.フレーム[4];
        言語プラスボタン.フレーム = AImage.フレーム[4];
        言語マイナスボタン.フレーム = AImage.フレーム[4];

        決定ボタン.フレーム = AImage.フレーム[4];
        //テキスト
        BGMプラスボタン.テキスト = ">";
        BGMマイナスボタン.テキスト = "<";
        効果音プラスボタン.テキスト = ">";
        効果音マイナスボタン.テキスト = "<";
        解像度プラスボタン.テキスト = ">";
        解像度マイナスボタン.テキスト = "<";
        言語プラスボタン.テキスト = ">";
        言語マイナスボタン.テキスト = "<";

        決定ボタン.テキスト = "Back";

        //クリックイベントの追加
        BGMプラスボタン.leftClickEvent = () =>
        {
            Config.BGM音量 = Math.Min(10,Config.BGM音量+1);
            Music.SetMasterVolume(Config.BGM音量 * Config.BGM音量 / 100.0);
        };

        BGMマイナスボタン.leftClickEvent = () =>
        {
            Config.BGM音量 = Math.Max(0, Config.BGM音量-1);
            Music.SetMasterVolume(Config.BGM音量 * Config.BGM音量 / 100.0);
        };
        効果音プラスボタン.leftClickEvent = () =>
        {
            Config.SE音量 = Math.Min(10, Config.SE音量+1);
            Sound.SetMasterVolume(Config.SE音量 * Config.SE音量 / 100.0);
        };
        効果音マイナスボタン.leftClickEvent = () =>
        {
            Config.SE音量 = Math.Max(0, Config.SE音量-1);
            Sound.SetMasterVolume(Config.SE音量 * Config.SE音量 / 100.0);
        };
        解像度プラスボタン.leftClickEvent = () =>
        {
            Config.解像度X倍 = Math.Min(Config.解像度上限, Config.解像度X倍+1);
            GameManager.SetWindowSize(Config.解像度W * Config.解像度X倍, Config.解像度H * Config.解像度X倍);
            GameManager.SetZoom(Config.解像度X倍);
        };
        解像度マイナスボタン.leftClickEvent = () =>
        {
            Config.解像度X倍 = Math.Max(1, Config.解像度X倍 - 1);
            GameManager.SetWindowSize(Config.解像度W * Config.解像度X倍, Config.解像度H * Config.解像度X倍);
            GameManager.SetZoom(Config.解像度X倍);
        };
        言語プラスボタン.leftClickEvent = () =>
        {
            Config.言語設定++;
            if(Config.言語設定 > 2) { Config.言語設定 = 0; }
        };
        言語マイナスボタン.leftClickEvent = () =>
        {
            Config.言語設定--;
            if (Config.言語設定 < 0) { Config.言語設定 = 2; }
        };

        決定ボタン.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.タイトル;
        };
    }

    public override void Update()
    {
        int cx = GameManager.GetWindowWidth() / 2;
        int cy = GameManager.GetWindowHeight() / 2;
        int ty = GameManager.GetWindowHeight() / 8;

        //オブジェクト位置
        BGM音量.形状 = new Rect(cx-50, 80, 100, 30);
        SE音量.形状 = new Rect(cx-50, 120, 100, 30);
        解像度.形状 = new Rect(cx-50, 160, 100, 30);
        言語.形状 = new Rect(cx-50, 200, 100, 30);

        BGMプラスボタン.形状 = new Rect(cx+55, 80, 30, 30);
        BGMマイナスボタン.形状 = new Rect(cx-85, 80, 30, 30);
        効果音プラスボタン.形状 = new Rect(cx + 55, 120, 30, 30);
        効果音マイナスボタン.形状 = new Rect(cx - 85, 120, 30, 30);
        解像度プラスボタン.形状 = new Rect(cx + 55, 160, 30, 30);
        解像度マイナスボタン.形状 = new Rect(cx - 85, 160, 30, 30);
        言語プラスボタン.形状 = new Rect(cx + 55, 200, 30, 30);
        言語マイナスボタン.形状 = new Rect(cx - 85, 200, 30, 30);

        決定ボタン.形状 = new Rect(cx-40, 240, 80, 30);

        //右クリックでもタイトルに戻る
        if(Input.mouseRight.on == true)
        { 
            //GameParam.ページタイプ = PageType.タイトル; 
        }

        //ボタンの更新
        foreach (UI_Object it in item)
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

        AFont.PM12.DrawRotate(cx, ty, 2, 0, Color.Black, "Config");

        BGM音量.Draw();
        SE音量.Draw();
        解像度.Draw();
        言語.Draw();

        //ボタンの表示
        foreach (UI_Object it in item)
        {
            it.Draw();
        }

    }
}
