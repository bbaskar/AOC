namespace AOC.Day4
{
    internal static class CampCleanup
    {
        public static void PrintResult()
        {
            List<bool> contain = new();
            List<bool> overlap = new();

            foreach (string line in System.IO.File.ReadLines(@"Day4/Input.txt"))
            {
                string[] section = line.Trim().Split(',');

                string[] section1 = section[0].Trim().Split('-');
                int a1 = Int32.Parse(section1[0]);
                int a2 = Int32.Parse(section1[1]);

                string[] section2 = section[1].Trim().Split('-');
                int b1 = Int32.Parse(section2[0]);
                int b2 = Int32.Parse(section2[1]);

                if ((a1 <= b1) && (a2 >= b2)) contain.Add(true);
                else if ((b1 <= a1) && (b2 >= a2)) contain.Add(true);
                else contain.Add(false);

                if (a1 >= b1 && a1 <= b2) overlap.Add(true);
                else if (a2 >= b1 && a2 <= b2) overlap.Add(true);
                else if (b1 >= a1 && b1 <= a2) overlap.Add(true);
                else if (b2 >= a1 && b2 <= a2) overlap.Add(true);
                else overlap.Add(false);
            }

            Console.WriteLine("(Part A) Total assignment pairs does one range fully contain the other: " + contain.Count(x => x));
            Console.WriteLine("(Part B) Total assignment pairs do the ranges overlap: " + overlap.Count(x => x));
        }
    }
}