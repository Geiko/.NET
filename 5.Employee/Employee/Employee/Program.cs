namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            var hrd = new HrDepartment();

            hrd.ReadFromFile(HrDepartment.INPUT);
            hrd.WriteInvalidInputsToFile(HrDepartment.OUTPUT, hrd.InvalidInput, false);

            hrd.WriteEmployeesToFile(HrDepartment.OUTPUT, hrd.Employees, true);

            hrd.SortByAverageSalary();
            hrd.WriteEmployeesToFile(HrDepartment.OUTPUT, hrd.Employees, true);

            hrd.WriteEmployeesToFile(HrDepartment.OUTPUT, hrd.GetFirst5Employees(), true);

            hrd.WriteIdToFile(HrDepartment.OUTPUT, hrd.GetLast3Id(), true);
        }
    }
}
