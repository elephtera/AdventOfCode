namespace AdventOfCode2021.Assignments
{
    internal class ScannerData
    {
        public ScannerData(int scannerID)
        {
            ID = scannerID;
            Probes = new List<Coordinate3D>();
            ProbeDiff = new List<Coordinate3D>();
        }
        
        public int ID { get; }

        public List<Coordinate3D> Probes { get; }

        public List<Coordinate3D> ProbeDiff { get; }

        public IEnumerable<Coordinate3D> ProbeDiffYX { get
            {
                foreach (Coordinate3D p in ProbeDiff)
                {
                    yield return new Coordinate3D(p.Y,p.X,p.Z);
                }
            } 
        }

        public IEnumerable<Coordinate3D> ProbeDiffZY
        {
            get
            {
                foreach (Coordinate3D p in ProbeDiff)
                {
                    yield return new Coordinate3D(p.X, p.Z, p.Y);
                }
            }
        }

        /**
         * ----- X
         * |
         * |
         * Y
         * */

        internal void AddProbe(int x, int y, int z)
        {
            Coordinate3D newProbe = new(x, y, z);
            foreach(Coordinate3D probe in Probes)
            {
                ProbeDiff.Add(probe.Diff(newProbe));
            }

            Probes.Add(newProbe);
        }

        //internal (int x, int y, int z) DetermineDiff(ScannerData scanner)
        //{
        //    var coordsX = Probes.Select(p => p.X).ToList();
        //    var coordsY = Probes.Select(p => p.Y).ToList();
        //    var coordsZ = Probes.Select(p => p.Z).ToList();
        //    int maxX = coordsX.Max();
        //    int maxY = coordsY.Max();
        //    int maxZ = coordsZ.Max();

        //    var minX = coordsX.Min();
        //    var minY = coordsY.Min();
        //    int minZ = coordsZ.Min();


        //    for (int i = minX; i < maxX; i++)
        //    {
        //        for(int j = minY; j < maxY; j++)
        //        {
        //            for(var k = minZ; k < maxZ; k++)
        //            {
        //                // 
        //            }
        //        }
        //    }
        //}
    }

    public class DiffCoord
    {
        public Coordinate3D CoordA { get; }
        public Coordinate3D CoordB { get; }

        public Coordinate3D Diff { get; }

        public DiffCoord(Coordinate3D coordA, Coordinate3D coordB)
        {
            CoordA = coordA;
            CoordB = coordB;
            Diff = CoordA.Diff(CoordB);
        }

        public override bool Equals(object? obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is DiffCoord))
            {
                return false;
            }
            var other = (DiffCoord)obj;

            return other.Diff == Diff;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public class Coordinate3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coordinate3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int[] Xyz => new int[3] { X, Y, Z };

        internal Coordinate3D Diff(Coordinate3D newProbe)
        {
            var diffX = Math.Abs(X - newProbe.X);
            var diffY = Math.Abs(Y - newProbe.Y);
            var diffZ = Math.Abs(Z - newProbe.Z);

            var diff = new Coordinate3D(diffX, diffY, diffZ);

            return diff;

        }

        public override bool Equals(object? obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Coordinate3D))
            {
                return false;
            }
            var other = (Coordinate3D)obj;

            return other.X == X && other.Y == Y && other.Z == Z;
        }

        public override int GetHashCode()
        {
            return X + Y * 1000 + Z * 1000000;
        }
    }

}