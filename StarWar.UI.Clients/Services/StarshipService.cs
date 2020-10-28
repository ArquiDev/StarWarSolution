using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StarWar.Core.Utilities;
using StarWar.Microservices.Starship.API.Controllers;
using StarWar.Microservices.Starship.API.Responses;
using StarWar.Microservices.Starship.Domain.Services.Journey;
using StarWar.UI.Clients.Services.Requests;
using StarWar.UI.Clients.ViewModels.Starships;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWar.UI.Clients.Services
{
    public static class StarshipService
    {
        /// <summary>
        /// This represent the rest client. To don't publish a service I'm just using a static class that call the controler by independency injection.
        /// </summary>
        /// <param name="request">This is all the parameters that need the function</param>
        /// <returns></returns>
        public static async Task<List<MinimumStopsStarship>> GetMinimunStops(MinimumStopsRequest request)
        {
            var controller = GetController();
            var result = await controller.MinimumStops(request.DistanceMGLT, request.ShowUnknowns, request.ShowRecommended);
            return Mapper.SimpleListMap<StarshipMinimumStopsResponse, MinimumStopsStarship>(result);
        }
        private static JourneyController GetController()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IJourneyService, JourneyService>()
            .BuildServiceProvider();
            
            var logger = serviceProvider.GetService<ILogger<JourneyController>>();
            var service = serviceProvider.GetService<IJourneyService>();
            return new JourneyController(logger, service);
        }
    }
}
