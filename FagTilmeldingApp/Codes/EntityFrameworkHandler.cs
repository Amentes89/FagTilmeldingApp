using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH1.Codes;

// Required NuGet packages:
//   - Microsoft.EntityFrameworkCore.SqlServer
//   - Microsoft.EntityFrameworkCore.Tools

// Database first method:
// Scaffold-DbContext "Data Source=TEC-8200-LA0006;Initial Catalog=TEC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Codes/EntityFrameworkModels
internal class EntityFrameworkHandler
{
    public object GetRecords(TecDBTables tableName)
    {
        object list = new object();
        using var tecContext = new TECContext();
        switch (tableName)
        {
            case TecDBTables.Teacher:
                list = tecContext.Teachers.ToList();
                break;
            case TecDBTables.Course:
                list = tecContext.Courses.ToList();
                break;
            case TecDBTables.Student:
                list = tecContext.Students.ToList();
                break;
            case TecDBTables.Enrollment:
                list = tecContext.Enrollments.ToList();
                break;
        }

        return list;
    }

    public void ClearEnrollmentTable()
    {
        using var tecContext = new TECContext();
        foreach (Enrollment item in tecContext.Enrollments.ToList())
            tecContext.Remove(item);
        tecContext.SaveChanges();
    }

    public void InsertEnrollment(int studentId, int courseId)
    {
        using var tecContext = new TECContext();

        var enrollment = new Enrollment() { StudentId = studentId, CourseId = courseId };
        tecContext.Add(enrollment);
        tecContext.SaveChanges();
    }
}