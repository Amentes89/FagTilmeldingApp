using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public int TeacherID { get; set; }
        public string? Coursename { get; set; }

    }
}