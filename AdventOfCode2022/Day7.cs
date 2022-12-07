using System.Drawing;

namespace AdventOfCode2022.Assignments
{
    /**
     * 
     */
    public class Day7 : IDay<long>
    {
        public long PartA(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
            var root = CreateDirectoryTree(inputData);
            var result = root.GetAllSubdirectories().Where(d => d.Size <= 100000).Sum(d => d.Size);
            return result;
        }

        public long PartB(IList<string> input)
        {
            var inputData = ProcessInput(input.Single());
            var root = CreateDirectoryTree(inputData);
            var freeSpace = (70000000 - root.Size);
            var neededSpace = 30000000 - freeSpace;

            var smallest = root.GetAllSubdirectories().Where(d => d.Size >= neededSpace).Min(d => d.Size);
            return smallest;
        }

        public static DirectoryNode CreateDirectoryTree(IList<string> inputData)
        {
            var root = new DirectoryNode("/", null);
            var currentDir = root;
            foreach (var line in inputData)
            {
                var items = line.Split(' ');
                if (items[0] == "$" && items[1] == "cd")
                {
                    if (items[2] == "..")
                    {
                        currentDir = currentDir?.Parent;
                    }
                    else if (items[2] == "/")
                    {
                        currentDir = root;
                    }
                    else
                    {
                        currentDir = currentDir?.AddSubdir(items[2]);
                    }

                }
                else if (items[0] == "dir" || items[1] == "ls")
                {
                    // Skip
                }
                else if (long.TryParse(items[0], out long size))
                {
                    currentDir.AddFile(items[1], size);
                }
            }

            return root;
        }

        public static IList<string> ProcessInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.None);

            return lines;
        }
    }

    public class DirectoryNode
    {
        public DirectoryNode(string name, DirectoryNode? parent)
        {
            Name = name;
            Parent = parent;            
        }

        public long Size { get
            {
                return Files.Sum(f => f.Size) + SubDirectories.Sum(d => d.Size);
            } 
        }

        public string Name { get; }
        public DirectoryNode? Parent { get; }
        public IList<DirectoryNode> SubDirectories { get; } = new List<DirectoryNode>();
        public IList<FileNodes> Files { get; } = new List<FileNodes>();

        public void AddFile(string name, long size)
        {
            var file = new FileNodes(name, size);
            Files.Add(file);
        }

        public DirectoryNode AddSubdir(string name)
        {
            var subdir = new DirectoryNode(name, this);
            SubDirectories.Add(subdir);
            return subdir;
        }

        public IList<DirectoryNode> GetAllSubdirectories()
        {
            var result = new List<DirectoryNode>();
            
            result.AddRange(SubDirectories.SelectMany(d => d.GetAllSubdirectories()));
            result.AddRange(SubDirectories);
            return result;
        }
    }

    public class FileNodes
    {
        public FileNodes(string name, long size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; }

        public long Size { get; }
    }
}
