namespace AOC.Day6
{
    internal static class TuningTrouble
    {
        private static void LoadMarkers(string datastream, int count, List<string> markers, int length)
        {
            markers.Clear();
            for (int i = 0; i < count; i++)
            {
                if ((i + length) < count)
                {
                    string marker = datastream.Substring(i, length + 1);
                    markers.Add(marker);
                }
            }
        }

        private static int FindDistinctMarker(List<string> markers, int length)
        {
            int startOfPacket = 0;
            foreach (string marker in markers)
            {
                startOfPacket++;
                string processedMarker = new(marker.Distinct().ToArray());
                if (processedMarker.Length > length)
                    break;
            }

            return startOfPacket;
        }

        public static void PrintResult()
        {
            string datastream = File.ReadAllText(@"Day6/Input.txt");
            int length = datastream.Trim().Length;
            List<string> markers = new();

            LoadMarkers(datastream, length, markers, 3);

            int startOfPacket = FindDistinctMarker(markers, 3);

            Console.WriteLine("(Part A) Total characters processed before the first start-of-packet marker is detected: " + (startOfPacket + 3));

            LoadMarkers(datastream, length, markers, 13);

            int startOfMessage = FindDistinctMarker(markers, 13);

            Console.WriteLine("(Part A) Total characters processed before the first start-of-message marker is detected: " + (startOfMessage + 13));
        }
    }
}