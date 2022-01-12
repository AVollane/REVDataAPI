using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RXVBackDL.Models.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RXVBackDL.Repository.DbContexts
{
    public class NeuronetInformationContext : DbContext
    {
        private string ConnectionString { get; set; }
        public DbSet<NeuronetInformation> NeuronetInformation => Set<NeuronetInformation>();
        public NeuronetInformationContext()
        {
            Database.EnsureCreated();
            // ОШИБКА ПРЕОБРАЗОВАНИЯ
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();

            // Get connection string using key. Change it if you need another provider
            //ConnectionString = configuration["MSSQLServer"];
            ConnectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
    }
}
