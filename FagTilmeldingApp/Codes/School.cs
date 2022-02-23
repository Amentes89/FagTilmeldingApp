using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class School
    {
        public string? SchoolName;

        public School()
        {
            Console.Write("Angiv Skole: ");
            SchoolName = Console.ReadLine();
        }


    }
}