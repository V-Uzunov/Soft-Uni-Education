namespace MassDefect.Client
{
    using MassDefect.Data;
    using MassDefect.Data.DTO;
    using MassDefect.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Startup
    {
        public static void Main()
        {
            var context = new MassDefectContext();

            //context.Database.Initialize(true);

            //01. Json Import
            //ImportSolarSystem();
            //ImportStars();
            //ImportPlanets();
            //ImportPersons();
            //ImportAnomalies();

        }
        #region 01.5. ImportAnomalies
        private static void ImportAnomalies()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText("../../datasets/anomalies.json");

                var anomalies = JsonConvert.DeserializeObject<ICollection<AnomalyDTO>>(json);

                foreach (var ano in anomalies)
                {
                    if (ano.OriginPlanet == null || ano.TeleportPlanet == null)
                    {
                        Console.WriteLine("Invalid data.");
                    }
                    else
                    {
                        var originPlanet = GetOriginPlanet(ano.OriginPlanet);
                        var teleportPlanet = GetTeleportPlanet(ano.TeleportPlanet);

                        if (originPlanet == null || teleportPlanet == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var anoRes = new Anomaly
                            {
                                OriginPlanetId = originPlanet.Id,
                                TeleportPlanetId = teleportPlanet.Id
                            };

                            context.Anomalies.Add(anoRes);
                            context.SaveChanges();
                            Console.WriteLine($"Successfully imported Origin Planet {originPlanet.Name} and Teleport Planet {teleportPlanet.Name}.");

                        }
                    }
                }
            }
        }

        private static Planet GetOriginPlanet(string originPlanet)
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets.Where(p => p.Name == originPlanet).FirstOrDefault();
            }
        }

        private static Planet GetTeleportPlanet(string teleportPlanet)
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets.Where(p => p.Name == teleportPlanet).FirstOrDefault();
            }
        }
        #endregion

        #region 01.4. ImportPersons
        private static void ImportPersons()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText("../../datasets/persons.json");

                var persons = JsonConvert.DeserializeObject<ICollection<PersonDTO>>(json);

                foreach (var person in persons)
                {
                    if (person.Name == null || person.HomePlanet == null)
                    {
                        Console.WriteLine("Invalid data.");
                    }
                    else
                    {
                        var homePlanet = GetHomePlanet(person.HomePlanet);

                        if (homePlanet == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var pers = new Person
                            {
                                Name = person.Name,
                                HomePlanetId = homePlanet.Id
                            };

                            context.Persons.Add(pers);
                            context.SaveChanges();
                            Console.WriteLine($"Successfully imported Person {person.Name}.");
                        }
                    }
                }
            }
        }

        public static Planet GetHomePlanet(string homePlanet)
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets.Where(p => p.Name == homePlanet).FirstOrDefault();
            }
        }
        #endregion

        #region 01.3. ImportPlanets
        private static void ImportPlanets()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText("../../datasets/planets.json");

                var planets = JsonConvert.DeserializeObject<ICollection<PlanetDTO>>(json);

                foreach (var planet in planets)
                {
                    if (planet.Name == null || planet.SolarSystem == null || planet.Sun == null)
                    {
                        Console.WriteLine("Invalid data.");
                    }
                    else
                    {
                        var solarSystem = GetSystemByName(planet.SolarSystem);
                        var sun = PlanetGetSun(planet.Sun);

                        if (solarSystem == null || sun == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var planetRes = new Planet
                            {
                                Name = planet.Name,
                                SunId = sun.Id,
                                SolarSystemId = solarSystem.Id
                            };
                            context.Planets.Add(planetRes);
                            context.SaveChanges();
                            Console.WriteLine($"Successfully imported Planet {planet.Name}.");
                        }
                    }
                }
            }
        }

        public static SolarSystem PlanetGetSystem(string name)
        {
            using (var context = new MassDefectContext())
            {
                var solarSystem = context.SolarSystems.Where(s => s.Name == name).FirstOrDefault();

                return solarSystem;
            }
        }
        public static Star PlanetGetSun(string sunName)
        {
            using (var context = new MassDefectContext())
            {
                return context.Stars.Where(s => s.Name == sunName).FirstOrDefault();
            }
        }
        #endregion

        #region 01.2. ImportStars
        private static void ImportStars()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText("../../datasets/stars.json");

                var stars = JsonConvert.DeserializeObject<ICollection<StarDTO>>(json);

                foreach (var star in stars)
                {
                    if (star.Name == null || star.SolarSystem == null)
                    {
                        Console.WriteLine("Invalid data.");
                    }
                    else
                    {
                        var solarSystem = GetSystemByName(star.SolarSystem);
                        if (solarSystem == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var res = new Star
                            {
                                Name = star.Name,
                                SolarSystemId = solarSystem.Id
                            };
                            context.Stars.Add(res);
                            context.SaveChanges();
                            Console.WriteLine($"Successfully imported Star {star.Name}.");
                        }
                    }
                }
            }
        }

        public static SolarSystem GetSystemByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                var solarSystem = context.SolarSystems.Where(s => s.Name == name).FirstOrDefault();

                return solarSystem;
            }
        }
        #endregion

        #region 01.1. ImportSolarSystem
        private static void ImportSolarSystem()
        {
            using (var context = new MassDefectContext())
            {
                var json = File.ReadAllText("../../datasets/solar-systems.json");

                var solarSystems = JsonConvert.DeserializeObject<ICollection<SolarSystemDTO>>(json);

                foreach (var ss in solarSystems)
                {
                    if (ss.Name == null)
                    {
                        Console.WriteLine("Invalid data.");
                    }
                    else
                    {
                        context.SolarSystems.Add(new SolarSystem { Name = ss.Name });
                        Console.WriteLine($"Successfully imported Solar System {ss.Name}");
                    }

                    context.SaveChanges();
                }
            }
        }
        #endregion
    }
}
