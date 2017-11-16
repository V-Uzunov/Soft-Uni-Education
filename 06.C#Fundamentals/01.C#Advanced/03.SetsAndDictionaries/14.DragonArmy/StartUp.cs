namespace _14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int[]>> dragonStats = new Dictionary<string, Dictionary<string, int[]>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string dragonType = data[0];
                string dragonName = data[1];
                int dragonDamage = 45;  // default values
                int dragonHealth = 250; // default values
                int dragonArmor = 10;   // default values
                if (data[2] != "null")
                {
                    dragonDamage = int.Parse(data[2]);
                }
                if (data[3] != "null")
                {
                    dragonHealth = int.Parse(data[3]);
                }                
                if (data[4] != "null")
                {
                    dragonArmor = int.Parse(data[4]);
                }
                int[] currentStats = { dragonDamage, dragonHealth, dragonArmor };

                if (!dragonStats.ContainsKey(dragonType))
                {
                    dragonStats[dragonType] = new Dictionary<string, int[]>();
                }                    
                if (!dragonStats[dragonType].ContainsKey(dragonName))
                {
                    dragonStats[dragonType][dragonName] = new int[3];
                }                    
                dragonStats[dragonType][dragonName] = currentStats; // overwrite previous data
            }
            foreach (var dragonTypePair in dragonStats)
            {
                // stats by dragon type
                Console.WriteLine($"{dragonTypePair.Key}::({dragonTypePair.Value.Select(x => x.Value[0]).Average():f2}/{dragonTypePair.Value.Select(x => x.Value[1]).Average():f2}/{dragonTypePair.Value.Select(x => x.Value[2]).Average():f2})");
                // stats by dragon
                foreach (var dragon in dragonTypePair.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }                    
            }
        }
    }
}
