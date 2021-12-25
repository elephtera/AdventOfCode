namespace AdventOfCode2021.Assignments
{
    public class AluInstruction
    {
        public Opcode Opcode { get; }

        public int OutputId { get; }

        public int Input { get; }

        public AluInstruction(string opcode, string outputId, string? inputId)
        {
            OutputId = ConverteerParameter(outputId);

            if (inputId != null)
            {
                Input = ConverteerParameter(inputId);
            }

            bool inputIsId = inputId == null || inputId.Contains('w') || inputId.Contains('x') || inputId.Contains('y') || inputId.Contains('z');
            if (inputIsId) {
                Opcode = opcode switch
                {
                    "inp" => Opcode.Input,
                    "add" => Opcode.Add,
                    "mul" => Opcode.Multiply,
                    "div" => Opcode.Divide,
                    "mod" => Opcode.Modulo,
                    "eql" => Opcode.Equal,
                    "set" => Opcode.Set,
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                Opcode = opcode switch
                {
                    "add" => Opcode.AddValue,
                    "mul" => Opcode.MultiplyValue,
                    "div" => Opcode.DivideValue,
                    "mod" => Opcode.ModuloValue,
                    "eql" => Opcode.EqualValue,
                    "set" => Opcode.SetValue,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        private static int ConverteerParameter(string parameter)
        {
            return parameter switch
            {
                "w" => 0,
                "x" => 1,
                "y" => 2,
                "z" => 3,
                _ => Convert.ToInt32(parameter),
            };
        }
    }

}