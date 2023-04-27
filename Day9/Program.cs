namespace Day9;
class Program
{

    public static void Compute(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        string? input = reader.ReadLine();

        // I chose to store positions in 4 variables
        int Hx = 0, Hy = 0, Tx = 0, Ty = 0;
        List<string> history = new List<string>();
        history.Add($"{Tx}-{Ty}");

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
                        Hy++;
                        break;
                    case "D":
                        Hy--;
                        break;
                    case "L":
                        Hx--;
                        break;
                    case "R":
                        Hx++;
                        break;
                }
                // Make the tail follow the head if necessary
                if (Math.Abs(Hx - Tx) <= 1 && Math.Abs(Hy - Ty) <= 1)
                {
                    // Close enough
                }
                else
                {
                    // The tail must follow
                    // If not in the same column nor row:
                    if (Hx != Tx && Hy != Ty)
                    {
                        if (Hx > Tx) Tx++;
                        else Tx--;
                        if (Hy > Ty) Ty++;
                        else Ty--;
                    }
                    else
                    {
                        // Need to move in the same col or row
                        if (Hx == Tx)
                        {
                            // Move in col
                            if (Hy > Ty) Ty++;
                            else Ty--;
                        }
                        else
                        {
                            // Move in row
                            if (Hx > Tx) Tx++;
                            else Tx--;
                        }
                    }
                }
                if (!history.Contains($"{Tx}-{Ty}"))
                    history.Add($"{Tx}-{Ty}");
            }

            input = reader.ReadLine();
        }
        reader.Close();

        Console.WriteLine($"--- {filename} ---");
        Console.WriteLine($"Part 1: {history.Count}");

    }
    static void Main(string[] args)
    {
        Compute("./test_input.txt");
        Compute("./input.txt");
    }
}
