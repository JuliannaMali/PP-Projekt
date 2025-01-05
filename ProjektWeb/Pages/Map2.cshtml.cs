using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjektWeb.Pages
{
    public class Map2Model : PageModel
    {

        public required Projekt.Mapy.
            InfiniteMap _mapa { get; set; }
        public void OnGet()
        {
            _mapa = App._infiniteMap;
        }
    }
}
