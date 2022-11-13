using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;

//UIオブジェクトのベースクラス
public class UI_Object
{
    public virtual void Draw派生()
    {

    }

    public virtual void Check派生()
    {

    }

    public string ヘルプテキスト = "";

    public static UI_Object now_help = null;

    public Action clickEvent = () => { };
    public Action drawEvent = () => { };
    public Func<bool> dropEvent = () => { return false; };
    public Action overEvent = () => { };

    public UI_Object 親 = null;

    public Rect 形状;

    public bool is表示 = true;
    public bool is表示オンリー = false;
    public bool isOver = false;
    public bool isCanClick = true;//クリック、ドラッグ、ドロップをスルー
    public int mousePos = 0;//0、マウス乗っていない：1、左側：2、右側

    public int lineID = 0;

    public bool isLeftDock = true;//X座標を左端から参照する

    public void SetUI()
    {

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
        return 0;
    }

    public int GetY()
    {
        return 0;
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
        return 0;
    }

    public int GetH()
    {
        return 0;
    }

    public void Draw()
    {

    }

    public void DrawUI()
    {

    }

    public bool CheckInput(double px, double py)
    {
        return true;
    }

    //クリック操作
    public virtual void Click()
    {
        clickEvent();
    }

    public virtual void RightClick()
    {

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

    public virtual void DrawHelp()
    {
        //通常はセットしてあるテキストヘルプ
        if (ヘルプテキスト != null)
        {
            UIHelp.Text(ヘルプテキスト);
        }
    }
}
