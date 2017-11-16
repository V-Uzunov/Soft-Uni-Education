using Newtonsoft.Json;
using PlanetHunter.Data;
using PlanetHunter.Data.DTO;
using PlanetHunter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PlanetHunter.Import
{
    class Startup
    {
        static void Main()
        {
            var context = new PlanetHunterContext();
            //context.Database.Initialize(true);


            //02.Data Import

            //-JSON Import 
            //ImportAstronomers(context);
            //ImportTelescopes(context);
            //ImportPlanets(context);

            //-XML Import
            //ImportStars(context);
            //ImportDiscoveries(context);
            
        }

        private static void ImportDiscoveries(PlanetHunterContext context)
        {
            var discXDoc = XDocument.Load("../../datasets/discoveries.xml");
            XElement discRoot = discXDoc.Root;

            using (context)
            {
                foreach (var discover in discRoot.Elements())
                {
                    var date = discover.Element("DateMade");
                    var telescope = discover.Element("Telescope");

                    
                }
            }
        }

        private static void ImportStars(PlanetHunterContext context)
        {
            XDocument starsXDoc = XDocument.Load("../../datasets/stars.xml");
            XElement starsRoot = starsXDoc.Root;
            using (context)
            {
                foreach (var star in starsRoot.Elements())
                {
                    var name = star.Element("Name");
                    var temperature = int.Parse(star.Element("Temperature").Value);
                    var starSystem = star.Element("StarSystem").Value;

                    if (name == null || temperature < 2400 || starSystem==null)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    var s = new Star();

                    var starSystemName = context.StarSystems.FirstOrDefault(ss => ss.Name == starSystem);

                    if (starSystemName != null)
                    {
                        s.Name = name.Value;
                        s.Temperature = temperature;
                        s.StarSystem = starSystemName;
                    }
                    else if (starSystemName == null)
                    {
                        s.Name = name.Value;
                        s.Temperature = temperature;
                        var ss = new StarSystem();
                        ss.Name = name.Value;
                        s.StarSystem = ss;
                    }
                    context.Stars.Add(s);
                    Console.WriteLine($"Record {s.Name} successfully imported.");
                }
                context.SaveChanges();
            }
        }

        private static void ImportPlanets(PlanetHunterContext context)
        {
            var json = File.ReadAllText("../../datasets/planets.json");

            var planets = JsonConvert.DeserializeObject<ICollection<PlanetsDTO>>(json);
            using (context)
            {
                foreach (var planet in planets)
                {
                    if (planet.Name == null || planet.StarSystem == null || planet.Mass <= 0)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }
                    var p = new Planet();

                    var starSystem = context.StarSystems.FirstOrDefault(pl => pl.Name == planet.StarSystem);

                    if (starSystem != null)
                    {
                        p.Name = planet.Name;
                        p.Mass = planet.Mass;
                        p.StarSystem = starSystem;
                    }
                    else if (starSystem == null)
                    {
                        p.Name = planet.Name;
                        p.Mass = planet.Mass;
                        var ss = new StarSystem();
                        ss.Name = planet.Name;
                        p.StarSystem = ss;
                    }
                    context.Planets.Add(p);
                    Console.WriteLine($"Record {planet.Name} successfully imported.");
                }
                context.SaveChanges();
            }
        }

        private static void ImportTelescopes(PlanetHunterContext context)
        {
            var json = File.ReadAllText("../../datasets/telescopes.json");

            var telescopes = JsonConvert.DeserializeObject<ICollection<TelescopesDTO>>(json);
            using (context)
            {
                foreach (var telescope in telescopes)
                {
                    if (telescope.MirrorDiameter <= 0 || telescope.Name == null || telescope.Location == null)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    var tel = new Telescope
                    {
                        Name = telescope.Name,
                        Location = telescope.Location,
                        MirrorDiameter = telescope.MirrorDiameter
                    };
                    context.Telescopes.Add(tel);
                    Console.WriteLine($"Record {telescope.Name} successfully imported.");
                }
                context.SaveChanges();
            }
        }

        private static void ImportAstronomers(PlanetHunterContext context)
        {
            var json = File.ReadAllText("../../datasets/astronomers.json");

            var astronomers = JsonConvert.DeserializeObject<ICollection<AstronomerDTO>>(json);

            using (context)
            {
                foreach (var astro in astronomers)
                {
                    if (astro.FirstName == null || astro.LastName == null)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    var a = new Astronomer()
                    {
                        FirstName = astro.FirstName,
                        LastName = astro.LastName
                    };

                    context.Astronomers.Add(a);
                    Console.WriteLine($"Record {astro.FirstName} {astro.LastName} successfully imported.");
                }
                context.SaveChanges();
            }
        }
    }
}
