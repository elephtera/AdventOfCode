namespace AdventOfCode2021.Assignments
{
    /**

     */
    public class Day24 : IDay
    {
        public string PartA()
        {
            var instructions = InputHandler.ConvertInputToOpcodes(Day24Input.Input);

            /**
             * 
             * (z/splitted[0])*
             * ((splitted[1]*((z%26+25) == A? 0 : 1))+1)+
             * (A+splitted[2])*((z%26+25) == A? 0 : 1)
             * 
             * 
             */
            long lowest = long.MaxValue;
            long highest = long.MinValue;

            for (long i = 10000000000000; i <= 99999999999999; i++)
            {
                var digits = i.ToString().Select(ch => int.Parse(ch.ToString())).ToArray();
                int step = 0;
                long z = 0;

                foreach (var split in instructions)
                {
                    var w = digits[step];
                    var test = (z % 26) + split[1] == w;
                    if (w != 0 && split[0] == 26 && test)
                    {
                        z /= split[0];
                    }
                    else if (w != 0 && split[0] == 1 && !test)
                    {
                        z = 26 * (z / split[0]) + w + split[2];
                    }
                    else
                    {
                        //e.g. 234560000 to 234569999
                        i += (long)Math.Pow(10, 13 - step);
                        i--;
                        break;
                    }
                    step++;
                }

                if (z == 0)
                {
                    lowest = Math.Min(lowest, i);
                    highest = Math.Max(highest, i);
                }
            }

            return $"low: {lowest} highest: {highest}" ;
        }

        public int[] ProcessAluInstructions(List<AluInstruction> instructions, int[] valueInput)
        {
            var register = new int[4]
            {
                0,0,0,0,
            };

            var inputCount = -1;
            foreach(var instruction in instructions)
            {
                switch (instruction.Opcode)
                {
                    case Opcode.Input:
                        register[instruction.OutputId] = valueInput[++inputCount];
                        break;
                    case Opcode.Add:
                        register[instruction.OutputId] += register[instruction.Input];
                        break;
                    case Opcode.Multiply:
                        register[instruction.OutputId] *= register[instruction.Input];
                        break;
                    case Opcode.Divide:
                        if (register[instruction.Input] == 0) { throw new Exception("Divide by zero"); }
                        register[instruction.OutputId] /= register[instruction.Input];
                        break;
                    case Opcode.Modulo:
                        if (register[instruction.Input] == 0) { throw new Exception("Modulo by zero"); }
                        register[instruction.OutputId] %= register[instruction.Input];
                        break;
                    case Opcode.Equal:
                        register[instruction.OutputId] = (register[instruction.OutputId] == register[instruction.Input] ? 1 : 0);
                        break;
                    case Opcode.AddValue:
                        register[instruction.OutputId] += instruction.Input;
                        break;
                    case Opcode.MultiplyValue:
                        register[instruction.OutputId] *= instruction.Input;
                        break;
                    case Opcode.DivideValue:
                        register[instruction.OutputId] /= instruction.Input;
                        break;
                    case Opcode.ModuloValue:
                        register[instruction.OutputId] %= instruction.Input;
                        break;
                    case Opcode.EqualValue:
                        register[instruction.OutputId] = (register[instruction.OutputId] == instruction.Input ? 1 : 0);
                        break;
                    case Opcode.Set:
                        register[instruction.OutputId] = register[instruction.Input];
                        break;
                    case Opcode.SetValue:
                        register[instruction.OutputId] = instruction.Input;
                        break;
                }

            }
            return register;
        }

        public string PartB()
        {
            
            return 0.ToString();
        }


    }

}
