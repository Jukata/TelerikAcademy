using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    //Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay
    //and method MoneyPerHour() that returns money earned by hour by the worker. 

    class Worker : Human
    {
        private const byte DefaultWorkDaysPerWeek = 5;

        public byte WorkDayPerWeek { get; set; }
        public decimal WeekSalary { get; set; }
        public byte WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, decimal weekSalary, byte workHoursPerDay, byte workDayPerWeek = DefaultWorkDaysPerWeek)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
            this.WorkDayPerWeek = workDayPerWeek;
        }

        public decimal MoneyPerHour()
        {
            return (WeekSalary / WorkDayPerWeek) / WorkHoursPerDay;
        }

        public override string ToString()
        {
            StringBuilder buildToString = new StringBuilder();

            buildToString.AppendLine(this.FirstName + " " + this.LastName);
            buildToString.AppendLine("Week salary: " + this.WeekSalary);
            buildToString.AppendLine("Work hours per day: " + this.WorkHoursPerDay);
            buildToString.AppendFormat("Money per hour: {0:0.000}", this.MoneyPerHour());
            buildToString.AppendLine();

            return buildToString.ToString();
        }
    }
}
