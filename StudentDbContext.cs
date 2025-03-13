using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace StudentRegistry
{
    class StudentDbContext : DbContext
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentRegistryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public void AddStudent()
        {
            string? fName;
            string? lName;
            string? city;

            Console.WriteLine("---- Add Student ----");
            Console.WriteLine("Insert student's first name:");

            while (true)
            {
                fName = Console.ReadLine();

                bool isValidFName = InputValidator.CheckValidInput(fName, true);

                if (isValidFName)
                {
                    break;
                }
                else
                {
                    InputValidator.PrintErrorInvalidInput();
                }
            }

            Console.WriteLine("Insert student's last name:");

            while (true)
            {
                lName = Console.ReadLine();

                bool isValidLName = InputValidator.CheckValidInput(lName, false);

                if (isValidLName)
                {
                    break;
                }
                else
                {
                    InputValidator.PrintErrorInvalidInput();
                }
            }

            Console.WriteLine("Insert student's city of residence:");

            while (true)
            {
                city = Console.ReadLine();

                bool isValidCity = InputValidator.CheckValidInput(city, false);

                if (isValidCity)
                {
                    break;
                }
                else
                {
                    InputValidator.PrintErrorInvalidInput();
                }
            }

            while (true)
            {
                Console.WriteLine($"Do you wish to add student {fName} {lName}, {city}? (Y/N)");

                string? confirmation = Console.ReadLine();

                if (confirmation != "Y" && confirmation != "N" && confirmation != "y" && confirmation != "n")
                {
                    InputValidator.PrintErrorInvalidInput();
                }
                else
                {
                    if (confirmation == "n" || confirmation == "N")
                    {
                        Console.WriteLine("Discarding student...");
                        break;
                    }

                    if (confirmation == "Y" || confirmation == "y")
                    {
                        Student stud = new(fName, lName, city);
                        Students.Add(stud);
                        SaveChanges();

                        Console.WriteLine("Added student!\n");

                        break;
                    }
                }
            }
        }

        public void UpdateStudent()
        {
            int selectionInt = 0;

            while (true)
            {
                Console.WriteLine("---- Choose Student ID To Update ----");
                ShowStudents();

                string? selection = Console.ReadLine();

                try
                {
                    selectionInt = Convert.ToInt32(selection);

                    if (selectionInt <= 0)
                    {
                        throw new Exception();
                    }

                    break;
                }
                catch
                {
                    InputValidator.PrintErrorInvalidInput();
                }
            }

            var studentToChange = Students.Where(s => s.StudentId == selectionInt).FirstOrDefault<Student>();

            if (studentToChange == null)
            {
                Console.WriteLine("Could not find that student.");
            }
            else
            {
                //test
                string? fName;
                string? lName;
                string? city;

                Console.WriteLine($"---- Update Student: {studentToChange.FirstName} {studentToChange.LastName}----");
                Console.WriteLine("Insert student's first name:");

                while (true)
                {
                    fName = Console.ReadLine();

                    bool isValidFName = InputValidator.CheckValidInput(fName, true);

                    if (isValidFName)
                    {
                        break;
                    }
                    else
                    {
                        InputValidator.PrintErrorInvalidInput();
                    }
                }

                Console.WriteLine("Insert student's last name:");

                while (true)
                {
                    lName = Console.ReadLine();

                    bool isValidLName = InputValidator.CheckValidInput(lName, false);

                    if (isValidLName)
                    {
                        break;
                    }
                    else
                    {
                        InputValidator.PrintErrorInvalidInput();
                    }
                }

                Console.WriteLine("Insert student's city of residence:");

                while (true)
                {
                    city = Console.ReadLine();

                    bool isValidCity = InputValidator.CheckValidInput(city, false);

                    if (isValidCity)
                    {
                        break;
                    }
                    else
                    {
                        InputValidator.PrintErrorInvalidInput();
                    }
                }

                studentToChange.FirstName = fName;
                studentToChange.LastName = lName;
                studentToChange.City = city;

                SaveChanges();

                Console.WriteLine("Student updated!\n");
            }
        }

        public void ShowStudents()
        {
            Console.WriteLine("---- Students ----");

            foreach (var stud in Students)
            {
                Console.WriteLine($"{stud.StudentId}: {stud.FirstName} {stud.LastName}, {stud.City}");
            }

            Console.WriteLine("------------------");
        }
    }
}
