namespace Day9;
class Program
{

    public static int Compute(string filename, int nbTails = 1)
    {
        StreamReader reader = new StreamReader(filename);
        string? input = reader.ReadLine();

        // I chose to store positions in 4 variables

        int[,] positions = new int[nbTails + 1, 2];

        List<string> history = new List<string>();
        history.Add($"{positions[nbTails, 0]}-{positions[nbTails, 1]}");

        while (input != null)
        {
            string[] instructions = input.Split(' ');
            string direction = instructions[0];
            int steps = Convert.ToInt32(instructions[1]);

            for (int i = 0; i < steps; i++)
            {
                // Move the head in the specified direction
                switch (direction)
                {
                    case "U":
                        positions[0, 1]++;
                        break;
                    case "D":
                        positions[0, 1]--;
                        break;
                    case "L":
                        positions[0, 0]--;
                        break;
                    case "R":
                        positions[0, 0]++;
                        break;
                }
                // Make the tails follow the head if necessary
                for (int j = 1; j < positions.GetLength(0); j++)
                {

                    if (Math.Abs(positions[j - 1, 0] - positions[j, 0]) <= 1 && Math.Abs(positions[j - 1, 1] - positions[j, 1]) <= 1)
                    {
                        // Close enough
                    }
                    else
                    {
                        // The tail must follow
                        // If not in the same column nor row:
                        if (positions[j - 1, 0] != positions[j, 0] && positions[j - 1, 1] != positions[j, 1])
                        {
                            if (positions[j - 1, 0] > positions[j, 0]) positions[j, 0]++;
                            else positions[j, 0]--;
                            if (positions[j - 1, 1] > positions[j, 1]) positions[j, 1]++;
                            else positions[j, 1]--;
                        }
                        else
                        {
                            // Need to move in the same col or row
                            if (positions[j - 1, 0] == positions[j, 0])
                            {
                                // Move in col
                                if (positions[j - 1, 1] > positions[j, 1]) positions[j, 1]++;
                                else positions[j, 1]--;
                            }
                            else
                            {
                                // Move in row
                                if (positions[j - 1, 0] > positions[j, 0]) positions[j, 0]++;
                                else positions[j, 0]--;
                            }
                        }
                    }

                }
                if (!history.Contains($"{positions[nbTails, 0]}-{positions[nbTails, 1]}"))
                    history.Add($"{positions[nbTails, 0]}-{positions[nbTails, 1]}");
            }

            input = reader.ReadLine();
        }
        reader.Close();

        //Console.WriteLine($"--- {filename} ---");
        //Console.WriteLine($"Part 1: {history.Count}");

        return history.Count;

    }
    static void Main(string[] args)
    {

        string[] filenames = new string[] { "./test_input.txt", "./input.txt" };
        foreach (string filename in filenames)
        {
            int p1 = Compute(filename, 1);
            int p2 = Compute(filename, 9);
            Console.WriteLine($"--- {filename} ---");
            Console.WriteLine($"Part 1: {p1}");
            Console.WriteLine($"Part 2: {p2}");
        }


        //Compute("./input.txt");
    }
}
