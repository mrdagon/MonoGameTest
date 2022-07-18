using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace MonoTest
{
    //戦闘中の敵の状態
    internal class Enemy
    {
        static Enemy This = new Enemy();

        double 最大HP;
        double 現在HP;
        Image 画像;
        bool isボス;
        int 雑魚数;
        int Lv;

        int 座標ズレX;
        int 座標ズレY;
        int 座標ズレ時間;

        Rect クリック範囲;

        static void Init()
        {
            
        }

        static void InitUI()
        {

        }

        void ダメージ処理(double ダメージ)
        {
            //HPを減らす
            
            //HP0以下なら死亡処理
        }

        void 死亡処理()
        {
            //次の敵の発生など

            //ボスなら街を開放

            //宝箱獲得判定
        }

        void Draw()
        {
            
        }

        static void Input()
        {

        }
    }
}
