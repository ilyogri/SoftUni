namespace _04.Students
{
    using System;
    using System.Collections.Generic;

    public class P04_Students
    {
        public static void Main()
        {
            var studentInput = Console.ReadLine();

            var students = new List<Student>();

            while (studentInput != "End")
            {
                var student = new Student() {Name = studentInput};
                students.Add(student);
                Student.studentsCount++;
                studentInput = Console.ReadLine();
            }

            Console.WriteLine(Student.studentsCount);
        }
    }
}