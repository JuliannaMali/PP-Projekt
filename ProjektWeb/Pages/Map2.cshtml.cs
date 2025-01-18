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
        public int EnemiesCounter { get; set; }
        public bool EnemiesMove { get; set; } = true;
        public void OnGet()
        {
            Game2 = App.Game2;
            EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 0;
        }
        public void OnPostEnemies()
        {
            Game2 = App.Game2;
            EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 1;

            if (EnemiesCounter < Game2.Mappables.Count)
            {
                Game2.EnemiesTurn(EnemiesCounter);
                EnemiesCounter++;
                Thread.Sleep(50 + Game2.Mappables.Count * 20);
            }
            else
            {
                EnemiesCounter = 1;
                EnemiesMove = false;
            }

            HttpContext.Session.SetInt32("EnemiesCounter", EnemiesCounter);
        }
        public void OnPostTopLeft()
        {
            Game2 = App.Game2;
            Game2.HeroTurn(Projekt.Direction.TopLeft);
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
