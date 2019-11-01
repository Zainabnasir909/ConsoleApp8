using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                writeFile.WriteLine(id + Environment.NewLine + name + Environment.NewLine + atten + Environment.NewLine + sem + Environment.NewLine + cgpa + Environment.NewLine + dept + Environment.NewLine + univ + Environment.NewLine);
            }
            Console.WriteLine("\n\tProfile of " + name + " created successfully\n");
        }
        public void fileReading(string filePath) //for reading data from file and making nodes from that data
        {
            string firstLine = "";
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((firstLine == file.ReadLine()) != null)
            {
                studentId = firstLine;
                studentName = file.ReadLine();
                attendance = file.ReadLine();
                semester = Convert.ToInt32(file.ReadLine());
                cgpa = (float)Convert.ToDouble(file.ReadLine());
                department = file.ReadLine();
                university = file.ReadLine();
            }
            file.Close();
            list.Add(new Student() { studentId = this.studentId, studentName = this.studentName, attendance = this.attendance, semester = this.semester, cgpa = this.cgpa, department = this.department, university = this.university });
            //Console.WriteLine(studentId[1]);
        }
    }
}
