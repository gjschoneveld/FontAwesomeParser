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

            string pattern = @"(?:\.fa-([a-z0-9-]+):before,?\s*)+{\s*content:\s*""\\([0-9a-f]+)"";\s*}";
            Regex rgx = new Regex(pattern);

            MatchCollection matches = rgx.Matches(input);
            foreach (Match match in matches)
            {
                // first group (0) is whole match
                int namesGroup = 1;
                int valueGroup = 2;

                // gather names
                List<string> names = match.Groups[namesGroup].Captures.Cast<Capture>().Select(c => c.Value).ToList();

                // gather value
                string value = match.Groups[valueGroup].Value;

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
