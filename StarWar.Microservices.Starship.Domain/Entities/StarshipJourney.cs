using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.Microservices.Starship.Domain.Entities
{
    public class StarshipJourney
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int? MinimumStops { get; set; }
        public bool Recommended { get; set; } = false;
    }
}
