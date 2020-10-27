using StarWar.UI.ConsoleApp.Classes;
using System;

namespace StarWar.UI.ConsoleApp.Screens.Help
{
    class MainHelpScreen : MasterScreenFixed<MainHelpScreen>
    {
        protected override void WriteBody()
        {
            Console.WriteLine($"{StarshipOptions.DISTANCE} d => Is the option to set the distance (in MGLT)");
            Console.WriteLine("                where d is a integer number.");
            Console.WriteLine();
            Console.WriteLine($"{StarshipOptions.SHOW_UNKNOWNS}  => Is the option to show the starships with unknown MGLT (by default it's not shown).");
            Console.WriteLine();
            Console.WriteLine($"{StarshipOptions.HIDE_RECOMENDED}  => Is the option to hide the starships recommended for the best match for that distance (by default it's shown).");
            Console.WriteLine();
            Console.WriteLine($"{StarshipOptions.HELP}       => Is the option show help.");
            Console.WriteLine();
            Console.WriteLine($"{StarshipOptions.EXIT}       => Is the option exit the application.");
        }
    }
}
