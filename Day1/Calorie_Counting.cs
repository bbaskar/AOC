namespace AOC.Day1
{
    internal static class Calorie_Counting
    {
        public static void PrintResult()
        {
            int calorie = 0;
            List<int> calories = new();

            foreach (string line in System.IO.File.ReadLines(@"Day1/Input.txt"))
            {
                string item = line.Trim();

                if (item != string.Empty)
                {
                    calorie += Int32.Parse(item);
                }
                else
                {
                    calories.Add(calorie);
                    calorie = 0;
                }
            }

            calories.Add(calorie);
            calories.Sort();

            Console.WriteLine("(Part A) Total calories the Elf is carrying (most calories): " + calories[^1]);
            Console.WriteLine("(Part B) Total calories the Elves are carrying (top three Elves): " + (calories[^1] + calories[^2] + calories[^3]));
        }
    }
}