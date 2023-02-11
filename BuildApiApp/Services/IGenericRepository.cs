using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildApiApp.Services
{
   public interface IGenericRepository <T> where T:class
    {
        public List<T> GetAll();
        public List<T> Search(string value);
        public T GetById(Guid id);
        public void Insert(T obj);
        public void Delete(T obj);
        public void Update(T obj);
        public void Save();
    }
}
