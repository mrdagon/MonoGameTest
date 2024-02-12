/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

public class P_Main : UI_Page
{
    public static P_Main This = new P_Main();

    //ウィンドウ
    public W_Info 情報ウィンドウ = new W_Info();
    
    //ポップアップ
    public P_Config コンフィグウィンドウ = new P_Config();
    public W_Tutorial チュートリアルウィンドウ = new W_Tutorial();

    //パラメータ
    public Guild guild = new Guild();

    public override void Init()
    {

    }

    //各種処理
    public override void Update()
    {

    }

    //描画処理
    public override void Draw()
    {

    }

    //●セーブ処理
    public bool Save(SaveData save_data)
    {
        return false;
    }

    public bool Load(SaveData save_data)
    {
        return false;
    }
}
