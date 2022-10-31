using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

namespace MonoWrap
{
    public class MainGame : Game
    {
        public MainGame()
        {
            Input.Init();
            //512,278
            GameManager.InitGraph(this, 1280, 720);//２倍ズーム時
            //1920、1080 ３倍ズーム時
        }

        protected override void Initialize()
        {
            base.Initialize();
            GameManager.SetTitle("Path of Yggdrasil");
            GameManager.SetWindowSize(1280, 720);
        }

        protected override void LoadContent()
        {
            MonoWrap.GameManager.InitSprite(GraphicsDevice);

            //ここでリソースを読み込む
            //RImage.Load();
            //RFont.Load();
            //RSound.Load();

            //RSound.メインBGM.Play();
            Music.SetMasterVolume(0.05);
            Sound.SetMasterVolume(0.01);

            //ここでパラメータの初期化
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }
            //ここに操作とフレーム毎の処理を書く
            //入力処理
            //Tab.Input();//タブ毎の入力処理

            //更新処理

            //
            base.Update(gameTime);
            Input.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GameManager.SetZoom(2);

            GameManager.BeginDraw();
            //ここに描画処理を書く
            //RImage.背景.Draw(0, 0);
            //Tab.Draw();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            Line.Draw(100, 100, 200, 200, Color.White);
            Rect.Draw(400, 100, 200, 200, Color.Green);
            Point.Draw(500, 200, Color.Yellow);

            //
            GameManager.EndDraw();
            base.Draw(gameTime);
        }

        public void Close()
        {
            //終了時の処理
        }

    }
}
