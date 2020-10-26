using Microsoft.Extensions.Logging;
using StarWar.Microservices.Starship.API.Models;
using StarWar.Microservices.Starship.API.Utilities;
using StarWar.Microservices.Starship.Domain.Entities;
using StarWar.Microservices.Starship.Domain.Services.Journey;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWar.Microservices.Starship.API.Controllers
{
    public class JourneyController
    {
        private readonly (ILogger<JourneyController> Logger, IJourneyService JourneyService) _services;

        public JourneyController(ILogger<JourneyController> logger, IJourneyService journeyService) => 
            _services = (logger, journeyService);

        public async Task<List<StarshipMinimumStopsResponse>> MinimumStops(int distanceMGLT) =>
            Mapper.SimpleListMap<StarshipJourney, StarshipMinimumStopsResponse>(
                await _services.JourneyService.GetStarshipMinimumStops(distanceMGLT, false));
    
    }
}
