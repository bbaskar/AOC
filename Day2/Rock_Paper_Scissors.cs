namespace AOC.Day2
{
    internal static class Rock_Paper_Scissors
    {
        public static void PrintResult()
        {
            List<int> part1 = new();
            List<int> part2 = new();

            int rock = 1, paper = 2, scissor = 3;

            foreach (string line in System.IO.File.ReadLines(@"Day2/Input.txt"))
            {
                string[] item = line.Trim().Split(' ');
                string player1 = item[0], player2 = item[1];

                // Part 1
                switch (player2)
                {
                    case "X":
                        // X means you need to lose
                        if (player1.Equals("A"))
                        {
                            part1.Add(3 + rock);
                            part2.Add(0 + scissor);
                        }
                        else if (player1.Equals("B"))
                        {
                            part1.Add(0 + rock);
                            part2.Add(0 + rock);
                        }
                        else if (player1.Equals("C"))
                        {
                            part1.Add(6 + rock);
                            part2.Add(0 + paper);
                        }
                        break;

                    case "Y":
                        // Y means you need to end the round in a draw
                        if (player1.Equals("A"))
                        {
                            part1.Add(6 + paper);
                            part2.Add(3 + rock);
                        }
                        else if (player1.Equals("B"))
                        {
                            part1.Add(3 + paper);
                            part2.Add(3 + paper);
                        }
                        else if (player1.Equals("C"))
                        {
                            part1.Add(0 + paper);
                            part2.Add(3 + scissor);
                        }
                        break;

                    case "Z":
                        // Z means you need to win
                        if (player1.Equals("A"))
                        {
                            part1.Add(0 + scissor);
                            part2.Add(6 + paper);
                        }
                        else if (player1.Equals("B"))
                        {
                            part1.Add(6 + scissor);
                            part2.Add(6 + scissor);
                        }
                        else if (player1.Equals("C"))
                        {
                            part1.Add(3 + scissor);
                            part2.Add(6 + rock);
                        }
                        break;
                }
            }

            Console.WriteLine("(Part A) Total score be if everything goes exactly according to your strategy guide: " + part1.Sum());
            Console.WriteLine("(Part B) Total score be if everything goes exactly according to your strategy guide: " + part2.Sum());
        }
    }
}