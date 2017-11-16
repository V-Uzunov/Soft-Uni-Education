namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var n = input[0];
            var m = input[1];

            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();
            
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                nSet.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                var num = int.Parse(Console.ReadLine());
                mSet.Add(num);
            }            

            nSet.IntersectWith(mSet);

            Console.WriteLine(string.Join(" ", nSet));

            //var result = new HashSet<int>();
            //foreach (var nums in nSet)
            //{
            //    foreach (var num in mSet)
            //    {
            //        if (nums == num)
            //        {
            //            result.Add(nums);
            //        }
            //    }
            //}
            //Console.WriteLine(string.Join(" ", result));
        }
    }
}
