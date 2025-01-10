using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;
using Projekt.Mapy;
using System.Diagnostics.Metrics;

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
            Game2.HeroTurn(Projekt.Direction.TopLeft);
            for(int i = 1; i < Game2.Mappables.Count; i++)
            {
                Thread.Sleep(1);
                Game2.EnemiesTurn(i);
            }
        }

        public void OnPostTopRight()
        {
            Game2 = App.Game2;
            Game2.HeroTurn(Projekt.Direction.TopRight);
        }

        public void OnPostLeft()
        {
            Game2 = App.Game2;
            Game2.HeroTurn(Projekt.Direction.Left);
        }

        public void OnPostRight()
        {
            Game2 = App.Game2;
            Game2.HeroTurn(Projekt.Direction.Right);
        }

        public void OnPostDownLeft()
        {
            Game2 = App.Game2;
            Game2.HeroTurn(Projekt.Direction.DownLeft);
        }        
        
        public void OnPostDownRight()
        {
            Game2 = App.Game2;
            Game2.HeroTurn(Projekt.Direction.DownRight);
        }
    }
}
