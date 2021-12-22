namespace AdventOfCode2021.Assignments
{
    public class ScannerData
    {
        public Coordinate3D ScannerLocation { get; }
        public int Rotation { get; }
        public List<Coordinate3D> Probes { get; }

        public ScannerData(Coordinate3D center, int rotation, List<Coordinate3D> probes)
        {
            ScannerLocation = center;
            Rotation = rotation;
            Probes = probes;
        }

        public ScannerData(List<Coordinate3D> probes)
        {
            ScannerLocation = new Coordinate3D(0,0,0);
            Rotation = 0;
            Probes = probes;
        }

        public ScannerData Rotate()
        {
            return new(ScannerLocation, Rotation + 1, Probes);
        }

        public ScannerData Translate(Coordinate3D t)
        {
            var translatedScannerLocation = new Coordinate3D(ScannerLocation.X + t.X, ScannerLocation.Y + t.Y, ScannerLocation.Z + t.Z);
            return new ScannerData(translatedScannerLocation, Rotation, Probes);
        }

        public Coordinate3D Transform(Coordinate3D coord)
        {
            var x = coord.X;
            var y = coord.Y;
            var z = coord.Z;

#pragma warning disable 1717
            // rotate coordinate system so that x-axis points in the possible 6 directions
            switch (Rotation % 6)
            {
                case 0: (x, y, z) = (x, y, z); break;
                case 1: (x, y, z) = (-x, y, -z); break;
                case 2: (x, y, z) = (y, -x, z); break;
                case 3: (x, y, z) = (-y, x, z); break;
                case 4: (x, y, z) = (z, y, -x); break;
                case 5: (x, y, z) = (-z, y, x); break;
            }

            // rotate around x-axis:
            switch ((Rotation / 6) % 4)
            {
                case 0: (x, y, z) = (x, y, z); break;
                case 1: (x, y, z) = (x, -z, y); break;
                case 2: (x, y, z) = (x, -y, -z); break;
                case 3: (x, y, z) = (x, z, -y); break;
            }
#pragma warning restore

            var rotatedScannerLocation = new Coordinate3D(ScannerLocation.X + x, ScannerLocation.Y + y, ScannerLocation.Z + z);
            return rotatedScannerLocation;
        }

        public IEnumerable<Coordinate3D> GetTransformedProbes()
        {
            return Probes.Select(Transform);
        }
    }

}
