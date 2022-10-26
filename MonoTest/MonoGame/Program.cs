using System;

namespace MonoWrap
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            //エントリーポイント
            using (var game = new MainGame())
            {
                game.Run();
                game.Close();
            }
        }
    }
}
