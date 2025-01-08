using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;
using Projekt.Mapy;

namespace ProjektWeb.Pages
{
    public class Map2Model : PageModel
    {
        public required Game Game2 { get; set; }
        public void OnGet()
        {
            Game2 = App.Game2;
        }
    }
}
