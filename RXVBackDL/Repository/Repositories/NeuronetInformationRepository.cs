using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RXVBackDL.Models.Implementations;
using RXVBackDL.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXVBackDL.Repository.Repositories
{
    public class NeuronetInformationRepository : IRepository<NeuronetInformation>
    {
        private readonly NeuronetInformationContext _db;

        public NeuronetInformationRepository()
        {
            _db = new NeuronetInformationContext();
        }
        public void Create(NeuronetInformation item)
        {
            _db.NeuronetInformation.Add(item);
        }

        public void Delete(int id)
        {
            NeuronetInformation ni = _db.NeuronetInformation.Find(id);
            _db.Remove<NeuronetInformation>(ni);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public NeuronetInformation Get(int id)
        {
            return _db.NeuronetInformation.Find(id);
        }

        public IEnumerable<NeuronetInformation> GetAll()
        {
            return _db.NeuronetInformation;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(NeuronetInformation item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public bool Contatins(NeuronetInformation item)
        {
            return _db.NeuronetInformation.Contains(item);
        }
    }
}
