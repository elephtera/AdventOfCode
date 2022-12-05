namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day5 : IDay<string>
    {
        public string PartA(IList<string> input)
        {
            var warehouse = FillWarehouse(input.First());
            var actions = FillActions(input.Last());

            foreach (var action in actions)
            {
                for(int i = 0; i < action.Amount; i++)
                {
                    warehouse[action.To].Add(warehouse[action.From].Last());
                    warehouse[action.From].RemoveAt(warehouse[action.From].Count - 1);
                }
            }
            
            var result = String.Concat(warehouse.Select(p => p.Last()));
            return result;
        }

        public string PartB(IList<string> input)
        {
            var warehouse = FillWarehouse(input.First());
            var actions = FillActions(input.Last());

            foreach (var action in actions)
            {
                var cnt = warehouse[action.From].Count;
                warehouse[action.To].AddRange(warehouse[action.From].GetRange(cnt - action.Amount, action.Amount));
                warehouse[action.From].RemoveRange(cnt - action.Amount, action.Amount);
            }

            var result = String.Concat(warehouse.Select(p => p.Last()));
            return result;
        }

        public static List<List<char>> FillWarehouse(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);

            var warehouse = new List<List<char>>();
            foreach (var line in lines)
            {
                var pile = line.ToList();
                warehouse.Add(pile);
            }

            return warehouse;
        }

        public static List<WarehouseAction> FillActions(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            var actions = new List<WarehouseAction>();
            foreach (var line in lines)
            {
                var splitted = line.Split(' ');
                actions.Add(new WarehouseAction(int.Parse(splitted[1]), int.Parse(splitted[3]), int.Parse(splitted[5])));
            }

            return actions;
        }

        public class WarehouseAction
        {
            public int From { get; }
            public int To { get; }
            public int Amount { get; }

            public WarehouseAction(int amount, int from, int to)
            {
                From = from - 1;
                To = to - 1;
                Amount = amount;
            }
        }
    }

}
