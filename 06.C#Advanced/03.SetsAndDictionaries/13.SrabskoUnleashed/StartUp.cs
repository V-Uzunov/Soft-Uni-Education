namespace _13.SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> sales = new Dictionary<string, Dictionary<string, long>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                // singerName1 [name2 name3] @venueName1 [name2 name3] ticketPrice ticketsCount
                string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length < 4 || data.Length > 8 || !input.Contains(" @"))
                {
                    continue;
                }                    
                int ticketsCount = 0;
                int ticketPrice = 0;
                try
                {
                    ticketPrice = int.Parse(data[data.Length - 2]);
                    ticketsCount = int.Parse(data[data.Length - 1]);
                }
                catch (Exception)
                {
                    continue;
                }
                string venue = string.Empty;
                string singer = string.Empty;
                for (int venueIndex = 1; venueIndex < data.Length - 2; venueIndex++)
                {
                    if (data[venueIndex][0] == '@')
                    {
                        for (int i = 0; i < venueIndex; i++)
                            singer += data[i] + " ";
                        singer = singer.Trim();
                        for (int i = venueIndex; i < data.Length - 2; i++)
                            venue += " " + data[i];
                        venue = venue.Substring(2); // trim "@ "
                        break;
                    }
                }
                if (!sales.ContainsKey(venue))
                {
                    sales[venue] = new Dictionary<string, long>();
                }                    
                if (!sales[venue].ContainsKey(singer))
                {
                    sales[venue][singer] = 0;
                }                    
                sales[venue][singer] += ticketPrice * ticketsCount;
            }
            foreach (var venuePair in sales)
            {
                Console.WriteLine(venuePair.Key);   // venue
                // singer sales in desc.order
                foreach (var singerSalesPair in venuePair.Value.OrderBy(x => -x.Value))
                    Console.WriteLine($"#  {string.Join(" -> ", singerSalesPair.Key, singerSalesPair.Value)}");
            }
        }
    }
}
