using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXVBackDL.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public void Create(T item);
        public void Update(T item);
        public void Delete(int id);
        public void Save();
    }
}
