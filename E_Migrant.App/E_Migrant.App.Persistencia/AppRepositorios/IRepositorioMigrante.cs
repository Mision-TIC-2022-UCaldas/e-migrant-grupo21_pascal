using System.Collections.Generic;
using E_Migrant.App.Dominio;


namespace E_Migrant.App.Persistencia.AppRepositorios
{
    
    public interface IRepositorioMigrante{
        IEnumerable<Migrante> GetAllMigrantes();

        Migrante AddMigrante(Migrante migrante);
        Migrante UpdateMigrante(Migrante migrante);

        void DeleteMigrante(int idMigrante);

        Migrante GetMigrante(int idMigrante);
    }
}