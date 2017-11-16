using System;

class SpecialNumbers
{
    static void Main()
    {
        var num = int.Parse(Console.ReadLine());

        for (int i = 1; i <= num; i++)
        {
            var sum = 0;
            var digit = i.ToString();
            for (int j = 0; j < digit.Length; j++)
            {
                sum += int.Parse(digit[j].ToString());
            }
            bool isSpecial = sum == 5 || sum == 7 || sum == 11;
            Console.WriteLine($"{i} -> {isSpecial}");
        }
            //var n = int.Parse(Console.ReadLine());

            //for (int i = 1; i <= n; i++)
            //{
            //    var sum = 0;
            //    var number = i;
            //    while (number > 0)
            //    {
            //        sum += number % 10;
            //        number /= 10;
            //    }
            //    bool ifSumIsEqualOnFive = (sum == 5);
            //    bool ifSumIsEqualOnSeven = (sum == 7);
            //    bool ifSumIsEqualOnElevan = (sum == 11);
            //    bool isSPecial = ifSumIsEqualOnFive || ifSumIsEqualOnSeven || ifSumIsEqualOnElevan;
            //    Console.WriteLine("{0} -> {1}", i, isSPecial);
            //}
        }
    }
