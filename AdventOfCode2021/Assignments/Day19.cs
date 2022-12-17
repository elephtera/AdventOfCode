using System.Text.RegularExpressions;

namespace AdventOfCode2021.Assignments
{
    public class Day19 : IDay
    {
        public string Part1()
        {
            return LocateScanners(Day19Input.Input)
                       .SelectMany(scanner => scanner.GetTransformedProbes())
                       .Distinct()
                       .Count().ToString();
        }
       

        public string Part2()
        {
            var scanners = LocateScanners(Day19Input.Input);
            return (
                from sA in scanners
                from sB in scanners
                where sA != sB
                select
                    Math.Abs(sA.ScannerLocation.X - sB.ScannerLocation.X) +
                    Math.Abs(sA.ScannerLocation.Y - sB.ScannerLocation.Y) +
                    Math.Abs(sA.ScannerLocation.Z - sB.ScannerLocation.Z)
            ).Max().ToString();
        }

        HashSet<ScannerData> LocateScanners(string input)
        {
            var scanners = new HashSet<ScannerData>(InputHandler.ConvertInputToScannerData(input));
            var locatedScanners = new HashSet<ScannerData>();
            var q = new Queue<ScannerData>();

            // when a scanner is located, it gets into the queue so that we can
            // explore its neighbours.

            locatedScanners.Add(scanners.First());
            q.Enqueue(scanners.First());

            scanners.Remove(scanners.First());

            while (q.Any())
            {
                var scannerA = q.Dequeue();
                foreach (var scannerB in scanners.ToArray())
                {
                    var maybeLocatedScanner = TryToLocate(scannerA, scannerB);
                    if (maybeLocatedScanner != null)
                    {

                        locatedScanners.Add(maybeLocatedScanner);
                        q.Enqueue(maybeLocatedScanner);

                        scanners.Remove(scannerB); // sic! 
                    }
                }
            }

            return locatedScanners;
        }
        ScannerData? TryToLocate(ScannerData scannerA, ScannerData scannerB)
        {
            var beaconsInA = scannerA.GetTransformedProbes().ToArray();

            foreach (var (beaconInA, beaconInB) in PotentialMatchingBeacons(scannerA, scannerB))
            {
                // now try to find the orientation for B:
                var rotatedB = scannerB;
                for (var rotation = 0; rotation < 24; rotation++, rotatedB = rotatedB.Rotate())
                {
                    // Moving the rotated scanner so that beaconA and beaconB overlaps. Are there 12 matches? 
                    var beaconInRotatedB = rotatedB.Transform(beaconInB);

                    var locatedB = rotatedB.Translate(new Coordinate3D(
                        beaconInA.X - beaconInRotatedB.X,
                        beaconInA.Y - beaconInRotatedB.Y,
                        beaconInA.Z - beaconInRotatedB.Z
                    ));

                    if (locatedB.GetTransformedProbes().Intersect(beaconsInA).Count() >= 12)
                    {
                        return locatedB;
                    }
                }
            }

            // no luck
            return null;
        }

        IEnumerable<(Coordinate3D beaconInA, Coordinate3D beaconInB)> PotentialMatchingBeacons(ScannerData scannerA, ScannerData scannerB)
        {
            // If we had a matching beaconInA and beaconInB and moved the center
            // of the scanners to these then we would find at least 12 beacons 
            // with the same coordinates.

            // The only problem is that the rotation of scannerB is not fixed yet.

            // We need to make our check invariant to that:

            // After the translation, we could form a set from each scanner 
            // taking the absolute values of the x y and z coordinates of their beacons 
            // and compare those. 

            IEnumerable<int> absCoordinates(ScannerData scanner) =>
                from coord in scanner.GetTransformedProbes()
                from v in new[] { coord.X, coord.Y, coord.Z }
                select Math.Abs(v);

            // This is the same no matter how we rotate scannerB, so the two sets should 
            // have at least 3 * 12 common values (with multiplicity).

            // 🐦 We can also considerably speed up the search with the pigeonhole principle 
            // which says that it's enough to take all but 11 beacons from A and B. 
            // If there is no match amongst those, there cannot be 12 matching pairs:
            IEnumerable<T> pick<T>(IEnumerable<T> ts) => ts.Take(ts.Count() - 11);

            foreach (var beaconInA in pick(scannerA.GetTransformedProbes()))
            {
                var absA = absCoordinates(
                    scannerA.Translate(new Coordinate3D(-beaconInA.X, -beaconInA.Y, -beaconInA.Z))
                ).ToHashSet();

                foreach (var beaconInB in pick(scannerB.GetTransformedProbes()))
                {
                    var absB = absCoordinates(
                        scannerB.Translate(new Coordinate3D(-beaconInB.X, -beaconInB.Y, -beaconInB.Z))
                    );

                    if (absB.Count(d => absA.Contains(d)) >= 3 * 12)
                    {
                        yield return (beaconInA, beaconInB);
                    }
                }
            }
        }
    }
}
