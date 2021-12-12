
namespace AdventOfCode2021.Assignments
{
    internal class CaveMap
    {
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        public CaveMap(IList<string> input)
        {
            foreach (var line in input)
            {
                var caves = line.Split(new string[] { "-" },
                    StringSplitOptions.None);

                AddToMap(caves[0], caves[1]);
                AddToMap(caves[1], caves[0]);
            }
        }

        private void AddToMap(string fromCave, string toCave)
        {
            if(toCave == "start" || fromCave == "end")
            {
                return;
            }

            if (map.ContainsKey(fromCave))
            {
                map[fromCave].Add(toCave);
            }
            else
            {
                map.Add(fromCave, new List<string>() { toCave });
            }
        }

        public List<List<string>> Travel(List<string> alreadyTravelled, string targetCave)
        {
            var allRoutes = new List<List<string>>();
            alreadyTravelled.Add(targetCave);

            if (targetCave == "end")
            {
                allRoutes.Add(alreadyTravelled);
                return allRoutes;
            }

            foreach (string cave in map[targetCave].Where(c => IsBigCave(c) || !alreadyTravelled.Contains(c)))
            {
                var travelled = new List<string>(alreadyTravelled);
                allRoutes.AddRange(Travel(travelled, cave));
            }

            return allRoutes;
        }

        public List<List<string>> TravelB(List<string> alreadyTravelled, string targetCave, bool hasVisitedSmallCaveTwice)
        {
            var allRoutes = new List<List<string>>();
            alreadyTravelled.Add(targetCave);

            if (targetCave == "end")
            {
                allRoutes.Add(alreadyTravelled);
                return allRoutes;
            }

            foreach (string cave in map[targetCave].Where(c => IsBigCave(c) || !hasVisitedSmallCaveTwice || !alreadyTravelled.Contains(c)))
            {
                var travelled = new List<string>(alreadyTravelled);
                var willVisitTwice = !IsBigCave(cave) && alreadyTravelled.Contains(cave);

                allRoutes.AddRange(TravelB(travelled, cave, hasVisitedSmallCaveTwice || willVisitTwice));
            }

            return allRoutes;
        }

        private static bool IsBigCave(string c)
        {
            return c.All(c => char.IsUpper(c));
        }
    }
}