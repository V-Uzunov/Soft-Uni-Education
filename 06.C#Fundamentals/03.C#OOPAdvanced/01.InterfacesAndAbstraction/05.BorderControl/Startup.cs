namespace _05.BorderControl
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class Startup
    {
        public static void Main()
        {
            string inputLine=string.Empty;

            ICollection<IBoearder> boearder = new List<IBoearder>();

            while ((inputLine = Console.ReadLine()) != "End")
            {

                var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    boearder.Add(new Sitizen(tokens[0], tokens[1], tokens[2]));
                }
                else
                {
                    boearder.Add(new Robot(tokens[0], tokens[1]));
                }
            }

            var fakeId = Console.ReadLine();

            boearder.Where(x=> x.Id.EndsWith(fakeId)).Select(x=> x.Id).ToList().ForEach(x=> Console.WriteLine(x));
        }
    }
}
