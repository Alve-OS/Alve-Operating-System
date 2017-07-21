﻿/*
* PROJECT:          Alve Operating System Development
* CONTENT:          Translation system
* PROGRAMMERS:      Alexy DA CRUZ <dacruzalexy@gmail.com>
*/

using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Alve_OS.System.Translation
{
    class Keyboard
    {
        public static void Init()
        {
            try
            {
                switch (Kernel.langSelected)
                {
                    case "fr_FR":
                        Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.FR_Standard());
                        Text.Display("keyboard");
                        break;

                    case "en_US":
                        Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.US_Standard());
                        Text.Display("keyboard");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("[ERROR]");
            }

            
        }

    }
}
