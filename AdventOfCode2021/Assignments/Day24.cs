namespace AdventOfCode2021.Assignments
{
    /**

     */
    public class Day24 : IDay
    {
        public string PartA()
        {
            var instructions = InputHandler.ConvertInputToOpcodes(Day24Input.Input);

            int[] valueInput = new int[14]
            {
                1,1,1,1,1,1,1,1,1,1,1,1,1,1
            };

            int[] result = ProcessAluInstructions(instructions, valueInput);
            if(result[3] == 0)
            {
                return "valid: " + string.Concat(valueInput);
            }

            return "invalid";
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
