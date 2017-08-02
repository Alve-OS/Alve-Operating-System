﻿/*
* PROJECT:          Alve Operating System Development
* CONTENT:          Interpreter
* PROGRAMMERS:      Alexy DA CRUZ <dacruzalexy@gmail.com>
*                   Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;
using System.IO;
using Sys = Cosmos.System;
using L = Alve_OS.System.Translation;
using Alve_OS.System;
using Alve_OS.System.Users;
using Alve_OS.System.Computer;

namespace Alve_OS.Shell
{
    class Interpreter
    {
        public static void Interpret(string cmd)
        {
            if (cmd.Equals("shutdown"))
            {
                Kernel.running = false;
                Console.Clear();
                L.Text.Display("shutdown");
                Sys.Power.Shutdown();
            }
            else if (cmd.Equals("reboot"))
            {
                Kernel.running = false;
                Console.Clear();
                L.Text.Display("restart");
                Sys.Power.Reboot();
            }
            else if (cmd.Equals("clear"))
            {
                Console.Clear();
            }
            else if (cmd.StartsWith("echo "))
            {
                cmd = cmd.Remove(0, 5);
                Console.WriteLine(cmd);
            }
            else if (cmd.Equals("help"))
            {
                L.Help.HelpD();
            }
            else if (cmd.Equals("cd .."))
            {
                Directory.SetCurrentDirectory(Kernel.current_directory);
                var dir = Kernel.FS.GetDirectory(Kernel.current_directory);
                if (Kernel.current_directory == @"0:\")
                {
                }
                else
                {
                    Kernel.current_directory = dir.mParent.mFullPath;
                }
            }
            else if (cmd.StartsWith("cd "))
            {
                string dir = cmd.Remove(0, 3);
                if (Directory.Exists(Kernel.current_directory + dir))
                {
                    Directory.SetCurrentDirectory(Kernel.current_directory);
                    Kernel.current_directory = Kernel.current_directory + dir + @"\";
                }
                else
                {
                    L.Text.Display("directorydoesntexist");
                }
            }
            else if (cmd.Equals("dir"))
            {
                L.Text.Display("typename");
                foreach (string dir in Directory.GetDirectories(Kernel.current_directory))
                {
                    Console.WriteLine("<DIR>\t" + dir);
                }
                foreach (string dir in Directory.GetFiles(Kernel.current_directory))
                {
                    Char formatDot = '.';
                    string[] ext = dir.Split(formatDot);
                    Console.WriteLine("<" + ext[ext.Length - 1] + ">\t" + dir);
                }

            }
            else if (cmd.StartsWith("mkdir "))
            {
                string dir = cmd.Remove(0, 6);
                if (!Directory.Exists(Kernel.current_directory + dir))
                {
                    Kernel.FS.CreateDirectory(Kernel.current_directory + dir);
                }
                else if (Directory.Exists(Kernel.current_directory + dir))
                {
                    Kernel.FS.CreateDirectory(Kernel.current_directory + dir + "-1");
                }
            }
            else if (cmd.StartsWith("rmdir "))
            {
                string dir = cmd.Remove(0, 6);
                if (Directory.Exists(Kernel.current_directory + dir))
                {
                    Directory.Delete(Kernel.current_directory + dir, true);
                }
                else
                {
                    L.Text.Display("doesnotexist");
                }
            }
            else if (cmd.StartsWith("rmfil "))
            {
                string file = cmd.Remove(0, 6);
                if (File.Exists(Kernel.current_directory + file))
                {
                    File.Delete(Kernel.current_directory + file);
                }
                else
                {
                    L.Text.Display("doesnotexist");
                }
            }
            else if (cmd.Equals("mkfil"))
            {
                L.Text.Display("mkfil");
            }
            else if (cmd.StartsWith("mkfil "))
            {
                string file = cmd.Remove(0, 6);
                if (!File.Exists(Kernel.current_directory + file))
                {
                    Apps.User.Editor application = new Apps.User.Editor();
                    application.Start(file, Kernel.current_directory);
                }
                else
                {
                    L.Text.Display("alreadyexist");
                }
            }
            else if (cmd.StartsWith("prfil "))
            {
                string file = cmd.Remove(0, 6);
                if (File.Exists(Kernel.current_directory + file))
                {
                    Apps.User.Editor application = new Apps.User.Editor();
                    application.Start(file, Kernel.current_directory);
                }
                else
                {
                    L.Text.Display("doesnotexit");
                }
            }
            else if (cmd.Equals("vol"))
            {
                var vols = Kernel.FS.GetVolumes();
                L.Text.Display("NameSizeParent");
                foreach (var vol in vols)
                {
                    Console.WriteLine(vol.mName + "\t" + vol.mSize + "\t" + vol.mParent);
                }
            }
            else if (cmd.Equals("systeminfo"))
            {
                L.Text.Display("OSName");
                L.Text.Display("OSVersion");
                L.Text.Display("OSRevision");
                L.Text.Display("computername", Info.getComputerName());
            }
            else if (cmd.Equals("langset"))
            {
                L.Text.Display("availablelanguage");
            }
            else if (cmd.StartsWith("langset "))
            {
                cmd = cmd.Remove(0, 8);
                if ((cmd.Equals("en_US")) || cmd.Equals("en-US"))
                {
                    Kernel.langSelected = "en_US";
                    L.Keyboard.Init();
                }
                else if ((cmd.Equals("fr_FR")) || cmd.Equals("fr-FR"))
                {
                    Kernel.langSelected = "fr_FR";
                    L.Keyboard.Init();
                }
                else
                {
                    L.Text.Display("unknownlanguage");
                    L.Text.Display("availablelanguage");
                }
            }
            else if (cmd.Equals("ver"))
            {
                Console.WriteLine("Alve [version " + Kernel.version + "-" + Kernel.revision + "]");
            }
            else if (cmd.Equals("setup"))
            {
                L.Text.Display("setupcmd");
                string setup = Console.ReadLine();
                if (setup == "o")
                {
                    SetupInit.Init();
                }
            }
            else if (cmd.Equals("logout"))
            {
                Kernel.Logged = false;
                Kernel.userLevelLogged = "";
                Kernel.userLogged = "";
                Console.Clear();
                WelcomeMessage.Display();
            }
            else if (cmd.Equals("settings"))
            {
                L.Help.Settings();
            }
            else if (cmd.StartsWith("settings "))
            {
                string argsettings = cmd.Remove(0, 9);
                if (argsettings.Equals("adduser"))
                {
                    //method user
                    string argsuser = argsettings.Remove(0, 5);
                    Users users = new Users();

                    users.Create(argsuser);

                }
            }
            else if (cmd.Equals("color"))
            {
                L.Color.Display();
            }
            else if (cmd.StartsWith("color "))
            {
                string color = cmd.Remove(0, 6);
                if (color.Equals("0"))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (color.Equals("1"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (color.Equals("2"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (color.Equals("3"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else if (color.Equals("4"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (color.Equals("5"))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (color.Equals("6"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (color.Equals("7"))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    L.Text.Display("unknowncolor");
                }
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
