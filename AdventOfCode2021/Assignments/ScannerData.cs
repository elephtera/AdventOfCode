namespace AdventOfCode2021.Assignments
{
    internal class ScannerData
    {
        public ScannerData(int scannerID)
        {
            ID = scannerID;
            Probes = new List<Coordinate3D>();
            ProbeDiff = new List<DiffCoord>();
        }

        public int ID { get; }

        public List<Coordinate3D> Probes { get; }

        public List<DiffCoord> ProbeDiff { get; }

        internal void AddProbe(int x, int y, int z)
        {
            Coordinate3D newProbe = new(x, y, z);
            if (Probes.Any(p => p.Equals(newProbe)))
            {
                return;
            }

            foreach (Coordinate3D probe in Probes)
            {
                ProbeDiff.Add(new DiffCoord(probe, newProbe));
            }

            Probes.Add(newProbe);
        }

        internal void RotateAndMap(ScannerData scanner)
        {
            foreach(DiffCoord diff in ProbeDiff)
            {
                DiffCoord? diffCoord = scanner.ProbeDiff.FirstOrDefault(p => p.Equals(diff));
                if (diffCoord != null)
                {

                }
            }
            var overlapInMap = ProbeDiff.Where(p => scanner.ProbeDiff.Any(pd => pd.DiffXYZ.Equals(p.DiffXYZ)));


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

        public Coordinate3D DiffXYZ { get; }

        public DiffCoord(Coordinate3D coordA, Coordinate3D coordB)
        {
            CoordA = coordA;
            CoordB = coordB;
            DiffXYZ = CoordA.Diff(CoordB);
        }

        public (int x, int y, int z) TranslationXYZ(DiffCoord other)
        {
            if (CoordA.X - CoordB.X == other.CoordA.X - other.CoordB.X && CoordA.Y - CoordB.Y == other.CoordA.Y - other.CoordB.Y)
            {
                // A == A, B == B
                return (CoordA.X - other.CoordA.X, CoordA.Y - other.CoordA.Y, CoordA.Z - other.CoordA.Z);
            }
            else
            {
                return (CoordA.X - other.CoordB.X, CoordA.Y - other.CoordB.Y, CoordA.Z - other.CoordB.Z);

            }
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

            return other.DiffXYZ.Equals(DiffXYZ);
        }

        public override int GetHashCode()
        {
            return DiffXYZ.GetHashCode();
        }
    }

    public class Coordinate3D
    {
        private int[] point3D;
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coordinate3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            point3D = new int[3] { x, y, z };
            AddAllCoordinates();
        }

        public List<int[]> AllCoordinates { get; } = new List<int[]>();

        private int[] Roll(int[] dice) => new int[3] { dice[0], dice[2], -dice[1] };
        private int[] Turn(int[] dice) => new int[3] { -dice[1], dice[0], dice[2] };

        public void AddAllCoordinates()
        {
            int[] v = this.point3D;
            for(int cycle = 0; cycle < 2; cycle++)
            {
                for(int step = 0; step < 3; step++)
                {
                    v = Roll(v);
                    AllCoordinates.Add(v);
                    for(int i = 0; i < 3; i++)
                    {
                        v = Turn(v);
                        AllCoordinates.Add(v);
                    }
                }
                Roll(Turn(Roll(v)));
            }
        }
      
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