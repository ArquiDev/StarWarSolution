using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.Microservices.Starship.API.Models
{
    public class StarshipMinimumStopsResponse
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int? MinimumStops { get; set; }
        public bool Recommended { get; set; } = false;
    }
}
