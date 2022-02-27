using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOPH1.Codes;

enum TecDBTables
{
    Teacher,
    Course,
    Student,
    Enrollment
}

internal class DBHandler
{
    public string ConnectionString
    {
        get => "Data Source=SKAB1-PC-02; Initial Catalog=TEC; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
    }

    public object GetRecords(TecDBTables tableName)
    {
        object list = new object();
        using SqlConnection con = new SqlConnection(ConnectionString);

        con.Open();

        SqlCommand command = new SqlCommand(
            $"SELECT * FROM {tableName}", con
        );

        SqlDataReader reader = command.ExecuteReader();
        switch (tableName)
        {
            case TecDBTables.Teacher:
                List<Teacher> teachers = new List<Teacher>();
                while (reader.Read())
                {
                    teachers.Add(new Teacher() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) });
                }
                list = teachers;
                break;
            case TecDBTables.Course:
                List<Course> courses = new List<Course>();
                while (reader.Read())
                {
                    courses.Add(new Course() { Id = reader.GetInt32(0), CourseName = reader.GetString(1), TeacherId = reader.GetInt32(2) });
                }
                list = courses;
                break;
            case TecDBTables.Student:
                List<Student> students = new List<Student>();
                while (reader.Read())
                {
                    students.Add(new Student() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) });
                }
                list = students;
                break;
            case TecDBTables.Enrollment:
                List<Enrollment> enrollments = new List<Enrollment>();
                while (reader.Read())
                {
                    enrollments.Add(new Enrollment() { Id = reader.GetInt32(0), StudentId = reader.GetInt32(1), CourseId = reader.GetInt32(2) });
                }
                list = enrollments;
                break;
        }

        return list;
    }

    public void RemoveStudentFromEnrollment(string firstName, string lastName)
    {
        List<Student> students = (List<Student>)GetRecords(TecDBTables.Student);
        Student? student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        int? studentId = student != null ? student.Id : null;

        if (studentId != null)
        {
            using SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand command = new SqlCommand(
                $"DELETE FROM Enrollment WHERE StudentId = {studentId}", con
            );

            command.ExecuteNonQuery();
        }
    }

    public void RemoveStudentFromEnrollment(int studentId)
    {
        using SqlConnection con = new SqlConnection(ConnectionString);

        con.Open();

        SqlCommand command = new SqlCommand(
            $"DELETE FROM Enrollment WHERE StudentId = {studentId}", con
        );

        command.ExecuteNonQuery();
    }

    public void DropEnrollmentTable()
    {
        using SqlConnection con = new SqlConnection(ConnectionString);

        con.Open();

        SqlCommand command = new SqlCommand(
            $"DELETE FROM Enrollment", con
        );

        command.ExecuteNonQuery();
    }

    public void InsertEnrollment(int studentId, int courseId)
    {
        using SqlConnection con = new SqlConnection(ConnectionString);

        con.Open();

        SqlCommand command = new SqlCommand(
            $"INSERT INTO Enrollment VALUES ({studentId}, {courseId})", con
        );

        command.ExecuteNonQuery();
    }
}