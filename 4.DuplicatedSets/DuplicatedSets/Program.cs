namespace DuplicatedSets
{
    using System;
    using System.IO;
    using MyLibrary;

    class Program
    {
        static void Main(string[] args)
        {
            //      Library is required to provide:

            // 		a)  a way to accept a string representing a new set of values delimited by comma sign “,” (e.g. “1,2,3”) 
            //          and return true / false if the given set is a duplicate of a set seen before,
            GroupHost<int> grouptHost = new IntegerGroupHost();
            string path = @"../../TextFiles/input.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string str = sr.ReadLine();
                        Console.WriteLine($"{grouptHost.IsDuplicate(str)}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file reading has failed: {e.ToString()}");
            }

            //		b)  a way to return an information on number of duplicates and non-duplicates seen so far,
            Console.WriteLine();
            Console.WriteLine($"Number of matches: {grouptHost.GetDuplicates()}");
            Console.WriteLine($"Number of mismatches: {grouptHost.GetNonDuplicates()}");

            //		c)  a way to list members of the most frequent duplicate group seen so far,
            var frequent = grouptHost.GetFrequentGroup();
            Console.WriteLine();
            Console.WriteLine($"The most frequent groop({frequent.Value} duplicates): {frequent.Key}");

            //		d)  a way to return human readable report on list of invalid inputs seen so far. 
            Console.WriteLine();
            Console.WriteLine("List of invalid inputs:");
            int i = 0;
            foreach (string item in grouptHost.InvalidInputs)
            {
                i++;
                Console.WriteLine($"{i,3} - {item}");
            }

            //  Get all groups
            grouptHost.GetGroups();

            Console.ReadKey();
        }
    }
}
