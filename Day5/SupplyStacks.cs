namespace AOC.Day5
{
    internal static class SupplyStacks
    {
        private static void ApplySubstring(ref string s1, ref string s2, ref string s3, ref string s4, ref string s5, ref string s6, ref string s7, ref string s8, ref string s9, int to, string crates)
        {
            if (to == 1) s1 += crates;
            else if (to == 2) s2 += crates;
            else if (to == 3) s3 += crates;
            else if (to == 4) s4 += crates;
            else if (to == 5) s5 += crates;
            else if (to == 6) s6 += crates;
            else if (to == 7) s7 += crates;
            else if (to == 8) s8 += crates;
            else if (to == 9) s9 += crates;
        }

        private static void RemoveSubstring(ref string s1, ref string s2, ref string s3, ref string s4, ref string s5, ref string s6, ref string s7, ref string s8, ref string s9, int move, int from)
        {
            if (from == 1) s1 = s1[..^move];
            else if (from == 2) s2 = s2[..^move];
            else if (from == 3) s3 = s3[..^move];
            else if (from == 4) s4 = s4[..^move];
            else if (from == 5) s5 = s5[..^move];
            else if (from == 6) s6 = s6[..^move];
            else if (from == 7) s7 = s7[..^move];
            else if (from == 8) s8 = s8[..^move];
            else if (from == 9) s9 = s9[..^move];
        }

        private static string GetSubstring(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, int move, int from, string crates)
        {
            if (from == 1) crates = s1[^move..];
            else if (from == 2) crates = s2[^move..];
            else if (from == 3) crates = s3[^move..];
            else if (from == 4) crates = s4[^move..];
            else if (from == 5) crates = s5[^move..];
            else if (from == 6) crates = s6[^move..];
            else if (from == 7) crates = s7[^move..];
            else if (from == 8) crates = s8[^move..];
            else if (from == 9) crates = s9[^move..];
            return crates;
        }

        private static string ReverseString(string crates)
        {
            char[] array = crates.ToCharArray();
            Array.Reverse(array);
            crates = new string(array);
            return crates;
        }

        private static void PrintCrateMover9000Result(ref string s1, ref string s2, ref string s3, ref string s4, ref string s5, ref string s6, ref string s7, ref string s8, ref string s9)
        {
            foreach (string line in System.IO.File.ReadLines(@"Day5/Input.txt"))
            {
                string[] instruction = line.Trim().Split(' ');
                int move = Int32.Parse(instruction[1].Trim());
                int from = Int32.Parse(instruction[3].Trim());
                int to = Int32.Parse(instruction[5].Trim());

                string crates = string.Empty;

                crates = GetSubstring(s1, s2, s3, s4, s5, s6, s7, s8, s9, move, from, crates);

                RemoveSubstring(ref s1, ref s2, ref s3, ref s4, ref s5, ref s6, ref s7, ref s8, ref s9, move, from);

                crates = ReverseString(crates);

                ApplySubstring(ref s1, ref s2, ref s3, ref s4, ref s5, ref s6, ref s7, ref s8, ref s9, to, crates);
            }

            string result = s1[^1..] + s2[^1..] + s3[^1..] + s4[^1..] + s5[^1..] + s6[^1..] + s7[^1..] + s8[^1..] + s9[^1..];

            Console.WriteLine("(Part A) Crates that ended up on top of each stack: " + result);
        }

        private static void PrintCrateMover9001Result(ref string s1, ref string s2, ref string s3, ref string s4, ref string s5, ref string s6, ref string s7, ref string s8, ref string s9)
        {
            string result;
            foreach (string line in System.IO.File.ReadLines(@"Day5/Input.txt"))
            {
                string[] instruction = line.Trim().Split(' ');
                int move = Int32.Parse(instruction[1].Trim());
                int from = Int32.Parse(instruction[3].Trim());
                int to = Int32.Parse(instruction[5].Trim());

                string crates = string.Empty;

                crates = GetSubstring(s1, s2, s3, s4, s5, s6, s7, s8, s9, move, from, crates);

                RemoveSubstring(ref s1, ref s2, ref s3, ref s4, ref s5, ref s6, ref s7, ref s8, ref s9, move, from);

                ApplySubstring(ref s1, ref s2, ref s3, ref s4, ref s5, ref s6, ref s7, ref s8, ref s9, to, crates);
            }

            result = s1[^1..] + s2[^1..] + s3[^1..] + s4[^1..] + s5[^1..] + s6[^1..] + s7[^1..] + s8[^1..] + s9[^1..];

            Console.WriteLine("(Part B) Crates that ended up on top of each stack: " + result);
        }

        public static void PrintResult()
        {
            // Part A
            // The CrateMover 9000 is notable for its ability to pick up and move individual crates one by one.

            string s1 = "FTCLRPGQ";
            string s2 = "NQHWRFSJ";
            string s3 = "FBHWPMQ";
            string s4 = "VSTDF";
            string s5 = "QLDWVFZ";
            string s6 = "ZCLS";
            string s7 = "ZBMVDF";
            string s8 = "TJB";
            string s9 = "QNBGLSPH";

            PrintCrateMover9000Result(ref s1, ref s2, ref s3, ref s4, ref s5, ref s6, ref s7, ref s8, ref s9);

            // Part B
            // The CrateMover 9001 is notable for its ability to pick up and move multiple crates at once.

            s1 = "FTCLRPGQ";
            s2 = "NQHWRFSJ";
            s3 = "FBHWPMQ";
            s4 = "VSTDF";
            s5 = "QLDWVFZ";
            s6 = "ZCLS";
            s7 = "ZBMVDF";
            s8 = "TJB";
            s9 = "QNBGLSPH";

            PrintCrateMover9001Result(ref s1, ref s2, ref s3, ref s4, ref s5, ref s6, ref s7, ref s8, ref s9);
        }
    }
}