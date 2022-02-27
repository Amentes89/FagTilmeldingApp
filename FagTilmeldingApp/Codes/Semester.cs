using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH1.Codes;

internal sealed class Semester : School
{
    public string? SemesterNavn { get; set; }

    public int ProgrammeringsFagIAlt { get; set; }

    public Semester(string? semesterNavn, string? schoolName) : base(schoolName)
    {
        SemesterNavn = semesterNavn;
    }

    public override void SetCourseCount(List<Course> courses)
    {
        base.SetCourseCount(courses);
        ProgrammeringsFagIAlt = (courses.Where(a => a.CourseName.ToLower().Contains("programmering")).ToList()).Count();
    }



}