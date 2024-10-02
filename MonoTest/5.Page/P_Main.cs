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

    UI_Button 対戦ロビー = new UI_Button();
    UI_Button デッキ構築 = new UI_Button();
    UI_Button パック開封 = new UI_Button();
    UI_Button 実績一覧 = new UI_Button();
    UI_Button ルールブック = new UI_Button();
    UI_Button タイトルへ = new UI_Button();

    public override void Init()
    {
        対戦ロビー.テキスト = "対戦ロビー";
        デッキ構築.テキスト = "デッキ構築";
        パック開封.テキスト = "パック開封";
        実績一覧.テキスト = "獲得実績";
        ルールブック.テキスト = "ルールブック";
        タイトルへ.テキスト = "タイトルへ";

        item.Add(対戦ロビー);
        item.Add(デッキ構築);
        item.Add(パック開封);
        item.Add(実績一覧);
        item.Add(ルールブック);
        item.Add(タイトルへ);

        対戦ロビー.フレーム = AImage.フレーム[4];
        デッキ構築.フレーム = AImage.フレーム[4];
        パック開封.フレーム = AImage.フレーム[4];
        実績一覧.フレーム = AImage.フレーム[4];
        ルールブック.フレーム = AImage.フレーム[4];
        タイトルへ.フレーム = AImage.フレーム[4];

        対戦ロビー.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.対戦ロビー;
        };
        デッキ構築.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.デッキ構築;
        };
        パック開封.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.パック開封;
        };
        実績一覧.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.実績;
        };
        ルールブック.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.ルールブック;
        };
        タイトルへ.leftClickEvent = () =>
        {
            GameParam.ページタイプ = PageType.タイトル;
        };
    }

    //各種処理
    public override void Update()
    {


        //ボタンの操作処理
        foreach (var it in item)
        {
            it.CheckInput();
        }
    }

    //描画処理
    public override void Draw()
    {
        int cx = GameManager.GetWindowWidth() / 2;
        int cy = GameManager.GetWindowHeight() / 2;
        int tx = GameManager.GetWindowWidth() / 2;
        int ty = 25;

        AImage.チェック背景.DrawRotate(cx + GameParam.タイマー / 2 % 72, cy, 36, 0);

        //ボタン位置とサイズ修正
        対戦ロビー.SetUI(new Rect(tx - 75, ty, 150, 30));
        デッキ構築.SetUI(new Rect(tx - 75, ty + 40, 150, 30));
        パック開封.SetUI(new Rect(tx - 75, ty + 80, 150, 30));
        実績一覧.SetUI(new Rect(tx - 75, ty + 120, 150, 30));
        ルールブック.SetUI(new Rect(tx - 75, ty + 160, 150, 30));
        タイトルへ.SetUI(new Rect(tx - 50, ty + 210, 100, 30));

        foreach (var it in item)
        {
            it.Draw();
        }
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
