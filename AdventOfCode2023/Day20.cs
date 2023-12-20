using System.Collections;
using System.Reflection.Metadata.Ecma335;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023
{
    /**
     * 
     */
    public class Day20 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);
            List<Modules> modules = new List<Modules>();
            foreach (var module in inputData)
            {
                modules.Add(new Modules(module));
            }

            foreach (var module in modules.Where(m => m.Type == ModuleType.Conjunction))
            {
                // prep all inputs
                foreach (var targets in modules.Where(m => m.Targets.Contains(module.ID)))
                {
                    module.ConjunctionMemory[targets.ID] = PulseType.Low;
                }
            }

            var pulses = new Queue<(PulseType type, string target, string source)>();
            
            // Press button
            var buttonPresses = 1;
            var lowPulseCount = 0;
            var highPulseCount = 0;

            pulses.Enqueue((PulseType.Low, "broadcaster", "button"));

            while (pulses.Count > 0)
            {
                var pulse = pulses.Dequeue();
                if (pulse.type == PulseType.Low) lowPulseCount++;
                if (pulse.type == PulseType.High) highPulseCount++;

                var targetModule = modules.SingleOrDefault(m => m.ID == pulse.target);
                if (targetModule != null)
                {

                    foreach (var newPulse in targetModule
                                 .ReceiveAndSendPulse(pulse.type, pulse.source))
                    {
                        pulses.Enqueue(newPulse);
                    }
                }

                if (pulses.Count == 0 && buttonPresses < 1000)
                {
                    buttonPresses++;
                    pulses.Enqueue((PulseType.Low, "broadcaster", "button"));
                }
            }
            
            
            var result = (long)lowPulseCount * highPulseCount;
            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);
            List<Modules> modules = new List<Modules>();
            foreach (var module in inputData)
            {
                modules.Add(new Modules(module));
            }

            foreach (var module in modules.Where(m => m.Type == ModuleType.Conjunction))
            {
                // prep all inputs
                foreach (var targets in modules.Where(m => m.Targets.Contains(module.ID)))
                {
                    module.ConjunctionMemory[targets.ID] = PulseType.Low;
                }
            }

            var pulses = new Queue<(PulseType type, string target, string source)>();

            // Press button
            var buttonPresses = 1;
            var lowPulseCount = 0;
            var highPulseCount = 0;

            pulses.Enqueue((PulseType.Low, "broadcaster", "button"));

            var conjunctionHighButtonPressCount = new Dictionary<string, int>();

            while (pulses.Count > 0)
            {
                var pulse = pulses.Dequeue();
                if (pulse.type == PulseType.Low) lowPulseCount++;
                if (pulse.type == PulseType.High) highPulseCount++;

                var targetModule = modules.SingleOrDefault(m => m.ID == pulse.target);
                if (targetModule != null)
                {

                    foreach (var newPulse in targetModule
                                 .ReceiveAndSendPulse(pulse.type, pulse.source))
                    {
                        pulses.Enqueue(newPulse);
                    }

                    if (targetModule.Type == ModuleType.Conjunction &&
                        targetModule.ConjunctionMemory.All(mem => mem.Value == PulseType.High))
                    {
                        conjunctionHighButtonPressCount.TryAdd(targetModule.ID, buttonPresses);
                    }
                }
                else if(pulse.target == "rx" && pulse.type == PulseType.Low)
                {
                    return buttonPresses;
                }

                if (pulses.Count == 0 && buttonPresses < 10000)
                {
                    buttonPresses++;
                    pulses.Enqueue((PulseType.Low, "broadcaster", "button"));
                }
            }

            
            var lcm = conjunctionHighButtonPressCount.Select(cnt => (long)cnt.Value).Aggregate(MathHelper.LCM);
            var result = lcm;
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine},
                    StringSplitOptions.None);
            
            return lines;
        }
    }

    public class Modules
    {
        public ModuleType Type { get; }
        public string ID { get; }

        public bool FlipFlipState
        {
            get;
            set;
        } = false;

        public Dictionary<string, PulseType> ConjunctionMemory { get; } = new Dictionary<string, PulseType>();

        public Modules(string module)
        {
            var moduleParts = module.Split(" -> ");
            switch (module[0])
            {
                case '%':
                    Type = ModuleType.FlipFlop;
                    ID = moduleParts[0][1..];
                    break;
                case '&':
                    Type = ModuleType.Conjunction;
                    ID = moduleParts[0][1..];
                    break;
                case 'b':
                    Type = ModuleType.Broadcast;
                    ID = "broadcaster";
                    break;
            }

            Targets = moduleParts[1].Split(", ").ToList();
        }

        public List<string> Targets { get; set; }

        public List<(PulseType pulse, string target, string source)> ReceiveAndSendPulse(PulseType pulse, string source)
        {
            switch (Type)
            {
                case ModuleType.FlipFlop:
                    if (pulse == PulseType.Low)
                    {
                        FlipFlipState = !FlipFlipState;
                        if(FlipFlipState)
                        {
                            // send high pulse
                            return Targets.Select(t => (PulseType.High, t, ID)).ToList();
                        }

                        // send low pulse
                        return Targets.Select(t => (PulseType.Low, t, ID)).ToList();
                    }
                    break;
                case ModuleType.Conjunction:
                    ConjunctionMemory[source] = pulse;
                    if (ConjunctionMemory.All(mem => mem.Value == PulseType.High))
                    {
                        return Targets.Select(t => (PulseType.Low, t, ID)).ToList();
                    }

                    return Targets.Select(t => (PulseType.High, t, ID)).ToList();

                    break;
                case ModuleType.Broadcast:
                    return Targets.Select(t => (pulse, t, ID)).ToList();
                    break;
            }

            return new List<(PulseType pulse, string target, string source)>();
        }



    }

    public enum PulseType
    {
        High,
        Low,
    }

    public enum ModuleType
    {
        FlipFlop,
        Conjunction,
        Broadcast
    }
}
