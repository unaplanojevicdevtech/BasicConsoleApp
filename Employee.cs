using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleApp
{
    internal class Employee: Person
    {
        public int EmployeeID { get; set; }
        public string Department { get; set; }

        public Employee(string firstName, string lastName, int age, int employeeID, string department): base(firstName, lastName, age)
        {
            EmployeeID = employeeID;
            Department = department;
        }

    }
}
