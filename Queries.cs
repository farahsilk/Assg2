using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using UniApp1.Contexts;
using UniApp1.Entities;
using static System.Formats.Asn1.AsnWriter;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public static class Queries
{
    //List all courses
    public static void Listing()
    {
        using (var context = new UniApp1DbContext())
        {
            var courses = context.Courses.ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseId} , {course.CourseName}");
            }
        }
    }

    //Show all assignments for a specific course
    public static void ShowAssignments()
    {
        using (var context = new UniApp1DbContext())
        {
            var courseId = 1;
            var assignments = context.Assignments
                                     .Where(a => a.CourseId == courseId)
                                     .ToList();

            Console.WriteLine($"Assignments for this Course ID {courseId}:");
            foreach (var assignment in assignments)
            {
                Console.WriteLine($"{assignment.AssignmentId} , {assignment.Title}");
            }
        }
    }

    //List all students
    public static void ListAllStudents()
    {
        using (var context = new UniApp1DbContext())
        {
            var allStudents = context.Users.Where(u => u.Role == "Student").ToList();
            foreach (var student in allStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is a student ");
            }
        }


    }

    //Show all comments for a given assignment
    public static void ShowComments()
    {
        using (var context = new UniApp1DbContext())
        {
            var assignmentId = 1;
            var comments = context.Comments.Where(c => c.AssignmentId == assignmentId).ToList();
            var assignment = context.Comments.Where(c => c.AssignmentId == assignmentId).ToList();

            Console.WriteLine($"Comments for Assignment ID {assignmentId}:");
            foreach (var c in comments)
            {
                Console.WriteLine($"the comment is : {c.Content}");
            }
        }
    }


    //List each assignment with its course and the teacher’s full name
    public static void ListAssignments()
    {
        using (var context = new UniApp1DbContext())
        {
            var assignments = context.Assignments.ToList();

            foreach (var assignment in assignments)
            {
                var course = assignment.Course;
                var teacherId = course.TeacherId;
                var teacher = context.Users.Single(u => u.UserId == teacherId);


                Console.WriteLine($"Assignment: {assignment.Title}, Course: {course.CourseName}, Teacher: {teacher.UserName} ");

            }
        }
    }

    //Show all grades for a student
    public static void ShowGrades()
    {
        using (var context = new UniApp1DbContext())
        {
            var studentId = 1;
            var grades = context.Grades.Where(g => g.StudentId == studentId).ToList();
            foreach (var g in grades)
            {
                var assignment = context.Assignments.FirstOrDefault(a => a.AssignmentId == g.AssignmentId);
                Console.WriteLine($"{assignment.Title}: {g.NumGrade}");
            }
        }
    }
    //Query to show average grade per course
    public static void ShowAverageGrade()
    {
        using (var context = new UniApp1DbContext())
        {
            var sum = 0; var count = 0;
            var asg = context.Assignments.Where(a => a.CourseId == 1).ToList();
            foreach (var A in asg)
            {
                var grade = A.Grade;
                sum += grade.NumGrade;
                count++;
            }
            Console.WriteLine($"Average = {sum / count}");
        }
    }

    //Create a method to return letter grades(A, B, C, etc.) based on the student’s performance
    public static void GetLetterGrade()
    {
        using (var context = new UniApp1DbContext())
        {
            var studentId = 1;
            var Grades = context.Grades.Where(g => g.StudentId == studentId).ToList();
            var x = "F";
            foreach (var score in Grades)
            {
                if (score.NumGrade >= 90) x = "A";
                if (score.NumGrade >= 80) x = "B";
                if (score.NumGrade >= 70) x = "C";
                if (score.NumGrade >= 60) x = "D";
                Console.WriteLine($"Assignment ID {score.AssignmentId} , Grade: {score.NumGrade} , Letter: {x}");

            }

        }
    }
    //Create a method to calculate GPA for a student
    public static void CalculateGPA()
    {
        using (var context = new UniApp1DbContext())
        {
            int studentId = 1;
            var grades = context.Grades.Where(g => g.StudentId == studentId).ToList();

            double totalPoints = 0;
            int count = 0;
            foreach (var grade in grades)
            {
                double gpaValue = grade.NumGrade;
                totalPoints += gpaValue;
                count++;
            }
            totalPoints /= 25;
            double gpa = totalPoints / count;
            Console.WriteLine($"Student ID {studentId} GPA: {gpa}");
        }
    }
}


