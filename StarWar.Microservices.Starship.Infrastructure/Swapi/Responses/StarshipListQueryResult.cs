using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.Microservices.Starship.Infrastructure.Swapi.Responses
{
    internal class StarshipListQueryResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public IList<StarshipQueryResult> results { get; set; }
    }
}
