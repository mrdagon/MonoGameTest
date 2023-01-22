using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;
using Microsoft.Xna.Framework;

namespace POY;

//設定変更ウィンドウ
public class W_Config : UI_Window
{
    class UI_BGM音量 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[0].Draw(形状);
            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, "BGM");
            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, W_Config.現在BGM音量.ToString() ,Font.FontPosition.Mid);
        }
    }

    class UI_SE音量 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[0].Draw(形状);
            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, "BGM");
            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, W_Config.現在SE音量.ToString(), Font.FontPosition.Mid);
        }
    }

    class UI_解像度 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[0].Draw(形状);
            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, "BGM");
            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, W_Config.現在解像度X倍.ToString() + "倍", Font.FontPosition.Mid);
        }
    }

    class UI_言語 : UI_Object
    {
        public override void Draw派生()
        {
            AImage.フレーム[0].Draw(形状);
            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, "BGM");

            string text = "";
            switch (W_Config.現在言語)
            {
                case 0: text = "日本語"; break;
                case 1: text = "英語"; break;
                case 2: text = "その他" ; break;
            }

            AFont.PM12.DrawEdge(形状.x, 形状.y, Color.White, Color.Black, text, Font.FontPosition.Mid);
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
    UI_Button キャンセルボタン = new UI_Button();

    public static int 現在BGM音量 = 0;
    public static int 現在SE音量 = 0;
    public static int 現在解像度X倍 = 0;
    public static int 現在言語 = 0;//0日本語,1英語,2その他

    public override void Init()
    {
        is閉じるボタン = false;
        isヘルプボタン = false;

        現在BGM音量 = Config.BGM音量;
        現在SE音量 = Config.SE音量;
        現在解像度X倍 = Config.解像度X倍;
        現在言語 = Config.言語設定;

        ResetItem();
        AddItem(BGM音量);
        AddItem(SE音量);
        AddItem(解像度);
        AddItem(言語);

        AddItem(BGMプラスボタン);
        AddItem(BGMマイナスボタン);
        AddItem(効果音プラスボタン);
        AddItem(効果音マイナスボタン);
        AddItem(解像度プラスボタン);
        AddItem(解像度マイナスボタン);
        AddItem(言語プラスボタン);
        AddItem(言語マイナスボタン);

        AddItem(決定ボタン);
        AddItem(キャンセルボタン);
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
        キャンセルボタン.フレーム = AImage.フレーム[4];

        //クリックイベントの追加
        BGMプラスボタン.leftClickEvent = () =>
        {

        };
        BGMマイナスボタン.leftClickEvent = () =>
        {

        };
        効果音プラスボタン.leftClickEvent = () =>
        {

        };
        効果音マイナスボタン.leftClickEvent = () =>
        {

        };
        解像度プラスボタン.leftClickEvent = () =>
        {

        };
        解像度マイナスボタン.leftClickEvent = () =>
        {

        };
        言語プラスボタン.leftClickEvent = () =>
        {

        };
        言語マイナスボタン.leftClickEvent = () =>
        {

        };

        決定ボタン.leftClickEvent = () =>
        {
            ClosePopup(1);
        };
        キャンセルボタン.leftClickEvent = () =>
        {
            ClosePopup(0);
        };
    }

    public override void Update()
    {
        //全体大きさ
        座標.x = 20;
        座標.y = 20;

        横幅 = 500;
        縦幅 = 300;

        //オブジェクト位置
        BGM音量.形状 = new Rect(0, 0, 100, 100);
        SE音量.形状 = new Rect(0, 0, 100, 100);
        解像度.形状 = new Rect(0, 0, 100, 100);
        言語.形状 = new Rect(0, 0, 100, 100);

        BGMプラスボタン.形状 = new Rect(0, 0, 100, 100);
        BGMマイナスボタン.形状 = new Rect(0, 0, 100, 100);
        効果音プラスボタン.形状 = new Rect(0, 0, 100, 100);
        効果音マイナスボタン.形状 = new Rect(0, 0, 100, 100);
        解像度プラスボタン.形状 = new Rect(0, 0, 100, 100);
        解像度マイナスボタン.形状 = new Rect(0, 0, 100, 100);
        言語プラスボタン.形状 = new Rect(0, 0, 100, 100);
        言語マイナスボタン.形状 = new Rect(0, 0, 100, 100);

        決定ボタン.形状 = new Rect(100, 0, 100, 100);
        キャンセルボタン.形状 = new Rect(200, 100, 100, 100);
    }
}
