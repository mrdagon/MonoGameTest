﻿/*
 Copyright © 2023- Dagonn
 License: http://www.gnu.org/licenses/gpl.html GPL version 2 or higher
*/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using SpriteFontPlus;
using System.IO;

namespace MONO_WRAP;

//MP3ファイルをループ再生する
public class Music
{
    private Song _song;

    //BGMとSEの読込み
    public void Load(string リソース名)
    {
        _song = GameManager._game.Content.Load<Song>(リソース名);
    }

    //バグるのでリソースの方を使う
    public void LoadFile(string ファイル名)
    {
        var uri = new Uri(ファイル名, UriKind.Relative);
        _song = Song.FromUri(ファイル名, uri);
    }

    //バックグラウンドでループ再生
    public void Play()
    {
        MediaPlayer.Play(_song);
        MediaPlayer.IsRepeating = true;
    }

    static public void SetMasterVolume(double 音量 = 1.0)
    {
        MediaPlayer.Volume = (float)音量;
    }
}

//Wavファイルを一度再生する
public class Sound
{
    private SoundEffect _se;

    public void Load(string リソース名)
    {
        _se = GameManager._game.Content.Load<SoundEffect>(リソース名);
    }

    public void LoadFile(string ファイル名)
    {
        _se = SoundEffect.FromFile(ファイル名);
    }

    public void Play()
    {

        _se.Play();
    }

    static public void SetMasterVolume(double 音量 = 1.0)
    {
        SoundEffect.MasterVolume = (float)音量;
    }

}

