namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day13Test
    {
        private const int AnswerPart1 = 5390;
        private const int AnswerPart2 = 19261;
        private const int AnswerExamplePart1 = 13;
        private const int AnswerExamplePart2 = 140;


        private readonly IDay<int> day = new Day13();
        private readonly IDayInput input = new Day13Input();

        [TestMethod]
        public void Part1Example()
        {
            var result = day.Part1(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart1, result);
        }

        [TestMethod]
        public void Part1()
        {
            var result = day.Part1(input.Input);
            Assert.AreEqual(AnswerPart1, result);
        }

        [TestMethod]
        public void Part2Example()
        {
            var result = day.Part2(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePart2, result);
        }

        [TestMethod]
        public void Part2()
        {
            var result = day.Part2(input.Input);
            Assert.AreEqual(AnswerPart2, result);
        }

        [TestMethod]
        public void PacketParser()
        {
            var rootPacket = new Packet();
            rootPacket.Add("[1]");
            Assert.HasCount(1, rootPacket.Packets);
            Assert.AreEqual(1, rootPacket.Packets[0].Value);

            rootPacket = new Packet();
            rootPacket.AddFirst("[1]");
            Assert.IsEmpty(rootPacket.Packets);
            Assert.AreEqual(1, rootPacket.Value);

            rootPacket = new Packet();
            rootPacket.AddFirst("[1,1,3,1,1]");
            Assert.HasCount(5, rootPacket.Packets);
            Assert.AreEqual(3, rootPacket.Packets[2].Value);

            rootPacket = new Packet();
            rootPacket.AddFirst("[[1],[2,3,4]]");
            Assert.HasCount(2, rootPacket.Packets);
            Assert.HasCount(3, rootPacket.Packets[1].Packets);
        }

        [TestMethod]
        public void PacketCompare()
        {
            var packetLeft = new Packet("[1,1,3,1,1]");
            var packetRight = new Packet("[1,1,5,1,1]");
            Assert.AreEqual(-1, packetLeft.CompareTo(packetRight));


            packetLeft = new Packet("[[1],[2,3,4]]");
            packetRight = new Packet("[[1],4]"); 
            Assert.AreEqual(-1, packetLeft.CompareTo(packetRight));


            packetLeft = new Packet("[9]");
            packetRight = new Packet("[[8,7,6]]");
            Assert.AreEqual(1, packetLeft.CompareTo(packetRight));

                        packetLeft = new Packet("[[4,4],4,4]");
            packetRight = new Packet("[[4,4],4,4,4]");
            Assert.AreEqual(-1, packetLeft.CompareTo(packetRight));


            packetLeft = new Packet("[7,7,7,7]");
            packetRight = new Packet("[7,7,7]");
            Assert.AreEqual(1, packetLeft.CompareTo(packetRight));

            packetLeft = new Packet("[]");
            packetRight = new Packet("[3]");
            Assert.AreEqual(-1, packetLeft.CompareTo(packetRight));


            packetLeft = new Packet("[[[]]]");
            packetRight = new Packet("[[]]");
            Assert.AreEqual(1, packetLeft.CompareTo(packetRight));

            packetLeft = new Packet("[1,[2,[3,[4,[5,6,7]]]],8,9]");
            packetRight = new Packet("[1,[2,[3,[4,[5,6,0]]]],8,9]");
            Assert.AreEqual(1, packetLeft.CompareTo(packetRight));

        }
    }
}