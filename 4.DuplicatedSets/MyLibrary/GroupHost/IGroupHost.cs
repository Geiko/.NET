namespace MyLibrary
{
    using System.Collections.Generic;

    public interface IGroupHost<T>
    {
        Dictionary<Group<T>, int> Groups { get; set; }
        List<string> InvalidInputs { get; }
        int InputCounter { get; set; }
        string IsDuplicate(string str);

        bool check(string str);
        int GetDuplicates();
        int GetNonDuplicates();
        KeyValuePair<Group<T>, int> GetFrequentGroup();
    }
}
