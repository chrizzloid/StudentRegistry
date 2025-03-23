using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry
{
    public class StudentHandler
    {
        private StudentDbContext studentDbContext = new();
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

                if (InputValidator.CheckValidInput(fName, true))
                {
                    break;
                }
            }

            Console.WriteLine("Insert student's last name:");

            while (true)
            {
                lName = Console.ReadLine();

                if (InputValidator.CheckValidInput(lName, false))
                {
                    break;
                }
            }

            Console.WriteLine("Insert student's city of residence:");

            while (true)
            {
                city = Console.ReadLine();

                if (InputValidator.CheckValidInput(city, false))
                {
                    break;
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
                        studentDbContext.Students.Add(stud);
                        studentDbContext.SaveChanges();

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

            var studentToChange = studentDbContext.Students.Where(s => s.StudentId == selectionInt).FirstOrDefault<Student>();

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

                    if (InputValidator.CheckValidInput(fName, true))
                    {
                        break;
                    }
                }

                Console.WriteLine("Insert student's last name:");

                while (true)
                {
                    lName = Console.ReadLine();

                    if (InputValidator.CheckValidInput(lName, false))
                    {
                        break;
                    }
                }

                Console.WriteLine("Insert student's city of residence:");

                while (true)
                {
                    city = Console.ReadLine();

                    if (InputValidator.CheckValidInput(city, false))
                    {
                        break;
                    }
                }

                studentToChange.FirstName = fName;
                studentToChange.LastName = lName;
                studentToChange.City = city;

                studentDbContext.SaveChanges();

                Console.WriteLine("Student updated!\n");
            }
        }

        public void ShowStudents()
        {
            Console.WriteLine("---- Students ----");

            foreach (var stud in studentDbContext.Students)
            {
                Console.WriteLine($"{stud.StudentId}: {stud.FirstName} {stud.LastName}, {stud.City}");
            }

            Console.WriteLine("------------------");
        }
    }
}
