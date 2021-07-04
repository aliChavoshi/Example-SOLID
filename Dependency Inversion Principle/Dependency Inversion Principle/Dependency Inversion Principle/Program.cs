using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Dependency_Inversion_Principle
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Position
    {
        Administrator,
        Manager,
        Executive
    }

    public class Employee
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
    }

    //Interfaces
    public interface IEmployeeSearchable
    {
        IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
    }

    public interface IEmployeeStatistics
    {
        int CountFemaleManagers();
    }

    //low level
    //Inmpliment INterface
    public class EmployManager : IEmployeeSearchable
    {
        private readonly List<Employee> _employees = new List<Employee>();
        public void AddEmploy(Employee employee)
        {
            _employees.Add(employee);
        }

        //public List<Employee> Employees => _employees;

        public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
        {
            return _employees.Where(x => x.Gender == gender && x.Position == position);
        }
    }

    //high level
    /*public class EmployeeStatistics1
    {
        private readonly EmployManager _employManager;

        public EmployeeStatistics1(EmployManager employManager)
        {
            _employManager = employManager;
        }

        public int CountFemaleManagers()
        {
            return _employManager.Employees.Count(x=>x.Gender==Gender.Female&&x.Position==Position.Manager);
        }

    }*/

    //high level
    public class EmployeeStatistics : IEmployeeStatistics
    {
        private readonly IEmployeeSearchable _employeeSearchable;
        public EmployeeStatistics(IEmployeeSearchable employeeSearchable)
        {
            _employeeSearchable = employeeSearchable;
        }
        public int CountFemaleManagers()
        {
            return _employeeSearchable.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var emoManagare = new EmployManager();
            emoManagare.AddEmploy(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
            emoManagare.AddEmploy(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });

            //Polumorphism
            //upcasting
            //in interfase
            var stats = new EmployeeStatistics(employeeSearchable: emoManagare);
            Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManagers()}");
        }
    }
}
