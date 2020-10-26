using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.Microservices.Starship.API.Utilities
{
    public static class Mapper
    {
        public static List<Tto> SimpleListMap<Tfrom, Tto>(List<Tfrom> from)
        {
            var text = JsonConvert.SerializeObject(from);
            return JsonConvert.DeserializeObject<List<Tto>>(text);
        }
    }
}
