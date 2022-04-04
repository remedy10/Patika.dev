using LinqKullanimi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqKullanimi.DbOperations
{
    public class StudentDbContext : DbContext
    {
        //  public StudentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: " studentDataase");
        }
        //yukarıda şekilde yapmak için webApp olması gerekir services kısmına ekleyeceğiz çünkü(emin değilim).
    }
}
