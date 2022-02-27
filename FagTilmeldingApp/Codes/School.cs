using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH1.Codes;

internal abstract class School
{
    public string? SchoolName { get; set; }

    public int FagIAlt { get; set; }


    public School(string? schoolName)
    {
        SchoolName = schoolName;
    }

    public virtual void SetCourseCount(List<Course> courses)
    {
        FagIAlt = courses.Count();
    }
}