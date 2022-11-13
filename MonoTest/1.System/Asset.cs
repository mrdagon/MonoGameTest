using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;

//画像リソース
public class AImage
{
    public static EnumArray<Frame, int> フレーム = new EnumArray<Frame, int>(9);

    public static void Load()
    {
        フレーム[0].LoadFile("Content/Frame/タブB.png");
        フレーム[1].LoadFile("Content/Frame/タブBB.png");
        フレーム[2].LoadFile("Content/Frame/フレームA.png");
        フレーム[3].LoadFile("Content/Frame/フレームB.png");
        フレーム[4].LoadFile("Content/Frame/フレームC.png");
        フレーム[5].LoadFile("Content/Frame/フレームD.png");
        フレーム[6].LoadFile("Content/Frame/フレームE.png");
        フレーム[7].LoadFile("Content/Frame/フレームF.png");
        フレーム[8].LoadFile("Content/Frame/フレームG.png");
    }
}

//フォントリソース
public class AFont
{
    public static Font PM12 = new Font();//PixelMPlus12point

    public static void Load()
    {
        PM12.LoadFNT("Content/Font", "PixelMPlus.fnt");
    }

}

//音声リソース
public class ASound
{
    public static Music メインBGM = new Music();
    public static EnumArray<Sound, SoundType> 効果音 = new EnumArray<Sound, SoundType>((int)SoundType.COUNT);

    public static void Load()
    {
        メインBGM.Load("BGM117-110921-yuuyakenagisa");

        効果音[SoundType.決定].LoadFile("Content/Sound/loop001.wav");
    }

}

