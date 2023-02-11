using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildApiApp.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string  EmployeeName { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
