using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWrap
{
    internal class GameManager
    {
        static public Game _game;
        static public GraphicsDeviceManager _graphDevice;
        static public SpriteBatch _spriteBatch;
        static public Color _drawingColor = Color.White;
        static public int _zoomRate = 1;

        public enum DrawMode
        {
            Normal,
            AlphaBlend,
            Opaque,
            Add,
            NonPremultiplied,
        }

        static public void InitGraph(Game game , int 幅 ,int 高さ)
        {
            _game = game;

            _graphDevice = new GraphicsDeviceManager(game);
            _graphDevice.PreferredBackBufferWidth = 幅;
            _graphDevice.PreferredBackBufferHeight = 高さ;

            game.Content.RootDirectory = "Content";
            game.IsMouseVisible = true;

            _graphDevice.ApplyChanges();
        }

        static public void InitSprite(GraphicsDevice graphicsDevice)
        {
            _spriteBatch = new SpriteBatch( graphicsDevice );
        }

        static public void SetWindowSize(int 幅 ,int 高さ)
        {
            _graphDevice.PreferredBackBufferWidth = 幅;
            _graphDevice.PreferredBackBufferHeight = 高さ;
            _graphDevice.ApplyChanges();
        }

        static public void SetTitle(string タイトル文字列)
        {
            _game.Window.Title = タイトル文字列;
        }

        static public void SetZoom(int 倍率)
        {
            _zoomRate = 倍率;
        }

        static public void BeginDraw()
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred,null,SamplerState.PointWrap);
        }

        static public void EndDraw()
        {
            _spriteBatch.End();
        }

        static public void SetDrawMode(DrawMode 描画モード = DrawMode.Normal)
        {
            _spriteBatch.End();

            switch (描画モード)
            {
                case DrawMode.Normal:
                    _spriteBatch.Begin();
                    break;
                case DrawMode.AlphaBlend:
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                    break;
                case DrawMode.NonPremultiplied:
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
                    break;
                case DrawMode.Opaque:
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque);
                    break;
                case DrawMode.Add:
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
                    break;
            }
        }

        static public void SetBright(Color 描画色)
        {
            _drawingColor = 描画色;
        }

        static public void SetMouseVisible(bool is表示)
        {
            _game.IsMouseVisible = is表示;
        }

        static public void SetViewPort(Rect 描画領域 = null)
        {
            if(描画領域 == null)
            {
                _game.GraphicsDevice.Viewport = new Viewport(0, 0, _graphDevice.PreferredBackBufferWidth, _graphDevice.PreferredBackBufferHeight);
                return;
            }

            Viewport vp = new Viewport(描画領域.x * _zoomRate, 描画領域.y * _zoomRate, 描画領域.w * _zoomRate, 描画領域.h * _zoomRate);
            _game.GraphicsDevice.Viewport = vp;

        }
    }
}
