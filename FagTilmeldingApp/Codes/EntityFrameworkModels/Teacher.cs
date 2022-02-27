using System;
using System.Collections.Generic;

namespace OOPH1.Codes.EntityFrameworkModels
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}