using StarWar.Microservices.Starship.Infrastructure.Swapi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWar.Microservices.Starship.Domain.Services.Journey.Classes
{
    internal class StarshipPointJourney
    {
        private static decimal TotalMaxAtmospheringSpeed { get; set; }
        private static decimal TotalMinCrew { get; set; }
        private static decimal TotalMaxPassengers { get; set; }
        private static decimal TotalMaxCargoCapacity { get; set; }
        private static decimal TotalMaxConsumables { get; set; }
        private static decimal TotalMaxHyperdriveRating { get; set; }
        private static decimal TotalMaxMGLT { get; set; }

        internal StarshipQueryResult ApiStarship { get; set; }
        internal bool Recommended { get; set; }
        internal decimal? MGLT { get; set; }

        private decimal MaxAtmospheringSpeed { get; set; }
        private decimal Crew { get; set; }
        private decimal Passengers { get; set; }
        private decimal CargoCapacity { get; set; }
        private decimal Consumables { get; set; }
        private decimal HyperdriveRating { get; set; }

        private decimal PointsMaxAtmospheringSpeed => GetPoints(TotalMaxAtmospheringSpeed, MaxAtmospheringSpeed); 
        private decimal PointsCrew => GetPoints(TotalMinCrew, Crew);
        private decimal PointsPassengers => GetPoints(TotalMaxPassengers, Passengers);
        private decimal PointsCargoCapacity => GetPoints(TotalMaxCargoCapacity, CargoCapacity);
        private decimal PointsConsumables => GetPoints(TotalMaxConsumables, Consumables);
        private decimal PointsHyperdriveRating => GetPoints(TotalMaxHyperdriveRating, HyperdriveRating);
        private decimal PointsMGLT => GetPoints(TotalMaxMGLT, MGLT ?? 0);

        private decimal TotalPoints => 4 * PointsMaxAtmospheringSpeed +
                                        PointsCrew +
                                        PointsPassengers +
                                        PointsCargoCapacity +
                                        PointsConsumables +
                                        PointsHyperdriveRating +
                                        10 * PointsMGLT;

        private decimal GetPoints(decimal total, decimal value) => GetPoints(1, total, value);
        private decimal GetPoints(int relevance, decimal total, decimal value) =>
            total == 0 ?
               0 :
               relevance * (1 - (Math.Abs(total - value) / total));

        internal static List<StarshipPointJourney> GetRatedList(IEnumerable<StarshipQueryResult> apiStarships, bool includeRecommended)
        {
            Func<string, decimal> getDecimal = value => decimal.TryParse(value, out decimal res) ? res : 0;
            var ratedStarships = apiStarships.Select(ass => new StarshipPointJourney
            {
                ApiStarship = ass,
                CargoCapacity = getDecimal(ass.cargo_capacity),
                Consumables = getDecimal(ass.consumables),
                Crew = getDecimal(ass.crew),
                HyperdriveRating = getDecimal(ass.hyperdrive_rating),
                MaxAtmospheringSpeed = getDecimal(ass.max_atmosphering_speed),
                Passengers = getDecimal(ass.passengers),
                MGLT = decimal.TryParse(ass.MGLT, out decimal res) ? res : null as decimal?,
            });
            TotalMaxCargoCapacity = ratedStarships.Max(ss => ss.CargoCapacity);
            TotalMaxConsumables = ratedStarships.Max(ss => ss.Consumables);
            TotalMinCrew = ratedStarships.Min(ss => ss.Crew);
            TotalMaxHyperdriveRating = ratedStarships.Max(ss => ss.HyperdriveRating);
            TotalMaxAtmospheringSpeed = ratedStarships.Max(ss => ss.MaxAtmospheringSpeed);
            TotalMaxPassengers = ratedStarships.Max(ss => ss.Passengers);
            TotalMaxMGLT = ratedStarships.Max(ss => ss.MGLT ?? 0);

            var orderedStarships = ratedStarships.OrderByDescending(ssp => ssp.TotalPoints).ToList();
            if (includeRecommended)
            {
                foreach (var starship in ratedStarships.Take(3))
                {
                    starship.Recommended = true;
                }
            }
            return orderedStarships;
        }
    }
}
