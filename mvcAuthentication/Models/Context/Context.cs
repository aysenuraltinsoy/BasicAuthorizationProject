using Microsoft.EntityFrameworkCore;
using mvcAuthentication.Models.Entities;

namespace mvcAuthentication.Models.Context
{
    public class Context:DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ORUQO20;Database=nrm1Autentication;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
    }
}
