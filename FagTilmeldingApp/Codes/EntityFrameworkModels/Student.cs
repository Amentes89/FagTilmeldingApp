using System;
using System.Collections.Generic;

namespace OOPH1.Codes.EntityFrameworkModels
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}