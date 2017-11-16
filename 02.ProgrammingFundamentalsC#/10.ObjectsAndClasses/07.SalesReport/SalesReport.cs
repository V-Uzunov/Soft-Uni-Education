using System;
using System.Collections.Generic;
using System.Linq;

class Sales
{
    public string Town { get; set; }
    public string Product { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}
class SalesReport
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        Sales[] sales = new Sales[n];

        for (int i = 0; i < n; i++)
        {
            sales[i] = ReadSale();
        }

        SortedDictionary<string, decimal> salesByTown = new SortedDictionary<string, decimal>();

        for (int i = 0; i < n; i++)
        {
            if (!salesByTown.ContainsKey(sales[i].Town))
            {
                salesByTown.Add(sales[i].Town, 0);
            }

            salesByTown[sales[i].Town] += sales[i].Price * sales[i].Quantity;
        }
        foreach (var Town in salesByTown)
        {
            Console.WriteLine($"{Town.Key} -> {Town.Value:f2}");
        }
    }

    private static Sales ReadSale()
    {
        string[] sale = Console.ReadLine().Split().ToArray();
        Sales singleSale = new Sales()
        { Town = sale[0], Product = sale[1], Price = decimal.Parse(sale[2]), Quantity = decimal.Parse(sale[3]) };

        return singleSale;
    }
}