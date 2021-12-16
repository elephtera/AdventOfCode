namespace AdventOfCode2021.Assignments
{
    /**
     * 
     */
    public class Day16 : IDay
    {


        public string PartA()
        {
            string input = InputHandler.ConvertInputToBitString(Day16Input.Input);
            var (_, _, versionCount) = ParsePacket(input, 0);
            return versionCount.ToString();


        }

        public string PartB()
        {
            string input = InputHandler.ConvertInputToBitString(Day16Input.Input);
            var (_, Value, _) = ParsePacket(input, 0);
            return Value.ToString();
        }

        private (int PacketSize, long Value, int PacketVersion) ParsePacket(string input, int startpoint)
        {
            // Offset values
            var packetVersionOffset = 0;
            var typeIDOffset = 3;

            // Parse header
            var packetVersionString = input.Substring(startpoint + packetVersionOffset, 3);
            var packetVersion = Convert.ToInt32(packetVersionString, 2);

            var typeIDString = input.Substring(startpoint + typeIDOffset, 3);
            var typeID = Convert.ToInt32(typeIDString, 2);

            var payloadOffset = typeIDOffset + 3;
            if(typeID == 4)
            {
                (int payloadSize, long literalValue) = ParseLiteralValue(input, startpoint + payloadOffset);
                var packetSize = payloadOffset + payloadSize;
                return (packetSize, literalValue, packetVersion);
            } 
            else
            {
                (int size, long[] values, int versioncount) = ParseOperator(input, startpoint + payloadOffset);
                var versionCount = versioncount + packetVersion;
                var packetSize = payloadOffset + size;

                switch (typeID)
                {
                    case 0:
                        return (packetSize, values.Sum(), versionCount);
                    case 1:
                        var product = 1L;
                        foreach (var value in values)
                        {
                            product *= value;
                        }
                        return (packetSize, product, versionCount);
                    case 2:
                        return (packetSize, values.Min(), versionCount);
                    case 3:
                        return (packetSize, values.Max(), versionCount);
                    case 5:
                        var gtCheck = values[0] > values[1] ? 1 : 0;
                        return (packetSize, gtCheck, versionCount);
                    case 6:
                        var ltCheck = values[0] < values[1] ? 1 : 0;
                        return (packetSize, ltCheck, versionCount);
                    case 7:
                        var eqCheck = values[0] == values[1] ? 1 : 0;
                        return (packetSize, eqCheck, versionCount);
                }

            }

            return (0, 0, packetVersion);
        }

        private (int size, long[] operatorvalue, int versioncount) ParseOperator(string input, int startpoint)
        {
            var lengthTypeID = input.Substring(startpoint, 1);

            var values = new List<long>();
            var versionCount = 0;

            if (lengthTypeID == "0")
            {
                var totalLengthInBitsString = input.Substring(startpoint + 1, 15);
                var totalLengthInBits = Convert.ToInt32(totalLengthInBitsString, 2);

                var payloadSize = 16 + totalLengthInBits;
                var packetOffset = startpoint + 16;

                var bitsLeft = totalLengthInBits;
                while (bitsLeft > 0)
                {
                    (int PacketSize, long Value, int PacketVersion) = ParsePacket(input, packetOffset);
                    bitsLeft -= PacketSize;
                    versionCount += PacketVersion;
                    packetOffset += PacketSize;
                    values.Add(Value);
                }

                return (payloadSize, values.ToArray(), versionCount);

            }
            else if (lengthTypeID == "1")
            {
                var numberOfSubPackagesString = input.Substring(startpoint + 1, 11);
                var numberOfSubPackages = Convert.ToInt32(numberOfSubPackagesString, 2);

                var payloadSize = 12;
                var packetOffset = startpoint + payloadSize;

                for (int i = 0; i < numberOfSubPackages; i++)
                {
                    (int PacketSize, long Value, int PacketVersion) = ParsePacket(input, packetOffset);
                    versionCount += PacketVersion;
                    packetOffset += PacketSize;
                    payloadSize += PacketSize;
                    values.Add(Value);
                }
                return (payloadSize, values.ToArray(), versionCount);
            }
            return (0, Array.Empty<long>(), 0);
        }

        private static (int PayloadSize, long LiteralValue) ParseLiteralValue(string input, int startpoint)
        {
            var literalBlockOffset = 0;
            var lastGroup = false;
            var literalValueString = "";
            while (!lastGroup)
            {
                lastGroup = input.Substring(startpoint + literalBlockOffset, 1) == "0";

                var nextValue = input.Substring(startpoint + literalBlockOffset + 1, 4);
                literalValueString += nextValue;
                literalBlockOffset += 5;
            }

            var literalValue = Convert.ToInt64(literalValueString, 2);
            var size = literalBlockOffset;// + (4 - (literalBlockOffset % 4));
            return (PayloadSize: size, LiteralValue: literalValue);
        }
    }


}
