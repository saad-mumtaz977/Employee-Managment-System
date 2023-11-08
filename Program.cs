using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagmentSystem
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    internal class ASE : Employee
    {
        public string Team { get; set; }
        public int TrainingPeriod { get; set; }
        public string TechStack { get; set; }

        public void SetDetails()
        {
            Console.WriteLine("Please Provide Folloing Details: ");

            Console.Write("Employee Id: ");
            Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Employee Name: ");
            Name = Console.ReadLine();

            Console.Write("Employee Salary: ");
            Salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Employee Team: ");
            Team = Console.ReadLine();

            Console.Write("Training Period (month(s)): ");
            TrainingPeriod = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tech Stack: ");
            TechStack = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"\n\n\nID: {Id}\nName: {Name}\nSalary: {Salary}\nTeam: {Team}\nTraining Period: {TrainingPeriod} month(s)\nTech Stack: {TechStack}\n\n\n";
        }
    }
    internal class Program
    {
        public static List<ASE> ASEs = new List<ASE>();

        public static void Main(string[] args)
        {
            int choice;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Title = "Employee Managment System";
            do
            {
                Console.WriteLine("\n1- View All Employees\n");
                Console.WriteLine("\n2- View Employee by ID\n");
                Console.WriteLine("\n3- Add Employee\n");
                Console.WriteLine("\n4- Remove Employee\n");
                Console.WriteLine("\n5- Exit\n");
                Console.WriteLine("------------------------------------");

                Console.Write("\nEnter Your Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        if (ASEs.Count == 0)
                        {
                            Console.WriteLine("\nEmployee List is Emplty :(\n");
                        }
                        else
                        {
                            foreach (var ase in ASEs)
                            {
                                Console.WriteLine(ase);
                            }
                        }
                        break;
                    case 2:
                        if (ASEs.Count == 0)
                        {
                            Console.WriteLine("\nEmployee List is Empty At the moment\n");
                            break;
                        }
                        Console.Write("\nEnter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ASE ase_temp = ASEs.Find(a => a.Id == id);
                        if (ase_temp != null)
                        {
                            Console.WriteLine(ase_temp);
                        }
                        else
                        {
                            Console.WriteLine("\nNo such Employee with Id: " + id + "\n");
                        }
                        break;
                    case 3:
                        ASE aSE = new ASE();
                        aSE.SetDetails();
                        ASEs.Add(aSE);
                        Console.WriteLine("\nEmployee Added Successfully!\n");
                        break;
                    case 4:
                        if (ASEs.Count == 0)
                        {
                            Console.WriteLine("\nEmployee List is Empty At the moment\n");
                            break;
                        }
                        Console.Write("\nEnter Id of Employee to Remove: ");
                        int id4 = Convert.ToInt32(Console.ReadLine());
                        ASE ase4 = ASEs.Find(a => a.Id == id4);
                        if (ase4 != null)
                        {
                            Console.WriteLine("Are You Sure You Want to Delete Employee with Id: " + id4 + " (Y or N)");
                            char inp = Convert.ToChar(Console.ReadLine());
                            if (inp == 'Y' || inp == 'y')
                            {
                                ASEs.Remove(ase4);
                                Console.WriteLine("Employee Deleted Successfully");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo such Employee with Id: " + id4 + "\n");
                        }
                        break;

                    case 5:
                        Console.WriteLine("\nThnanks for using the App!\n");
                        return;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice\n");
                        break;
                }
            } while (choice != 5);
        }

    }
}