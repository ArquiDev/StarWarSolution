using StarWar.Microservices.Starship.Domain.Entities;
using StarWar.Microservices.Starship.Domain.Services.Journey.Classes;
using StarWar.Microservices.Starship.Infrastructure.Swapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar.Microservices.Starship.Domain.Services.Journey
{
    public class JourneyService : IJourneyService
    {
        public async Task<List<StarshipJourney>> GetStarshipMinimumStops(int distanceMGLT, bool includeUnknownMGLT, bool includeRecommended)
        {
            Func<string, decimal> getDecimal = value => decimal.TryParse(value, out decimal res) ? res : 0; 
            var apiStarships = await SwapiService.Swapi.GetAPIStarships();
            var ratedStarships = StarshipPointJourney.GetRatedList(apiStarships, includeRecommended);
            var starships = ratedStarships.Select(oss => new StarshipJourney
            {
                Name = oss.ApiStarship.name,
                Model = oss.ApiStarship.model,
                MinimumStops = oss.MGLT.HasValue ?
                    Convert.ToInt32(Math.Floor(distanceMGLT / oss.MGLT.Value)) :
                    null as int?,
                Recommended = oss.Recommended,
            });
            if (!includeUnknownMGLT)
                starships = starships.Where(s => s.MinimumStops.HasValue);
            return starships.ToList();
        }
    }
}
