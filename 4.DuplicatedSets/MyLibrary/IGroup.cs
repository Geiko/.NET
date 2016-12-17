namespace MyLibrary
{
    using System.Collections.Generic;

    interface IGroup<T>
    {
        IList<T> Group { get; set; }
        int GetHashCode();
        bool Equals(object obj);
    }
}