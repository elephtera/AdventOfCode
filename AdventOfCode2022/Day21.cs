using System.Data.SqlTypes;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day21 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            var result = inputData.First(m => m.Name == "root").GetValue();
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);

            var root = inputData.First(m => m.Name == "root");

            var monkey = root.MonkeyLeft.IsParentOfHumn() ? root.MonkeyLeft : root.MonkeyRight;

            var expectedValue = root.MonkeyLeft.IsParentOfHumn() ? root.MonkeyRight.GetValue() : root.MonkeyLeft.GetValue();
            while(true)
            {
                if(monkey.Action == MonkeyAction.Number)
                {
                    return expectedValue;
                }

                if (monkey.MonkeyLeft.IsParentOfHumn())
                {
                    switch (monkey.Action)
                    {
                        case MonkeyAction.Add:
                            //a+b=c => a = c-b
                            expectedValue -= monkey.MonkeyRight.GetValue();
                            break;
                        case MonkeyAction.Minus:
                            //a-b=c => a = c+b
                            expectedValue += monkey.MonkeyRight.GetValue();
                            break;
                        case MonkeyAction.Divide:
                            //a/b=c => a = c*b
                            expectedValue *= monkey.MonkeyRight.GetValue();
                            break;
                        case MonkeyAction.Multiply:
                            //a*b=c => a = c/b
                            expectedValue /= monkey.MonkeyRight.GetValue();
                            break;
                        case MonkeyAction.Number:
                            return expectedValue;
                    }

                    monkey = monkey.MonkeyLeft;
                    // right = the constant, perform action on right. 
                }
                else
                {
                    switch (monkey.Action)
                    {
                        case MonkeyAction.Add:
                            //a+b=c => b = c-a
                            expectedValue -= monkey.MonkeyLeft.GetValue();
                            break;
                        case MonkeyAction.Minus:
                            //a-b=c => a-c = b
                            expectedValue = monkey.MonkeyLeft.GetValue() - expectedValue;
                            break;
                        case MonkeyAction.Divide:
                            //a/b=c => a/c = b
                            expectedValue = monkey.MonkeyLeft.GetValue()/expectedValue;
                            break;
                        case MonkeyAction.Multiply:
                            //a*b=c => b = c/a
                            expectedValue /= monkey.MonkeyLeft.GetValue();
                            break;
                        case MonkeyAction.Number:
                            return expectedValue;
                    }

                    monkey = monkey.MonkeyRight;
                }
            }
        }

        public static IList<MonkeyShout> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);
            var monkeys = new List<MonkeyShout>();
            List<string[]> splitted = new List<string[]>();
            foreach (var line in lines)
            {
                string[] item = line.Split(' ').ToArray();
                splitted.Add(item);
                monkeys.Add(new MonkeyShout(item[0][..4]));
            }

            foreach (var item in splitted)
            {
                var monkey = monkeys.First(x => x.Name == item[0][..4]);

                if (item.Length == 2)
                {
                    monkey.Value = long.Parse(item[1]);
                    monkey.Action = MonkeyAction.Number;
                }
                else
                {
                    monkey.MonkeyLeft = monkeys.First(x => x.Name == item[1]);
                    monkey.MonkeyRight = monkeys.First(x => x.Name == item[3]);
                    if (item[2] == "+") monkey.Action = MonkeyAction.Add;
                    else if (item[2] == "-") monkey.Action = MonkeyAction.Minus;
                    else if (item[2] == "*") monkey.Action = MonkeyAction.Multiply;
                    else if (item[2] == "/") monkey.Action = MonkeyAction.Divide;
                }
            }

            return monkeys;
        }


    }

    public class MonkeyShout
    {
        public MonkeyShout(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public MonkeyShout? MonkeyLeft { get; set; }
        public MonkeyShout? MonkeyRight { get; set; }

        public long Value { get; set; }

        public long GetValue()
        {
            switch (Action)
            {
                case MonkeyAction.Add:
                    return MonkeyLeft.GetValue() + MonkeyRight.GetValue();
                    case MonkeyAction.Minus:
                    return MonkeyLeft.GetValue() - MonkeyRight.GetValue();
                case MonkeyAction.Divide:
                    return MonkeyLeft.GetValue() / MonkeyRight.GetValue();
                case MonkeyAction.Multiply:
                    return MonkeyLeft.GetValue() * MonkeyRight.GetValue();
                case MonkeyAction.Number:
                default:
                    return Value;
            }
        }

        public bool IsParentOfHumn()
        {
            if (Action == MonkeyAction.Number) return Name == "humn";
            return MonkeyLeft.IsParentOfHumn() || MonkeyRight.IsParentOfHumn();
        }

        public MonkeyAction Action { get; set; }

    }

    public enum MonkeyAction
    {
        Add,
        Minus,
        Divide,
        Multiply,
        Number
    }
}
