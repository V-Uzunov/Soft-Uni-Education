namespace _03.ParseTags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var startTag = "<upcase>";
            var endTag = "</upcase>";

            var startIndex = input.IndexOf(startTag);

            while (startIndex != -1)
            {
                var endIndex = input.IndexOf(endTag);
                if (endIndex == -1)
                {
                    break;
                }
                var mustReplase = input.Substring(startIndex, endIndex  - startIndex + endTag.Length);
                var replaced = mustReplase
                    .Replace(startTag, String.Empty)
                    .Replace(endTag, String.Empty)
                    .ToUpper();

                input = input.Replace(mustReplase, replaced);
                startIndex = input.IndexOf(startTag);
            }
            Console.WriteLine(input);
        }
    }
}
