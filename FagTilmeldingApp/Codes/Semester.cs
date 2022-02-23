using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class Semester : School
    {
        public string? SemesterNavn;

        public Semester()
        {
            Console.Write("Angiv Hovedforløb: ");
            SemesterNavn = Console.ReadLine();
        }
    }
}