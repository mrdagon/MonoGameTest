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
using SpriteFontPlus;
using System.IO;

namespace MONO_WRAP;

public class Key
{
    public bool on = false;
    public bool off = false;
    public bool hold = false;
    public int holdCount = 0;

    public void Update(bool isPush)
    {
        if (isPush == true)
        {
            on = !hold;
            off = false;
            hold = true;
            holdCount++;
        }
        else
        {
            off = hold;
            on = false;
            hold = false;
            holdCount = 0;
        }
    }
}

public class Input
{
    static public Key[] keys = new Key[Enum.GetNames(typeof(Keys)).Length];

    static public Position mouse = new Position(0,0);
    static public Key mouseLeft = new Key();
    static public Key mouseRight = new Key();
    static public Key mouseMiddle = new Key();

    static public int moveX = 0;
    static public int moveY = 0;
    static public int whell = 0;

    static public void Init()
    {
        int key_count = Enum.GetNames(typeof(Keys)).Length;

        for (int i = 0; i < key_count; i++)
        {
            keys[i] = new Key();
        }
    }

    static public void Update()
    {
        int key_count = Enum.GetNames(typeof(Keys)).Length;

        //マウス入力の更新
        int mx = Mouse.GetState().X;
        int my = Mouse.GetState().Y;

        if(GameManager._zoomRate != 1 )
        {
            mx = mx / GameManager._zoomRate;
            my = my / GameManager._zoomRate;
        }

        moveX = mx - mouse.x;
        moveY = my - mouse.y;
        mouse.x = mx;
        mouse.y = my;

        whell = Mouse.GetState().ScrollWheelValue;

        mouseLeft.Update(Mouse.GetState().LeftButton == ButtonState.Pressed);
        mouseRight.Update(Mouse.GetState().RightButton == ButtonState.Pressed);
        mouseMiddle.Update(Mouse.GetState().MiddleButton == ButtonState.Pressed);

        //キーボード入力の更新
        for (int i=0;i< key_count; i++)
        {
            keys[i].Update(Keyboard.GetState().IsKeyDown((Keys)i) == true);
        }

        //ゲームパッド入力の更新
        //とりあえず使わないので未実装
        if (GamePad.GetState(0).IsConnected == false)
        {
            return;
        }
		}
}
