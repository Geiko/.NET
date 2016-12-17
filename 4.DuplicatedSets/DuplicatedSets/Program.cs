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
            IntegerGroupHost setMaster = new IntegerGroupHost();
            string path = @"../../TextFiles/input.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string str = sr.ReadLine();
                        Console.WriteLine($"{setMaster.IsDuplicate(str)}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file reading has failed: {e.ToString()}");
            }

            //		b)  a way to return an information on number of duplicates and non-duplicates seen so far,
            setMaster.ShowDuplicatesNumber();

            //		c)  a way to list members of the most frequent duplicate group seen so far,
            setMaster.ShowFrequentGroup();

            //		d)  a way to return human readable report on list of invalid inputs seen so far. 
            setMaster.ShowInvalidInputs();

            Console.ReadKey();
        }
    }
}
