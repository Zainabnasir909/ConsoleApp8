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
        int studentId;
        string studentName;
        int semester;
        float cgpa;
        string department;
        string university;

        public Student()
        {
            list = new List<Student>();
            studentId = 0;
            semester = 0;
            studentName = "";
            department = "";
            university = "";
            cgpa = 0;
        }
        public void createStudentProfile(int id, string name, int sem, float c, string dept, string univ)
        {
            studentId = id;    
            studentName = name;
            semester = sem;
            cgpa = c;
            department = dept;
            university = univ;
            list.Add(new Student() { studentId = id, studentName = name, semester = sem, cgpa = c, department = dept, university = univ });
            Console.WriteLine(list[0].studentName);
        }
    }
}
