﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Aura API used by C compiled programs.
* PROGRAMMER(S):    John Welsh <djlw78@gmail.com>
*                   Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;
using static Cosmos.Core.INTs;
using System.Collections.Generic;

namespace Aura_OS.System.Drivers.Syscalls
{
    class AuraAPI : Driver
    {
        public override bool Init()
        {
            Name = "Aura API";
            SetIntHandler(0x48, SWI); //ints.setinthandler
            return true;
        }

        public static int x = Console.CursorLeft;
        public static int y = Console.CursorTop;

        public unsafe static void SWI(ref IRQContext aContext)
        {
            if (aContext.Interrupt == 0x48) //Aura interrupt.
            {
                if (aContext.EAX == 0x01) //Print function.
                {
                    uint ptr = aContext.ESI;
                    byte* dat = (byte*)(ptr + Executables.PlainBinaryProgram.ProgramAddress);
                    for (int i = 0; dat[i] != 0; i++)
                    {
                        if ((char)dat[i] == 0x0A)
                            Console.WriteLine("\n");
                        else
                            Console.Write((char)dat[i]);
                    }
                }
                else if (aContext.EAX == 0x02) //Readline function.
                {
                    uint ptr = aContext.ESI;
                    byte* dat = (byte*)(ptr + Executables.PlainBinaryProgram.ProgramAddress);

                    string input = "";

                    for (int i = 0; dat[i] != 0; i++)
                    {
                        input = input + (char)dat[i];
                    }

                    Console.Write(input);
                    string output = Console.ReadLine();

                    uint ptr2 = aContext.EDI;
                    byte* dat2 = (byte*)(ptr2 + Executables.PlainBinaryProgram.ProgramAddress);

                    List<byte> list = new List<byte>();

                    foreach (char charr in output)
                    {
                        list.Add(Utils.Convert.StringToByte(charr));
                    }

                    byte[] test = list.ToArray();

                    for (int i = 0; i < test.Length; i++)
                    {
                        dat2[i] = test[i];
                    }

                    aContext.EDI = (uint)dat2 - Executables.PlainBinaryProgram.ProgramAddress;

                }
            }
        }
    }
}
