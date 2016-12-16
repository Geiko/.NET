namespace MyLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IsDuplicateSets;

    public class CheckSets
    {
        private static int _lineCounter = 0;
        private static Dictionary<IntegerSet, int> Log = new Dictionary<IntegerSet, int>();
        private static int Matches = 0;
        private static int Mismatches = 0;
        private static List<string> InvalidInputs = new List<string>();


        public static string Duplicates(string str)
        {
            _lineCounter++;
            string result;
            
            try
            {
                result = $"{_lineCounter}) {check(str)}";
            }
            catch (ArgumentNullException)
            {
                result = $"{_lineCounter}) Input is null ({str})";
                InvalidInputs.Add(result);
            }
            catch (FormatException)
            {
                result = $"{_lineCounter}) Input format is invalid ({str})";
                InvalidInputs.Add(result);
            }
            catch (OverflowException)
            {
                result = $"{_lineCounter}) Input is overflowed ({str})";
                InvalidInputs.Add(result);
            }

            return result;
        }



        private static bool check(string str)
        {
            IntegerSet s = new IntegerSet {IntSet = parse(str)};
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
            string[] strArray = str.Split(',');
            List<int> set = new List<int>();
            for (int i = 0; i < strArray.Length; i++)
            {
                set.Add(int.Parse(strArray[i].Trim()));
            }

            set.Sort();
            return set;
        }



        public static void ShowDuplicatsNumber()
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
                Console.WriteLine($"     {set.Value} - {set.Key}");
            }
        }



        public static void ShowInvalidInputs()
        {
            Console.WriteLine();
            Console.WriteLine("List of invalid inputs:");
            int i = 0;
            foreach (string item in InvalidInputs)
            {
                i++;
                Console.WriteLine($"{i} - {item}");
            }
        }
    }
}
