/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MonoWrap;

namespace POY;

//画像リソース
public class AImage
{
    public static EnumArray<Frame, int> フレーム = new EnumArray<Frame, int>(9);
    public static EnumArray<Image, IconType> アイコン = new EnumArray<Image, IconType>((int)(IconType.COUNT));

    public static Image タイトルロゴ = new Image();
    public static Image タイトル背景前 = new Image();
    public static Image タイトル背景後 = new Image();

    public static List<Image> ダンジョン背景 = new List<Image>();
    public static Image ダンジョン鉱石 = new Image();

    public static void Load()
    {
        //アイコン素材
        アイコン[IconType.仮].LoadFile("Content/Icon/歯車.png");

        //タイトル用素材
        タイトルロゴ.LoadFile("Content/System/title.png");
        タイトル背景前.LoadFile("Content/Back/middleground.png");
        タイトル背景後.LoadFile("Content/Back/background.png");

        //ダンジョン用素材

        //フレーム素材
        フレーム[0].LoadFile("Content/Frame/tab_00.png");
        フレーム[1].LoadFile("Content/Frame/tab_01.png");
        フレーム[2].LoadFile("Content/Frame/frame_00.png");
        フレーム[3].LoadFile("Content/Frame/frame_01.png");
        フレーム[4].LoadFile("Content/Frame/frame_02.png");
        フレーム[5].LoadFile("Content/Frame/frame_03.png");
        フレーム[6].LoadFile("Content/Frame/frame_04.png");
        フレーム[7].LoadFile("Content/Frame/frame_05.png");
        フレーム[8].LoadFile("Content/Frame/frame_06.png");

        UI_Window.SetFrameFont(フレーム[0], フレーム[0],フレーム[0],フレーム[0],フレーム[0],AFont.PM12);
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
        メインBGM.Load("Music/BGM117-110921-yuuyakenagisa");

        効果音[SoundType.決定].LoadFile("Content/Sound/loop001.wav");
    }

}