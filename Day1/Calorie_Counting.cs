// See https://adventofcode.com/2022/day/1 for more information

int calorie = 0;
List<int> calories = new();

// Read the file and display it line by line.
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

Console.WriteLine("Elf carrying the most Calories (in total): " + calories[^1]);
Console.WriteLine("Total of 3 Elfs carrying the most Calories (in total): " + (calories[^1] + calories[^2] + calories[^3]));