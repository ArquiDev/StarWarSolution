using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.UI.ConsoleApp.Screens.Starships
{
    class MainScreen : MasterScreenFixed<MainScreen>
    {
        protected override void WriteBody()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Welcome to star war starship minimun stop feature. Please enter a distance in MGLT and press enter to calculate the number of stops for each starship:");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
