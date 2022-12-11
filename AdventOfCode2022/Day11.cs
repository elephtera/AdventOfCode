namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day11
    {
        public long PartA(IList<Monkey> input)
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in input)
                {
                    foreach (var item in monkey.Items)
                    {
                        var calc = monkey.Operation(item);
                        calc /= 3;
                        if (calc % monkey.ModuloValue == 0)
                        {
                            input.Where(m => m.ID == monkey.MonkeyTrue).Single().Items.Add(calc);
                        }
                        else
                        {
                            input.Where(m => m.ID == monkey.MonkeyFalse).Single().Items.Add(calc);
                        }

                        monkey.inspectedCount++;
                    }
                    monkey.Items.Clear();
                }

            }
            var inspectionCount = input.Select(m => m.inspectedCount).OrderByDescending(i=>i).Take(2).ToList();
            var result = inspectionCount[0] * inspectionCount[1];
            return result;
        }

        public long PartB(IList<Monkey> input)
        {
            long monkeyModulo = input.Select(m => m.ModuloValue).Aggregate((m1, m2) => m1 * m2);

            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in input)
                {
                    foreach (var item in monkey.Items)
                    {
                        var calc = monkey.Operation(item);
                        calc %= monkeyModulo;

                        if (calc % monkey.ModuloValue == 0)
                        {
                            input.Where(m => m.ID == monkey.MonkeyTrue).Single().Items.Add(calc);
                        }
                        else
                        {
                            input.Where(m => m.ID == monkey.MonkeyFalse).Single().Items.Add(calc);
                        }

                        monkey.inspectedCount++;
                    }
                    monkey.Items.Clear();
                }
            }
            var inspectionCount = input.Select(m => m.inspectedCount).OrderByDescending(i => i).Take(2).ToList();
            var result = inspectionCount[0] * inspectionCount[1];
            return result;
        }
        
    }
    public class Monkey
    {
        public long ID { get; set; }
        public List<long> Items { get; set; }
        public Func<long, long> Operation { get; set; }
        public long MonkeyFalse { get; set; }
        public long MonkeyTrue { get; set; }
        public long inspectedCount { get; set; } = 0;
        public int ModuloValue { get; set; }
    }
}
