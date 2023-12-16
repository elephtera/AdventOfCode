namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day15 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);

            var result = 0;

            foreach (var step in inputData)
            {
                var currentValue = 0;

                foreach (var character in step)
                {
                    currentValue += character;
                    currentValue *= 17;
                    currentValue %= 256;
                }
                result += currentValue;
            }

            return result;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);

            var id = 0;
            var boxes = Enumerable.Repeat(0, 256).Select(i => new Box(id++)).ToArray();

            foreach (var step in inputData)
            {
                var boxId = 0;

                foreach (var character in step)
                {
                    if (character == '=')
                    {
                        boxes[boxId].AddLens(step[..^2], int.Parse(step[^1..]));
                        break;
                    }
                    else if (character == '-')
                    {
                        // remove something
                        boxes[boxId].RemoveLens(step[..^1]);
                    }
                    else
                    {
                        boxId += character;
                        boxId *= 17;
                        boxId %= 256;
                    }
                }
            }

            var result = boxes.Sum(box => box.FocusPower);


            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(',',
                    StringSplitOptions.None).ToList();

            return lines;
        }
    }

    public class Box
    {
        public Box(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        public List<Lens> Lenses { get; } = new();

        public void RemoveLens(string label)
        {
            Lenses.RemoveAll(l => l.Label == label);
        }

        public void AddLens(string label, int focalLength)
        {
            var lens = Lenses.SingleOrDefault(l => l.Label == label);
            if (lens == null)
            {
                lens = new Lens(label);
                Lenses.Add(lens);
            }

            lens.FocalLength = focalLength;
        }

        public int FocusPower
        {
            get
            {
                var result = 0;
                var cnt = 1;
                foreach (var lense in Lenses)
                {
                    result += (Id + 1) * cnt * lense.FocalLength;
                    cnt++;
                }
                return result;
            }
        }
    }

    public class Lens
    {
        public Lens(string label)
        {
            Label = label;
        }

        public string Label { get; set; }
        public int FocalLength { get; set; }
    }
}
