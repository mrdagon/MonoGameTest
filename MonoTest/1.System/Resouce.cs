using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;


namespace POY
{
    //Asetに統合
    public class RImage
    {
        public static EnumArray<Image, RecipeType> 製造アイコン = new EnumArray<Image, RecipeType>((int)RecipeType.Count);
        public static EnumArray<Image, RelicType> 財宝アイコン = new EnumArray<Image, RelicType>((int)RelicType.Count);
        public static Image 実績アイコン = new Image();

        public static Image 背景 = new Image();
        public static EnumArray<Frame,int> フレーム = new EnumArray<Frame, int>(9);

        public static void Load()
        {
            背景.LoadFile("back/background.png");

            フレーム[0].LoadFile("frame/タブB.png");
            フレーム[1].LoadFile("frame/タブBB.png");
            フレーム[2].LoadFile("frame/フレームA.png");
            フレーム[3].LoadFile("frame/フレームB.png");
            フレーム[4].LoadFile("frame/フレームC.png");
            フレーム[5].LoadFile("frame/フレームD.png");
            フレーム[6].LoadFile("frame/フレームE.png");
            フレーム[7].LoadFile("frame/フレームF.png");
            フレーム[8].LoadFile("frame/フレームG.png");

            製造アイコン[RecipeType.丸太].LoadFile("icon/丸太.png");
            製造アイコン[RecipeType.木材].LoadFile("icon/木材.png");
            製造アイコン[RecipeType.木炭].LoadFile("icon/木炭.png");
            製造アイコン[RecipeType.岩].LoadFile("icon/岩.png");
            製造アイコン[RecipeType.砂].LoadFile("icon/砂.png");
            製造アイコン[RecipeType.ガラス].LoadFile("icon/ガラス.png");
            製造アイコン[RecipeType.鉄鉱石].LoadFile("icon/鉄鉱石.png");
            製造アイコン[RecipeType.銅鉱石].LoadFile("icon/銅鉱石.png");
            製造アイコン[RecipeType.金鉱石].LoadFile("icon/金鉱石.png");
            製造アイコン[RecipeType.ミスリル鉱石].LoadFile("icon/ミスリル鉱石.png");
            製造アイコン[RecipeType.アダマンタイト].LoadFile("icon/アダマンタイト.png");
            製造アイコン[RecipeType.オリハルコン].LoadFile("icon/オリハルコン.png");
            製造アイコン[RecipeType.鉄].LoadFile("icon/鉄.png");
            製造アイコン[RecipeType.銅].LoadFile("icon/銅.png");
            製造アイコン[RecipeType.金].LoadFile("icon/金.png");
            製造アイコン[RecipeType.ミスリル].LoadFile("icon/ミスリル.png");
            製造アイコン[RecipeType.鋼].LoadFile("icon/鋼.png");
            製造アイコン[RecipeType.超合金].LoadFile("icon/超合金.png");

            製造アイコン[RecipeType.水].LoadFile("icon/水.png");
            製造アイコン[RecipeType.魚].LoadFile("icon/魚.png");
            製造アイコン[RecipeType.マンドラゴラ].LoadFile("icon/マンドラゴラ.png");
            製造アイコン[RecipeType.野菜].LoadFile("icon/野菜.png");
            製造アイコン[RecipeType.果物].LoadFile("icon/果物.png");
            製造アイコン[RecipeType.血].LoadFile("icon/血.png");
            製造アイコン[RecipeType.毛皮].LoadFile("icon/毛皮.png");
            製造アイコン[RecipeType.卵].LoadFile("icon/卵.png");
            製造アイコン[RecipeType.肉].LoadFile("icon/肉.png");

            製造アイコン[RecipeType.焼き魚].LoadFile("icon/焼き魚.png");
            製造アイコン[RecipeType.野菜ジュース].LoadFile("icon/野菜ジュース.png");
            製造アイコン[RecipeType.ジャム].LoadFile("icon/ジャム.png");
            製造アイコン[RecipeType.マンドラ粉].LoadFile("icon/マンドラ粉.png");
            製造アイコン[RecipeType.粉薬].LoadFile("icon/粉薬.png");
            製造アイコン[RecipeType.紙].LoadFile("icon/紙.png");
            製造アイコン[RecipeType.布].LoadFile("icon/布.png");
            製造アイコン[RecipeType.ロープ].LoadFile("icon/ロープ.png");
            製造アイコン[RecipeType.血の結晶].LoadFile("icon/血の結晶.png");

            製造アイコン[RecipeType.歯車].LoadFile("icon/歯車.png");
            製造アイコン[RecipeType.鉄の棒].LoadFile("icon/鉄の棒.png");
            製造アイコン[RecipeType.ネジ].LoadFile("icon/ネジ.png");
            製造アイコン[RecipeType.精密歯車].LoadFile("icon/精密歯車.png");
            製造アイコン[RecipeType.黄金歯車].LoadFile("icon/黄金歯車.png");
            製造アイコン[RecipeType.魔法回路].LoadFile("icon/魔法回路.png");
            製造アイコン[RecipeType.応用回路].LoadFile("icon/応用回路.png");
            製造アイコン[RecipeType.発展回路].LoadFile("icon/発展回路.png");
            製造アイコン[RecipeType.錬金回路].LoadFile("icon/錬金回路.png");

            製造アイコン[RecipeType.クッキー].LoadFile("icon/クッキー.png");
            製造アイコン[RecipeType.チョコレート].LoadFile("icon/チョコレート.png");
            製造アイコン[RecipeType.ケーキ].LoadFile("icon/ケーキ.png");
            製造アイコン[RecipeType.プリン].LoadFile("icon/プリン.png");
            製造アイコン[RecipeType.ハンバーガー].LoadFile("icon/ハンバーガー.png");
            製造アイコン[RecipeType.ロールケーキ].LoadFile("icon/ロールケーキ.png");
            製造アイコン[RecipeType.ステーキ].LoadFile("icon/ステーキ.png");
            製造アイコン[RecipeType.オムライス].LoadFile("icon/オムライス.png");
            製造アイコン[RecipeType.賢者の飯].LoadFile("icon/賢者の飯.png");

            製造アイコン[RecipeType.職人の槌].LoadFile("icon/職人の槌.png");
            製造アイコン[RecipeType.錬金の槌].LoadFile("icon/錬金の槌.png");
            製造アイコン[RecipeType.フライパン].LoadFile("icon/フライパン.png");
            製造アイコン[RecipeType.鍋].LoadFile("icon/鍋.png");
            製造アイコン[RecipeType.スコップ].LoadFile("icon/スコップ.png");
            製造アイコン[RecipeType.農場].LoadFile("icon/農場.png");
            製造アイコン[RecipeType.つるはし].LoadFile("icon/つるはし.png");
            製造アイコン[RecipeType.鉱山].LoadFile("icon/鉱山.png");
            製造アイコン[RecipeType.石の炉].LoadFile("icon/石の炉.png");
            製造アイコン[RecipeType.鋼の炉].LoadFile("icon/鋼の炉.png");
            製造アイコン[RecipeType.ブーメラン].LoadFile("icon/ブーメラン.png");
            製造アイコン[RecipeType.ライフル].LoadFile("icon/ライフル.png");
            製造アイコン[RecipeType.牧場].LoadFile("icon/牧場.png");
            製造アイコン[RecipeType.斧].LoadFile("icon/斧.png");
            製造アイコン[RecipeType.バケツ].LoadFile("icon/バケツ.png");
            製造アイコン[RecipeType.船].LoadFile("icon/船.png");
            製造アイコン[RecipeType.使い魔].LoadFile("icon/使い魔.png");
            製造アイコン[RecipeType.街].LoadFile("icon/街.png");
            製造アイコン[RecipeType.なし].LoadFile("icon/なし.png");

            実績アイコン.LoadFile("icon/実績.png");

            財宝アイコン[RelicType.金レシピ].LoadFile("icon/金レシピ.png");
            財宝アイコン[RelicType.時の石].LoadFile("icon/時の石.png");
            財宝アイコン[RelicType.勝利の鍵].LoadFile("icon/勝利の鍵.png");
            財宝アイコン[RelicType.召喚の札].LoadFile("icon/召喚の札.png");
            財宝アイコン[RelicType.封印のツボ].LoadFile("icon/封印の壷.png");
        }
    }

    internal class RFont
    {
        public static Font ドット = new Font();

        public static void Load()
        {
            ドット.LoadFNT("Content", "test.fnt");
        }
    }

    internal class RSound
    {
        public static Music メインBGM = new Music();
        public static EnumArray<Sound,SoundType> 効果音 = new EnumArray<Sound, SoundType>((int)SoundType.Count);

        public static void Load()
        {
            メインBGM.Load("BGM117-110921-yuuyakenagisa");

            効果音[SoundType.転生].LoadFile("sound/loop001.wav");
            効果音[SoundType.宝箱取得].LoadFile("sound/coin03.wav");
            効果音[SoundType.設備増設].LoadFile("sound/chari13_a.wav");
            効果音[SoundType.チュートリアル表示].LoadFile("sound/paper01.wav");
            効果音[SoundType.クエストクリア].LoadFile("sound/power33.wav");
            効果音[SoundType.製造クリック].LoadFile("sound/on09.wav");
            効果音[SoundType.攻撃クリック].LoadFile("sound/hit_p12.wav");
        }

    }
}
