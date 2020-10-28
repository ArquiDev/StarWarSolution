using StarWar.UI.Clients.ViewModels.Starships;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.UI.ConsoleApp.Screens.Starships
{
    class MinimumStopsScreen : MasterScreenModel<MinimumStopsScreen, List<MinimumStopsStarship>>
    {
        protected override void WriteBody(List<MinimumStopsStarship> model)
        {
            Console.WriteLine();
            Console.WriteLine($"For the distance of {MinimumStopsStarship.DistanceMGLT} MGLT the minumum stops for each starship:");
            Console.WriteLine();
            foreach (var starship in model)
            {
                Console.WriteLine(starship.GetLine());
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
