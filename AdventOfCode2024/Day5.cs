using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace AdventOfCode2024
{
    public class Day5 : IDay<long>
    {
        public long Part1(string input)
        {
            var (rules, updates) = ProcessInput(input);
            var result = 0;

            foreach(var update in updates)
            {
                bool invalid = checkIfUpdateIsValid(rules, update);

                if (!invalid)
                {
                    // add middle item
                    result += update[update.Count / 2];
                }
            }

            return result;
        }

        public long Part2(string input)
        {
            var (rules, updates) = ProcessInput(input);
            var result = 0;
            var invalid_updates = new List<List<int>>();
            foreach (var update in updates)
            {
                bool invalid = checkIfUpdateIsValid(rules, update);

                if (invalid)
                {
                    // add middle item
                    invalid_updates.Add(update);
                }
            }

            foreach(var update in invalid_updates)
            {
                List<int> printed = update;
                while (checkIfUpdateIsValid(rules, printed))
                {
                    printed = ReOrderPages(rules, printed);
                }
                    
                result += printed[printed.Count / 2];
            }


            return result;
        }

        private static List<int> ReOrderPages(Dictionary<int, List<int>> rules, List<int> update)
        {
            var printed = new List<int>();
            foreach (var page in update)
            {

                printed.Add(page);
                if (rules.TryGetValue(page, out var order))
                {
                    foreach (var item in order)
                    {
                        if (printed.Contains(item))
                        {
                            // Move the item to the end of the print-list
                            printed.Remove(item);
                            printed.Add(item);
                        }
                    }
                }
            }

            return printed;
        }

        private static bool checkIfUpdateIsValid(Dictionary<int, List<int>> rules, List<int> update)
        {
            var invalid = false;
            var printed = new List<int>();
            foreach (var page in update)
            {
                if (rules.TryGetValue(page, out var list))
                {
                    foreach (var item in list)
                    {
                        if (printed.Contains(item))
                        {
                            // invalid update!
                            invalid = true;
                        }
                    }
                }
                printed.Add(page);
            }

            return invalid;
        }

        public static (Dictionary<int, List<int>>, IList<List<int>>) ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var rules = new Dictionary<int, List<int>>();
            var updates = new List<List<int>>();
            foreach (var line in lines)
            {
                // Process each line
                if (line.Contains('|'))
                {
                    // first lines are number | number
                    var parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                    rules.TryGetValue(parts[0], out var list);
                    if (list == null)
                    {
                        list = new List<int>();
                        rules[parts[0]] = list;
                    }

                    list.Add(parts[1]);
                }
                else if (line.Contains(','))
                {
                    updates.Add(line.Split(',').Select(x => int.Parse(x)).ToList());
                }
            }

            return (rules, updates);
        }
    }
}
