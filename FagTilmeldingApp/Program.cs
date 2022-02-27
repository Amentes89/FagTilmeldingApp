// Iteration 3
global using OOPH1.Codes;
global using OOPH1.Codes.Models;

#region Model and generic list.
string? errorMsg = null;
Student? matchedStudent = null;
Course? matchedCourse = null;

Console.Write("Angiv skole: ");
string? skoleNavn = Console.ReadLine();

Console.Write("Angiv hovedforløb: ");
string? hovedforløbNavn = Console.ReadLine();

Console.Write("Angiv uddannelseslinje: ");
string? uddannelseslinje = Console.ReadLine();

Semester semester = new(hovedforløbNavn, skoleNavn);
semester.SetUddannelseslinje(uddannelseslinje);

// ---------------------------------------------------------------------------------
// Opret List af model klasserne
List<Teacher> teachers = new()
{
    new Teacher() { Id = 1, FirstName = "Niels", LastName = "Olesen" },
    new Teacher() { Id = 2, FirstName = "Henrik", LastName = "Poulsen" }
};

List<Student> students = new()
{
    new Student() { Id = 1, FirstName = "Martin", LastName = "Jensen" },
    new Student() { Id = 2, FirstName = "Patrik", LastName = "Nielsen" },
    new Student() { Id = 1, FirstName = "Susanne", LastName = "Hansen" },
    new Student() { Id = 2, FirstName = "Thomas", LastName = "Olsen" }
};

List<Course> courses = new()
{
    new Course() { Id = 1, CourseName = "Grundlæggende programmering", TeacherId = 1 },
    new Course() { Id = 2, CourseName = "Database programmering", TeacherId = 1 },
    new Course() { Id = 6, CourseName = "StudieTeknik", TeacherId = 1 },
    new Course() { Id = 7, CourseName = "Clientside programmering", TeacherId = 2 },
};

List<Enrollment> enrollments = new();
while (true)
{
    Console.Clear();

    // ---------------------------------------------------------------------------------
    // Vis titel.
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{semester.SchoolName}, {semester.Uddannelseslinje}, {semester.SemesterNavn} fag tilmeldning app.");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------------------");
    Console.WriteLine();

    // ---------------------------------------------------------------------------------
    // Vis list af tilmeldt elev per fag.
    int antalTilmeld = (enrollments.Where(a => a.CourseId == 1).ToList()).Count();
    string? fagNavn = (courses.FirstOrDefault(a => a.Id == 1)).CourseName;
    Console.WriteLine($"{antalTilmeld} elever i {fagNavn}");

    antalTilmeld = (enrollments.Where(a => a.CourseId == 2).ToList()).Count();
    fagNavn = (courses.FirstOrDefault(a => a.Id == 2)).CourseName;
    Console.WriteLine($"{antalTilmeld} elever i {fagNavn}");

    antalTilmeld = (enrollments.Where(a => a.CourseId == 6).ToList()).Count();
    fagNavn = (courses.FirstOrDefault(a => a.Id == 6)).CourseName;
    Console.WriteLine($"{antalTilmeld} elever i {fagNavn}");

    Console.WriteLine();

    // ---------------------------------------------------------------------------------
    // Vis fejl beskider.
    if (errorMsg != null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMsg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    // ---------------------------------------------------------------------------------
    // Konfirmation besked til bruger.
    if (enrollments.Count() > 0)
    {
        foreach (Enrollment item in enrollments)
        {
            matchedStudent = students.FirstOrDefault(a => a.Id == item.StudentId);
            matchedCourse = courses.FirstOrDefault(a => a.Id == item.CourseId);
            if (matchedStudent != null && matchedCourse != null)
            {
                Console.WriteLine($"{matchedStudent.FirstName} {matchedStudent.LastName} tilmeld fag {matchedCourse.CourseName}");
            }
        }
        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine();
    }

    // ---------------------------------------------------------------------------------
    // Register elev til et fag med validering
    errorMsg = null;

    Console.Write("Indsæt elev id: ");
    string? studentId = Console.ReadLine();
    errorMsg = Validation.ValidateStudent(studentId, students);
    if (errorMsg == null)
    {
        Console.Write("Indsæt fag id: ");
        string? courseId = Console.ReadLine();
        errorMsg = Validation.ValidateCourse(courseId, courses);
    }

    if (errorMsg == null)
    {
        errorMsg = Validation.ValidateEnrollment(enrollments);
        if (errorMsg == null)
        {
            int id = enrollments.Count() + 1;
            enrollments.Add(new Enrollment() { Id = id, StudentId = Validation.StudentId, CourseId = Validation.CourseId });
        }
    }
}
#endregion