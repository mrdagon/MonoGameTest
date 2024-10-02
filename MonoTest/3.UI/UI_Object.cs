/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//UIオブジェクトのベースクラス
public class UI_Object
{
    public string テキスト = "";

    public static UI_Object now_help = null;

    public Action leftClickEvent = () => { };
    public Action rightClickEvent = () => { };
    public Action drawEvent = () => { };
    public Func<bool> dropEvent = () => { return false; };
    public Action overEvent = () => { };

    public UI_Object 親 = null;

    public Rect 形状;
    public int 整列x = 0;
    public int 整列y = 0;
    public int 改行値 = 1;

    public bool is表示 = true;
    public bool is表示オンリー = false;
    public bool isOver = false;
    public bool isCanClick = true;//クリック、ドラッグ、ドロップをスルー
    public int mousePos = 0;//0、マウス乗っていない：1、左側：2、右側

    public int 整列ID = 0;

    public bool isLeftDock = true;//X座標を左端から参照する

    public virtual void Draw派生()
    {
        drawEvent();
    }

    public void SetUI(Rect レイアウト , int 整列ID = 0 , UI_Object 親オブジェクト = null)
    {
        形状 = レイアウト;
        this.整列ID = 整列ID;
        親 = 親オブジェクト;
    }

    Position GetPos()
    {
        return new Position( GetX() , GetY() );
    }

    Position GetPos(Rect レイアウト)
    {
        return new Position( GetX() + レイアウト.x , GetY() + レイアウト.y );
    }

    Position GetCenterPos()
    {
        return new Position( GetCenterX() , GetCenterY() );
    }

    Position GetCenterPos(Rect レイアウト)
    {
        return new Position( GetCenterX() + レイアウト.x , GetCenterY() + レイアウト.y );
    }

    public int GetX()
    {
        //通常座標系
        if( isLeftDock == true)
        {
            if( 整列ID <= 0 )
            {
                if( 親 == null )
                {
                    return 形状.x;
                }

                return 形状.x + 親.GetX();
            }

            if (親 == null)
            {
                return 形状.x + (整列ID % 改行値) * 整列x;
            }

            return 親.GetX() + 形状.x + (整列ID % 改行値) * 整列x;
        }

        //右側座標系
        if (整列ID <= 0)
        {
            if (親 == null)
            {
                return Config.解像度W - (形状.x);
            }

            return Config.解像度W - (親.GetX() + 形状.x);
        }

        if (親 == null)
        {
            return Config.解像度W - (形状.x + (整列ID % 改行値) * 整列x);
        }

        return Config.解像度W - (親.GetX() + 形状.x + (整列ID % 改行値) * 整列x);
    }

    public int GetY()
    {
        if (整列ID <= 0)
        {
            if (親 == null)
            {
                return 形状.y;
            }
            return 親.GetY() + 形状.y;
        }

        if (親 == null)
        {
            return 形状.y + (整列ID / 改行値) * 整列y;
        }

        return 親.GetY() + 形状.y + (整列ID / 改行値) * 整列y;
    }

    public int GetCenterX()
    {
        return GetX() + GetW() / 2;
    }

    public int GetCenterY()
    {
        return GetY() + GetH() / 2;
    }

    public int GetW()
    {
        return 形状.w;
    }

    public int GetH()
    {
        return 形状.h;
    }

    public void Draw()
    {
        Draw派生();

        //クリック判定のサイズ表示
        if( CV.isデバッグ == true && CV.isオブジェクト形状表示 == true )
        {
            Rect.Draw(GetX(), GetY(), GetW(), GetH(), Microsoft.Xna.Framework.Color.Red,false);
        }

        isOver = false;
    }

    //クリック、ドロップ、マウスオーバー判定を処理 //クリック or ドロップでtrue
    //px 座標差分、py 座標差分
    public bool CheckInput(int px = 0, int py = 0)
    {
        mousePos = 0;

        //非表示 or 表示だけで触れないオブジェクト
        if (is表示 == false || is表示オンリー == true) { return false; }

        Rect rect = new Rect(GetX() + px , GetY() + py , GetW() , GetH() );

        if (Input.mouse.Hit(rect) == false) { return false; }

        isOver = true;
        mousePos = Input.mouse.x < (rect.x + GetW() / 2) ? 1 : 2;//左右のどちら側をクリックしたか

        if (isCanClick == false)
        {
            Over();
            return false;
        }
        else if(Input.mouseLeft.on == true )
        {
            Click();
            return true;
        }
        else if (Input.mouseRight.on == true)
        {
            RightClick();
            return true;
        }
        else if (Input.mouseLeft.off == true)
        {
            if (Drop() == true) { return true; };
        }

        Over();
        return true;
    }

    //左クリック操作
    public virtual void Click()
    {
        leftClickEvent();
    }

    //右クリック操作
    public virtual void RightClick()
    {
        rightClickEvent();
    }

    //ドロップ操作
    public virtual bool Drop()
    {
        return dropEvent();
    }

    //マウスオーバー時の処理
    public virtual void Over()
    {
        overEvent();
    }
}
