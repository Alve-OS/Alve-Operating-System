﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Command Interpreter - Settings
* PROGRAMMER(S):    John Welsh <djlw78@gmail.com>
*/

using System;
using System.IO;
using L = Aura_OS.System.Translation;
using Aura_OS.System.Users;
using Aura_OS.System.Computer;

namespace Aura_OS.Shell.cmdIntr.Settings
{
    class Settings
    {
        private static string HelpInfo = "";

        /// <summary>
        /// Getter and Setters for Help Info.
        /// </summary>
        public static string HI
        {
            get { return HelpInfo; }
            set { HelpInfo = value; /*PUSHED OUT VALUE (in)*/}
        }

        /// <summary>
        /// Empty constructor. (Good for debug)
        /// </summary>
        public Settings() { }

        /// <summary>
        /// c = command, c_Settings
        /// </summary>
        public static void c_Settings()
        {
            L.Help.Settings();
        }

        public static void c_Settings(string settings)
        {
            Char separator = ' ';
            string[] cmdargs = settings.Split(separator);

            if (cmdargs[1].Equals("adduser"))
            {
                //todo remake this method
                //with users.Create();

                //method user
                string argsuser = cmdargs[2];
                Users users = new Users();

                users.Create(argsuser);
            }

            else if (cmdargs[1].Equals("setcomputername"))
            {
                //method computername
                Info.AskComputerName();
            }

            else if (cmdargs[1].Equals("setlang"))
            {
                if ((cmdargs[2].Equals("en_US")) || cmdargs[2].Equals("en-US"))
                {
                    Kernel.langSelected = "en_US";
                    L.Keyboard.Init();
                    if (File.Exists(@"0:\System\lang.set"))
                    {
                        File.WriteAllText(@"0:\System\lang.set", Kernel.langSelected);
                    }
                    else
                    {
                        File.Create(@"0:\System\lang.set");
                        File.WriteAllText(@"0:\System\lang.set", Kernel.langSelected);
                    }
                }
                else if ((cmdargs[2].Equals("fr_FR")) || cmdargs[2].Equals("fr-FR"))
                {
                    Kernel.langSelected = "fr_FR";
                    L.Keyboard.Init();
                    if (File.Exists(@"0:\System\lang.set"))
                    {
                        File.WriteAllText(@"0:\System\lang.set", Kernel.langSelected);
                    }
                    else
                    {
                        File.Create(@"0:\System\lang.set");
                        File.WriteAllText(@"0:\System\lang.set", Kernel.langSelected);
                    }
                }
                else
                {
                    L.Text.Display("unknownlanguage");
                    L.Text.Display("availablelanguage");
                }
            }

            else if (cmdargs[1].Equals("textcolor"))
            {
                  c_Console.TextColor.c_TextColor(cmdargs[2]);
            }
            else if (cmdargs[1].Equals("backgroundcolor"))
            {
                c_Console.BackGroundColor.c_BackGroundColor(cmdargs[2]);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                L.Text.Display("UnknownCommand");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
