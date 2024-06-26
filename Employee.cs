using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleApp
{
    internal class Employee: Person
    {
        public string EmployeeID { get; set; }
        public string Department { get; set; }

        public Employee(string firstName, string lastName, int age, string department): base(firstName, lastName, age)
        {
            EmployeeID = GenerateID();
            Department = department;
        }

        private static string GenerateID()
        {
            return Guid.NewGuid().ToString("N");
        }

    }
}
