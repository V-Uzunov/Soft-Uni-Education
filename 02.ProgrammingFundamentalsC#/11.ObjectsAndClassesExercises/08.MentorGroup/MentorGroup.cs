using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

class MentorGroup
{
    static void Main()
    {
        SortedDictionary<string, List<DateTime>> userNames = new SortedDictionary<string, List<DateTime>>();
        Dictionary<string, List<string>> userComments = new Dictionary<string, List<string>>();
        string command = "";
        while (command != "end")
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = input[0];
            if (name == "end")
            {
                break;
            }
            List<DateTime> dates = input.Skip(1)
                .Select(date => DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                .ToList();
            if (!userNames.ContainsKey(name))
            {
                userNames.Add(name, new List<DateTime>());
            }
            userNames[name].AddRange(dates);
        }
        command = "";
        while (command != "end of comments")
        {
            string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = input[0];
            if (name == "end of comments")
            {
                break;
            }
            string comment = input[1];
            List<string> comments = new List<string>();
            comments.Add(comment);

            if (userNames.ContainsKey(name) && !userComments.ContainsKey(name))
            {
                userComments.Add(name, new List<string>());
            }
            if (userComments.ContainsKey(name))
            {
                userComments[name].AddRange(comments);
            }
        }
        foreach (var user in userNames)
        {
            string person = user.Key;
            Console.WriteLine(person);
            Console.WriteLine("Comments:");
            foreach (var human in userComments)
            {
                List<string> comments = human.Value;
                string man = human.Key;
                if (man == person)
                {
                    Console.WriteLine("- " + string.Join("\r\n- ", comments));
                }
            }
            List<DateTime> dates = user.Value;
            Console.WriteLine("Dates attended:");
            foreach (var date in dates.OrderBy(x => x))
            {
                string ourDate = date.ToString("dd/MM/yyyy");
                Console.WriteLine("-- " + ourDate);
            }
        }
    }
}