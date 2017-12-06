namespace _03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);               

            var dictNums = new SortedDictionary<double, int>();

            foreach (var nums in numbers)
            {
                double reminder = double.Parse(nums);
                if (!dictNums.ContainsKey(reminder))
                {
                    dictNums.Add(reminder, 1);
                }
                else
                {
                    dictNums[reminder]++;
                }
            }
            foreach (var item in dictNums)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }            
        }
    }
}
