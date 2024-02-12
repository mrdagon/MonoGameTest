/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CARD_IDLE;

//ウィンドウベースクラス-削除時の警告専用
public class UI_Window
{
    private bool is最小縮小;
    
    //
    public static readonly int タイトル枠高さ = 30;
    public static readonly int ツールバー高さ = 120;

    private static Frame タイトルフレーム = null;
    private static Frame 枠フレーム = null;
    private static Frame 空白フレーム = null;
    private static Frame スクロールフレーム = null;
    private static Frame スクロール内部フレーム = null;
    private static Font フォント = null;

    public WindowType 種類;
    public UI_Window ヘルプウィンドウ = null;

    public List<UI_Object> item = new List<UI_Object>();//スクロールする子オブジェクト
    public List<UI_Object> fix_item = new List<UI_Object>();//スクロールしない子オブジェクト

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

    static public List<UI_Window> ポップアップウィンドウ = new List<UI_Window>();
    public bool isポップアップウィンドウ = false;
    public int ポップアップリザルト = 0;//ポップアップの戻り値用

    public static void SetFrameFont(Frame タイトル,Frame 枠 , Frame 空白,Frame スクロール,Frame スクロール内部,Font _フォント)
    {
        タイトルフレーム = タイトル;
        枠フレーム = 枠;
        空白フレーム = 空白;
        スクロールフレーム = スクロール;
        スクロール内部フレーム = スクロール内部;
        フォント = _フォント;
    }

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
        GameManager.EndDraw();
        GameManager.BeginDraw();

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
        GameManager.EndDraw();
        GameManager.BeginDraw();

        GameManager.SetCamera(0, 0);
        GameManager.ResetViewPort();
    }

    public void 共通Draw()
    {
        //タイトル部分
        タイトルフレーム.Draw(座標.x, 座標.y, 横幅, タイトル枠高さ);

        //ウィンドウ名
        フォント.DrawEdge(座標.x + 34, 座標.y + 1, Color.White , Color.Black, "タイトルテスト");

        //ウィンドウアイコン
        空白フレーム.Draw(座標.x + 6, 座標.y + 6, タイトル枠高さ - 12, タイトル枠高さ - 12);
        //todo MIcon::UI[アイコン].DrawRotate({ 座標.x + 15,座標.y + 15 }, 1, 0);

        //閉じるボタン
        if (is閉じるボタン == true)
        {
            空白フレーム.Draw(座標.x + 横幅 - 25, 座標.y + 6, タイトル枠高さ - 12, タイトル枠高さ - 12);
            //todo MIcon::UI[IconType::閉じる].DrawRotate({ 座標.x + 横幅 - 16 ,座標.y + 15 }, 1, 0);
        }

        //ヘルプボタン
        if (isヘルプボタン == true)
        {
            空白フレーム.Draw(座標.x + 横幅 - 55, 座標.y + 6, タイトル枠高さ - 12, タイトル枠高さ - 12);
            //todo MIcon::UI[IconType::ヘルプ].DrawRotate({ 座標.x + 横幅 - 46 ,座標.y + 15 }, 1, 0);
        }

        //メイン描画部分
        枠フレーム.Draw(座標.x, 座標.y + タイトル枠高さ, 横幅, 縦幅);

        //スクロールバー
        if (縦幅 < 縦内部幅)
        {
            スクロールフレーム.Draw(座標.x + 横幅 - 26, 座標.y + タイトル枠高さ + 4, 20, 縦幅 - 8);

            int scrH = (縦幅 - 16) * 縦幅 / 縦内部幅;
            int scrY = 座標.y + タイトル枠高さ + 8 + (縦幅 - 16) * スクロール位置 / 縦内部幅;
            スクロール内部フレーム.Draw(座標.x + 横幅 - 23, scrY, 14, scrH);
        }
    }

    //なんらかの操作をしたorウィンドウ上にあった場合 trueを返す
    public bool Input()
    {
        if( is表示 == false) { return false; }

        bool is操作 = 共通Input();

        相対座標.x = 座標.x;
        相対座標.y = 座標.y - スクロール位置 + タイトル枠高さ + 固定縦;

        //ウィンドウ範囲内の時の操作
        if (MONO_WRAP.Input.mouse.x / Config.解像度X倍 >= 座標.x &&
            MONO_WRAP.Input.mouse.x / Config.解像度X倍 <= 座標.x + 横幅 &&
            MONO_WRAP.Input.mouse.y / Config.解像度X倍 >= 座標.y &&
            MONO_WRAP.Input.mouse.y / Config.解像度X倍 <= 座標.y + 縦幅 + タイトル枠高さ)
        {
            is操作 = is操作 || ObjectInput();
        }

        return is最前面へ移動 || is操作 || new Rect(座標.x, 座標.y, 横幅, タイトル枠高さ + 縦幅).Hit(MONO_WRAP.Input.mouse);
    }

    //ドラッグ移動、拡大、縮小、閉じる、ホイール操作
    public bool 共通Input()
    {
        Position マウス座標 = new Position(MONO_WRAP.Input.mouse.x , MONO_WRAP.Input.mouse.y);

        //ホイール操作
        if (isスクロールバー表示 && new Rect(座標.x, 座標.y + タイトル枠高さ, 横幅, 縦幅).Hit(MONO_WRAP.Input.mouse) && MONO_WRAP.Input.whell != 0 && !is下拡縮中 && !is上拡縮中 && !isスクロール中)
        {
            スクロール位置 -= MONO_WRAP.Input.whell * 1;// CV::スクロール感度;

            if (スクロール位置 > 縦内部幅 - 縦幅) { スクロール位置 = 縦内部幅 - 縦幅; }
            if (スクロール位置 < 0) { スクロール位置 = 0; }
        }

        //左押してない場合共通操作なし
        if (MONO_WRAP.Input.mouseLeft.hold == false)
        {
            is移動中 = false;
            is上拡縮中 = false;
            is下拡縮中 = false;
            isスクロール中 = false;
            return false;
        }

        //タイトル掴んで移動中
        if (is移動中)
        {
            座標.x = マウス座標.x + 掴み座標.x;
            座標.y = マウス座標.y + 掴み座標.y;

            座標.x = Math.Min(GameManager.GetWindowWidth() - 横幅, 座標.x);
            座標.x = Math.Max(0, 座標.x);

            座標.y = Math.Min(GameManager.GetWindowHeight() - 縦幅 - タイトル枠高さ, 座標.y);
            座標.y = Math.Max(is固定 ? 0 : ツールバー高さ, 座標.y);

            return true;
        }
        else
        {
            座標.x = Math.Min(GameManager.GetWindowWidth() - 横幅, 座標.x);
            座標.x = Math.Max(0, 座標.x);

            座標.y = Math.Min(GameManager.GetWindowHeight() - 縦幅 - タイトル枠高さ, 座標.y);
            座標.y = Math.Max(is固定 ? 0 : ツールバー高さ, 座標.y);
        }

        //上側掴んで拡大縮小中
        if (is上拡縮中)
        {
            if (is最小縮小 == true && 座標.y < マウス座標.y)
            {
                return true;
            }
            else
            {
                is最小縮小 = false;
            }

            if (座標.y > MONO_WRAP.Input.mouse.y + 5 && MONO_WRAP.Input.moveY > 0)
            {
                return true;
            }

            縦幅 -= MONO_WRAP.Input.moveY;
            座標.y += MONO_WRAP.Input.moveY;

            if (座標.y < ツールバー高さ)
            {
                縦幅 -= ツールバー高さ - 座標.y;
                座標.y = ツールバー高さ;

            }

            if (縦幅 > 最大縦)
            {
                座標.y += 縦幅 - 最大縦;
                縦幅 = 最大縦;
            }
            if (縦幅 < 最小縦)
            {
                座標.y += 縦幅 - 最小縦;
                縦幅 = 最小縦;
                is最小縮小 = true;
            }
        }

        //下側掴んで拡大縮小中
        if (is下拡縮中)
        {
            if (is最小縮小 == true && 座標.y + タイトル枠高さ + 最小縦 > マウス座標.y)
            {
                return true;
            }
            else
            {
                is最小縮小 = false;
            }

            if (座標.y + 縦幅 < MONO_WRAP.Input.mouse.y - タイトル枠高さ - 5 && MONO_WRAP.Input.moveY < 0)
            {
                return true;
            }

            縦幅 += MONO_WRAP.Input.moveY;

            if (縦幅 < 最小縦)
            {
                //座標.y += 縦幅 - 最小縦;
                縦幅 = 最小縦;
                is最小縮小 = true;
            }
            if (縦幅 > 最大縦) { 縦幅 = 最大縦; }
        }

        //スクロールバー掴んでいる
        if (isスクロール中 && isスクロールバー表示 &&
            マウス座標.y > 座標.y + タイトル枠高さ &&
            マウス座標.y < 座標.y + タイトル枠高さ + 縦幅)
        {
            スクロール位置 += MONO_WRAP.Input.moveY / Config.解像度X倍 * 縦内部幅 / 縦幅;
        }

        if (スクロール位置 > 縦内部幅 - 縦幅) { スクロール位置 = 縦内部幅 - 縦幅; }
        if (スクロール位置 < 0) { スクロール位置 = 0; }

        //クリックしてないなら以降の処理はなし//
        if (MONO_WRAP.Input.mouseLeft.on == false)
        {
            return false;
        }

        //閉じる判定//
        if (is閉じるボタン == true &&
            Math.Abs(マウス座標.x - (座標.x + 横幅 - タイトル枠高さ / 2 - 2)) < タイトル枠高さ / 2 - 1 &&
            Math.Abs(マウス座標.y - (座標.y + 2 + タイトル枠高さ / 2)) < タイトル枠高さ / 2 - 1)
        {
            is表示 = false;
            //MSound::効果音[SE::ウィンドウ閉じ].Play();todo 閉じる効果音
            ポップアップリザルト = 0;
            if( isポップアップウィンドウ == true)
            {
                MONO_WRAP.Input.mouseLeft.on = false;//マウスクリックを無効化
                ポップアップウィンドウ.Remove(this);
            }
            return true;
        }

        //ヘルプクリック
        if ( isヘルプボタン == true &&
            Math.Abs(マウス座標.x - (座標.x + 横幅 - タイトル枠高さ / 2 - 2) + 30) < タイトル枠高さ / 2 - 1 &&
            Math.Abs(マウス座標.y - (座標.y + 2 + タイトル枠高さ / 2)) < タイトル枠高さ / 2 - 1)
        {
            ヘルプウィンドウ.OpenPopup();
            return true;
        }

        //上側掴む
        if (is固定 == false &&
            Math.Abs(マウス座標.y - 座標.y) < 10 &&
            マウス座標.x > 座標.x &&
            マウス座標.x < 座標.x + 横幅)
        {
            掴み座標.x = 座標.x - マウス座標.x;
            掴み座標.y = 座標.y - マウス座標.y;

            is上拡縮中 = true;
            return true;
        }
        //下側掴む
        if (is固定 == false &&
            Math.Abs(マウス座標.y - (座標.y + 縦幅 + タイトル枠高さ)) < 10 &&
            マウス座標.x > 座標.x &&
            マウス座標.x < 座標.x + 横幅)
        {
            掴み座標.x = 座標.x - マウス座標.x;
            掴み座標.y = 座標.y - マウス座標.y;
            is下拡縮中 = true;
            return true;
        }
        //タイトル掴む
        if (is固定 == false &&
            マウス座標.y > 座標.y &&
            マウス座標.y < 座標.y + タイトル枠高さ &&
            マウス座標.x > 座標.x &&
            マウス座標.x < 座標.x + 横幅)
        {
            掴み座標.x = 座標.x - マウス座標.x;
            掴み座標.y = 座標.y - マウス座標.y;
            is移動中 = true;
            return true;
        }

        //スクロール掴む
        if (isスクロールバー表示 &&
            マウス座標.y > 座標.y + タイトル枠高さ &&
            マウス座標.y < 座標.y + タイトル枠高さ + 縦幅 &&
            マウス座標.x > 座標.x + 横幅 - 24 &&
            マウス座標.x < 座標.x + 横幅)
        {
            //スクロール位置を計算
            //最小0 ～ 縦内部幅 - 縦幅
            double dis_y = マウス座標.y - (座標.y + タイトル枠高さ) / 縦幅;
            int スクロール移動位置 = (int)(縦内部幅 * dis_y);

            if (スクロール移動位置 < スクロール位置)
            {
                スクロール位置 -= 縦幅;
            }
            else if (スクロール移動位置 > スクロール位置 + 縦幅)
            {
                スクロール位置 += 縦幅;
            }
            else
            {
                isスクロール中 = true;
            }

            if (スクロール位置 > 縦内部幅 - 縦幅) { スクロール位置 = 縦内部幅 - 縦幅; }
            if (スクロール位置 < 0) { スクロール位置 = 0; }

            return true;
        }

        return false;
    }

    public bool ObjectInput()
    {
        //配列の前からチェック
        if (MONO_WRAP.Input.mouse.y / Config.解像度X倍 - 座標.y - タイトル枠高さ <= 固定縦)
        {
            foreach(var it in fix_item)
            {
                //クリックとドロップのチェック
                if (it.CheckInput(座標.x, 座標.y + タイトル枠高さ)) { return true; };
            }
        }

        foreach(var it in item)
        {
            //クリックとドロップのチェック
            if (it.CheckInput(相対座標.x, 相対座標.y)) { return true; };
        }

        return false;
    }

    //どこかをクリックするか、最前面フラグがtrueの時最前面へ
    public bool Check最前面へ移動()
    {
        if (is最前面へ移動)
        {
            is最前面へ移動 = false;
            return true;
        }

        return new Rect(座標.x, 座標.y, 横幅, タイトル枠高さ + 縦幅).Hit( MONO_WRAP.Input.mouse) && MONO_WRAP.Input.mouseLeft.on;
    }

    public void Reset描画範囲(bool is固定)
    {
        int スクロールバー太さ = 28;
        if (isスクロールバー表示 == false) { スクロールバー太さ = 0; }

        if (is固定)
        {
            //固定部分
            //GameManager.SetCamera(-座標.x, -座標.y - タイトル枠高さ);
            GameManager.SetViewPort( new Rect( 座標.x , 座標.y + タイトル枠高さ , 横幅 - スクロールバー太さ,縦幅 ) );
        }
        else
        {
            //固定部分を省いた相対座標
            //GameManager.SetCamera(-相対座標.x,-相対座標.y );
            GameManager.SetViewPort( new Rect( 相対座標.x , 相対座標.y + スクロール位置,横幅 - スクロールバー太さ,縦幅 - 固定縦 ));
        }
    }

    //ポップアップウィンドウとして表示
    public void OpenPopup()
    {
        Init();
        is表示 = true;
        is固定 = true;
        isポップアップウィンドウ = true;
        ポップアップウィンドウ.Add(this);
    }

    public void ClosePopup(int リザルト)
    {
        is表示 = false;
        //MSound::効果音[SE::ウィンドウ閉じ].Play();todo 閉じる効果音
        ポップアップリザルト = リザルト;
        MONO_WRAP.Input.mouseLeft.on = false;//マウスクリックを無効化
        ポップアップウィンドウ.Remove(this);        
    }

    //子オブジェクトの追加
    public void AddItem(UI_Object ui_object , bool is固定 = false)
    {
        if (is固定 == true)
        {
            fix_item.Insert( fix_item.Count ,ui_object);
        }
        else
        {
            item.Insert(fix_item.Count, ui_object);
        }
    }

    public void ResetItem()
    {
        fix_item.Clear();
        item.Clear();
    }

}
