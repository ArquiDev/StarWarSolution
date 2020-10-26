using StarWar.Microservices.Starship.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWar.Microservices.Starship.Domain.Services.Journey
{
    public interface IJourneyService
    {
        Task<List<StarshipJourney>> GetStarshipMinimumStops(int distanceMGLT, bool includeUnknownMGLT);
    }
}
