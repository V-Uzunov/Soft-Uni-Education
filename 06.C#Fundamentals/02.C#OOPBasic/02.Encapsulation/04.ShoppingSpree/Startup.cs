namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var people = new List<Person>();
                var products = new List<Product>();

                var allPeople = Console.ReadLine();
                var allPeopleTokens = allPeople.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var token in allPeopleTokens)
                {
                    var info = token.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = info[0];
                    var money = decimal.Parse(info[1]);

                    people.Add(new Person(name, money));

                }

                var allProducts = Console.ReadLine();
                var allProductToken = allProducts.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var token in allProductToken)
                {
                    var info = token.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                    var prodName = info[0];
                    var prodCost = decimal.Parse(info[1]);

                    products.Add(new Product(prodName, prodCost));
                }

                string inputLine;
                while ((inputLine=Console.ReadLine()) != "END")
                {
                    var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                    var name = tokens[0];
                    var prod = tokens[1];

                    var person = people.FirstOrDefault(p => p.Name == name);
                    var product = products.FirstOrDefault(p => p.Name == prod);

                    person.BuyProduct(product);
                }

                foreach (var person in people)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(p => p.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);                
            }
        }
    }
}
