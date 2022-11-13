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
        GameManager.SetTitle("Path of Yggdrasil");
        GameManager.SetWindowSize(1280, 720);
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
        ASound.メインBGM.Play();//再生テスト
    }

    protected override void Update(GameTime gameTime)
    {

        //ここに操作とフレーム毎の処理を書く

        //デバッグ用にEscapeでセーブせず終了
        if (Keyboard.GetState().IsKeyDown(Keys.Escape) && CV.isデバッグ == true) { Exit(); }

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
        
        /*
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

        AFont.PM12.Draw(40, 40, Color.Black, "テスト描画\nMojiretu123");
        */

        //ライブラリ必須処理
        GameManager.EndDraw();
        base.Draw(gameTime);
    }

    public void Close()
    {
        //終了時の処理
    }

}
