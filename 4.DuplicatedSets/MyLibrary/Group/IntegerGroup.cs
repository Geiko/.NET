namespace MyLibrary
{
    using System.Collections.Generic;
    using System.Text;

    public class IntegerGroup : IGroup<int>
    {
        public IList<int> CustomGroup { get; set; }

        /// <summary>
        /// This method GetHashCode() must be overrided in order 
        /// to use this class IntegerGroup as a Key in a Dictionary.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (int item in CustomGroup)
            {
                hashcode = 31 * hashcode + item.GetHashCode();
            }

            return hashcode;
        }

        /// <summary>
        /// This method Equals(object obj) must be overrided in order 
        /// to use this class IntegerGroup as a Key in a Dictionary.
        /// </summary>
        /// <param name="obj">It is an object to compare with an object of this class.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            IGroup<int> o = obj as IntegerGroup;
            if (o == null)
            {
                return false;
            }

            if (CustomGroup.Count != o.CustomGroup.Count)
            {
                return false;
            }

            for (int i = 0; i < CustomGroup.Count; i++)
            {
                if (CustomGroup[i] != o.CustomGroup[i])
                {
                    return false;
                }
            }

            return true;
        }



        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < CustomGroup.Count; i++)
            {
                sb.Append(i != CustomGroup.Count - 1 ? $"{CustomGroup[i]}, " : $"{CustomGroup[i]};");
            }

            return sb.ToString();
        }
    }
}

