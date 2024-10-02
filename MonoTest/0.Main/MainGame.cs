/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

using CARD_IDLE;

namespace MONO_WRAP;

public class MainGame : Game
{
    public MainGame()
    {
        Input.Init();
        //512,288
        GameManager.SetZoom(2);
        GameManager.InitGraph(this, 512, 288);//２倍ズーム時
        //1920、1080 ３倍ズーム時
    }

    protected override void Initialize()
    {
        base.Initialize();
        GameManager.SetTitle("Build & Battle! Card Idle !! 0.01a");
        GameManager.SetWindowSize(Config.解像度W*Config.解像度X倍, Config.解像度H*Config.解像度X倍);

        GameManager.SetZoom(Config.解像度X倍);
        //GameManager.SetWindowSize(512*3, 288*3);//２倍ズーム時
    }

    //起動時に全リソースを一度に読み込む
    protected override void LoadContent()
    {
        MONO_WRAP.GameManager.InitSprite(GraphicsDevice);

        //ここでリソースを読み込む
        AImage.Load();
        AFont.Load();
        ASound.Load();

        Music.SetMasterVolume(0.00);
        Sound.SetMasterVolume(0.05);

        //ここでパラメータの初期化
        P_Title.This.Init();
        P_Main.This.Init();
        P_Archive.This.Init();
        P_Config.This.Init();
        P_Credit.This.Init();
        P_DeckBuild.This.Init();
        P_Lobby.This.Init();
        P_Pack.This.Init();
        P_RuleBook.This.Init();

        //テスト再生
        ASound.メインBGM.Play();//再生テスト
    }

    protected override void Update(GameTime gameTime)
    {

        //ここに操作とフレーム毎の処理を書く

        //デバッグ用にEscapeでセーブせず終了
        if (Keyboard.GetState().IsKeyDown(Keys.Escape) && CV.isデバッグ == true) { Exit(); }
        if (GameParam.isゲーム終了 == true) { Exit(); }

        GameParam.タイマー++;

        //入力&更新処理
        switch (GameParam.ページタイプ)
        {
            case PageType.メインメニュー:
                P_Main.This.Update();
                break;
            case PageType.タイトル:
                P_Title.This.Update();
                break;
            case PageType.クレジット:
                P_Credit.This.Update();
                break;
            case PageType.実績:
                P_Archive.This.Update();
                break;
            case PageType.コンフィグ:
                P_Config.This.Update();
                break;
            case PageType.デッキ構築:
                P_DeckBuild.This.Update();
                break;
            case PageType.パック開封:
                P_Pack.This.Update();
                break;
            case PageType.対戦ロビー:
                P_Lobby.This.Update();
                break;
            case PageType.ルールブック:
                P_RuleBook.This.Update();
                break;
        }

        //ライブラリ必須処理
        base.Update(gameTime);
        Input.Update();
    }

    protected override void Draw(GameTime gameTime)
    {

        GameManager.BeginDraw();
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //ここに描画処理を書く
        switch (GameParam.ページタイプ)
        {
            case PageType.メインメニュー:
                P_Main.This.Draw();
                break;
            case PageType.タイトル:
                P_Title.This.Draw();
                break;
            case PageType.クレジット:
                P_Credit.This.Draw();
                break;
            case PageType.実績:
                P_Archive.This.Draw();
                break;
            case PageType.コンフィグ:
                P_Config.This.Draw();
                break;
            case PageType.デッキ構築:
                P_DeckBuild.This.Draw();
                break;
            case PageType.パック開封:
                P_Pack.This.Draw();
                break;
            case PageType.対戦ロビー:
                P_Lobby.This.Draw();
                break;
            case PageType.ルールブック:
                P_RuleBook.This.Draw();
                break;
        }

        //ライブラリ必須処理
        GameManager.EndDraw();
        base.Draw(gameTime);
    }

    public void Close()
    {
        //終了時の処理
    }

}
