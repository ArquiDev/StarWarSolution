using Newtonsoft.Json;
using StarWar.Microservices.Starship.Infrastructure.Swapi.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWar.Microservices.Starship.Infrastructure.Swapi
{
    public class SwapiService
    {
        //This could be also saved on a file setting or DB. But this normally don't change, so is fine also in this way.
        private const string SWAPI_DEV_STARSHIPS = "https://swapi.dev/api/starships/";

        #region Singleton
        // Using singleton to have just one instance that manage the service, also will be create just when it's needed, 
        //       and also can be inherit to add some other specific logic.
        private static SwapiService swapiService;
        public static SwapiService Swapi => swapiService = swapiService ?? new SwapiService();
        private SwapiService() { }
        #endregion

        /// <summary>
        /// Get all straships from the API.
        /// </summary>
        /// <returns></returns>
        public async Task<List<StarshipQueryResult>> GetAPIStarships() => await GetAPIStarships(0, SWAPI_DEV_STARSHIPS);

        /// <summary>
        /// Get all starships from the API (the query is paged so the function is recursive).
        /// </summary>
        /// <param name="count">Quantity previous preload. This it's just to control to don't have a overflow calls.</param>
        /// <param name="url">The next url (page) to load.</param>
        /// <returns></returns>
        private async Task<List<StarshipQueryResult>> GetAPIStarships(int count, string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var page = JsonConvert.DeserializeObject<StarshipListQueryResult>(apiResponse);
            if (!string.IsNullOrWhiteSpace(page.next) && count < page.count && count < 10000)
                page.results = page.results.Concat(await GetAPIStarships(count + page.results.Count(), page.next)).ToList();
            return page.results.ToList();
        }

    }
}
