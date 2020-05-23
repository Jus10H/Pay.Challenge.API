﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.DLL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfDependents { get; set; }
    }
}
