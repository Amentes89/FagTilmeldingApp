﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH1.Codes.Models;

internal class Course
{
    public int Id { get; set; }

    public string? CourseName { get; set; }

    public int TeacherId { get; set; }
}