using System;
using System.Collections.Generic;

namespace AdventOfCode2024
{
    public class Day9 : IDay<long>
    {
        public long Part1(string input)
        {
            var inputData = ProcessInput(input);

            var files = new List<(int id, int fileSize)>();
            var spaces = new List<int>();
            bool isSpace = false;
            int nextId = 0;
            foreach (var c in input)
            {
                if (isSpace)
                {
                    spaces.Add(c - '0');
                }
                else
                {
                    files.Add((nextId, c - '0'));
                    nextId++;
                }

                isSpace = !isSpace;
            }

            var result = 0L;
            var blockPointer = 0;
            var filePointer = 0;
            var spacePointer = 0;

            var lastFile = files.Last();
            files.RemoveAt(files.Count - 1);

            while (true)
            {
                // Processing logic goes here
                if (filePointer == spacePointer)
                {
                    if (files.Count == 0)
                    {
                        // do something with lastFile

                        break;
                    }

                    var file = files[0];
                    files.RemoveAt(0);

                    // handle files
                    for (int i = 0; i < file.fileSize; i++)
                    {
                        result += blockPointer * file.id;
                        blockPointer++;
                    }

                    filePointer++;
                }
                else
                {
                    // handle spaces
                    if (spacePointer >= spaces.Count)
                    {
                        break;
                    }

                    var fillableSpace = spaces[spacePointer];

                    while (fillableSpace > 0)
                    {
                        fillableSpace--;
                        lastFile.fileSize--;

                        result += blockPointer * lastFile.id;
                        blockPointer++;

                        if (lastFile.fileSize == 0)
                        {
                            if (files.Count > 0)
                            {
                                lastFile = files.Last();
                                files.RemoveAt(files.Count - 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    spacePointer++;

                }

            }

            for (int i = 0; i < lastFile.fileSize; i++)
            {
                result += blockPointer * lastFile.id;
                blockPointer++;
            }

            return result;
        }

        public long Part2(string input)
        {
            var inputData = ProcessInput(input);

            var files = new List<(int id, int fileSize)>();
            var spaces = new List<int>();
            bool isSpace = false;
            int nextId = 0;
            var disk = new List<(int id, int fileSize, bool space)>();
            foreach (var c in input)
            {
                if (isSpace)
                {
                    disk.Add((-1, c - '0', true));
                }
                else
                {
                    disk.Add((nextId, c - '0', false));
                    nextId++;
                }

                isSpace = !isSpace;
            }

            var highestId = nextId - 1;
            for (int i = highestId; i >= 0; i--)
            {
                // Find the file with this id
                var fileIndex = disk.FindIndex(x => x.id == i && !x.space);
                if (fileIndex == -1)
                    continue;

                // Pop the file
                var (id, fileSize, space) = disk[fileIndex];

                for (int index = 0; index < fileIndex; index++)
                {
                    var freeSpace = disk[index];
                    if (!freeSpace.space)
                        continue;

                    if (freeSpace.fileSize >= fileSize)
                    {
                        // We can move the entire file here
                        disk[index] = (freeSpace.id, freeSpace.fileSize - fileSize, true);
                        disk.Insert(index, (id, fileSize, false));

                        // Remove the original file, which is now 1 index ahead, replacing it with empty space
                        disk[fileIndex + 1] = (-1, fileSize, true);

                        break;
                    }
                }
            }

            var result = 0L;
            var blockPointer = 0;

            foreach (var (id, fileSize, space) in disk)
            {
                if (space)
                {
                    blockPointer += fileSize;
                    continue;
                }

                for (int i = 0; i < fileSize; i++)
                {
                    result += id * blockPointer;
                    blockPointer++;
                }
            }

            return result;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }
}
