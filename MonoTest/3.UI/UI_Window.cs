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
    public Point 座標 = new Point(0, 0);;
    public Point 相対座標 = new Point(0, 0);;//タイトル部分を除外した、スクロール位置計算後の左上座標

    public int 横幅;
    public int 縦幅 = 0;//タイトル部分は含まない
    public int 最大縦, 最小縦;
    public int 固定縦 = 0;//スクロールせずに固定な部分の高さ

    //内部の幅、内部幅が縦幅より大きい場合スクロールバーが出る
    public int 縦内部幅;
    public int スクロール位置 = 0;//最小0、最大立幅内部 - 立幅
    public bool isスクロールバー表示 = true;

    //つかみ処理用、一時変数
    public Point 掴み座標 = new Point(0, 0);
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

    }

    public void Draw()
    {

    }

    public void 共通Draw()
    {

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
