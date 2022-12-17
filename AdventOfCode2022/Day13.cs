using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day13 : IDay<int>
    {
        public int Part1(string input)
        {
            var inputData = ProcessInput(input);
            var total = 0;
            var pairId = 0;
            for (int i = 0; i < inputData.Count; i += 2)
            {
                pairId++;
                var res = (new Packet(inputData[i])).CompareTo(new Packet(inputData[i + 1]));
                if (res == -1)
                {
                    total += pairId;
                }
            }

            return total;
        }

        public int Part2(string input)
        {
            var inputData = ProcessInput(input);
            
            var packets = inputData.Select(input => new Packet(input)).ToList();
            var packet2 = new Packet("[[2]]");
            var packet6 = new Packet("[[6]]");

            packets.Add(packet2);
            packets.Add(packet6);

            packets.Sort();
            var res2 = 0;
            var res6 = 0;
            for(int i = 0; i< packets.Count; i++)
            {
                if (packets[i] == packet2)
                {
                    res2 = i+1;
                }

                if (packets[i] == packet6)
                {
                    res6 = i+1;
                }
            }

            var result = res2 * res6;
            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            return lines;
        }


    }

    public class Packet : IComparable<Packet>
    {
        public Packet()
        {
        }

        public Packet(string input)
        {
            AddFirst(input);
        }

        public List<Packet> Packets { get; } = new List<Packet>();
        public int? Value { get; set; }

        public void AddFirst(string input)
        {
            Add(input.Substring(1, input.Length - 2));
        }

        public string Add(string input)
        {
            while (input.Length > 0)
            {
                if (input[0] == '[')
                {
                    var p = new Packet();
                    Packets.Add(p);
                    input = p.Add(input.Substring(1));
                }
                else if (input[0] == ']')
                {
                    return input.Substring(1);
                }
                else if (input[0] == ',')
                {
                    input = input.Substring(1);
                }
                else
                {
                    string val = "";
                    if (input.Length > 1 && input[1] >= '0' && input[1] <= '9')
                    {
                        //2 decimals
                        val = input.Substring(0, 2);
                        input = input.Substring(2);
                    }
                    else
                    {
                        val = input.Substring(0, 1);
                        input = input.Substring(1);
                    }

                    if (Packets.Count == 0 && (input.Length == 0 || input[0] == ']'))
                    {
                        // single value between brackets
                        Value = int.Parse(val);
                    }
                    else
                    {
                        // no single value, thus new packet
                        var p = new Packet();
                        p.Value = int.Parse(val);
                        Packets.Add(p);
                    }
                }

            }

            return input;
        }

        public static bool? Compare(Packet packetLeft, Packet packetRight)
        {
            if (packetLeft.Value == null && packetLeft.Packets.Count == 0 &&
                (packetRight.Value != null || packetRight.Packets.Count > 0))
            {
                // left list is empty, right list is not.
                return true;
            }

            if ((packetLeft.Value != null || packetLeft.Packets.Count > 0) &&
                (packetRight.Value == null && packetRight.Packets.Count == 0))
            {
                // left list is not empty, right list is.
                return false;
            }

            /**
             * If both values are integers, the lower integer should come first. 
             * If the left integer is lower than the right integer, the inputs are 
             * in the right order. If the left integer is higher than the right integer, 
             * the inputs are not in the right order. Otherwise, the inputs are the 
             * same integer; continue checking the next part of the input.
             */
            if (packetLeft.Value != null && packetRight.Value != null)
            {
                if (packetLeft.Value < packetRight.Value)
                {
                    return true;
                }
                else if (packetLeft.Value > packetRight.Value)
                {
                    return false;
                }

                return null;
            }

            // Number and packet => packet and packet
            if (packetLeft.Value != null && packetRight.Packets.Count > 0)
            {
                packetLeft.Packets.Add(new Packet() { Value = packetLeft.Value });
                packetLeft.Value = null;
            }
            else if (packetLeft.Packets.Count > 0 && packetRight.Value != null)
            {

                packetRight.Packets.Add(new Packet() { Value = packetRight.Value });
                packetRight.Value = null;
            }

            /**
             * If both values are lists, compare the first value of each list, then 
             * the second value, and so on. If the left list runs out of items first, 
             * the inputs are in the right order. If the right list runs out of items 
             * first, the inputs are not in the right order. If the lists are the same 
             * length and no comparison makes a decision about the order, continue 
             * checking the next part of the input.
             */
            if (packetLeft.Packets.Count > 0 && packetRight.Packets.Count > 0)
            {
                for (int i = 0; i < packetLeft.Packets.Count; i++)
                {
                    if (packetRight.Packets.Count <= i)
                    {
                        // If the right list runs out of items first, the inputs are not in the right order.
                        return false;
                    }

                    var res = Compare(packetLeft.Packets[i], packetRight.Packets[i]);
                    if (res != null)
                    {
                        return res;
                    }
                }

                // Processed left list, if still items left in the right list: its in the correct order.
                if (packetRight.Packets.Count > packetLeft.Packets.Count)
                {
                    return true;
                }

                if (packetRight.Packets.Count == packetLeft.Packets.Count)
                {
                    return null;
                }
            }

            return null;
        }

        public int CompareTo(Packet? other)
        {
            var res = Compare(this, other);
            if (res == null)
            {
                return 0;
            }
            
            if (res == true)
            {
                return -1;
            }

            return 1;

        }
    }


}
