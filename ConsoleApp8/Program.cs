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
            int id, semester;
            string name = "", dept = "", univ = "";
            double cgpa;
            char attendance;
            Console.WriteLine("\n 1. Create Student Profile\n 2. Search Student\n 3. Delete Student Record\n 4. List top 03 of Class\n 5. Mark student Attendance\n 6. View Attendance\n\n Choice:");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("\tCreate Student Profile\n");

                        Console.Write("Enter Student ID: ");
                        id = Convert.ToInt32(Console.ReadLine());


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
                        Student s = new Student();
                        s.createStudentProfile(id, name, semester, (float)cgpa, dept, univ);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("\tSearch Student\n");
                        Console.WriteLine(" 1. Search by Id\n 2. Search by name\nChoice: ");
                        int searchChoice;

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Delete Student Record\n\n");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("List top 03 of Class\n");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Mark Student Attendance\n");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("View Attendance\n");
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
}
