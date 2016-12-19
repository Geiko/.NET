namespace MyLibrary
{
    using System.Collections.Generic;

    public interface IGroupHost<T>
    {
        Dictionary<IGroup<T>, int> Groups { get; set; }
        List<string> InvalidInputs { get; }
        int InputCounter { get; set; }
        string IsDuplicate(string str);
        bool Check(string str);
        IGroup<T> GetGroup(string str);
        int GetDuplicates();
        int GetNonDuplicates();
        KeyValuePair<IGroup<T>, int> GetFrequentGroup();
    }
}
