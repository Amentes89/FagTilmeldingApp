using System;
using System.Collections.Generic;

namespace OOPH1.Codes.EntityFrameworkModels
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}