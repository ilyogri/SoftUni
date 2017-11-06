namespace _03.Mankind
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var studentInfo = Console.ReadLine().Split();
                var workerInfo = Console.ReadLine().Split();

                var studentFirstName = studentInfo[0];
                var studentLastName = studentInfo[1];
                var studentFacultyNumber = studentInfo[2];
                var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

                var workerFirstName = workerInfo[0];
                var workerLastName = workerInfo[1];
                var workerSalary = decimal.Parse(workerInfo[2]);
                var workingHours = decimal.Parse(workerInfo[3]);
                var worker = new Worker(workerFirstName, workerLastName, workerSalary, workingHours);

                PrintData(student, worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        public static void PrintData(Student student, Worker worker)
        {
            Console.WriteLine(student.ToString());
            Console.WriteLine(worker.ToString());
        }
    }
}