namespace _05.PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            try
            {
                string inputLine;
                while (!(inputLine = Console.ReadLine()).Equals("END"))
                {
                    var tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0].Equals("Dough"))
                    {
                        var dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
                        Console.WriteLine($"{dough.Calories():f2}");
                    }
                    else if (tokens[0].Equals("Topping"))
                    {
                        var topping = new Topping(tokens[1], int.Parse(tokens[2]));
                        Console.WriteLine($"{topping.Callories():f2}");
                    }
                    else
                    {
                        var pizzaName = tokens[1];
                        var numberOfToppings = int.Parse(tokens[2]);
                        if (numberOfToppings > 10)
                        {
                            Console.WriteLine("Number of toppings should be in range [0..10].");
                            return;
                        }

                        inputLine = Console.ReadLine();
                        var tokensDough = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var dough = new Dough(tokensDough[1], tokensDough[2], int.Parse(tokensDough[3]));
                        var pizza = new Pizza(pizzaName, dough);

                        for (int i = 0; i < numberOfToppings; i++)
                        {
                            inputLine = Console.ReadLine();
                            var tokenTopping = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            pizza.AddToppind(new Topping(tokenTopping[1], int.Parse(tokenTopping[2])));
                        }

                        Console.WriteLine($"{pizza.Name} - {pizza.Callories():f2} Calories.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Pizza
    {
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }
        public List<Topping> Toppings
        {
            get { return this.toppings; }
            set
            {
                this.toppings = value;
            }
        }

        public void AddToppind(Topping topping)
        {
            this.Toppings.Add(topping);
        }

        public double Callories()
        {
            double callories = 0;
            callories += this.dough.Calories();
            this.Toppings.ForEach(c => callories += c.Callories());

            return callories;
        }

    }


    public class Topping
    {
        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string type;
        private int weight;
        private const double baseCalloriesPerGram = 2;

        private string Type
        {
            get { return this.type; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        private int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double Callories()
        {
            var modifier = baseCalloriesPerGram;

            switch (this.Type.ToLower())
            {
                case "meat":
                    modifier *= 1.2;
                    break;
                case "veggies":
                    modifier *= 0.8;
                    break;
                case "cheese":
                    modifier *= 1.1;
                    break;
                case "sauce":
                    modifier *= 0.9;
                    break; ;
            }

            return this.Weight * modifier;
        }

    }


    public class Dough
    {
        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string flourType;
        private string bakingTechnique;
        private int weight;
        private const double baseCalloriesPerGram = 2;

        private string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        private int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double Calories()
        {
            double modifier = baseCalloriesPerGram;
            switch (this.FlourType.ToLower())
            {
                case "white":
                    modifier *= 1.5;
                    break;
                case "wholegrain":
                    modifier *= 1.0;
                    break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    modifier *= 0.9;
                    break;
                case "chewy":
                    modifier *= 1.1;
                    break;
                case "homemade":
                    modifier *= 1.0;
                    break;
            }

            return modifier * this.Weight;
        }
    }
}
