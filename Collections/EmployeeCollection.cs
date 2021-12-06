using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public static class EmployeeCollection
    {
        //public static List<Employee> Employees { get; set; }
        private static List<Employee> employees = new List<Employee>();

        internal static List<Employee> Employees { get => employees; set => employees = value; }

        public static void SetEmployees()
        {
            Employees.Add(new Employee(1, "Nike", "Ivan", "Petrov", 25));
            Employees.Add(new Employee(2, "Nike", "Petr", "Ivanov", 26));
            Employees.Add(new Employee(3, "Nike", "Alex", "Alexeev", 27));
            Employees.Add(new Employee(4, "Nike", "John", "Doe", 28));
            Employees.Add(new Employee(5, "Adidas", "Mary", "Poppins", 29));
            Employees.Add(new Employee(6, "Adidas", "Fred", "Kruger", 30));
            Employees.Add(new Employee(7, "Adidas", "Robin", "Shulz", 31));
            Employees.Add(new Employee(8, "Adidas", "Jay", "Aliev", 32));
            Employees.Add(new Employee(9, "Zara", "Nick", "Jackson", 27));
            Employees.Add(new Employee(10, "Zara", "Ilon", "Musk", 25));
            Employees.Add(new Employee(11, "Zara", "John", "Rambo", 26));
            Employees.Add(new Employee(12, "Zara", "Mike", "Tyson", 27));
            Employees.Add(new Employee(13, "Continental", "Julia", "Roberts", 28));
            Employees.Add(new Employee(14, "Continental", "Steven", "Jobbs", 29));
            Employees.Add(new Employee(15, "Continental", "Edgar", "Codd", 30));
            Employees.Add(new Employee(16, "Continental", "Bill", "Gates", 31));
            Employees.Add(new Employee(17, "Continental", "Donald", "Trump", 32));
            Employees.Add(new Employee(18, "Apple", "John", "Smith", 27));
            Employees.Add(new Employee(19, "Apple", "Britney", "Spears", 31));
            Employees.Add(new Employee(20, "Apple", "Sherlock", "Holmes", 32));
            Employees.Add(new Employee(21, "Apple", "John", "Miller", 27));
        }

        public static Dictionary<string, int> AverageAgeForEachCompany()
        {
            Dictionary<string, int> StageList = 
             (from t in Employees
              group t by new
              {
                  t.Company
              } into g
              select new
              {
                  AverageAge = g.Average(p => p.Age),
                  g.Key.Company
              })
              .OrderByDescending(x => x.Company).ToDictionary(x => x.Company, x => (int)x.AverageAge);
            //.OrderBy(x => x.Company).ToList();
            return StageList;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany()
        {
            Dictionary<string, int> StageList =
             (from t in Employees
              group t by new
              {
                  t.Company
              } into g
              select new
              {
                  Count = g.Count(),
                  g.Key.Company
              })
              .OrderBy(x => x.Company).ToDictionary(x => x.Company, x => (int)x.Count);
            //.OrderBy(x => x.Company).ToList();
            return StageList;
        }

        public static Dictionary<string, int> OldestAgeForEachCompany()
        {
            Dictionary<string, int> StageList =
             (from t in Employees
              group t by new
              {
                  t.Company
              } into g
              select new
              {
                  OldestAge = g.Max(x => x.Age),
                  g.Key.Company
              })
              .OrderBy(x => x.Company).ToDictionary(x => x.Company, x => (int)x.OldestAge);
            return StageList;
        }


    }
}
