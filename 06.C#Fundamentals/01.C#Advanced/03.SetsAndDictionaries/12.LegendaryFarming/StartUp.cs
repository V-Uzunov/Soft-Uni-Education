namespace _12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, int> junkItems = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            bool itemObtained = false;

            while (!itemObtained)
            {
                string[] data = Console.ReadLine()
                    .ToLower()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < data.Length; i += 2)
                {
                    int quantity = int.Parse(data[i]);
                    string material = data[i + 1];

                    if (!keyMaterials.ContainsKey(material))    // junk items
                    {
                        if (!junkItems.ContainsKey(material))
                        {
                            junkItems[material] = 0;
                        }
                        junkItems[material] += quantity;
                    }
                    else // key materials
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials[material] >= 250)
                        {
                            switch (material)
                            {
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                            }
                            keyMaterials[material] -= 250;
                            itemObtained = true;

                            // print remaining key materials
                            var keyMaterialsDescOrder = keyMaterials
                                .OrderBy(x => x.Key)
                                .OrderByDescending(x => x.Value);
                            foreach (var item in keyMaterialsDescOrder)
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }

                            // print remaining junk items
                            var junkDescOrder = junkItems
                                .OrderBy(x => x.Key);
                            foreach (var item in junkDescOrder)
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
