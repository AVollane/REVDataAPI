using RXVBackDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXVBackDL.Repository
{
    public interface IRepository<T> where T: Entity
    {
        IQueryable<T> GetAll();
        bool Save(T entity);
        bool Delete(int id);
        bool Delete(T entity);
    }
}
