namespace Employee.Entities
{
    using System.Collections.Generic;

    internal interface IHrDepartment
    {
        IList<Employee> Employees { get; set; }
        IList<string> InvalidInput { get; set; }
        int InputCounter { get; set; }

        void SortByAverageSalary();
        IList<Employee> GetFirst5Employees();
        IList<int> GetLast3Id();

        void ReadFromFile(string path);
        void WriteEmployeesToFile(string path, IList<Employee> employeesList, bool isAppend);
        void WriteIdToFile(string path, IList<int> idList, bool isAppend);
        void WriteInvalidInputsToFile(string path, IList<string> invalidInputs, bool isAppend);
    }
}

