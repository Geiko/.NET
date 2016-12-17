namespace MyLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CheckSets
    {
        private static int lineCounter = 0;
        private static Dictionary<IntegerSet, int> Log = new Dictionary<IntegerSet, int>();
        private static int Matches = 0;
        private static int Mismatches = 0;
        private static List<string> InvalidInputs = new List<string>();


        public static string Duplicates(string str)
        {
            lineCounter++;
            string result;

            try
            {
                result = $"{lineCounter, 5}) {check(str)}";
            }
            catch (ArgumentNullException)
            {
                result = $"{lineCounter, 3}) Input is null ({str})";
                InvalidInputs.Add(result);
            }
            catch (FormatException)
            {
                result = $"{lineCounter, 3}) Input format is invalid ({str})";
                InvalidInputs.Add(result);
            }
            catch (OverflowException)
            {
                result = $"{lineCounter, 3}) Input is overflowed ({str})";
                InvalidInputs.Add(result);
            }

            return result;
        }



        private static bool check(string str)
        {
            IntegerSet s = new IntegerSet { IntSet = parse(str) };
            if (Log.ContainsKey(s))
            {
                Log[s]++;
                Matches++;
                return true;
            }

            Log.Add(s, 0);
            Mismatches++;
            return false;
        }



        private static List<int> parse(string str)
        {
            var set = str.Split(',').Select(int.Parse).ToList();
            set.Sort();
            return set;
        }



        public static void ShowDuplicatesNumber()
        {
            Console.WriteLine();
            Console.WriteLine($"Number of matches: {Matches}");
            Console.WriteLine($"Number of mismatches: {Mismatches}");
        }



        public static void ShowDuplicatedGroupsSortedDescending()
        {
            Console.WriteLine();
            Console.WriteLine("Matches - Group");
            var ordered = Log.OrderByDescending(x => x.Value);
            foreach (var set in ordered)
            {
                Console.WriteLine($"{set.Value, 7} - {set.Key}");
            }
            
            var frequent = Log.FirstOrDefault(s => s.Value == Log.Max(f => f.Value));
            Console.WriteLine($"The most frequent groop({frequent.Value} duplicates): {frequent.Key}");
        }



        public static void ShowInvalidInputs()
        {
            Console.WriteLine();
            Console.WriteLine("List of invalid inputs:");
            int i = 0;
            foreach (string item in InvalidInputs)
            {
                i++;
                Console.WriteLine($"{i, 3} - {item}");
            }
        }
    }
}
