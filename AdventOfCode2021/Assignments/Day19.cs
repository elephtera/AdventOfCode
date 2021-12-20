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
            
            // Use scannerData as one central map
            var map = new ScannerData(99);
            foreach(var probe in scanners[10].Probes)
            {
                map.AddProbe(probe.X, probe.Y, probe.Z);
            }
            var cnt = 1;

            foreach(var scanner in scanners)
            {

                map.RotateAndMap(scanner);


                var overlapInMap = map.ProbeDiff.Where(p => scanner.ProbeDiff.Any(pd => pd.DiffXYZ.Equals( p.DiffXYZ)));
                if (overlapInMap.Count() > 12)
                {
                    var firstOverlapInMap = overlapInMap.First();
                    var first = scanner.ProbeDiff.First(p => p.Equals(firstOverlapInMap));
                    var (diffX, diffY, diffZ) = firstOverlapInMap.TranslationXYZ(first);

                    foreach (var probe in scanner.Probes)
                    {
                        map.AddProbe(probe.X + diffX, probe.Y + diffY, probe.Z + diffZ);
                    }
                    cnt++;
                    continue;
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
