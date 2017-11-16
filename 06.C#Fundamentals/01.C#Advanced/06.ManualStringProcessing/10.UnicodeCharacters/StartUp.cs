namespace _10.UnicodeCharacters
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                sb.Append("\\u");
                sb.Append($"{(int)c:x4}");
            }
            Console.WriteLine(sb);
        }
    }
}
