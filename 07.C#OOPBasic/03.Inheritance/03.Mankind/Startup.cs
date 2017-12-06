namespace _03.Mankind
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var inputStudent = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);
                var inputWorker = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);

                var student = new Student(inputStudent[0], inputStudent[1], inputStudent[2]);
                
                var worker = new Worker(inputWorker[0], inputWorker[1], decimal.Parse(inputWorker[2]), decimal.Parse(inputWorker[3]));

                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(worker.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
