namespace MyLibrary
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerGroupHost : GroupHost<int>
    {
        public override Group<int> GetGroup(string str)
        {
            Group<int> group = new IntegerGroup { CustomGroup = parse(str) };
            return group;
        }


        private List<int> parse(string str)
        {
            var group = str.Split(',').Select(int.Parse).ToList();
            group.Sort();
            return group;
        }
    }
}
