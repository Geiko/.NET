namespace Employee
{
    public class MonthEmployee : Employee
    {
        public double MonthRate { get; set; }



        public override double CalculateAverageSalary()
        {
            return MonthRate;
        }
    }
}
