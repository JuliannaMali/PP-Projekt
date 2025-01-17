using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;
using Projekt.Mapy;
using System.Diagnostics.Metrics;

namespace ProjektWeb.Pages
{
    public class Demo : PageModel
    {
        public required Game demo { get; set; }
        public int EnemiesCounter { get; set; }
        public bool EnemiesMove { get; set; } = true;
        public void OnGet()
        {
            demo = App.Demo;
            EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 0;
        }
        public void OnPostEnemies()
        {
            demo = App.Demo;
            EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 1;

            if (EnemiesCounter < demo.Mappables.Count)
            {
                demo.EnemiesTurn(EnemiesCounter);
                EnemiesCounter++;
                Thread.Sleep(300 + demo.Mappables.Count * 20);
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
            demo = App.Demo;
            demo.HeroTurn(Projekt.Direction.TopLeft);
        }
        public void OnPostTopRight()
        {
            demo = App.Demo;
            demo.HeroTurn(Projekt.Direction.TopRight);
        }
        public void OnPostLeft()
        {
            demo = App.Demo;
            demo.HeroTurn(Projekt.Direction.Left);
        }
        public void OnPostRight()
        {
            demo = App.Demo;
            demo.HeroTurn(Projekt.Direction.Right);
        }
        public void OnPostDownLeft()
        {
            demo = App.Demo;
            demo.HeroTurn(Projekt.Direction.DownLeft);
        }
        public void OnPostDownRight()
        {
            demo = App.Demo;
            demo.HeroTurn(Projekt.Direction.DownRight);
        }
    }
}
