using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        public static int getResult(string input, int length = 4)
        {
            int result = -1;

            if (input.Length >= length)
            {
                for (int i = 0; i < input.Length - length + 1; i++)
                {
                    bool duplicates = false;
                    string temp = "";
                    for (int j = 0; j < length; j++)
                        temp += input[i + j];
                    // We check for duplicates in temp string
                    temp = String.Concat(temp.OrderBy(c => c));
                    for (int j = 0; j < temp.Length - 1; j++)
                    {
                        if (temp[j] == temp[j + 1])
                        {
                            duplicates = true;
                            break;
                        }
                    }
                    // We check the result
                    if (!duplicates)
                    {
                        result = i + length;
                        break;
                    }
                }
            }

            return result;
        }

        public static void Compute(string filename)
        {
            // Reading input
            // I suppose that the string is short enough that I can read it entirely
            StreamReader reader = new StreamReader(filename);
            string? input = reader.ReadLine();
            reader.Close();

            if (input != null)
            {
                int part1_result = getResult(input, 4);
                int part2_result = getResult(input, 14);

                Console.WriteLine($"--- {filename} ---");
                Console.WriteLine($"Part 1: {part1_result}");
                Console.WriteLine($"Part 2: {part2_result}");
            }
        }
        static void Main(string[] args)
        {
            //Compute("./test_input.txt");
            Compute("./input.txt");
        }
    }
}