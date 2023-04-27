using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("./input.txt");
            string? line = reader.ReadLine();

            Dictionary<string, Dictionary<string, int>> fileSystem = new Dictionary<string, Dictionary<string, int>>();
            string currentDictory = "/";

            while (line != null)
            {
                // Do smth
                if (line[0] == '$')
                {
                    // Command
                    if (line.IndexOf("cd") == 2)
                    {
                        // cd
                        string target = line.Split(' ')[2];
                        if (target == "..")
                        {
                            // Back
                            currentDictory = currentDictory.Substring(0, 1 + currentDictory.Substring(0, currentDictory.Length - 1).LastIndexOf('/'));
                        }
                        else
                        {
                            // Deeper
                            if (target != "/")
                                currentDictory += target + "/";
                        }

                        if (!fileSystem.ContainsKey(currentDictory))
                            fileSystem.Add(currentDictory, new Dictionary<string, int>());
                    }
                    // We do nothing for ls command
                }
                else
                {
                    // Listing the content
                    if (line.IndexOf("dir") != 0)
                    {
                        // Listing a file, we care and add it
                        string[] file = line.Split(' ');
                        int size = Convert.ToInt32(file[0]);
                        string filename = file[1];

                        if (!fileSystem[currentDictory].ContainsKey(filename))
                            fileSystem[currentDictory].Add(filename, size);
                    }
                }
                // end
                line = reader.ReadLine();
            }

            reader.Close();

            int part1_total = 0;
            Dictionary<string, int> dirSizes = new Dictionary<string, int>();

            foreach (KeyValuePair<string, Dictionary<string, int>> dir in fileSystem)
            {
                string dirName = dir.Key;
                int dirSize = 0;
                // We add the size of each of the files located in the directory:
                foreach (KeyValuePair<string, int> file in dir.Value)
                {
                    dirSize += file.Value;
                }
                // Now we need to add content of subdirectories:
                foreach (KeyValuePair<string, Dictionary<string, int>> subDir in fileSystem)
                {
                    if (subDir.Key.IndexOf(dirName) == 0 && subDir.Key != dirName)
                    {
                        foreach (KeyValuePair<string, int> subfile in subDir.Value)
                        {
                            dirSize += subfile.Value;
                        }
                    }
                }
                dirSizes.Add(dirName, dirSize);
                if (dirSize < 100000) part1_total += dirSize;
            }

            Console.WriteLine($"Part 1: {part1_total}");

            int totalUsed = dirSizes["/"];
            int diskSpace = 70000000;
            int neededSpace = 30000000;

            int spaceToFree = neededSpace - diskSpace + totalUsed;

            int part2_result = totalUsed;
            foreach (KeyValuePair<string, int> dir in dirSizes)
            {
                if (dir.Value >= spaceToFree && dir.Value < part2_result)
                {
                    part2_result = dir.Value;
                }
            }

            Console.WriteLine($"Part 2: {part2_result}");
        }
    }
}