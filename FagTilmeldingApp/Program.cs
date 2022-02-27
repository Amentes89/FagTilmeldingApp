//Iteration 4
global using OOPH1.Codes;
global using OOPH1.Codes.Models;

# region Project

string? errorMsg = null;
Student? matchedStudent = null;
Course? matchedCourse = null;

DBHandler dBHandler = new DBHandler();
List<Teacher> teachers = dBHandler.GetTeachers();
List<Course> courses = dBHandler.GetCourse();
List<Student> students = dBHandler.GetStudent();

Console.Write("Angiv skolens navn: ");
string? skoleNavn = Console.ReadLine();

Console.Write("Angiv forløb: ");
string? hovedforløbNavn = Console.ReadLine();

Console.Write("Angiv uddannelseslinje: ");
string? uddannelseslinje = Console.ReadLine();

string? uddannelseslinjeBeskrivelse = null;
bool exitLoop = false;
while (!exitLoop)
{
    Console.WriteLine();
    Console.WriteLine("Ønsker du at angiv en kort beskrivelse af uddannelseslinje: ");
    Console.WriteLine("1) Ja");
    Console.WriteLine("2) Nej");
    Console.Write("Vælg 1 eller 2: ");
    switch ((Console.ReadKey()).Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine();
            Console.WriteLine("Angiv kort beskrivelse af uddannelseslinje: ");
            uddannelseslinjeBeskrivelse = Console.ReadLine();
            exitLoop = true;
            break;
        case ConsoleKey.D2:
            exitLoop = true;
            break;
        default:
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Forkert valgt, prøv igen: ");
            Console.ForegroundColor = ConsoleColor.White;
            break;
    }
}

Semester semester = new(hovedforløbNavn, skoleNavn);
if (uddannelseslinjeBeskrivelse != null)
    semester.SetUddannelseslinje(uddannelseslinje, uddannelseslinjeBeskrivelse);
else
    semester.SetUddannelseslinje(uddannelseslinje);

List<Enrollment> enrollments = new();
while (true)
{
    Console.Clear();

    // ---------------------------------------------------------------------------------
    // Vis titel.
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Green;
    if (semester.UddannelseslinjeBeskrivelse != null)
    {
        Console.WriteLine($"{semester.SchoolName}, {semester.Uddannelseslinje}, {semester.SemesterNavn} fag tilmeldning app.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[ {semester.UddannelseslinjeBeskrivelse} ]");
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else
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