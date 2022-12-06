internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Missing command-line arguments.");
                Environment.Exit(0);
            }
            switch (Int32.Parse(args[0]))
            {
                case 1:
                    // Ref: https://adventofcode.com/2022/day/1
                    AOC.Day1.CalorieCounting.PrintResult();
                    break;

                case 2:
                    // Ref: https://adventofcode.com/2022/day/2
                    AOC.Day2.RockPaperScissors.PrintResult();
                    break;

                case 3:
                    // Ref: https://adventofcode.com/2022/day/3
                    AOC.Day3.RucksackReorganization.PrintResult();
                    break;

                case 4:
                    // Ref: https://adventofcode.com/2022/day/4
                    AOC.Day4.CampCleanup.PrintResult();
                    break;

                case 5:
                    // Ref: https://adventofcode.com/2022/day/5
                    AOC.Day5.SupplyStacks.PrintResult();
                    break;

                case 6:
                    // Ref: https://adventofcode.com/2022/day/6
                    AOC.Day6.TuningTrouble.PrintResult();
                    break;

                default:
                    Console.WriteLine("Invalid command-line arguments.");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}