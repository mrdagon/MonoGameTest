/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

using POY;

namespace MonoWrap;

public class MainGame : Game
{
    public MainGame()
    {
        Input.Init();
        //512,278
        GameManager.SetZoom(2);
        GameManager.InitGraph(this, 1280, 720);//２倍ズーム時
        //1920、1080 ３倍ズーム時
    }

    protected override void Initialize()
    {
        base.Initialize();
        GameManager.SetTitle("Hack and Slash Simulator(Kari)");
        GameManager.SetWindowSize(1280, 720);

        GameManager.SetZoom(2);
        GameManager.SetWindowSize(1280, 720);//２倍ズーム時
        Config.解像度X倍 = 2;
    }

    //起動時に全リソースを一度に読み込む
    protected override void LoadContent()
    {
        MonoWrap.GameManager.InitSprite(GraphicsDevice);

        //ここでリソースを読み込む
        AImage.Load();
        AFont.Load();
        ASound.Load();
        Design.Load();

        Music.SetMasterVolume(0.05);
        Sound.SetMasterVolume(0.01);

        //ここでパラメータの初期化
        TitleScene.This.Init();
        MainScene.This.Init();

        //テスト再生
        //ASound.メインBGM.Play();//再生テスト
    }

    protected override void Update(GameTime gameTime)
    {

        //ここに操作とフレーム毎の処理を書く

        //デバッグ用にEscapeでセーブせず終了
        if (Keyboard.GetState().IsKeyDown(Keys.Escape) && CV.isデバッグ == true) { Exit(); }
        if (GameParam.isゲーム終了 == true) { Exit(); }

        //入力&更新処理
        switch (GameParam.シーンタイプ)
        {
            case SceneType.メインゲーム:
                MainScene.This.Input();
                MainScene.This.Process();
                break;
            case SceneType.タイトル:
                TitleScene.This.Input();
                TitleScene.This.Process();
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
        switch (GameParam.シーンタイプ)
        {
            case SceneType.メインゲーム:
                MainScene.This.Draw();
                break;
            case SceneType.タイトル:
                TitleScene.This.Draw();
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
