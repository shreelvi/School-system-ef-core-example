using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Web_mvc.Models;

namespace Web_mvc.Data
{
    public class SchoolContextSeed
    {
        public static async Task SeedAsync(SchoolContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //context.Database.EnsureCreated();

                // Look for any students.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                var students = new Student[]
                {
                    new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                    new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                    new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
                };

                foreach (Student s in students)
                {
                    context.Students.Add(s);
                }

                context.SaveChanges();

                var instructors = new Instructor[]
                {
                    new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                        HireDate = DateTime.Parse("1995-03-11") },
                    new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                        HireDate = DateTime.Parse("2002-07-06") },
                    new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                        HireDate = DateTime.Parse("1998-07-01") },
                    new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                        HireDate = DateTime.Parse("2001-01-15") },
                    new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                        HireDate = DateTime.Parse("2004-02-12") }
                };

                context.Instructors.AddRange(instructors);
                context.SaveChanges();

                var departments = new Department[]
                {
                    new Department { Name = "English",
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").Id },
                    new Department { Name = "Mathematics",
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").Id },
                    new Department { Name = "Engineering",
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Harui").Id },
                    new Department { Name = "Economics",
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Kapoor").Id }
                };

                context.Departments.AddRange(departments);
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course {CourseId = 1050, Title = "Chemistry",      Credits = 3,
                        DepartmentId = departments.Single( s => s.Name == "Engineering").Id
                    },
                    new Course {CourseId = 4022, Title = "Microeconomics", Credits = 3,
                        DepartmentId = departments.Single( s => s.Name == "Economics").Id
                    },
                    new Course {CourseId = 4041, Title = "Macroeconomics", Credits = 3,
                        DepartmentId = departments.Single( s => s.Name == "Economics").Id
                    },
                    new Course {CourseId = 1045, Title = "Calculus",       Credits = 4,
                        DepartmentId = departments.Single( s => s.Name == "Mathematics").Id
                    },
                    new Course {CourseId = 3141, Title = "Trigonometry",   Credits = 4,
                        DepartmentId = departments.Single( s => s.Name == "Mathematics").Id
                    },
                    new Course {CourseId = 2021, Title = "Composition",    Credits = 3,
                        DepartmentId = departments.Single( s => s.Name == "English").Id
                    },
                    new Course {CourseId = 2042, Title = "Literature",     Credits = 4,
                        DepartmentId = departments.Single( s => s.Name == "English").Id
                    },
                };

                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment{StudentId=1,CourseId=1050,Grade=Grade.A},
                    new Enrollment{StudentId=1,CourseId=4022,Grade=Grade.C},
                    new Enrollment{StudentId=1,CourseId=4041,Grade=Grade.B},
                    new Enrollment{StudentId=2,CourseId=1045,Grade=Grade.B},
                    new Enrollment{StudentId=2,CourseId=3141,Grade=Grade.F},
                    new Enrollment{StudentId=2,CourseId=2021,Grade=Grade.F},
                    new Enrollment{StudentId=3,CourseId=1050},
                    new Enrollment{StudentId=4,CourseId=1050},
                    new Enrollment{StudentId=4,CourseId=4022,Grade=Grade.F},
                    new Enrollment{StudentId=5,CourseId=4041,Grade=Grade.C},
                    new Enrollment{StudentId=6,CourseId=1045},
                    new Enrollment{StudentId=7,CourseId=3141,Grade=Grade.A},
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }

                var courseInstructors = new CourseAssignment[]
                {
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Kapoor").Id
                        },
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Chemistry" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Harui").Id
                        },
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Microeconomics" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Zheng").Id
                        },
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Macroeconomics" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Zheng").Id
                        },
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Calculus" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Fakhouri").Id
                        },
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Trigonometry" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Harui").Id
                        },
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Composition" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Abercrombie").Id
                        },
                    new CourseAssignment {
                        CourseId = courses.Single(c => c.Title == "Literature" ).CourseId,
                        InstructorId = instructors.Single(i => i.LastName == "Abercrombie").Id
                        },
                };

            context.CourseAssignments.AddRange(courseInstructors);
            context.SaveChanges();
                    
                await context.SaveChangesAsync();
            }
            
            catch (Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<SchoolContextSeed>();
                 logger.LogError(ex.Message);;
            }
            
        }
    }
}