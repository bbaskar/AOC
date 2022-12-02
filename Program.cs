﻿internal class Program
{
    private static void Main(string[] args)
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
                AOC.Day1.Calorie_Counting.PrintResult();
                break;

            case 2:
                // Ref: https://adventofcode.com/2022/day/2
                AOC.Day2.Rock_Paper_Scissors.PrintResult();
                break;

            default:
                Console.WriteLine("Error parsing command-line arguments.");
                break;
        }
    }
}