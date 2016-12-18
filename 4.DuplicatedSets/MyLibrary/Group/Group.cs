namespace MyLibrary
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class Group<T> : IGroup<T>
    {
        public IList<T> CustomGroup { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < CustomGroup.Count; i++)
            {
                if (i != CustomGroup.Count - 1)
                {
                    sb.Append($"{CustomGroup[i]}, ");
                }
                else
                {
                    sb.Append($"{CustomGroup[i]};");
                }
            }

            return sb.ToString();
        }
    }
}
