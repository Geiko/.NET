namespace MyLibrary
{
    using System.Collections.Generic;

    public interface IGroupHost<T>
    {
        Dictionary<IGroup<T>, int> Groups { get; }
        List<string> InvalidInputs { get; }

        string IsDuplicate(string str);
        void ShowDuplicatesNumber();
        void ShowFrequentGroup();
        void ShowInvalidInputs();
    }
}
