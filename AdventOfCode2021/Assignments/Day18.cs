using System.Text.RegularExpressions;

namespace AdventOfCode2021.Assignments
{
    /**
     * 
     */
    public class Day18 : IDay
    {


        public string Part1()
        {
            string rawInput = Day18Input.Input;
            SnailfishMath processed = DoMath(InputHandler.GetInputAsStringList(rawInput));

            return processed.ToString() + " => " + processed.Magnitude.ToString();


        }

        public SnailfishMath DoMath(IList<string>? input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            // Parse input per line
            var snailfishlines = new List<SnailfishMath>();
            foreach (var line in input)
            {
                var parsedLine = ParseElement(line);
                snailfishlines.Add(parsedLine);
            }

            var processed = snailfishlines.First();
            foreach (var newMathObject in snailfishlines.Skip(1))
            {
                var next = new SnailfishMath();
                next.Left = processed;
                next.Right = newMathObject;
                next.Reduce();
                processed = next;
            }

            return processed;
        }

        public SnailfishMath ParseElement(string line)
        {
            var math = new SnailfishMath();
            var r = new Regex(@"\[              # match eerste '['
                                (?:             #    
                                [^\[\]]         # match alles wat geen [] is
                                |               #
                                (?<open> \[ )   # tel alle interne open '['
                                |               #
                                (?<-open> \] )  # verminder met alle interne sluit ']'
                                )+              #
                                (?(open)(?!))   # Fail als het aantal open/dicht haken niet klopt
                                \]              # match laatste ']'
                                ", RegexOptions.IgnorePatternWhitespace);


            var inner = line[1..^1];
            if (inner.First() == '[')
            {
                var matched = r.Match(inner);
                var res = ParseElement(matched.Value);
                math.Left = res;
                inner = inner[(matched.Length + 1)..^0]; // + 1 is for the ','
            } 
            else
            {
                // het is een nummer
                math.ValueLeft = inner.First() - '0';;
                inner = inner[2..^0]; // 2 = number + ','
            }

            if (inner.Last() == ']')
            {
                var matched = r.Match(inner);
                var res = ParseElement(matched.Value);
                math.Right = res;
            } else
            {
                math.ValueRight = inner.Last() - '0';

            }

            return math;
        }

        public string Part2()
        {
            var maxMagnitude = 0L;

            string rawInput = Day18Input.Input;
            IList<string> input = InputHandler.GetInputAsStringList(rawInput);


            foreach(string inputString in input)
            {
                foreach(string inputString2 in input.Where(i => i != inputString))
                {
                    var mathInput = new List<string>() { inputString, inputString2 };
                    SnailfishMath processed = DoMath(mathInput);
                    if(processed.Magnitude > maxMagnitude)
                    {
                        maxMagnitude = processed.Magnitude;
                    }
                }
            }
            

            return maxMagnitude.ToString();
        }
    }

    public class SnailfishMath
    {
        public int? ValueLeft { get; set; }
        public int? ValueRight { get; set; }

        public SnailfishMath? Left { get; set; }

        public SnailfishMath? Right { get; set; }

        //public int Depth { get; set; }

        public long Magnitude
        {
            get
            {
                var magnitude = 0L;
                if (ValueLeft.HasValue)
                {
                    magnitude += ValueLeft.Value * 3;
                }
                else
                {
                    magnitude += Left?.Magnitude * 3 ?? 0;
                }

                if (ValueRight.HasValue)
                {
                    magnitude += ValueRight.Value * 2;
                } 
                else
                {
                    magnitude += Right?.Magnitude * 2 ?? 0;
                }

                return magnitude;
            }
        }

        internal (int? left, int? right, bool exploded) Explode(int depth)
        {
            if (ValueLeft.HasValue && ValueRight.HasValue && depth > 4)
            {
                return (ValueLeft.Value, ValueRight.Value, true);
            }

            // Explode and add!
            if(Left != null)
            {
                // [[[a,b],[c,d]]

                (int? left, int? right, bool exploded) explodedLeft = Left.Explode(depth + 1);
                if(explodedLeft.left.HasValue && explodedLeft.right.HasValue)
                {
                    // Exploded, thus set it to zero.
                    Left = null;
                    ValueLeft = 0;
                }

                if (explodedLeft.right.HasValue)
                {
                    if (ValueRight.HasValue)
                    {
                        ValueRight += explodedLeft.right.Value;
                    }
                    else
                    {
                        Right?.AddFirstLeft(explodedLeft.right.Value);
                    }
                }

                if (explodedLeft.exploded)//(explodedLeft.left.HasValue)
                {
                    return (explodedLeft.left, null, true);
                }
            }

            // If exploded left, stop!

            if (Right != null)
            {
                (int? left, int? right, bool exploded) explodedRight = Right.Explode(depth + 1);
                if (explodedRight.left.HasValue && explodedRight.right.HasValue)
                {
                    // Exploded, thus set it to zero.
                    Right = null;
                    ValueRight = 0;
                }

                if (explodedRight.left.HasValue)
                {
                    if (ValueLeft.HasValue)
                    {
                        ValueLeft += explodedRight.left.Value;
                    }
                    else
                    {
                        Left?.AddFirstRight(explodedRight.left.Value);
                    }
                }

                if (explodedRight.exploded)
                {
                    return (null, explodedRight.right, true);
                }                
            }

            return (null, null, false);

        }

        private void AddFirstLeft(int value)
        {
            if (ValueLeft.HasValue)
            {
                ValueLeft += value;
            } 
            else
            {
                Left?.AddFirstLeft(value);
            }
        }

        private void AddFirstRight(int value)
        {
            if (ValueRight.HasValue)
            {
                ValueRight += value;
            }
            else
            {
                Right?.AddFirstRight(value);
            }
        }

        /// <summary>
        /// Split one item per time.
        /// </summary>
        /// <returns></returns>
        internal bool Split()
        {
            if (Left != null)
            {
                if (Left.Split())
                {
                    return true;
                }
            }
            else if(ValueLeft.HasValue && ValueLeft.Value > 9)
            {
                Left = new SnailfishMath() { ValueLeft = this.ValueLeft.Value / 2, ValueRight = (this.ValueLeft.Value + 1) / 2 };
                ValueLeft = null;
                return true;
            }

            if (Right != null)
            {
                if (Right.Split())
                {
                    return true;
                }

            }
            else if (ValueRight.HasValue && ValueRight.Value > 9)
            {
                Right = new SnailfishMath() { ValueLeft = this.ValueRight.Value / 2, ValueRight = (this.ValueRight.Value + 1) / 2 };
                ValueRight = null;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var result = "[";
            if (ValueLeft.HasValue)
            {
                result += ValueLeft.Value; 
            }
            else
            {
                result += Left?.ToString();
            }
            result += ",";
            if (ValueRight.HasValue)
            {
                result += ValueRight.Value;
            }
            else
            {
                result += Right?.ToString();
            }
            result += "]";
            return result;
        }

        internal void Reduce()
        {
            while (true)
            {
                (int? left, int? right, bool exploded) res = Explode(1);
                if (res.exploded)
                {
                    continue;
                }

                if (Split())
                {
                    continue;
                }

                break;
            }
        }
    }

}
