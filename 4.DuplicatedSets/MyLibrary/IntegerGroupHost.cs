namespace MyLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerGroupHost : IGroupHost<int>
    {
        public static int GroupCounter { get; set; } = 0;
        public Dictionary<IGroup<int>, int> Groups { get; } = new Dictionary<IGroup<int>, int>();
        public List<string> InvalidInputs { get; } = new List<string>();


        public string IsDuplicate(string str)
        {
            GroupCounter++;
            string result;

            try
            {
                result = $"{GroupCounter,5}) {check(str)}";
            }
            catch (ArgumentNullException)
            {
                result = $"{GroupCounter,3}) Input is null ({str})";
                InvalidInputs.Add(result);
            }
            catch (FormatException)
            {
                result = $"{GroupCounter,3}) Input format is invalid ({str})";
                InvalidInputs.Add(result);
            }
            catch (OverflowException)
            {
                result = $"{GroupCounter,3}) Input is overflowed ({str})";
                InvalidInputs.Add(result);
            }

            return result;
        }



        private bool check(string str)
        {
            IntegerGroup s = new IntegerGroup { Group = parse(str) };
            if (Groups.ContainsKey(s))
            {
                Groups[s]++;
                return true;
            }

            Groups.Add(s, 0);
            return false;
        }



        private List<int> parse(string str)
        {
            var set = str.Split(',').Select(int.Parse).ToList();
            set.Sort();
            return set;
        }



        public void ShowDuplicatesNumber()
        {
            Console.WriteLine();
            Console.WriteLine($"Number of matches: {Groups.Sum(s => s.Value)}");
            Console.WriteLine($"Number of mismatches: {Groups.Count}");
        }



        public void ShowFrequentGroup()
        {
            Console.WriteLine();
            Console.WriteLine("Matches - Group");
            var ordered = Groups.OrderByDescending(x => x.Value);
            foreach (var set in ordered)
            {
                Console.WriteLine($"{set.Value,7} - {set.Key}");
            }

            var frequent = Groups.FirstOrDefault(s => s.Value == Groups.Max(f => f.Value));
            Console.WriteLine($"The most frequent groop({frequent.Value} duplicates): {frequent.Key}");
        }



        public void ShowInvalidInputs()
        {
            Console.WriteLine();
            Console.WriteLine("List of invalid inputs:");
            int i = 0;
            foreach (string item in InvalidInputs)
            {
                i++;
                Console.WriteLine($"{i,3} - {item}");
            }
        }
    }
}
