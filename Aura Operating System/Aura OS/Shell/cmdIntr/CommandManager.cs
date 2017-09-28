﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Command Interpreter - CommandManager
* PROGRAMMER(S):    John Welsh <djlw78@gmail.com>
*/

using DZetko.Xml;
using System;

namespace Aura_OS.Shell.cmdIntr
{
    class CommandManager
    {

        /// <summary>
        /// Empty constructor. (Good for debug)
        /// </summary>
        public CommandManager() { }
        /// <summary>
        /// Shell Interpreter
        /// </summary>
        /// <param name="cmd">Command</param>
        public static void _CommandManger(string cmd)
        {

        #region Power

            if (cmd.Equals("shutdown"))
            {//NOTE: Why isn't it just the constructor? This leaves more room for <package>.<class>.HelpInfo;
                Power.Shutdown.c_Shutdown();
            }
            else if (cmd.Equals("reboot"))
            {
                Power.Reboot.c_Reboot();
            }

        #endregion Power

        #region Console

            else if ((cmd.Equals("clear")) || (cmd.Equals("cls")))
            {
                c_Console.Clear.c_Clear();
            }
            else if (cmd.StartsWith("echo "))
            {
                c_Console.Echo.c_Echo(cmd);
            }
            else if (cmd.Equals("help"))
            {
                System.Translation.Help._Help();
            }
            else if (cmd.Equals("textcolor"))
            {
                c_Console.TextColor.c_TextColor();
            }
            else if (cmd.StartsWith("textcolor "))
            {
                c_Console.TextColor.c_TextColor(cmd);
            }
            else if (cmd.Equals("backgroundcolor"))
            {
                c_Console.BackGroundColor.c_BackGroundColor();
            }
            else if (cmd.StartsWith("backgroundcolor "))
            {
                c_Console.BackGroundColor.c_BackGroundColor(cmd);
            }

        #endregion Console

        #region FileSystem

            else if ((cmd.Equals("cd ..")) || (cmd.Equals("bkroot")))
            {
                FileSystem.CD.c_CD();
            }
            else if (cmd.StartsWith("cd "))
            {
                FileSystem.CD.c_CD(cmd);
            }
            else if (cmd.Equals("cp"))
            {
                FileSystem.CP.c_CP();
            }
            else if (cmd.StartsWith("cp "))
            {
                FileSystem.CP.c_CP();
            }
            else if ((cmd.Equals("dir")) || (cmd.Equals("ls")))
            {
                FileSystem.Dir.c_Dir();
            }
            else if ((cmd.StartsWith("dir ")) || (cmd.StartsWith("ls ")))
            {
                FileSystem.Dir.c_Dir(cmd);
            }
            else if (cmd.Equals("mkdir"))
            {
                FileSystem.Mkdir.c_Mkdir();
            }
            else if (cmd.StartsWith("mkdir "))
            {
                FileSystem.Mkdir.c_Mkdir(cmd);
            }
            else if (cmd.StartsWith("rmdir "))
            {
                FileSystem.Rmdir.c_Rmdir(cmd);
            }//TODO: orgainize
            else if (cmd.StartsWith("rmfil "))
            {
                FileSystem.Rmfil.c_Rmfil(cmd);
            }
            else if (cmd.Equals("mkfil"))
            {
                FileSystem.Mkfil.c_mkfil();
            }
            else if (cmd.StartsWith("mkfil "))
            {
                FileSystem.Mkfil.c_mkfil(cmd);
            }
            else if (cmd.StartsWith("edit "))
            {
                FileSystem.Edit.c_Edit(cmd);
            }
            else if (cmd.Equals("vol"))
            {
                FileSystem.Vol.c_Vol();
            }

        #endregion FileSystem

        #region Settings

            else if (cmd.Equals("logout"))
            {
                Settings.Logout.c_Logout();
            }
            else if (cmd.Equals("settings"))
            {
                Settings.Settings.c_Settings();
            }
            else if (cmd.StartsWith("settings "))
            {
                Settings.Settings.c_Settings(cmd);
            }

        #endregion Settings

        #region System Infomation

            else if (cmd.Equals("systeminfo"))
            {
                SystemInfomation.SystemInfomation.c_SystemInfomation();
            }
            else if ((cmd.Equals("ver")) || (cmd.Equals("version")))
            {
                SystemInfomation.Version.c_Version();
            }

        #endregion System Infomation

        #region Tests

            else if (cmd.Equals("crash"))
            {
                Tests.Crash.c_Crash();
            }

            else if (cmd.Equals("xml1"))
            {
                XmlParser parser = new XmlParser(XmlParser.InputType.File, "0:\\file.xml"); // Creating new instance of XmlParser with file path
                XmlDocument xmlDocument = parser.Parse(); // Creating a new instance of XmlDocument and asigning a result to it.
                Console.WriteLine(xmlDocument.RootNode.Children["book"].Children["price"].Content); // Writing a part of the parsed XML file to the console.
            }

            #endregion Tests

            #region Util

            else
            {
                Util.CmdNotFound.c_CmdNotFound();
            }

        #endregion Util

        }
    }
}
