namespace MyLibrary
{
    using System.Collections.Generic;
    using System.Text;

    public class IntegerGroup : IGroup<int>
    {
        public IList<int> Group { get; set; }



        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (int item in Group)
            {
                hashcode = 31 * hashcode + item.GetHashCode();
            }

            return hashcode;
        }



        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            IGroup<int> o = obj as IntegerGroup;
            if (o == null)
            {
                return false;
            }

            if (Group.Count != o.Group.Count)
            {
                return false;
            }

            for (int i = 0; i < Group.Count; i++)
            {
                if (Group[i] != o.Group[i])
                {
                    return false;
                }
            }

            return true;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Group.Count; i++)
            {
                if (i != Group.Count - 1)
                {
                    sb.Append($"{Group[i]}, ");
                }
                else
                {
                    sb.Append($"{Group[i]};");
                }
            }

            return sb.ToString();
        }
    }
}
