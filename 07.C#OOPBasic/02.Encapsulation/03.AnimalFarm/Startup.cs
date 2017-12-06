namespace _03.AnimalFarm
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using global::AnimalFarm.Models;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                Type chickenType = typeof(Chicken);
                FieldInfo[] fields = chickenType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo[] methods = chickenType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
                Debug.Assert(fields.Count(f => f.IsPrivate) == 2);
                Debug.Assert(methods.Count(m => m.IsPrivate) == 1);

                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(
                    "Chicken {0} (age {1}) can produce {2} eggs per day.",
                    chicken.Name,
                    chicken.Age,
                    chicken.GetProductPerDay());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            
        }
    }
}
