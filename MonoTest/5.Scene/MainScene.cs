/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;

public class MainScene : Scene
{
    public static MainScene This = new MainScene();

    public List<UI_Window> windows = new List<UI_Window>();

    //ウィンドウ
    public W_Toolbar ツールバー = new W_Toolbar();

    public W_Archive 実績ウィンドウ = new W_Archive();
    public W_Crossing アイテムエンチャントウィンドウ = new W_Crossing();
    public W_Facility エンチャントマスタリーウィンドウ = new W_Facility();
    public W_Info 情報ウィンドウ = new W_Info();
    public W_Item アイテムウィンドウ = new W_Item();
    public W_Material 素材ウィンドウ = new W_Material();
    public W_Character キャラクターウィンドウ = new W_Character();
    public W_Party パーティウィンドウ = new W_Party();
    public W_Quest クエストウィンドウ = new W_Quest();
    
    //ポップアップ
    public W_Config コンフィグウィンドウ = new W_Config();
    public W_Tutorial チュートリアルウィンドウ = new W_Tutorial();

    //パラメータ
    public Guild guild = new Guild();

    public void Init()
    {

    }

    //各種処理
    public void Process()
    {

    }

    //操作処理
    public void Input()
    {

    }

    //描画処理
    public void Draw()
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
