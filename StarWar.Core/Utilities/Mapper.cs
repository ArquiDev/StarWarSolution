using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWar.Core.Utilities
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
