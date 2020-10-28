using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.UI.Clients.Services.Requests
{
    public class MinimumStopsRequest
    {
        public bool ShowUnknowns { get; set; }
        public bool ShowRecommended { get; set; }
        public int DistanceMGLT { get; set; }
    }
}
