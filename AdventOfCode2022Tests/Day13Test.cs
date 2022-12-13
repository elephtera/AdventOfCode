namespace AdventOfCode2022Tests
{
    [TestClass]
    public class Day13Test
    {
        private const int AnswerPartA = 0;
        private const int AnswerPartB = 0;
        private const int AnswerExamplePartA = 13;
        private const int AnswerExamplePartB = 0;


        private readonly IDay<int> day = new Day13();
        private readonly IDayInput input = new Day13Input();

        [TestMethod]
        public void PartAExample()
        {
            var result = day.PartA(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartA, result);
        }

        [TestMethod]
        public void PartA()
        {
            var result = day.PartA(input.Input);
            Assert.AreEqual(AnswerPartA, result);
        }

        [TestMethod]
        public void PartBExample()
        {
            var result = day.PartB(input.ExampleInput);
            Assert.AreEqual(AnswerExamplePartB, result);
        }

        [TestMethod]
        public void PartB()
        {
            var result = day.PartB(input.Input);
            Assert.AreEqual(AnswerPartB, result);
        }

        [TestMethod]
        public void PacketParser()
        {
            var rootPacket = new Packet();
            rootPacket.Add("[1]");
            Assert.AreEqual(1, rootPacket.Packets.Count);
            Assert.IsTrue(rootPacket.Packets[0].Value == 1);

            rootPacket = new Packet();
            rootPacket.AddFirst("[1]");
            Assert.AreEqual(0, rootPacket.Packets.Count);
            Assert.IsTrue(rootPacket.Value == 1);

            rootPacket = new Packet();
            rootPacket.AddFirst("[1,1,3,1,1]");
            Assert.AreEqual(5, rootPacket.Packets.Count);
            Assert.IsTrue(rootPacket.Packets[2].Value == 3);

            rootPacket = new Packet();
            rootPacket.AddFirst("[[1],[2,3,4]]");
            Assert.AreEqual(2, rootPacket.Packets.Count);
            Assert.AreEqual(3, rootPacket.Packets[1].Packets.Count);
        }

        [TestMethod]
        public void PacketCompare()
        {
            var packetLeft = new Packet("[1,1,3,1,1]");
            var packetRight = new Packet("[1,1,5,1,1]");
            Assert.AreEqual(true, Day13.Compare(packetLeft, packetRight));


            packetLeft = new Packet("[[1],[2,3,4]]");
            packetRight = new Packet("[[1],4]");
            Assert.AreEqual(true, Day13.Compare(packetLeft, packetRight));

            packetLeft = new Packet("[9]");
            packetRight = new Packet("[[8,7,6]]");
            Assert.AreEqual(false, Day13.Compare(packetLeft, packetRight));

            packetLeft = new Packet("[[4,4],4,4]");
            packetRight = new Packet("[[4,4],4,4,4]");
            Assert.AreEqual(true, Day13.Compare(packetLeft, packetRight));

            packetLeft = new Packet("[7,7,7,7]");
            packetRight = new Packet("[7,7,7]");
            Assert.AreEqual(false, Day13.Compare(packetLeft, packetRight));

            packetLeft = new Packet("[]");
            packetRight = new Packet("[3]");
            Assert.AreEqual(true, Day13.Compare(packetLeft, packetRight));

            packetLeft = new Packet("[[[]]]");
            packetRight = new Packet("[[]]");
            Assert.AreEqual(false, Day13.Compare(packetLeft, packetRight));

            packetLeft = new Packet("[1,[2,[3,[4,[5,6,7]]]],8,9]");
            packetRight = new Packet("[1,[2,[3,[4,[5,6,0]]]],8,9]");
            Assert.AreEqual(false, Day13.Compare(packetLeft, packetRight));

        }
    }
}