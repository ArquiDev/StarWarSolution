using StarWar.UI.ConsoleApp.Classes;
using System.Collections.Generic;

namespace StarWar.UI.ConsoleApp.Utilities
{
    static class Converter
    {
        public static StarshipOptions ToStarshipOptions(IEnumerable<string> args)
        {
            int distance;
            var options = new StarshipOptions();
            if (StarshipOptions.IsHelp(args))
            {
                options.ShowHelp = true;
            }
            else
            {
                var argQueue = new Queue<string>(args);
                while (argQueue.TryDequeue(out string param))
                {
                    switch (StarshipOptions.GetOptionType(param))
                    {
                        case StarshipOptions.ArgumentOptions.Distance:
                            if (argQueue.TryDequeue(out string value) &&
                                    int.TryParse(value, out distance))
                                options.DistanceMGLT = distance;
                            else
                                options.ListErrors.Add("When you the option -d you need to write a distance continue to the parameter and must be a number.");
                            break;
                        case StarshipOptions.ArgumentOptions.ShowUnknowns:
                            options.ShowUnkowns = true;
                            break;
                        case StarshipOptions.ArgumentOptions.HideRecommended:
                            options.HideRecommended = true;
                            break;
                        default:
                            if (int.TryParse(param, out distance))
                                options.DistanceMGLT = distance;
                            else if(!string.IsNullOrWhiteSpace(param))
                                options.ListErrors.Add($"Unknown parameter {param}.");
                            break;
                    }
                }
            }
            return options;
        }
    }
}
