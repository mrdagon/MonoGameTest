using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

namespace MonoWrap;

//枠と割合ゲージ用
public class Frame
{
    private Image[] _枠画像;
    private Image[] _ゲージ画像;

    public void Load(string 枠画像リソース名 , string 内部画像リソース名 = "")
    {
        _枠画像 = Image.LoadDivGraph(枠画像リソース名,3,3,9);

        if(内部画像リソース名 != "")
        {
            _ゲージ画像 = Image.LoadDivGraph(内部画像リソース名, 3, 3, 9);
        }
        else
        {
            _ゲージ画像 = _枠画像;
        }
    }

    public void LoadFile(string 枠画像ファイル名, string 内部画像ファイル名 = "")
    {
        _枠画像 = Image.LoadDivGraphFile(枠画像ファイル名, 3, 3, 9);

        if (内部画像ファイル名 != "")
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

public enum UIType
{
    明ボタン,
    平ボタン,
    暗ボタン,
    凸明ボタン,
    凸ボタン,
    凸暗ボタン,
    凹ボタン,
    グループ明,
    グループ中,
    グループ暗,
    タイトル,
    ウィンドウ,
    フレーム,
}

public class Design
{
    public static Design Green = new Design();
    public static Design Blue = new Design();
    public static Design Brown = new Design();
    public static Design Brown2 = new Design();
    public static Design Wood = new Design();
    public static Design BlueGrey = new Design();
    public static Design Grey = new Design();

    private static Color 暗字;
    private static Color 灰字;
    private static Color 明字;

    Color 影色;//ほぼ黒色

    Color エッジ色;//濃色
    Color 濃色;
    Color 凹色;//やや暗い、凹みボタン、非選択タブ、タイトル色
    Color グループ;//やや濃色
    Color 凸色;//やや明るい
    Color 背景色;//ほぼ白色
    Color ハイライト;//明るい色

    //ウィンドウカラー初期設定処理
    //起動後に一度だけ呼び出す
    public static void Load()
    {

        Green.影色 = new Color( 0x42, 0x42, 0x42);//Gray 800
        Green.エッジ色 = new Color( 0x61, 0x61, 0x61);//Gray 600
        Green.濃色 = new Color( 0x2E, 0x7D, 0x32);//Green 800
        Green.凹色 = new Color( 0x43, 0xA0, 0x47);//Green 600
        Green.グループ = new Color( 0x66, 0xbb, 0x6a);//Green 400
        Green.背景色 = new Color( 0xa5, 0xd6, 0xa7);//Green 200
        Green.凸色 = new Color( 0xc8, 0xe6, 0xc9);//Green 100
        Green.ハイライト = new Color( 0xE8, 0xF5, 0xE9);////Green 50

        Blue.影色 = new Color( 0x42,0x42, 0x42);//Gray 800
        Blue.エッジ色 = new Color( 0x61, 0x61, 0x61);//Gray 600
        Blue.濃色 = new Color( 0x0d, 0x47, 0xa1);//900
        Blue.凹色 = new Color( 0x15, 0x65, 0xc0);//800
        Blue.グループ = new Color( 0x42, 0xA5, 0xF5);//400
        Blue.背景色 = new Color( 0x90, 0xCA, 0xF9);//200
        Blue.凸色 = new Color( 0xBB, 0xDE, 0xFB);//100
        Blue.ハイライト = new Color( 0xE3, 0xF2, 0xFD);////50

        Brown.影色 = new Color( 0x42, 0x42, 0x42);//Gray 800
        Brown.エッジ色 = new Color( 0x61, 0x61, 0x61);//Gray 600
        Brown.濃色 = new Color( 0x6D, 0x4C, 0x41);//600
        Brown.凹色 = new Color( 0x8D, 0x6E, 0x63);//400
        Brown.グループ = new Color( 0xA1, 0x88, 0x7F);//300
        Brown.背景色 = new Color( 0xBC, 0xAA, 0xA4);//200
        Brown.凸色 = new Color( 0xD7, 0xCC, 0xC8);//100
        Brown.ハイライト = new Color( 0xEF, 0xEB, 0xE9);////50

        BlueGrey.影色 = new Color( 0x42, 0x42, 0x42);//Gray 800
        BlueGrey.エッジ色 = new Color( 0x61, 0x61, 0x61);//Gray 600
        BlueGrey.濃色 = new Color( 0x37, 0x47, 0x4F);//800
        BlueGrey.凹色 = new Color( 0x54, 0x6E, 0x7A);//600
        BlueGrey.グループ = new Color( 0x78, 0x90, 0x9C);//400
        BlueGrey.背景色 = new Color( 0x90, 0xA4, 0xAE);//300
        BlueGrey.凸色 = new Color( 0xB0, 0xBE, 0xC5);//200
        BlueGrey.ハイライト = new Color( 0xCF,0xD8, 0xDC);//100


        //オリジナル配色
        Wood.影色 = new Color( 0x42, 0x42, 0x42);//Gray 800
        Wood.エッジ色 = new Color( 0x61, 0x61, 0x61);//Gray 600
        Wood.濃色 = new Color( 82,45,20 );//800
        Wood.凹色 = new Color( 135,95,60 );//600
        Wood.グループ = new Color( 175,135,92 );//400
        Wood.背景色 = new Color( 195,165,132 );//200
        Wood.凸色 = new Color( 225,205,172 );//100
        Wood.ハイライト = new Color( 247,235,214 );////50

        明字 = new Color( 0xFAFAFA );//Gray 50
        灰字 = new Color( 0x9E9E9E );//Gray 500
        暗字 = new Color( 0x212121 );//Gray 900


        Brown2.影色 = new Color( 0x42, 0x42, 0x42);//Gray 800
        Brown2.エッジ色 = new Color( 0x61, 0x61, 0x61);//Gray 600
        Brown2.濃色 = new Color( 0x5d, 0x40, 0x37);//800
        Brown2.凹色 = new Color( 0x6D, 0x4C, 0x41);//600
        Brown2.グループ = new Color( 0x8D, 0x6E, 0x63);//400
        Brown2.背景色 = new Color( 0xA1, 0x88, 0x7F);//300
        Brown2.凸色 = new Color( 0xBC, 0xAA, 0xA4);//200
        Brown2.ハイライト = new Color( 0xD7, 0xCC, 0xC8);////100


        Grey.影色 = new Color( 0x42, 0x42, 0x42);//Gray 800
        Grey.エッジ色 = new Color( 0x61, 0x61, 0x61);//Gray 600
        Grey.濃色 = new Color( 0x42, 0x42, 0x42);//800
        Grey.凹色 = new Color( 0x61, 0x61, 0x61);//700
        Grey.グループ = new Color( 0x75, 0x75, 0x75);//600
        Grey.背景色 = new Color( 0x9E, 0x9E, 0x9E);//500
        Grey.凸色 = new Color( 0xBD, 0xBD, 0xBD);//400
        Grey.ハイライト = new Color( 0xE0, 0xE0, 0xE0);//300
    }

    public void Draw(UIType type, int x, int y, int w, int h)
    {

        switch (type)
        {
            case UIType.明ボタン: DrawButton(x, y, w, h, ハイライト); break;
            case UIType.平ボタン: DrawButton(x, y, w, h, 凸色); break;
            case UIType.暗ボタン: DrawButton(x, y, w, h, 背景色); break;
            case UIType.凸明ボタン: DrawButton凸(x, y, w, h, ハイライト); break;
            case UIType.凸ボタン: DrawButton凸(x, y, w, h, 凸色); break;
            case UIType.凸暗ボタン: DrawButton凸(x, y, w, h, 背景色); break;
            case UIType.凹ボタン: DrawButton凹(x, y, w, h); break;
            case UIType.グループ明: DrawBack(x, y, w, h, ハイライト); break;
            case UIType.グループ暗: DrawBack(x, y, w, h, グループ); break;
            case UIType.グループ中: DrawBack(x, y, w, h, 背景色); break;
            case UIType.タイトル: DrawTitle(x, y, w, h); break;
            case UIType.ウィンドウ: DrawWindow(x, y, w, h); break;
            case UIType.フレーム: DrawFrame(x, y, w, h); break;
            default:
                break;
        }
    }

    //平面ボタン
    private void DrawButton(int x, int y, int w, int h, Color ボタン色)
    {
        Rect.Draw( x,y,w,h , エッジ色);
        Rect.Draw( x + 1,y + 1,w - 2,h - 2 , ボタン色);
        Line.HDraw(x + 1, y + h - 2, w - 2, 凹色);
    }

    private void DrawButton凸(int x, int y, int w, int h, Color 色)
    {
        Rect.Draw( x,y,w,h - 2 , エッジ色);
        Rect.Draw( x + 1,y + 1,w - 2,h - 2 , 色);
        Line.HDraw( x + 1 , y + h - 3 , w - 2, グループ);
        Rect.Draw( x,y + h - 2,w,2 , 影色);
    }

    //縁有りで凹んだボタン
    private void DrawButton凹(int x, int y, int w, int h)
    {
        Rect.Draw( x,y,w,h , エッジ色);
        Rect.Draw( x + 1,y + 1, w - 2, 2 , 影色);
        Rect.Draw( x + 1,y + 3,w - 2,h - 4 , 凹色);
        Line.HDraw( x + 1 , y + h - 2 , w - 1, 濃色);
    }

    //背景色の四角を描画
    private void DrawBack(int x, int y, int w, int h, Color 色)
    {
        Rect.Draw( x  , y + 1 , w , h - 2 , 色);
        Line.HDraw( x + 1 , y , w - 2, 色);
        Line.HDraw( x + 1 , y + h - 1 , w - 2, 色);
    }

    //ウィンドウのタイトル部
    private void DrawTitle(int x, int y, int w, int h)
    {
        Rect.Draw( x,y,w,h , エッジ色, false);
        Rect.Draw( x + 1,y + 1,w - 2,h - 3 , グループ);
        Line.HDraw( x + 1 , y + h - 2 , w - 2, 凹色);
    }

    //タイトル下のウィンドウ部分
    private void DrawWindow(int x, int y, int w, int h)
    {
        Rect.Draw( x,y,w,h , エッジ色, false);
        Rect.Draw( x + 1,y + 1,w - 2,h - 2 , 背景色);
        Line.HDraw( x + 1 , y + h - 2 , w - 2, 凸色);
        Rect.Draw( x ,y + h,w , 2 , 影色);
    }

    //ヘルプウィンドウ用描画
    private void DrawFrame(int x, int y, int w, int h)
    {
        Rect.Draw( x , y , w  , h , 凹色);
    }

    //丸ボタン
    //丸ゲージ

}


