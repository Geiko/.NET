﻿namespace MyLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class GroupHost<T> : IGroupHost<T>
    {
        public Dictionary<Group<T>, int> Groups { get; set; } = new Dictionary<Group<T>, int>();
        public List<string> InvalidInputs { get; } = new List<string>();
        public int InputCounter { get; set; } = 0;


        public string IsDuplicate(string str)
        {
            InputCounter++;
            string result;

            try
            {
                result = $"{InputCounter,5}) {Check(str)}";
            }
            catch (ArgumentNullException)
            {
                result = $"{InputCounter,3}) Input is null ({str})";
                InvalidInputs.Add(result);
            }
            catch (FormatException)
            {
                result = $"{InputCounter,3}) Input format is invalid ({str})";
                InvalidInputs.Add(result);
            }
            catch (OverflowException)
            {
                result = $"{InputCounter,3}) Input is overflowed ({str})";
                InvalidInputs.Add(result);
            }

            return result;
        }



        public bool Check(string str)
        {
            Group<T> group = GetGroup(str);
            if (Groups.ContainsKey(group))
            {
                Groups[group]++;
                return true;
            }

            Groups.Add(group, 0);
            return false;
        }



        public abstract Group<T> GetGroup(string str);



        public int GetDuplicates()
        {
            return Groups.Sum(s => s.Value);
        }



        public int GetNonDuplicates()
        {
            return Groups.Count;
        }



        public KeyValuePair<Group<T>, int> GetFrequentGroup()
        {
            var frequent = Groups.FirstOrDefault(s => s.Value == Groups.Max(f => f.Value));
            return frequent;
        }



        public void GetGroups()
        {
            Console.WriteLine();
            Console.WriteLine("Matches - Group");
            var ordered = Groups.OrderByDescending(x => x.Value).ToList();

            foreach (var set in ordered)
            {
                Console.WriteLine($"{set.Value,7} - {set.Key}");
            }
        }
    }
}
