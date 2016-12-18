namespace MyLibrary
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerGroupHost : GroupHost<int>
    {
        public override bool check(string str)
        {
            Group<int> s = new IntegerGroup { CustomGroup = parse(str) };
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
    }
}
