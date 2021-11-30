using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using E_Migrant.App.Dominio;
using  E_Migrant.App.Persistencia;
using E_Migrant.App.Persistencia.AppRepositorios;
namespace E_Migrant.App.Frontend.Pages
{
        public class ListModel : PageModel
    {
        //private string[] servicios = {"Buenos dias", "Buenas tardes", "Buneas noches", "Hasta mañana"};
        //public List<string> ListaServicios {get; set;}
        [BindProperty]
        public string password { get; set; }


        [BindProperty]
        public string RepeatPassword { get; set; }

        [BindProperty]
        public string MensajePassword { get; set; }

        public void OnGet()
        {


        }

        public IActionResult OnPost()
        {
            E_Migrant.App.Persistencia.AppContext conn = new E_Migrant.App.Persistencia.AppContext();
            var Username = HttpContext.Session.GetString("username");
            HttpContext.Session.Remove("username");
            migrante migrante = conn.migrantes.FirstOrDefault(e => e.Documento == Username);
            if(!password.Equals(RepeatPassword)){
                MensajePassword = "Las contraseñas no coinciden";
                return Page();
            }else{
                migrante.contraseña = password;
                conn.SaveChanges();
                //return RedirectToPage("../Login/Login");
            }
        }

    }
}
