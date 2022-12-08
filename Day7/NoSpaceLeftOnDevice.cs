namespace AOC.Day7
{
    internal static class NoSpaceLeftOnDevice
    {
        public static void PrintResult()
        {
            int fileSize = 0;

            List<string> sourceFilename = new();
            List<int> sourceFilesize = new();

            List<string> targetFilename = new();
            List<int> targetFilesize = new();

            foreach (string line in System.IO.File.ReadLines(@"Day7/Input.txt"))
            {
                switch (line)
                {
                    case "$ cd ..":
                        for (int i = 0; i < sourceFilesize.Count; i++)
                            sourceFilesize[i] = sourceFilesize[i] + fileSize;
                        targetFilename.Add(sourceFilename[^1]);
                        targetFilesize.Add(sourceFilesize[^1]);
                        sourceFilename.Remove(sourceFilename[^1]);
                        sourceFilesize.Remove(sourceFilesize[^1]);
                        fileSize = 0;
                        break;

                    default:
                        if (line.StartsWith("$ cd"))
                        {
                            for (int i = 0; i < sourceFilesize.Count; i++)
                                sourceFilesize[i] = sourceFilesize[i] + fileSize;
                            string folderName = line.Trim().Split(' ')[2];
                            sourceFilename.Add(folderName);
                            sourceFilesize.Add(0);
                            fileSize = 0;
                        }
                        else if ((!line.StartsWith("$")) && (!line.StartsWith("dir")))
                        {
                            fileSize += Int32.Parse(line.Trim().Split(' ')[0]);
                        }
                        break;
                }
            }

            if (fileSize > 0)
            {
                for (int i = 0; i < sourceFilesize.Count; i++)
                    sourceFilesize[i] = sourceFilesize[i] + fileSize;
                for (int i = 0; i < sourceFilename.Count; i++)
                    targetFilename.Add(sourceFilename[i]);
                for (int i = 0; i < sourceFilesize.Count; i++)
                    targetFilesize.Add(sourceFilesize[i]);
                sourceFilename.Clear();
                sourceFilesize.Clear();
            }

            int sum = 0;
            for (int i = 0; i < targetFilesize.Count; i++)
                if (targetFilesize[i] <= 100000)
                    sum += targetFilesize[i];

            Console.WriteLine("(Part A) Sum of the total sizes of those directories with a total size of at most 100000: " + sum);

            targetFilesize.Sort();
            int usedSpace = targetFilesize[^1];
            int unusedSpace = 70000000 - usedSpace;
            int requiredSpace = 30000000 - unusedSpace;
            int updateSpace = 0;
            for (int i = 0; i < targetFilesize.Count; i++)
            {
                if (targetFilesize[i] >= requiredSpace)
                {
                    updateSpace = targetFilesize[i];
                    break;
                }
            }

            Console.WriteLine("(Part B) Total size of that directory that would free up enough space on the filesystem to run the update: " + updateSpace);
        }
    }
}