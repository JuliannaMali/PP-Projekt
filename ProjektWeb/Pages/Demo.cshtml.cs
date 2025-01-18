using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace ProjektWeb.Pages;

public class Demo : PageModel
{
    [BindProperty]
    public char HeroChoice { get; set; }
    [BindProperty]
    public required string HeroName { get; set; }
    public Game DemoGame => App.Demo;
    public int EnemiesCounter { get; set; }
    public bool EnemiesMove { get; set; } = true;

    public void OnGet()
    {
        InitializeHero();
        EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 0;
    }

    public void OnPost()
    {
        InitializeHero();
        EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 0;
    }

    public void OnPostEnemies()
    {
        EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 1;

        if (EnemiesCounter < DemoGame.Mappables.Count)
        {
            DemoGame.EnemiesTurn(EnemiesCounter);
            EnemiesCounter++;
            Thread.Sleep(500 + DemoGame.Mappables.Count * 20);
        }
        else
        {
            EnemiesCounter = 1;
            EnemiesMove = false;
        }

        HttpContext.Session.SetInt32("EnemiesCounter", EnemiesCounter);
    }

    // Metoda do obs³ugi ruchów
    private IActionResult HandleHeroTurn(Projekt.Direction direction)
    {
        try
        {
            DemoGame.HeroTurn(direction);
            return null!;
        }
        catch (Projekt.Gra.Game.FightException)
        {
            string enemyJson = JsonSerializer.Serialize((DemoGame.Map.At(((DemoGame.Mappables[0] as Hero)!.Position).Next(direction))) as Projekt.Postaci.Character);            
            string heroJson = JsonSerializer.Serialize((DemoGame.Mappables[0] as Projekt.Postaci.Hero));

            return RedirectToPage("/Fight", new { HeroData = heroJson, EnemyData = enemyJson});
        }
    }

    // Przyk³ad wykorzystania w metodzie OnPost

    public IActionResult OnPostTopLeft()
    {
        var result = HandleHeroTurn(Projekt.Direction.TopLeft);
        return result ?? Page();
    }
    public IActionResult OnPostTopRight()
    {
        var result = HandleHeroTurn(Projekt.Direction.TopRight);
        return result ?? Page();
    }
    public IActionResult OnPostLeft()
    {
        var result = HandleHeroTurn(Projekt.Direction.Left);
        return result ?? Page();
    }
    public IActionResult OnPostRight()
    {
        var result = HandleHeroTurn(Projekt.Direction.Right);
        return result ?? Page();
    }
    public IActionResult OnPostDownLeft()
    {
        var result = HandleHeroTurn(Projekt.Direction.DownLeft);
        return result ?? Page();
    }
    public IActionResult OnPostDownRight()
    {
        var result = HandleHeroTurn(Projekt.Direction.DownRight);
        return result ?? Page();
    }

    // do inicjalizacji bohatera
    private void InitializeHero()
    {
        var bohater = new Projekt.Postaci.Hero(HeroChoice)
        {
            Name = HeroName
        };

        DemoGame.Map.Remove(new Projekt.Point(2, 0, null, null));
        DemoGame.Mappables[0] = bohater;
        DemoGame.Map.Add(bohater, new Projekt.Point(2, 0, null, null));
    }
}
