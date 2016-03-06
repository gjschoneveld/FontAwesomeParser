using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace FontAwesome
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("font-awesome.css");

            string pattern = @"(?:\.fa-([a-z]+):before,\s*)*\.fa-([a-z]+):before {\s*content: ""\\([0-9a-f]+)"";\s*}";


            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            foreach (Match match in matches)
            {
                // gather names; first group is whole match; last is value
                List<string> names = new List<string>();
                for (int i = 1; i < match.Groups.Count - 1; i++)
                {
                    foreach (var capt in match.Groups[i].Captures)
                    {
                        names.Add(capt.ToString());
                    }
                }

                // gather value
                string value = match.Groups[match.Groups.Count - 1].Value;

                // process data
                foreach (var n in names)
                {
                    Console.WriteLine("{0}:", n);
                }
                Console.WriteLine("-> {0}", value);
            }

            Console.ReadKey();

        }
    }
}
