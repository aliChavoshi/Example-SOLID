using System;
using System.Collections.Generic;

namespace Open_Closed_Principle
{
    public class DeveloperReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int WorkingHours { get; set; }
        //نرخ ساعتی
        public double HourlyRate { get; set; }
    }

    //public class SalaryCalculator
    //{
    //    private readonly IEnumerable<DeveloperReport> _developerReports;

    //    public SalaryCalculator(List<DeveloperReport> developerReports)
    //    {
    //        _developerReports = developerReports;
    //    }

    //    public double CalculateTotalSalaries()
    //    {
    //        double totalSalaries = 0D;

    //        foreach (var devReport in _developerReports)
    //        {
    //            totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
    //        }

    //        return totalSalaries;
    //    }
    //}

    public abstract class BaseSalaryCalculator
    {
        private readonly DeveloperReport _developerReport;

        public BaseSalaryCalculator(DeveloperReport developerReport)
        {
            _developerReport = developerReport;
        }

        public abstract double CalculateSalary();

        public double GetSalaryDeveloer()
        {
            return _developerReport.HourlyRate * _developerReport.WorkingHours;
        }
    }

    public class SeniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public SeniorDevSalaryCalculator(DeveloperReport developerReport) : base(developerReport)
        {

        }

        public override double CalculateSalary()
        {
            return GetSalaryDeveloer() * 1.2;
        }
    }

    public class JuniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public JuniorDevSalaryCalculator(DeveloperReport developerReport) : base(developerReport)
        {

        }
        public override double CalculateSalary()
        {
            return GetSalaryDeveloer();
        }
    }

    public class SalaryCalculate
    {
        private readonly IEnumerable<BaseSalaryCalculator> _developerCalculator;

        public SalaryCalculate(IEnumerable<BaseSalaryCalculator> developerReports)
        {
            _developerCalculator = developerReports;
        }
        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0;
            foreach (var developer in _developerCalculator)
            {
                totalSalaries += developer.CalculateSalary();
            }
            return totalSalaries;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Polymorphism
            //upcasting Senior To Base
            var devCalculations = new List<BaseSalaryCalculator>
            {
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
                new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
            };

            var calculator = new SalaryCalculate(devCalculations);
            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
        }
    }
}
