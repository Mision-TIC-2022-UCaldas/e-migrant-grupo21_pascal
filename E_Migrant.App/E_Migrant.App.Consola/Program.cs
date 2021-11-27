using System;
using E_Migrant.App.Dominio;
using E_Migrant.App.Persistencia;

namespace E_Migrant.App.Consola
{
    class Program
    {
        private static IRepositorioMigrante _repoMigrante = new RepositorioMigrante(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BuscarMigrante(1);
        }
        private static void AddMigrante()
        {
            var migrante = new Migrante{
                Nombre="Nicolay",
                Apellidos="Perez",
                TDocuento="CC",
                Documento="1087453290",
                PaisOrigen="Venezuela",
                FechaNacimiento="20/04/1997",
                DirElectronica="nicolay@gmail.com",
                Telefono="7202020",
                DirActual="Pandiaco",
                Ciudad="Pasto",
                SitLaboral="Desempleado",
                contraseña="123"

            };
            _repoMigrante.AddMigrante(migrante);
        }
        private static void BuscarMigrante(int idMigrante){
            var migrante = _repoMigrante.GetMigrante(idMigrante);
            Console.WriteLine(migrante.Nombre+" "+migrante.Apellidos);
        }
    }
}
