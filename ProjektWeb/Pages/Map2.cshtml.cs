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

        public void OnPostTopLeft()
        {
            Game2 = App.Game2;
            Game2.Turn(Projekt.Direction.TopLeft);
        }

        public void OnPostTopRight()
        {
            Game2 = App.Game2;
            Game2.Turn(Projekt.Direction.TopRight);
        }

        public void OnPostLeft()
        {
            Game2 = App.Game2;
            Game2.Turn(Projekt.Direction.Left);
        }

        public void OnPostRight()
        {
            Game2 = App.Game2;
            Game2.Turn(Projekt.Direction.Right);
        }

        public void OnPostDownLeft()
        {
            Game2 = App.Game2;
            Game2.Turn(Projekt.Direction.DownLeft);
        }        
        
        public void OnPostDownRight()
        {
            Game2 = App.Game2;
            Game2.Turn(Projekt.Direction.DownRight);
        }
    }
}
