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
        Image back = new Image();
        Image[] ballDiv = null;
        Font font = new Font();
        Frame frame = new Frame();
        Music music = new Music();
        Sound sound = new Sound();

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
            GameManager.SetTitle("放置工場～Idle Factory～");
            GameManager.SetWindowSize(1280, 720);
        }

        protected override void LoadContent()
        {
            MonoWrap.GameManager.InitSprite(GraphicsDevice);

            //ここでリソースを読み込む
            ball.LoadFile("icon/オムライス.png");
            back.LoadFile("background.png");

            ballDiv = Image.LoadDivGraph("ball", 3, 3, 9);
            //font.LoadTTF("Content/JF-Dot-MPlusH10.ttf", 11);
            font.LoadFNT("Content", "test.fnt");

            //music.LoadFile("alarm00r.mp3");
            sound.LoadFile("alarm00_r.wav");

            frame.LoadFile("frame/タブB.png");

            //music.Play();
            sound.Play();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }
            //ここに処理を書く

            //
            base.Update(gameTime);
            Input.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            GameManager.SetZoom(2);

            GameManager.BeginDraw();
            //ここに処理を書く
            back.Draw(0, 0);

            ball.Draw(new Point(25, 25), false);
            ball.DrawExtend(25, 25, 100, 25);

            font.Draw(50, 50, Color.Black, $"テスト文字列 X{Input.mouse.x},Y{Input.mouse.y}");
            font.Draw(50, 70, Color.White, "テスト文字列" , Font.FontPosition.Mid);
            font.DrawRotate(50, 90, 0.5,0,Color.Wheat, "テスト\n文字列");

            frame.Draw(100, 100, 90, 90);
            frame.DrawGauge(100, 100, 100, 100, 5, 0.5);

            GameManager.EndDraw();
            base.Draw(gameTime);
        }
    }
}
