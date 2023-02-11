using BuildApiApp.Data;
using BuildApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildApiApp.Services.Implement
{
    public class ProjectRepository : IGenericRepository<Project>
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Project obj)
        {
            _context.Projects.Remove(obj);
        }

        public List<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public Project GetById(Guid id)
        {
            return _context.Projects.SingleOrDefault(q=>q.Id==id);
        }

        public void Insert(Project obj)
        {
            _context.Projects.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Project> Search(string value)
        {
            return _context.Projects.Where(q => q.ProjectName.ToUpper().Contains(value.ToUpper())).ToList();
        }

        public void Update(Project obj)
        {
            _context.Projects.Update(obj);
        }
    }
}
