namespace MyLibrary
{
    using System.Collections.Generic;

    public interface IGroup<T>
    {
        IList<T> CustomGroup { get; set; }
    }
}