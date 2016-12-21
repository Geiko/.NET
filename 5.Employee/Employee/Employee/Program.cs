namespace Employee
{
    using Entities;

    class Program
    {
        static void Main(string[] args)
        {
            IHrDepartment hrdepartment = new HrDepartment();

            hrdepartment.ReadFromFile(HrDepartment.INPUT);
            hrdepartment.WriteInvalidInputsToFile(HrDepartment.OUTPUT, hrdepartment.InvalidInput, false);

            hrdepartment.WriteEmployeesToFile(HrDepartment.OUTPUT, hrdepartment.Employees, true);

            hrdepartment.SortByAverageSalary();
            hrdepartment.WriteEmployeesToFile(HrDepartment.OUTPUT, hrdepartment.Employees, true);

            hrdepartment.WriteEmployeesToFile(HrDepartment.OUTPUT, hrdepartment.GetFirst5Employees(), true);

            hrdepartment.WriteIdToFile(HrDepartment.OUTPUT, hrdepartment.GetLast3Id(), true);
        }
    }
}
