using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOPH1.Codes;

internal class DBHandler
{
    public string ConnectionString
    {
        get => "Data Source=SKAB1-PC-02; Initial Catalog=TEC; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
    }

    public List<Teacher> GetTeachers()
    {
        List<Teacher> list = new List<Teacher>();
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();

            SqlCommand command = new SqlCommand(
                $"SELECT * FROM Teacher", con
            );

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Teacher() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) });
            }
        }

        return list;
    }

    public List<Course> GetCourse()
    {
        List<Course> list = new List<Course>();
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();

            SqlCommand command = new SqlCommand(
                $"SELECT * FROM Course", con
            );

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Course() { Id = reader.GetInt32(0), CourseName = reader.GetString(1), TeacherId = reader.GetInt32(2) });
            }
        }

        return list;
    }

    public List<Student> GetStudent()
    {
        List<Student> list = new List<Student>();
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();

            SqlCommand command = new SqlCommand(
                $"SELECT * FROM Student", con
            );

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Student() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) });
            }
        }

        return list;
    }

    public void InsertEnrollment(int studentId, int courseId)
    {
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();

            SqlCommand command = new SqlCommand(
                $"INSERT INTO Enrollment VALUES ({studentId}, {courseId})", con
            );

            command.ExecuteNonQuery();
        }
    }

    public void RemoveStudentFromEnrollment(string firstName, string lastName)
    {
        List<Student> students = GetStudent();
        Student? student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        int? studentId = student != null ? student.Id : null;

        if (studentId != null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(
                    $"DELETE FROM Enrollment WHERE StudentId = {studentId}", con
                );

                command.ExecuteNonQuery();
            }
        }
    }

    public void RemoveStudentFromEnrollment(int studentId)
    {
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();

            SqlCommand command = new SqlCommand(
                $"DELETE FROM Enrollment WHERE StudentId = {studentId}", con
            );

            command.ExecuteNonQuery();
        }
    }
}