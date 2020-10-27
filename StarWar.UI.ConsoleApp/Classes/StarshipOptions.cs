using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWar.UI.ConsoleApp.Classes
{
    class StarshipOptions
    {
        public const string DISTANCE = "-d";
        public const string SHOW_UNKNOWNS = "-u";
        public const string HIDE_RECOMENDED = "-s";
        public const string HELP = "-h";
        public const string EXIT = "-e";

        public enum ArgumentOptions
        {
            Unknown,
            Distance,
            ShowUnknowns,
            HideRecommended,
            Exit,
        }
        public int? DistanceMGLT { get; set; }
        public bool ShowUnkowns { get; set; }
        public bool HideRecommended { get; set; }
        public bool ShowHelp { get; set; }
        public bool IsExit { get; set; }
        public List<string> ListErrors { get; set; } = new List<string>();

        public bool IsError => ListErrors.Any();

        public static bool IsHelp(IEnumerable<string> options) => options?.Contains(HELP) ?? false;
        public static ArgumentOptions GetOptionType(string option) => option switch
        {
            DISTANCE => ArgumentOptions.Distance,
            SHOW_UNKNOWNS => ArgumentOptions.ShowUnknowns,
            HIDE_RECOMENDED => ArgumentOptions.HideRecommended,
            EXIT => ArgumentOptions.Exit,
            _ when option == "" => ArgumentOptions.Unknown,
            _ => ArgumentOptions.Unknown,
        };
    }
}
