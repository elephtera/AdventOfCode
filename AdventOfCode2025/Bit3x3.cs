using System.Numerics;
using System.Text;

namespace AdventOfCode2025
{
    /// <summary>
    /// 3x3 bitmask stored in a single byte. Bits are indexed row-major:
    /// bit 0 = (0,0) top-left, bit 1 = (1,0) top-middle, ..., bit 8 = (2,2) bottom-right.
    /// </summary>
    public readonly record struct Bit3x3(byte Mask)
    {
        public const int Width = 3;
        public const int Height = 3;

        public int OccupiedCount => BitOperations.PopCount(Mask);

        public bool Get(int x, int y)
        {
            ValidateCoords(x, y);
            var index = y * Width + x;
            return ((Mask >> index) & 1) != 0;
        }

        public Bit3x3 Set(int x, int y, bool value)
        {
            ValidateCoords(x, y);
            var index = y * Width + x;
            var mask = value ? (byte)(Mask | (1 << index)) : (byte)(Mask & ~(1 << index));
            return new Bit3x3(mask);
        }

        public int CountBits() => BitOperations.PopCount((uint)Mask);

        public Bit3x3 Rotate90Clockwise()
        {
            byte newMask = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var oldIndex = y * Width + x;
                    if (((Mask >> oldIndex) & 1) == 0) continue;
                    // (x,y) -> (newX, newY) = (2 - y, x)
                    int newIndex = x * Width + (2 - y);
                    newMask |= (byte)(1 << newIndex);
                }
            }
            return new Bit3x3(newMask);
        }

        public Bit3x3 Rotate180() => Rotate90Clockwise().Rotate90Clockwise();

        public Bit3x3 Rotate270Clockwise() => Rotate180().Rotate90Clockwise();

        public Bit3x3 FlipHorizontal() // mirror left-right
        {
            byte newMask = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var oldIndex = y * Width + x;
                    if (((Mask >> oldIndex) & 1) == 0) continue;
                    int newIndex = y * Width + (2 - x);
                    newMask |= (byte)(1 << newIndex);
                }
            }
            return new Bit3x3(newMask);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    sb.Append(Get(x, y) ? '#' : '.');
                }
                if (y < Height - 1) sb.AppendLine();
            }
            return sb.ToString();
        }

        public static Bit3x3 FromStrings(IList<string> lines)
        {
            if (lines is null) throw new ArgumentNullException(nameof(lines));
            if (lines.Count != Height) throw new ArgumentException($"Expected {Height} rows.");
            byte mask = 0;
            for (int y = 0; y < Height; y++)
            {
                var row = lines[y] ?? throw new ArgumentException("Row is null", nameof(lines));
                if (row.Length != Width) throw new ArgumentException($"Each row must be {Width} chars long.");
                for (int x = 0; x < Width; x++)
                {
                    char c = row[x];
                    if (c == '#') mask |= (byte)(1 << (y * Width + x));
                    else if (c == '.') { /* empty */ }
                    else throw new ArgumentException("Only '#' and '.' allowed in shape.");
                }
            }
            return new Bit3x3(mask);
        }

        public Bit3x3 CanonicalizeByRotationAndFlip()
        {
            // Return lexicographically smallest mask string among all rotations/flips
            Bit3x3 best = this;
            var variants = new[]
            {
                this,
                this.Rotate90Clockwise(),
                this.Rotate180(),
                this.Rotate270Clockwise(),
                this.FlipHorizontal(),
                this.FlipHorizontal().Rotate90Clockwise(),
                this.FlipHorizontal().Rotate180(),
                this.FlipHorizontal().Rotate270Clockwise()
            };

            foreach (var v in variants)
            {
                if (v.Mask < best.Mask) best = v;
            }
            return best;
        }

        private static void ValidateCoords(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException($"Coordinates must be in [0..{Width-1}]x[0..{Height-1}]");
        }
    }
}
