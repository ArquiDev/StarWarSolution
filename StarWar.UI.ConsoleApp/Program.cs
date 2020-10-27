using StarWar.UI.ConsoleApp.Screens.Errors;
using StarWar.UI.ConsoleApp.Screens.Help;
using StarWar.UI.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;

namespace StarWar.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> arguments = args;
            var options = Converter.ToStarshipOptions(arguments);
            while (!options.IsExit)
            {
                if (options.ShowHelp)
                    MainHelpScreen.Screen.WriteScreen();
                else if (options.IsError)
                    ListMessageErrorScreen.Screen.WriteScreen(options.ListErrors);
                else if (options.DistanceMGLT.HasValue)
                {

                }
                else
                {

                }
                arguments = Console.ReadLine()?.Split(' ');
                options = Converter.ToStarshipOptions(arguments);
            }
        }
    }
}
