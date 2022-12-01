// See https://adventofcode.com/2022/day/1 for more information

int counter = 0;
List<int> calories = new();

// Read the file and display it line by line.
foreach (string line in System.IO.File.ReadLines(@"Day1/Input.txt"))
{
    string item = line.Trim();

    if (item != string.Empty)
    {
        counter += Int32.Parse(item);
    }
    else
    {
        calories.Add(counter);
        counter = 0;
    }
}

Console.WriteLine("Elf carrying the most Calories (in total): " + calories.Max());