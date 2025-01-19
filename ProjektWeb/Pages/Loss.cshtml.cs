using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjektWeb.Pages
{
    public class LossModel : PageModel
    {
        public void OnGet()
        {
            try
            {
                App.Demo.Map.Remove(((App.Demo.Mappables[0]) as Projekt.Postaci.Hero)!.Position);
            }
            catch(Exception)
            {
                try
                {
                    App.Game1.Map.Remove(((App.Game1.Mappables[0]) as Projekt.Postaci.Hero)!.Position);
                }
                catch(Exception)
                {
                    try
                    {
                        App.Game2.Map.Remove(((App.Game2.Mappables[0]) as Projekt.Postaci.Hero)!.Position);
                    }
                    catch(Exception)
                    {
                        ;
                    }
                }
                try
                {
                    App.Game2.Map.Remove(((App.Game2.Mappables[0]) as Projekt.Postaci.Hero)!.Position);
                }
                catch (Exception)
                {
                    ;
                }
            }
        }
    }
}
