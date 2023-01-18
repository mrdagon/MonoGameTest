using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;

//ウィンドウベースクラス
public class UI_Window
{
    private bool is最小縮小;

    //
    public static readonly int タイトル枠高さ = 30;
    public static readonly int ツールバー高さ = 120;

    public WindowType 種類;
    public Design デザイン;
    public UI_Window ヘルプウィンドウ = null;

    public List<UI_Object> item;//スクロールする子オブジェクト
    public List<UI_Object> fix_item;//スクロールしない子オブジェクト

    public bool is閉じるボタン = true;
    public bool isヘルプボタン = true;
    public bool is固定 = false;//大きさ変更と掴み移動可能フラグ

    //状態
    public bool is表示 = true;
    public IconType アイコン;

    //座標
    public Position 座標 = new Position(0, 0);
    public Position 相対座標 = new Position(0, 0);//タイトル部分を除外した、スクロール位置計算後の左上座標

    public int 横幅;
    public int 縦幅 = 0;//タイトル部分は含まない
    public int 最大縦, 最小縦;
    public int 固定縦 = 0;//スクロールせずに固定な部分の高さ

    //内部の幅、内部幅が縦幅より大きい場合スクロールバーが出る
    public int 縦内部幅;
    public int スクロール位置 = 0;//最小0、最大立幅内部 - 立幅
    public bool isスクロールバー表示 = true;

    //つかみ処理用、一時変数
    public Position 掴み座標 = new Position(0, 0);
    public bool is移動中 = false;
    public bool is上拡縮中 = false;
    public bool is下拡縮中 = false;
    public bool isスクロール中 = false;

    public bool is最前面へ移動 = false;//trueの時、falseにして一番前に持ってくる

    public int ポップアップリザルト = 0;//ポップアップの戻り値用

    //各種初期化
    public virtual void Init() { }

    public virtual void Update() { }

    public void SetPos(int w, int h, bool is中央表示, bool isスクロールバー, bool is縦横固定)
    {
        横幅 = w;
        if( is縦横固定 == true )
        {
            縦幅 = h;
            最小縦 = h;
            最大縦 = h;
            縦内部幅 = h;
        }
        else
        {
            最小縦 = h;
            最大縦 = Config.解像度H;
            縦内部幅 = h;
        }

        if( is中央表示 == true )
        {
            座標.x = Config.解像度W / 2 - 横幅 / 2;
            座標.y = Config.解像度H / 2 - 横幅 / 2;
        }

        isスクロールバー表示 = isスクロールバー;
    }

    public void Draw()
    {
        if( is表示 == false) { return; }

        相対座標.x = 座標.x;
        相対座標.y = 座標.y - スクロール位置 + タイトル枠高さ + 固定縦;

        共通Draw();

        Reset描画範囲(true);
        //固定アイテムの描画
        for( int a = fix_item.Count - 1 ; a >= 0; a--)
        {
            if (fix_item[a].is表示 == true) { fix_item[a].Draw(); }
        }
        Reset描画範囲(false);
        //スクロールするアイテムの描画

        for (int a = (int)item.Count - 1; a >= 0; a--)
        {
            if (item[a].is表示) { item[a].Draw(); }
        }

        GameManager.SetCamera(0, 0);
        GameManager.ResetViewPort();
    }

    public void 共通Draw()
    {
        //タイトル部分


        //ウィンドウ名

        //ウィンドウアイコン

        //閉じるボタン/ヘルプボタン

        //メイン描画部分

        //スクロールバー

    }

    //なんらかの操作をしたorウィンドウ上にあった場合 trueを返す
    public bool Input()
    {
        return false;
    }

    //ドラッグ移動、拡大、縮小、閉じる、ホイール操作
    public bool 共通Input()
    {
        return false;
    }

    public bool ObjectInput()
    {
        return false;
    }

    //どこかをクリックするか、最前面フラグがtrueの時最前面へ
    public bool Check最前面へ移動()
    {
        return false;
    }

    public void Reset描画範囲(bool is固定)
    {

    }

    //ポップアップウィンドウとして表示
    public int OpenPopup(bool is多重呼び出し = false)
    {
        return ポップアップリザルト;
    }

    //子オブジェクトの追加
    public void AddItem(UI_Object ui_object , bool is固定 = false)
    {

    }

    public void AddItem<TObject>(List<TObject> _tobject , bool is固定 = false)
    {

    }

    public void AddItem<TObject>(TObject[] _tobject, bool is固定 = false)
    {

    }
}
