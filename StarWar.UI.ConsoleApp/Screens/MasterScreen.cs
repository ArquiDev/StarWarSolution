﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.UI.ConsoleApp.Screens
{
    abstract class MasterScreen
    {
        protected void WriteHead()
        {
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("**                 Starship Application                          **");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("*****************************************************************");
            Console.WriteLine();
        }
    }
}
