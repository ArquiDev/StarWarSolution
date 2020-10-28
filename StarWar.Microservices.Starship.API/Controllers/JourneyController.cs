using Microsoft.Extensions.Logging;
using StarWar.Core.Utilities;
using StarWar.Microservices.Starship.API.Responses;
using StarWar.Microservices.Starship.Domain.Entities;
using StarWar.Microservices.Starship.Domain.Services.Journey;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWar.Microservices.Starship.API.Controllers
{
    public class JourneyController
    {
        private readonly ILogger<JourneyController> _logger; 
        private readonly IJourneyService _journeyService;

        public JourneyController(ILogger<JourneyController> logger, IJourneyService journeyService) =>
            (_logger, _journeyService) = (logger, journeyService);

        public async Task<List<StarshipMinimumStopsResponse>> MinimumStops(int distanceMGLT, bool showUnknown, bool showRecommended) =>
            Mapper.SimpleListMap<StarshipJourney, StarshipMinimumStopsResponse>(
                await _journeyService.GetStarshipMinimumStops(distanceMGLT, showUnknown, showRecommended));
    
    }
}
