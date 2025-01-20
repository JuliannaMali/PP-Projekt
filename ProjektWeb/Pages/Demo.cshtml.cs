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

    public IActionResult OnPostReturnFromFight()
    {
        (DemoGame.Mappables[0] as Projekt.Postaci.Hero)!.Fight_won(HttpContext.Session.GetInt32("EarnedExp") ?? 0);
        var pointJson = HttpContext.Session.GetString("EnemyPosition");

        if (!string.IsNullOrEmpty(pointJson))
        {
            var enemyPosition = JsonSerializer.Deserialize<Projekt.Point>(pointJson);
            DemoGame.Mappables.Remove(DemoGame.Map.At(enemyPosition));
            App.Demo.Map.Remove(new Projekt.Point(enemyPosition.X, enemyPosition.Y, enemyPosition.V, enemyPosition.W));
            DemoGame.Map = App.Demo.Map;
        }
        return Page();
    }

    public IActionResult OnPostEnemies()
    {
        EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 1;

        if (EnemiesCounter < DemoGame.Mappables.Count)
        {
            try
            {
                DemoGame.EnemiesTurn(EnemiesCounter);
                EnemiesCounter++;
                Thread.Sleep(DemoGame.Mappables.Count * 20);
            }
            catch (Projekt.Gra.Game.FightException)
            {
                var jsonOptions = new JsonSerializerOptions { IncludeFields = true };

                Projekt.Point sourcepoint = ((DemoGame.Mappables[EnemiesCounter] as Character)!.Position);

                List<IMappable> enemy = [(DemoGame.Map.At(sourcepoint))];

                string enemyJson = JsonSerializer.Serialize(enemy, jsonOptions);
                string heroJson = JsonSerializer.Serialize((DemoGame.Mappables[0] as Projekt.Postaci.Hero));

                string pointJson = JsonSerializer.Serialize(sourcepoint);

                HttpContext.Session.SetString("EnemyPosition", pointJson);

                return RedirectToPage("/Fight", new { HeroData = heroJson, EnemyData = enemyJson, Source = "/Map1" });
            }
        }
        else
        {
            EnemiesCounter = 1;
            EnemiesMove = false;
        }

        HttpContext.Session.SetInt32("EnemiesCounter", EnemiesCounter);
        return Page();
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
            var jsonOptions = new JsonSerializerOptions { IncludeFields = true };

            Projekt.Point sourcepoint = ((DemoGame.Mappables[0] as Hero)!.Position).Next(direction);

            List<IMappable> enemy = [(DemoGame.Map.At(sourcepoint))];

            string enemyJson = JsonSerializer.Serialize(enemy, jsonOptions);            
            string heroJson = JsonSerializer.Serialize((DemoGame.Mappables[0] as Projekt.Postaci.Hero));

            string pointJson = JsonSerializer.Serialize(sourcepoint);

            HttpContext.Session.SetString("EnemyPosition", pointJson);

            if ((DemoGame.Mappables[0] as Projekt.Postaci.Hero)!.Level == 1)
                (DemoGame.Mappables[0] as Projekt.Postaci.Hero)!.Fight_won(500);

            return RedirectToPage("/Fight", 
                new { HeroData = heroJson, EnemyData = enemyJson, Source = "/Demo"});
        }
    }
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

        bohater.Fight_won(50);

        DemoGame.Map.Remove(new Projekt.Point(2, 0, null, null));
        DemoGame.Mappables[0] = bohater;
        DemoGame.Map.Add(bohater, new Projekt.Point(2, 0, null, null));
    }
}
