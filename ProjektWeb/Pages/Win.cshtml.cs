using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjektWeb.Pages
{
    public class WinModel : PageModel
    {
        [BindProperty]
        public string? WinnerName { get; set; }

        public void OnPost()
        {

        }
    }
}
