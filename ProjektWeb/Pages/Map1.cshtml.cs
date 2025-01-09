using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;

namespace ProjektWeb.Pages
{
    public class Map1Model : PageModel
    {
        public required Game Game1 { get; set; }
        public void OnGet()
        {
            Game1 = App.Game1;
        }
    }
}
