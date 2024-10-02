/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using MONO_WRAP;

namespace CARD_IDLE;

//画像リソース
public class AImage
{
    public static EnumArray<Frame, int> フレーム = new EnumArray<Frame, int>(9);
    public static List<Image> アイコン = new List<Image>(10);
    public static List<Image> カード = new List<Image>(51);
    public static List<Image> 台座 = new List<Image>(2);

    public static Image タイトルロゴ = new Image();

    public static Image チェック背景 = new Image();

    public static void Load()
    {
        //カード素材
        for (int a = 0; a < 51; a++)
        {
            カード.Add(new Image());
            カード[a].LoadFile("Content/Card/char_"+a/10+a%10+".png");
        }

        //台座素材
        for (int a = 0; a < 2; a++)
        {
            台座.Add(new Image());
        }
        台座[0].LoadFile("Content/Card/card_omote.png");
        台座[1].LoadFile("Content/Card/card_ura.png");

        //アイコン素材
        for (int a = 0; a < 17; a++)
        {
            アイコン.Add(new Image());
            アイコン[a].LoadFile("Content/Icon/"+a/100+a/10%10+a%10+".gif");
        }

        //タイトル用素材
        //タイトルロゴ.LoadFile("Content/System/title.png");

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

        チェック背景.LoadFile("Content/Back/check.png");
        
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

        効果音[SoundType.決定].LoadFile("Content/Sound/hit_p12.wav");
    }

}