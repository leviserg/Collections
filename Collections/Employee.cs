using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Employee
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Employee(int _Id, string _Company, string _FirstName, string _LastName, int _Age)
        {
            Id = _Id;
            Company = _Company;
            FirstName = _FirstName;
            LastName = _LastName;
            Age = _Age;
        }
    }
}
