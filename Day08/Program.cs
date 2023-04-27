using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void ComputeVisibleTrees(int[,] forest)
        {
            int count = 0;
            int maxScenicScore = 0;

            for (int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    if (j == 0 || i == 0 || i == forest.GetLength(0) - 1 || j == forest.GetLength(1) - 1)
                    {
                        // On the side
                        count++;
                    }
                    else
                    {
                        // We need to check each of the sides
                        // Tree [i,j]
                        int height = forest[i, j];

                        bool borderVisible;
                        bool visibleTree = false;
                        int scenicScore = 1;
                        int tempCount;

                        // top
                        borderVisible = true;
                        tempCount = 0;
                        for (int k = i - 1; k >= 0; k--)
                        {
                            tempCount++;
                            if (forest[k, j] >= height)
                            {
                                borderVisible = false;
                                break;
                            }
                        }
                        scenicScore *= tempCount;
                        if (borderVisible)
                            visibleTree = true;

                        // left
                        borderVisible = true;
                        tempCount = 0;
                        for (int k = j - 1; k >= 0; k--)
                        {
                            tempCount++;
                            if (forest[i, k] >= height)
                            {
                                borderVisible = false;
                                break;
                            }
                        }
                        scenicScore *= tempCount;
                        if (borderVisible)
                            visibleTree = true;

                        // bottom
                        borderVisible = true;
                        tempCount = 0;
                        for (int k = i + 1; k < forest.GetLength(0); k++)
                        {
                            tempCount++;
                            if (forest[k, j] >= height)
                            {
                                borderVisible = false;
                                break;
                            }
                        }
                        scenicScore *= tempCount;
                        if (borderVisible)
                            visibleTree = true;

                        // right
                        borderVisible = true;
                        tempCount = 0;
                        for (int k = j + 1; k < forest.GetLength(0); k++)
                        {
                            tempCount++;
                            if (forest[i, k] >= height)
                            {
                                borderVisible = false;
                                break;
                            }
                        }
                        scenicScore *= tempCount;
                        if (borderVisible)
                            visibleTree = true;

                        if (visibleTree)
                            count++;

                        if (scenicScore > maxScenicScore) maxScenicScore = scenicScore;
                    }
                }
            }

            Console.WriteLine($"Part 1: {count}");
            Console.WriteLine($"Part 2: {maxScenicScore}");
        }

        public static int[,] ReadForest(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            List<string> inputLines = new List<string>();

            string? line = reader.ReadLine();
            while (line != null)
            {
                inputLines.Add(line);
                line = reader.ReadLine();
            }

            reader.Close();

            int[,] grid = new int[inputLines.Count, inputLines[0].Length];
            for (int i = 0; i < inputLines.Count; i++)
            {
                for (int j = 0; j < inputLines[i].Length; j++)
                {
                    grid[i, j] = inputLines[i][j] - '0';
                }
            }

            return grid;
        }
        static void Main(string[] args)
        {
            int[,] test_forest = ReadForest("./test_input.txt");
            int[,] forest = ReadForest("./input.txt");
            ComputeVisibleTrees(test_forest);
            ComputeVisibleTrees(forest);
        }
    }
}