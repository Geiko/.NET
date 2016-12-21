namespace Employee
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract double CalculateAverageSalary();
    }
}