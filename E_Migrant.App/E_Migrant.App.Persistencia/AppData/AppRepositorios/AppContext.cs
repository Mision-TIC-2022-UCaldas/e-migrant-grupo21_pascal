using Microsoft.EntityFrameworkCore;
using E_Migrant.App.Dominio;

namespace E_Migrant.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Migrante> Migrantes {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; initial Catalog = PascalDB");
            }
        }                
    }
}