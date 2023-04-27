namespace Day10;
class Program
{

    public static void DisplayCRT(char[,] CRT)
    {
        for (int i = 0; i < CRT.GetLength(0); i++)
        {
            for (int j = 0; j < CRT.GetLength(1); j++)
            {
                Console.Write(CRT[i, j]);
            }
            Console.WriteLine();
        }
    }
    public static void ComputeSignalStrengths(string filename)
    {
        char[,] CRT = new char[6, 40];
        for (int i = 0; i < CRT.GetLength(0); i++)
        {
            for (int j = 0; j < CRT.GetLength(1); j++)
            {
                CRT[i, j] = '.';
            }
        }

        int sum = 0;

        int cpuRegister = 1;
        int currentCycle = 1;

        StreamReader reader = new StreamReader(filename);
        string? line = reader.ReadLine();
        while (line != null)
        {
            int addValue = 0;
            int cycles = 0;

            if (line == "noop")
                cycles = 1;
            else
            {
                string[] instruction = line.Split(' ');
                addValue = Convert.ToInt32(instruction[1]);
                cycles = 2;
            }

            for (int i = 0; i < cycles; i++)
            {
                // Here we got value at each cycle
                //Console.WriteLine($"Cycle {currentCycle}: {cpuRegister}");
                if ((currentCycle - 20) % 40 == 0)
                    sum += currentCycle * cpuRegister;
                int X = (currentCycle - 1) / 40;
                int Y = (currentCycle - 1) % 40;
                int spritePosition = cpuRegister;
                //Console.WriteLine($"{X} {Y}");
                if (Y == spritePosition || Y == spritePosition - 1 || Y == spritePosition + 1)
                {
                    CRT[X, Y] = '#';
                }
                currentCycle++;

            }

            cpuRegister += addValue;

            line = reader.ReadLine();
        }

        //Console.WriteLine($"Final register value: {cpuRegister}");
        Console.WriteLine($"Part 1: {sum}");
        Console.WriteLine("Part 2:");
        DisplayCRT(CRT);
    }
    static void Main(string[] args)
    {
        string[] files = new string[] { "./test_input.txt", "./input.txt" };
        foreach (string filename in files)
        {
            Console.WriteLine($"\n--- {filename} ---");
            ComputeSignalStrengths(filename);
            if (filename == "./input.txt") Console.WriteLine("PZGPKPEB !\n");
        }

    }
}
