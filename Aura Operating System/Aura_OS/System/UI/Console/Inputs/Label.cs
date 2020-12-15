﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          https://github.com/Haydend/ConsoleDraw
* PROGRAMMERS:      Haydend <haydendunnicliffe@gmail.com>
*/

using ConsoleDraw.Inputs.Base;
using ConsoleDraw.Windows.Base;
using System;

namespace ConsoleDraw.Inputs
{
    public class Label : Input
    {
        private String Text = "";
        private ConsoleColor TextColour = ConsoleColor.Black;
        public ConsoleColor BackgroundColour = ConsoleColor.Gray;

        public Label(String text, int x, int y, String iD, Window parentWindow) : base(x, y, 1, text.Length, parentWindow, iD)
        {
            Text = text;
            BackgroundColour = parentWindow.BackgroundColour;
            Selectable = false;
        }

        public override void Draw()
        {
            WindowManager.WirteText(Text, Xpostion, Ypostion, TextColour, BackgroundColour);
        }

        public void SetText(String text)
        {
            Text = text;
            Width = text.Length;
            Draw();
        }
       
    }
}
