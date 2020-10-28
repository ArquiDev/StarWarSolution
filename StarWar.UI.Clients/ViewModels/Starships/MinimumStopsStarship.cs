using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace StarWar.UI.Clients.ViewModels.Starships
{
    public class MinimumStopsStarship
    {
        public static int DistanceMGLT { get; set; }

        public string Name { get; set; }
        public string Model { get; set; }
        public int? MinimumStops { get; set; }
        public bool Recommended { get; set; }

        public string GetLine() => $"  -> {GetRecommended()} {Name} ({Model}): {GetMinimumStopsText()} stops.";
        private string GetRecommended() => Recommended ? "*" : " ";
        private string GetMinimumStopsText() => MinimumStops.HasValue ? MinimumStops.ToString() : "Unknown";
    }
}
