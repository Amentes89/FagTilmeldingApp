//Box Opgave
global using OOPH1.Codes;
global using OOPH1.Codes.Models;

#region Model and generic list.

List<Course> courses = new()
{
    new Course() { Id = 10, CourseName = "Grundlæggende programmering", TeacherId = 1 },
    new Course() { Id = 5, CourseName = "Database programmering", TeacherId = 1 },
    new Course() { Id = 6, CourseName = "StudieTeknik", TeacherId = 1 },
    new Course() { Id = 11, CourseName = "Clientside programmering", TeacherId = 2 },
};

Semester s = new Semester("TEC", "H1");
s.SetCourseCount(courses);

Console.WriteLine($"Skolen har i alt : {s.FagIAlt} fag.");
Console.WriteLine();
Console.WriteLine($"H1 har i alt : {s.ProgrammeringsFagIAlt} programmerings fag");

Console.ReadLine();

#endregion