namespace Employee
{
    public class MonthEmployee : Employee
    {
        public const SalaryType SALARY_TYPE = SalaryType.Month;

        public double MonthRate { get; set; }



        public override double CalculateAverageSalary()
        {
            return MonthRate;
        }



        public override string ToString()
        {
            return $"{Id,3}  {Name,-10} {(int)SALARY_TYPE} {CalculateAverageSalary(),10}";
        }
    }
}
