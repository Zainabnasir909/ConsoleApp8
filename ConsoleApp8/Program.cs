using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int semester, choice;
            string id = "" , name = "", attendance = "P", dept = "", univ = "", filePath = "";
            double cgpa;
            filePath = @"D:\LECTURES\BSE05\Visual Programming\Assignments\Assignment 2\\test.txt";
            Student s = new Student();
            Console.WriteLine("\n 1. Create Student Profile\n 2. Search Student\n 3. Delete Student Record\n 4. List top 03 of Class\n 5. Mark student Attendance\n 6. View Attendance\n\n Choice:");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            s.fileReading(filePath);
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("\tCreate Student Profile\n");
                        Console.Write("Enter Student ID: ");
                        id = Console.ReadLine();
                        int result = s.checkExistingId(id);
                        if(result == 1)
                        {
                            Console.WriteLine("Error - Id " + id + " already exists");
                            break;
                        }
                        Console.Write("Enter Student Name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter Semester: ");
                        semester = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter CGPA: ");
                        cgpa = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Department: ");
                        dept = Console.ReadLine();
                        Console.Write("Enter University: ");
                        univ = Console.ReadLine();
                        s.createStudentProfile(id, name, attendance, semester, (float)cgpa, dept, univ, filePath);
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("\tSearch Student\n");
                        Console.Write(" 1. Search by Id\n 2. Search by name\n 3. List of All Students\n\nChoice: ");
                        int searchChoice;
                        searchChoice = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if(searchChoice == 1)
                        {
                            Console.Write("\tEnter Student Id\n");
                            id = Console.ReadLine();
                            Console.WriteLine("\nStudentId\tStudent Name\tAttendance\tSemester\tCGPA\tDepartment\tUniveristy\n");
                            s.searchById(id);
                            break;
                        }
                        else if(searchChoice == 2)
                        {
                            Console.Write("\tEnter Student Name\n");
                            name = Console.ReadLine();
                            Console.WriteLine("\nStudentId\tStudent Name\tAttendance\tSemester\tCGPA\tDepartment\tUniveristy\n");
                            s.searchByName(name);
                            break;
                        }
                        else if(searchChoice == 3)
                        {
                            Console.WriteLine("\n\tList of All Students\n");
                            s.display();
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("\tDelete Student Record\n\n");
                        Console.Write("\nEnter Student Id: ");
                        id = Console.ReadLine();
                        s.deleteRecord(id);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("\n\tList top 03 of Class\n");
                        Console.WriteLine("StudentId\tStudent Name\t\tCGPA\n");
                        s.findTopThree();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("\n\tMark Student Attendance\n");
                        Console.WriteLine("StudentId\tStudent Name\t\tAttendance\n");
                        s.markAttendance();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("\n\tView Attendance\n");
                        Console.WriteLine("StudentId\tStudent Name\t\tAttendance\n");
                        s.viewAttendace();
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
