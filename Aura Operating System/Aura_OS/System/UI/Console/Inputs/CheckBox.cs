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
    public class CheckBox : Input
    {
        public ConsoleColor BackgroundColour = ConsoleColor.Gray;
        private ConsoleColor TextColour = ConsoleColor.Black;

        private ConsoleColor SelectedBackgroundColour = ConsoleColor.DarkGray;
        private ConsoleColor SelectedTextColour = ConsoleColor.White;

        private bool Selected = false;
        public bool Checked = false;

        public Action Action;

        public CheckBox(int x, int y, String iD, Window parentWindow) : base(x, y, 1, 3, parentWindow, iD)
        {
            BackgroundColour = parentWindow.BackgroundColour;
             Selectable = true;
        }

        public override void Select()
        {
            if (!Selected)
            {
                Selected = true;
                Draw();
            }
        }

        public override void Unselect()
        {
            if (Selected)
            {
                Selected = false;
                Draw();
            }
        }

        public override void Enter()
        {
            Checked = !Checked; //Toggle Checked

            Draw();

            if (Action != null) //If an action has been set
                Action();
        }

        public override void Draw()
        {
            String Char = Checked ? "X" : " ";

            if(Selected)
                WindowManager.WirteText('[' + Char + ']', Xpostion, Ypostion, SelectedTextColour, SelectedBackgroundColour);
            else
                WindowManager.WirteText('[' + Char + ']', Xpostion, Ypostion, TextColour, BackgroundColour);  
        }

        public override void CursorMoveDown()
        {
            ParentWindow.MovetoNextItemDown(Xpostion + 1, Ypostion, Width);
        }

        public override void CursorMoveRight()
        {
            ParentWindow.MovetoNextItemRight(Xpostion - 1, Ypostion + Width, 3);

        }

        public override void CursorMoveLeft()
        {
            ParentWindow.MovetoNextItemLeft(Xpostion - 1, Ypostion, 3);
        }

        public override void CursorMoveUp()
        {
            ParentWindow.MovetoNextItemUp(Xpostion - 1, Ypostion, Width);
        }
    }
}
