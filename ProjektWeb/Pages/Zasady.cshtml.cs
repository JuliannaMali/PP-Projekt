using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjektWeb.Pages
{
    public class ZasadyModel : PageModel
    {
        public void OnPostData(string check, string name) 
        {
            Console.WriteLine(check, name);
            if(check == "knightcheck")
            {
            }
        }
    }
}
