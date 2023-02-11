using BuildApiApp.Data;
using BuildApiApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildApiApp.Services.Implement
{
    public class EmployeeRepository : IGenericRepository<Employee>
    {
        private ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Employee obj)
        {
            _context.Employees.Remove(obj);
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.Include(q=>q.Project).ToList();
        }

        public Employee GetById(Guid id)
        {
            return _context.Employees.Include(q => q.Project).SingleOrDefault(q=>q.Id==id);
        }

        public void Insert(Employee obj)
        {
            _context.Employees.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Employee> Search(string value)
        {
            return _context.Employees.Where(q => q.EmployeeName.ToUpper().Contains(value.ToUpper())).ToList();
        }

        public void Update(Employee obj)
        {
            _context.Employees.Update(obj);
        }
    }
}
