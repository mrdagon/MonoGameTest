using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

namespace MonoWrap
{
    public class MainGame : Game
    {
        Image ball = new Image();
        Image[] ballDiv = null;
        Font font = new Font();
        Frame frame = new Frame();
        Music music = new Music();
        Sound sound = new Sound();

        public MainGame()
        {
            GameManager.InitGraph(this, 1200, 800);   
        }

        protected override void Initialize()
        {
            base.Initialize();
            GameManager.SetTitle("タイトルテスト");
        }

        protected override void LoadContent()
        {
            MonoWrap.GameManager.InitSprite(GraphicsDevice);

            //ここでリソースを読み込む
            ball.Load("ball");
            ballDiv = Image.LoadDivGraph("ball", 3, 3, 9);
            font.LoadTTF("Content/JF-Dot-MPlusH10.ttf", 11);
            font.LoadFNT("Content", "test.fnt");

            sound.Load("alarm00_r");

            frame.Load("ball");

            sound.Play();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }
            //ここに処理を書く

            //
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GameManager.SetZoom(2);

            GameManager.BeginDraw();
            //ここに処理を書く
            ball.Draw(new Point(25, 25), false);
            ball.DrawExtend(25, 25, 100, 25);

            font.Draw(50, 50, Color.Black, "テスト文字列");
            font.Draw(50, 70, Color.White, "テスト文字列" , Font.FontPosition.Mid);
            font.Draw(50, 90, Color.Wheat, "テスト\n文字列" , Font.FontPosition.Right);

            frame.Draw(100, 100, 90, 90);
            frame.DrawGauge(100, 100, 100, 100, 5, 0.5);

            GameManager.EndDraw();
            base.Draw(gameTime);
        }
    }
}
