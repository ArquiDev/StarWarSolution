using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace StarWar.UI.Common.ViewModels.Starships
{
    public class MinimumStopsStarship
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int? MinimumStops { get; set; }
        public bool Recommended { get; set; }

        public string GetLine(bool showRecommended) => $"  -> {GetRecommended(showRecommended)}{Name} ({Model})";
        private string GetRecommended(bool showRecommended) => showRecommended ? "*" : " ";
    }
}
