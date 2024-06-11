namespace BasicConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("-------------------------\n");
            List<Employee> employees = new List<Employee>();

            // Adding employees
            employees.Add(new Employee("Petar", "Petrovic", 42, 1, "IT"));
            employees.Add(new Employee("Milica", "Stefanovic", 32, 2, "HR"));
            employees.Add(new Employee("Nebojsa", "Markovic", 29, 3, "IT"));

            Console.WriteLine("Employees Management System");
            Console.WriteLine("1. View all employees");
            Console.WriteLine("2. Add new employee");
            Console.WriteLine("3. Delete an employee");
            Console.WriteLine("4. Exit");

            bool isLive = true;

            while (isLive)
            {
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Employees: ");
                        foreach (var employee in employees)
                        {
                            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Departmenent: {employee.Department}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter first name: ");
                        string firstName = Console.ReadLine();

                        Console.WriteLine("Enter last name: ");
                        string lastName = Console.ReadLine();

                        Console.WriteLine("Enter age: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter employee ID: ");
                        int employeeID = int.Parse(Console.ReadLine());
                        Employee addedEmployee = employees.FirstOrDefault(e => e.EmployeeID == employeeID);
                        if (addedEmployee != null)
                        {
                            Console.WriteLine("ID has already been taken. Please try another one.");
                            employeeID = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Enter employee's department: ");
                        string department = Console.ReadLine();

                        employees.Add(new Employee(firstName, lastName, age, employeeID, department));
                        Console.WriteLine("Employee added successfully!");
                        break;
                    case "3":
                        Console.WriteLine("Enter ID from employee you want to remove: ");
                        int id = int.Parse(Console.ReadLine());
                        Employee employeeToRemove = employees.FirstOrDefault(e => e.EmployeeID == id);
                        if (employeeToRemove != null)
                        {
                            employees.Remove(employeeToRemove);
                            Console.WriteLine($"Employee with ID: {id} has been successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("There is no employee with such ID. Please try again.");
                        }
                        break;
                    case "4":
                        isLive = false;
                        break;
                    default:
                        Console.WriteLine("No action for this choice. Please try again.");
                        break;
                }
            }
        }
    }
}
