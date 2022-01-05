using Microsoft.EntityFrameworkCore;
using RXVBackDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXVBackDL.Repository
{
    public abstract class RepositoryBase<T, DbT> : IRepository<T>
        where T : Entity where DbT : class, IDbEntity, new()
    {
        //protected readonly DbContext context = new DbContext();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return null;
        }

        public bool Save(T entity)
        {
            DbT dbEntity;

            if (entity.IsNew())
            {
                dbEntity = new DbT();
            }
            else
            {
                
            }
            return false;
        }
    }
}
