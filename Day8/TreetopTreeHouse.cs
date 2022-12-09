namespace AOC.Day8
{
    internal static class TreetopTreeHouse
    {
        private static int ScenicScore(int item, int[] items)
        {
            int score = 0;
            for (int i = 0; i < items.Length; i++)
            {
                score++;
                if (item <= items[i])
                    break;
            }
            return score;
        }

        public static void PrintResult()
        {
            string fileContent = File.ReadAllText(@"Day8/Input.txt");
            string[] lines = fileContent.Split("\r\n");

            List<string> vlines = new();
            int count = (lines.Length * 2) + ((lines[0].Length - 1) * 2) - 2;
            int scenicScore = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string vline = string.Empty;
                for (int j = 0; j < lines.Length; j++)
                    vline += lines[j][i].ToString();
                vlines.Add(vline);
            }

            for (int i = 1; i < (lines.Length - 1); i++)
            {
                string line = lines[i];

                for (int x = 1; x < (line.Length - 1); x++)
                {
                    string vline = vlines[x];
                    var item = Int32.Parse(line[x].ToString());
                    var right = line.Substring(0, x).Reverse().Select(c => c - '0').ToArray();
                    var left = line.Substring(x + 1).Select(c => c - '0').ToArray();
                    var top = vline.Substring(0, i).Reverse().Select(c => c - '0').ToArray();
                    var bottom = vline.Substring(i + 1).Select(c => c - '0').ToArray();

                    if ((item > right.Max()) || (item > left.Max()) || (item > top.Max()) || (item > bottom.Max()))
                        count++;

                    int score = ScenicScore(item, right) * ScenicScore(item, left) * ScenicScore(item, top) * ScenicScore(item, bottom);

                    if (scenicScore < score)
                        scenicScore = score;
                }
            }

            Console.WriteLine("(Part A) Total trees that are visible from outside the grid: " + count);
            Console.WriteLine("(Part B) Highest scenic score possible for any tree: " + scenicScore);
        }
    }
}