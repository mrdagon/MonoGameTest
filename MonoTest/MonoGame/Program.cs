/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;

namespace MONO_WRAP;

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
