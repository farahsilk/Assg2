using UniApp1.Contexts;
using UniApp1.Entities;

public static class AddData
{
    public static void InsertUsers(UniApp1DbContext context)
    {
        var students = new List<User>
        {
     new User { UserName = "abdelhakeh", FirstName = "Abdelhake", LastName = "Hamdaoui", EmailAddress = "abdelhakehamdaoui@test.com", PhoneNumber = "5378527466", Role = "Student" },
    new User { UserName = "houzifah", FirstName = "Houzifa", LastName = "Habbo", EmailAddress = "houzifahabbo@test.com", PhoneNumber = "5300560001", Role = "Student" },
    new User { UserName = "ayak", FirstName = "Aya", LastName = "Khalifa", EmailAddress = "ayakhalifa@test.com", PhoneNumber = "5300000001", Role = "Student" },
    new User { UserName = "farahs", FirstName = "Farah", LastName = "Silk", EmailAddress = "farahsilk@test.com", PhoneNumber = "5300000002", Role = "Student" },
    new User { UserName = "masas", FirstName = "Masa", LastName = "Soudan", EmailAddress = "masasoudan@test.com", PhoneNumber = "5300000007", Role = "Student" },
    new User { UserName = "mohammadr", FirstName = "Mohammad", LastName = "Ramez", EmailAddress = "mohammadramez@test.com", PhoneNumber = "5300000008", Role = "Student" },
    new User { UserName = "mosam", FirstName = "Mosa", LastName = "Mosa", EmailAddress = "mosamosa@test.com", PhoneNumber = "5300000009", Role = "Student" },
    new User { UserName = "nouhade", FirstName = "Nouhad", LastName = "El Hallab", EmailAddress = "nouhadelhallab@test.com", PhoneNumber = "5300000010", Role = "Student" },
    new User { UserName = "shamj", FirstName = "Sham", LastName = "Jamous", EmailAddress = "shamjamous@test.com", PhoneNumber = "5300000012", Role = "Student" },
    new User { UserName = "yasiny", FirstName = "Yasin", LastName = "Yildiz", EmailAddress = "yasinyildiz@test.com", PhoneNumber = "5300000013", Role = "Student" },
    new User { UserName = "zaida", FirstName = "Zaid", LastName = "Almoughrabl", EmailAddress = "zaidalmoughrabl@test.com", PhoneNumber = "5300000014", Role = "Student" },
    new User { UserName = "zomorodb", FirstName = "Zomorodah", LastName = "Bakhit", EmailAddress = "zomorodahbakhit@test.com", PhoneNumber = "5300000015", Role = "Student" }


        };

        var teachers = new List<User>
        {
    new User { UserName = "feryal", FirstName = "Feryal", LastName = "Tulaimat", EmailAddress = "feryaltulaimat@test.com", PhoneNumber = "5300000003", Role = "Teacher" },
    new User { UserName = "sami", FirstName = "Sami", LastName = "Hijazi", EmailAddress = "samihijazi@test.com", PhoneNumber = "5300000011", Role = "Teacher" }

        };

        context.Users.AddRange(students);
        context.Users.AddRange(teachers);
        context.SaveChanges();



        //insert 5 courses

        var courses = new List<Course>();
        string[] courseNames = { "SQL", "C#", "Entity Framework", "Web API", "React" };

        foreach (var teacher in teachers)
        {
            foreach (var courseName in courseNames)
            {
                var course = new Course
                {
                    CourseName = courseName,
                    TeacherId = teacher.UserId,
                    StartDate = DateTime.Now.AddMonths(0),
                    EndDate = DateTime.Now.AddMonths(4),
                };
                courses.Add(course);
            }
        }

        context.Courses.AddRange(courses);
        context.SaveChanges();



        //Insert Assignments

        // var courses = context.Courses.ToList();
        var random = new Random();

        foreach (var course in courses)
        {
            for (int i = 1; i <= 5; i++)
            {
                var assignment = new Assignment
                {
                    CourseId = course.CourseId,
                    Title = $"{course.CourseName} Assignment {i}",
                    Description = $"Description for {course.CourseName} Assignment {i}",
                    Weight = 0.2,
                    MaxGrade = 100,
                    DueDate = DateTime.Now.AddDays(random.Next(-10, 10))
                };

                context.Assignments.Add(assignment);
            }
        }

        context.SaveChanges();




        //Insert Syllabus

        foreach (var course in courses)
        {
            var syllabus = new Syllabus
            {
                Description = $"this is {course.CourseName}'s syllabus"
            };

            context.Syllabus.Add(syllabus);
            course.Syllabus = syllabus; 
        }

        context.SaveChanges();



        //insert Comments

        var random2 = new Random();
        var assignments = context.Assignments.ToList();

        for (int i = 0; i < 10; i++)
        {
            var assignment = assignments[random.Next(assignments.Count)];
            var student = students[random2.Next(students.Count)];

            var comment = new Comment
            {
                AssignmentId = assignment.AssignmentId,
                CreatedByUserId = student.UserId,
                CreatedDate = DateTime.Now.AddMinutes(random2.Next(-1,10)),
                Content = "This is my comment!"
            };

            context.Comments.Add(comment);
        }

        context.SaveChanges();


        //insert Grade

      
        foreach (var assignment in assignments)
        {
            foreach (var student in students)
            {
                var grade = new Grade
                {
                    AssignmentId = assignment.AssignmentId,
                    StudentId = student.UserId,
                    NumGrade = random.Next(60, 100)
                };

                context.Grades.Add(grade);
            }
        }

        context.SaveChanges();

    }

    }


