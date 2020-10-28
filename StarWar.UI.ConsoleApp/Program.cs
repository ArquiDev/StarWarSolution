using StarWar.UI.Clients.Services;
using StarWar.UI.Clients.Services.Requests;
using StarWar.UI.Clients.ViewModels.Starships;
using StarWar.UI.ConsoleApp.Classes;
using StarWar.UI.ConsoleApp.Screens.Errors;
using StarWar.UI.ConsoleApp.Screens.Help;
using StarWar.UI.ConsoleApp.Screens.Starships;
using StarWar.UI.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                else if (!options.DistanceMGLT.HasValue)
                {
                    MainScreen.Screen.WriteScreen();
                }
                else
                {
                    try
                    {
                        MinimumStopsScreen.Screen.WriteScreen(GetResult(options));
                    }
                    catch //To simplify I don-t implement a logger on this leve. 
                    {
                        ListMessageErrorScreen.Screen.WriteScreen(new List<string>() { "Something strange happen, please try again later." });
                    }
                }
                arguments = Console.ReadLine()?.Split(' ');
                options = Converter.ToStarshipOptions(arguments);
            }
        }
        private static List<MinimumStopsStarship> GetResult(StarshipOptions options)
        {
            MinimumStopsStarship.DistanceMGLT = options.DistanceMGLT.Value;
            var request = new MinimumStopsRequest
            {
                DistanceMGLT = options.DistanceMGLT.Value,
                ShowUnknowns = options.ShowUnkowns,
                ShowRecommended = !options.HideRecommended,
            };
            return Task.Run(async () => await StarshipService.GetMinimunStops(request)).Result;
        }
    }
}
