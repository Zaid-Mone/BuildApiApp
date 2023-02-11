using System;
using System.Collections.Generic;

namespace BuildApiApp.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
