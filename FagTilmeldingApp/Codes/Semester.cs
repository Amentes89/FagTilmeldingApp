using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH1.Codes;

internal sealed class Semester : School
{
    public string? SemesterNavn { get; set; }
    public override string? Uddannelseslinje { get; set; }
    public override string? UddannelseslinjeBeskrivelse { get; set; }

    public Semester(string? semesterNavn, string? schoolName) : base(schoolName)
    {
        SemesterNavn = semesterNavn;
        SchoolName = schoolName;
    }

    public override void SetUddannelseslinje(string uddannelseslinje)
    {
        Uddannelseslinje = uddannelseslinje;
    }

    public void SetUddannelseslinje(string uddannelseslinje, string uddannelseslinjeBeskrivelse)
    {
        Uddannelseslinje = uddannelseslinje;
        UddannelseslinjeBeskrivelse = uddannelseslinjeBeskrivelse;
    }
}