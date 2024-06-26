using System.Text.RegularExpressions;

namespace BasicConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("-------------------------\n");
            List<Employee> employees = new List<Employee>();

            // Adding employees
            employees.Add(new Employee("Petar", "Petrovic", 42, "IT"));
            employees.Add(new Employee("Milica", "Stefanovic", 32, "HR"));
            employees.Add(new Employee("Nebojsa", "Markovic", 29, "IT"));

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
                        // Enter first name and its validations
                        string? firstName = null;

                        while (string.IsNullOrWhiteSpace(firstName))
                        {
                            Console.WriteLine("Enter first name: ");
                            firstName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(firstName))
                            {
                                Console.WriteLine("First name cannot be empty. Please try again.");
                            }
                            else
                            {
                                try
                                {
                                    ValidateInputIsString(firstName);
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    firstName = null; // Reset to null to re-prompt
                                }
                            }
                        }

                        // Enter last name and its validations
                        string? lastName = null;

                        while (string.IsNullOrWhiteSpace(lastName))
                        {
                            Console.WriteLine("Enter last name: ");
                            lastName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(lastName))
                            {
                                Console.WriteLine("Last name cannot be empty. Please try again.");
                            }
                            else
                            {
                                try
                                {
                                    ValidateInputIsString(lastName);
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    lastName = null;
                                }
                            }
                        }

                        // Enter age and its validations
                        int age = 0;
                        bool isValidAge = false;

                        while (!isValidAge)
                        {
                            Console.WriteLine("Enter age: ");
                            string ageInput = Console.ReadLine();

                            try
                            {
                                age = int.Parse(ageInput);
                                isValidAge = true;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid format. Please try again with a valid number.");
                            }
                        }

                        // Enter department and its validations
                        string? department = null;

                        while (string.IsNullOrWhiteSpace(department))
                        {
                            Console.WriteLine("Enter employee's department: ");
                            department = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(department))
                            {
                                Console.WriteLine("Employee's department cannot be empty. Please try again.");
                            }
                            else
                            {
                                try
                                {
                                    ValidateInputIsString(department);
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    department = null;
                                }
                            }
                        }

                        employees.Add(new Employee(firstName, lastName, age, department));
                        Console.WriteLine("Employee added successfully!");
                        break;
                    case "3":
                        for (int i = 0; i < employees.Count; i++)
                        {
                            var employee = employees[i];
                            Console.WriteLine($"Index: {i+1}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}");
                        }

                        Console.WriteLine("Enter index of the employee you want to remove: ");
                        int index = int.Parse(Console.ReadLine());

                        if (index >=0 && index <= employees.Count)
                        {
                            employees.RemoveAt(index-1);
                            Console.WriteLine("Employee removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid index. Please try again.");
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

        static void ValidateInputIsString(string input)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
            {
                throw new FormatException("Input can contain only letters and spaces. Please try again.");
            }
        }
    }
}
