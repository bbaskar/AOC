namespace AOC.Day3
{
    internal static class Rucksack_Reorganization
    {
        public static void PrintResult()
        {
            List<string> compartment = new();
            List<string> compartment1 = new();
            List<string> compartment2 = new();
            List<int> priority1 = new();
            List<int> priority2 = new();

            foreach (string rucksack in System.IO.File.ReadLines(@"Day3/Input.txt"))
            {
                string item1 = rucksack.Substring(0, (rucksack.Length / 2));
                string item2 = rucksack.Substring((rucksack.Length / 2), (rucksack.Length / 2));
                string common = string.Join("", item1.Intersect(item2));

                int ascii = Convert.ToInt32(common[0]);

                if (ascii > 96 && ascii < 123)
                    priority1.Add(ascii - 96);
                else
                    priority1.Add(ascii - 38);

                compartment.Add(rucksack);
                compartment1.Add(item1);
                compartment2.Add(item2);
            }

            for (int i = 0; i < 300; i += 3)
            {
                string common = string.Join("", compartment[i].Intersect(compartment[i + 1]).Intersect(compartment[i + 2]));
                int ascii = Convert.ToInt32(common[0]);

                if (ascii > 96 && ascii < 123)
                    priority2.Add(ascii - 96);
                else
                    priority2.Add(ascii - 38);
            }

            Console.WriteLine("(Part A) Sum of the priorities of those item types that appears in both compartments of each rucksack: " + priority1.Sum());
            Console.WriteLine("(Part B) Sum of the priorities of those item types that corresponds to the badges of each three-Elf group: " + priority2.Sum());
        }
    }
}