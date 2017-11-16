using Newtonsoft.Json;
using PlanetHunter.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunter.Export
{
    class Startup
    {
        static void Main()
        {
            var context = new PlanetHunterContext();

            //Export Data

            //JSON Export
            ExportPlanets(context);
        }

        private static void ExportPlanets(PlanetHunterContext context)
        {
            var enterTelescopeName = Console.ReadLine();
            var telescopeName = context.Planets
                .Where(p=> p.Discovery.Telescope.Name==enterTelescopeName)
                .Select(t => new
            {
                Name = t.Name,
                Mass = t.Mass,
                Orbiting = t.StarSystem.Stars.Select(a => new
                {
                    Name = a.Name                   
                })
            })
            .OrderByDescending(b => b.Mass);

            string result = JsonConvert.SerializeObject(telescopeName, Formatting.Indented);
            Console.WriteLine(result);
            File.WriteAllText($"../../Export/planets-by-{enterTelescopeName}.json", result);
        }
    }
}
