using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjektWeb.Pages
{
    public class Map1Model : PageModel
    {

        public required Projekt.Mapy.FiniteMap _mapa { get; set; }
        public void OnGet()
        {
            _mapa = App._finiteMap;
        }
    }
}
