using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.Microservices.Starship.Infrastructure.Swapi.Responses
{
    public class StarshipQueryResult
    {
        public string url { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
    }
}
