using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_P.Codes.Models
{
    internal class ADO
    {
        public string? ConnectionString
        {
            get => "Data Source=SKAB1-PC-02; Initial Catalog=TEC; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
        }

        public List<Teacher> GetTeacher()
        {
            List<Teacher> teachers = new List<Teacher>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM TEACHER");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Teacher teacher = new Teacher() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2) };

                teachers.Add(teacher);
            }


            return teachers;
        }

    }

}