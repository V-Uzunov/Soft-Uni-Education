namespace _03.Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal hourPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal hourPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HourPerDay = hourPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value<=10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public decimal HourPerDay
        {
            get { return this.hourPerDay; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }
                this.hourPerDay = value;
            }
        }
        
        public override string LastName
        {
            get => base.LastName;
            protected set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
                }

                base.LastName = value;
            }
        }

        public decimal SalaryPerHour()
        {
            return this.WeekSalary / (5 * this.HourPerDay);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
            sb.AppendLine($"Hours per day: {this.HourPerDay:F2}");
            sb.Append($"Salary per hour: {SalaryPerHour():F2}");

            return sb.ToString();
        }
    }
}
