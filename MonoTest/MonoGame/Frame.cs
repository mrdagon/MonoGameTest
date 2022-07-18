using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

namespace MonoWrap
{
    //枠と割合ゲージ用
    internal class Frame
    {
        private Image[] _枠画像;
        private Image[] _ゲージ画像;

        public void Load(string 枠画像ファイル名 , string 内部画像ファイル名 = "")
        {
            _枠画像 = Image.LoadDivGraph(枠画像ファイル名,3,3,9);

            if(内部画像ファイル名 != "")
            {
                _ゲージ画像 = Image.LoadDivGraph(内部画像ファイル名, 3, 3, 9);
            }
            else
            {
                _ゲージ画像 = _枠画像;
            }
        }

        public void Draw(int 座標X ,int 座標Y , int 幅 , int 高さ)
        {
            int w = _枠画像[0].GetWidth();
            int h = _枠画像[0].GetHeight();

            //四隅
            _枠画像[0].Draw(座標X, 座標Y, false);
            _枠画像[2].Draw(座標X+幅-w, 座標Y, false);
            _枠画像[6].Draw(座標X, 座標Y+高さ-h, false);
            _枠画像[8].Draw(座標X+幅-w, 座標Y+高さ-h, false);

            //四辺
            _枠画像[1].DrawExtend(座標X + w, 座標Y, 幅 - w * 2, h);
            _枠画像[3].DrawExtend(座標X    , 座標Y+h, w, 高さ - h * 2);
            _枠画像[5].DrawExtend(座標X + 幅 - w , 座標Y + h, w, 高さ - h * 2);
            _枠画像[7].DrawExtend(座標X + w, 座標Y + 高さ - h , 幅 - w * 2, h);
            //中央
            _枠画像[4].DrawExtend(座標X + w, 座標Y + h, 幅 - w * 2, 高さ - h*2);
        }

        public void DrawGauge(int 座標X, int 座標Y, int 幅, int 高さ , int 余白 , double 割合)
        {
            Draw(座標X, 座標Y, 幅, 高さ);

            int w = _ゲージ画像[0].GetWidth();
            int h = _ゲージ画像[0].GetHeight();

            座標X += 余白;
            座標Y += 余白;
            高さ -= 余白 * 2;
            幅 -= 余白 * 2;
            幅 = (int)(幅 * 割合);

            //四隅
            _ゲージ画像[0].Draw(座標X, 座標Y, false);
            _ゲージ画像[2].Draw(座標X + 幅 - w, 座標Y, false);
            _ゲージ画像[6].Draw(座標X, 座標Y + 高さ - h, false);
            _ゲージ画像[8].Draw(座標X + 幅 - w, 座標Y + 高さ - h, false);

            //四辺
            _ゲージ画像[1].DrawExtend(座標X + w, 座標Y, 幅 - w * 2, h);
            _ゲージ画像[3].DrawExtend(座標X, 座標Y + h, w, 高さ - h * 2);
            _ゲージ画像[5].DrawExtend(座標X + 幅 - w, 座標Y + h, w, 高さ - h * 2);
            _ゲージ画像[7].DrawExtend(座標X + w, 座標Y + 高さ - h, 幅 - w * 2, h);
            //中央
            _ゲージ画像[4].DrawExtend(座標X + w, 座標Y + h, 幅 - w * 2, 高さ - h * 2);
        }

    }
}
