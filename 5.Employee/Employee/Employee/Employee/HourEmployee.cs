namespace Employee
{
    public class HourEmployee : Employee
    {
        public const SalaryType SALARY_TYPE = SalaryType.Hour;
        public const double AVERAGE_WORKING_DAYS_QUANTITY_IN_MONTH = 20.8;
        public const double WORKING_HOURS_QUANTITY_IN_DAY = 8;
        public double HourRate { get; set; }



        public override double CalculateAverageSalary()
        {
            return AVERAGE_WORKING_DAYS_QUANTITY_IN_MONTH * WORKING_HOURS_QUANTITY_IN_DAY * HourRate;
        }



        public override string ToString()
        {
            return $"{Id,3}  {Name,-10} {(int)SALARY_TYPE} {CalculateAverageSalary(),10}";
        }
    }
}