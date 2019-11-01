using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    class Student
    {
        List<Student> list;
        string studentId;
        string studentName;
        string attendance;
        int semester;
        float cgpa;
        string department;
        string university;

        public Student()
        {
            list = new List<Student>();
            studentId = "";
            semester = 0;
            studentName = "";
            department = "";
            university = "";
            attendance = "";
            cgpa = 0;
        }
        public void createStudentProfile(string id, string name, string atten, int sem, float c, string dept, string univ, string path)
        {
            studentId = id;
            studentName = name;
            attendance = atten;
            semester = sem;
            cgpa = c;
            department = dept;
            university = univ;
            list.Add(new Student() { studentId = id, studentName = name, attendance = atten, semester = sem, cgpa = c, department = dept, university = univ });
            using (System.IO.StreamWriter writeFile = new System.IO.StreamWriter(path, true))
            {
                writeFile.WriteLine(id + Environment.NewLine + name + Environment.NewLine + atten + Environment.NewLine + sem + Environment.NewLine + cgpa + Environment.NewLine + dept + Environment.NewLine + univ);
            }
            Console.WriteLine("\n\tProfile of " + name + " created successfully\n");
        }
        public void fileReading(string filePath) //for reading data from file and making nodes from that data
        {
            string firstLine = "";
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((firstLine = file.ReadLine()) != null)
            {
                studentId = firstLine;
                studentName = file.ReadLine();
                attendance = file.ReadLine();
                semester = Convert.ToInt32(file.ReadLine());
                cgpa = (float)Convert.ToDouble(file.ReadLine());
                department = file.ReadLine();
                university = file.ReadLine();
                list.Add(new Student() { studentId = this.studentId, studentName = this.studentName, attendance = this.attendance, semester = this.semester, cgpa = this.cgpa, department = this.department, university = this.university });
            }
            file.Close();
        }
        public void searchById(string id)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].studentId == id)
                {
                    count++;
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t{5}\t\t{6}\n", list[i].studentId, list[i].studentName, list[i].attendance, list[i].semester, list[i].cgpa, list[i].department, list[i].university);
                }
            }
            if (count == 0)
            {
                Console.WriteLine("\n\tInvalid - Record does not exists\n");
            }
        }
        public void searchByName(string name)
        {
            name.ToLower();
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                string FirstName = list[i].studentName.Substring(0, name.Length);
                if (FirstName == name)
                {
                    count++;
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t{5}\t\t{6}\n", list[i].studentId, list[i].studentName, list[i].attendance, list[i].semester, list[i].cgpa, list[i].department, list[i].university);
                }
            }
            if (count == 0)
            {
                Console.WriteLine("\n\tInvalid - Record Does not exists\n");
            }
        }
        public int checkExistingId(string id)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list[i].studentId)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                return 1;
            }
            else
                return 0;
        }
        public void findTopThree()
        {
            list.Sort((x, y) => (y.cgpa.CompareTo(x.cgpa)));
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}\t\t{1}\t\t\t{2}", list[i].studentId, list[i].studentName, list[i].cgpa);
            }
        }
        public void display()
        {
            Console.WriteLine("\nStudentId\tStudent Name\tAttendance\tSemester\tCGPA\tDepartment\tUniveristy\n");
            for (int i = 0; i < list.Count; i++)
            {
                
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t{5}\t\t{6}\n", list[i].studentId, list[i].studentName, list[i].attendance, list[i].semester, list[i].cgpa, list[i].department, list[i].university);
            }
        }
        public void deleteRecord(string id)
        {
            int count = 0, fileIndex = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].studentId == id)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                list.RemoveAt(count
);
                string[] fileLine = File.ReadAllLines(@"D:\LECTURES\BSE05\Visual Programming\Assignments\Assignment 2\test.txt");
                List<string> deleteList = new List<string>(fileLine);
                File.Delete(@"D:\LECTURES\BSE05\Visual Programming\Assignments\Assignment 2\test.txt");
                for (int i = 0; i < fileLine.Length; i++)
                {
                    if (fileLine[i] == id)
                    {
                        fileIndex = i;
                        break;
                    }
                }
                deleteList.RemoveRange(fileIndex, 7);
                Console.WriteLine("\n\tRecord Deletion Successfull");
                using (StreamWriter writer = File.AppendText(@"D:\LECTURES\BSE05\Visual Programming\Assignments\Assignment 2\test.txt"))
                {
                    foreach (string str in deleteList)
                    {
                        writer.WriteLine(str);
                    }
                }
            }
            else
                Console.WriteLine("\n\tError - Student not found\n");
        }
        public void markAttendance()
        {
            string[] file = File.ReadAllLines(@"D:\LECTURES\BSE05\Visual Programming\Assignments\Assignment 2\test.txt");
            int index = 2;
            for(int i = 0; i<list.Count(); i++)
            {
                Console.Write(" {0}\t\t{1}\t\t\t", list[i].studentId, list[i].studentName);
                attendance = Console.ReadLine();
                if(attendance == "p" || attendance == "P")
                {
                    list[i].attendance = "P";
                    file[index] = "P";
                }
                else if(attendance == "a" || attendance == "A")
                {
                    list[i].attendance = "A";
                    file[index] = "A";
                }
                else
                {
                    Console.Write("Error - Invalid Input\n");
                    break;
                }
                index = index + 7;
            }
            File.WriteAllLines(@"D:\LECTURES\BSE05\Visual Programming\Assignments\Assignment 2\test.txt", file);
        }
        public void viewAttendace()
        {
            for(int i = 0; i< list.Count; i++)
            {
                Console.WriteLine(" {0}\t\t{1}\t\t\t{2}", list[i].studentId, list[i].studentName, list[i].attendance);
            }
        }
    }
}
