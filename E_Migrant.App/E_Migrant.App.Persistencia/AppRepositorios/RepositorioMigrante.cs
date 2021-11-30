using System.Collections.Generic;
using System.Linq;
using E_Migrant.App.Dominio;
namespace E_Migrant.App.Persistencia.AppRepositorios
{
    public class RepositorioMigrante:IRepositorioMigrante{  
        // <summary>
        // Referencia al contexto de Paciente
        // </summary> 

        private readonly AppContext _appContext;
        // <summary>
        //Metodo Constructor Utiliza 
        //Inyeccion de dependencias para indicar el contexto a utilizar
        //</sumary>
        //<param name="appContext"></param>//
        public RepositorioMigrante(AppContext appContext){
            _appContext=appContext;
        }   
        Migrante IRepositorioMigrante.AddMigrante(Migrante migrante){
            var migranteAdicionado = _appContext.Migrantes.Add(migrante);
            _appContext.SaveChanges();
            return migranteAdicionado.Entity;
        }

        void IRepositorioMigrante.DeleteMigrante(int idMigrante){
            var migranteEncontrado = _appContext.Migrantes.FirstOrDefault(m => m.Id==idMigrante);
            if(migranteEncontrado==null)
                return; 
            _appContext.Migrantes.Remove(migranteEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Migrante> IRepositorioMigrante.GetAllMigrantes(){
            return _appContext.Migrantes;
        }

        Migrante IRepositorioMigrante.GetMigrante(int idMigrante){
            return _appContext.Migrantes.FirstOrDefault(m => m.Id==idMigrante);
        }

        Migrante IRepositorioMigrante.UpdateMigrante(Migrante migrante){
            var migranteEncontrado = _appContext.Migrantes.FirstOrDefault(m => m.Id==migrante.Id);
            if(migranteEncontrado!=null){
                migranteEncontrado.Nombre =migrante.Nombre;
                migranteEncontrado.Apellidos = migrante.Apellidos;
                _appContext.SaveChanges();                
            }
            return migranteEncontrado;
        }
    }
}