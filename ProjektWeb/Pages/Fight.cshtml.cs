using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;

namespace ProjektWeb.Pages
{
    public class WalkaModel : PageModel
    {
        public required Game Game { get; set; }

        public void OnGet()
        {
            Game = App.Game2;
        }
    }
}
