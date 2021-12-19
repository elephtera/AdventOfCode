using System.Text.RegularExpressions;

namespace AdventOfCode2021.Assignments
{
    /**
     * 
     */
    public class Day19 : IDay
    {


        public string PartA()
        {
            
            string rawInput = Day19Input.Input;
            var scanners = InputHandler.ConvertInputToScannerData(rawInput);
            
            string result = "";
            foreach(var scanner in scanners)
            {

                var overlapping = scanners.Where(s => s != scanner).Where(s => s.ProbeDiff.Intersect(scanner.ProbeDiff).Count() > 12);
                if (overlapping.Any())
                {
                    
                    result += $" |xyz| {scanner.ID}: " + string.Join(",", overlapping.Select(o => o.ID)) + Environment.NewLine;
                }

                overlapping = scanners.Where(s => s != scanner).Where(s => s.ProbeDiffYX.Intersect(scanner.ProbeDiff).Count() > 12);
                if (overlapping.Any())
                {
                    result += $" |yxz| {scanner.ID}: " + string.Join(",", overlapping.Select(o => o.ID)) + Environment.NewLine;
                }

                overlapping = scanners.Where(s => s != scanner).Where(s => s.ProbeDiffZY.Intersect(scanner.ProbeDiff).Count() > 12);
                if (overlapping.Any())
                {
                    result += $" |xzy| {scanner.ID}: " + string.Join(",", overlapping.Select(o => o.ID)) + Environment.NewLine;
                }

            }


            // Use scannerData as one central map
            var map = new ScannerData(99);
            foreach(var probe in scanners[0].Probes)
            {
                map.AddProbe(probe.X, probe.Y, probe.Z);
            }

            foreach(var scanner in scanners.Skip(1))
            {
                var overlap = map.ProbeDiff.Intersect(scanner.ProbeDiff);
                if (overlap.Count() > 12)
                {
                    // There is a match. We can add this scannerdata to the map
                    (int x, int y, int z) = map.DetermineDiff(scanner);
                    foreach (var probe in scanner.Probes)
                    {
                        map.AddProbe(probe.X, probe.Y, probe.Z);
                    }
                }
            }


            return result.ToString();


        }

        public string PartB()
        {
           
            return "0";
        }
    }

}
