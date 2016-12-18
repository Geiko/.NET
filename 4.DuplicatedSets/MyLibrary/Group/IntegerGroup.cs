namespace MyLibrary
{
    using System.Text;

    public class IntegerGroup : Group<int>
    {
        /// <summary>
        /// This method GetHashCode() must be override in order 
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
        /// This method Equals(object obj) must be override in order 
        /// to use this class IntegerGroup as a Key in a Dictionary.
        /// </summary>
        /// <param name="obj">It is an object to compare with an object of this class.</param>
        /// <returns></returns>
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
    }
}
