using System;
using System.Collections.Generic;
using System.Linq;

public class Students
{
    public string Name { get; set; }
    public List<double> Grades { get; set; }

    public double AverageGrades
    {
        get
        {
            return Grades.Average();
        }
    }

}
class AverageGrades
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var students = new List<Students>();

        for (int name = 0; name < n; name++)
        {
            Students firstStudent = new Students();
            List<string> studentInfo = Console.ReadLine().Split().ToList();
            var studentName = studentInfo[0];
            firstStudent.Name = studentName;

            List<double> oneStudentGrades = new List<double>();
            for (int grade = 1; grade < studentInfo.Count; grade++)
            {
                var studentGrade = double.Parse(studentInfo[grade]);
                oneStudentGrades.Add(studentGrade);
            }

            firstStudent.Grades = oneStudentGrades;
            students.Add(firstStudent);
        }

        List<Students> listOfStudents=students.OrderBy(s => s.Name).ThenByDescending(s => s.AverageGrades).ToList();

        foreach (var stud in listOfStudents)
        {
            if (stud.AverageGrades>=5)
            {
                Console.WriteLine("{0} -> {1:F2}", stud.Name, stud.AverageGrades);
            }
        }
    }
}