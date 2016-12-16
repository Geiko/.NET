namespace IsDuplicateSets
{
    using System.Collections.Generic;
    using System.Text;

    public class IntegerSet
    {
        public List<int> IntSet { get; set; }



        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (int item in IntSet)
            {
                hashcode = 31*hashcode + item.GetHashCode();
            }
            return hashcode;
        }



        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            IntegerSet o = obj as IntegerSet;
            if (o == null)
            {
                return false;
            }

            if (IntSet.Count != o.IntSet.Count)
            {
                return false;
            }
            
            for (int i = 0; i < IntSet.Count; i++)
            {
                if (IntSet[i] != o.IntSet[i])
                {
                    return false;
                }
            }

            return true;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IntSet.Count; i++)
            {
                if (i != IntSet.Count - 1)
                {
                    sb.Append($"{IntSet[i]}, ");
                }
                else
                {
                    sb.Append($"{IntSet[i]};");
                }
            }
            return sb.ToString();
        }
    }
}
