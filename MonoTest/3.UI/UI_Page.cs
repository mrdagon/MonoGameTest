/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MONO_WRAP;

namespace CARD_IDLE;

public class UI_Page
{

    public List<UI_Object> item = new List<UI_Object>();//スクロールする子オブジェクト

    //初期化処理
    public virtual void Init() { }

    //毎フレームの操作等の処理
    public virtual void Update() { }

    //毎フレームの描画
    public virtual void Draw() { }

    //子オブジェクトの追加
    public void AddItem(UI_Object ui_object)
    {
        item.Insert(item.Count, ui_object);
    }

    public void ResetItem()
    {
        item.Clear();
    }
}