namespace Employee
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SalaryType SalaryType { get; set; }



        public abstract double CalculateAverageSalary();


        
        public override string ToString()
        {
            return $"{Id,3}  {Name,-10} {(int)SalaryType} {CalculateAverageSalary(),10}";
        }
    }
}