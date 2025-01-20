using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace ProjektWeb.Pages;

public class Map2Model : PageModel
{
    [BindProperty]
    public char HeroChoice { get; set; }

    [BindProperty]
    public required string HeroName { get; set; }

    public Game Game2 => App.Game2;
    public int EnemiesCounter { get; set; }

    [BindProperty(SupportsGet = true)]
    public string HeroData { get; set; }

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
        (Game2.Mappables[0] as Projekt.Postaci.Hero)!.Fight_won(HttpContext.Session.GetInt32("EarnedExp") ?? 0);
        var pointJson = HttpContext.Session.GetString("EnemyPosition");

        if (!string.IsNullOrEmpty(pointJson))
        {
            var enemyPosition = JsonSerializer.Deserialize<Projekt.Point>(pointJson);
            App.Game2.Map.Remove(new Projekt.Point(enemyPosition.X, enemyPosition.Y, enemyPosition.V, enemyPosition.W));
            Game2.Map = App.Game2.Map;
        }
        return Page();
    }

    public IActionResult OnPostEnemies()
    {
        EnemiesCounter = HttpContext.Session.GetInt32("EnemiesCounter") ?? 1;

        if (EnemiesCounter < Game2.Mappables.Count)
        {
            try
            {
                Game2.EnemiesTurn(EnemiesCounter);
                EnemiesCounter++;
                Thread.Sleep(Game2.Mappables.Count * 20);
            }
            catch (Projekt.Gra.Game.FightException)
            {
                var jsonOptions = new JsonSerializerOptions { IncludeFields = true };

                Projekt.Point sourcepoint = ((Game2.Mappables[EnemiesCounter] as Character)!.Position);

                List<IMappable> enemy = [(Game2.Map.At(sourcepoint))];

                string enemyJson = JsonSerializer.Serialize(enemy, jsonOptions);
                string heroJson = JsonSerializer.Serialize((Game2.Mappables[0] as Projekt.Postaci.Hero));

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
        if (MapIsCleared())
        {
            string heroJson = JsonSerializer.Serialize((Game2.Mappables[0] as Projekt.Postaci.Hero));
            return RedirectToPage("/Map2", new { HeroData = heroJson });
        }

        try
        {
            Game2.HeroTurn(direction);
            return null!;
        }
        catch (Projekt.Gra.Game.FightException)
        {
            var jsonOptions = new JsonSerializerOptions { IncludeFields = true };

            Projekt.Point sourcepoint = ((Game2.Mappables[0] as Hero)!.Position).Next(direction);

            List<IMappable> enemy = [(Game2.Map.At(sourcepoint))];

            string enemyJson = JsonSerializer.Serialize(enemy, jsonOptions);
            string heroJson = JsonSerializer.Serialize((Game2.Mappables[0] as Projekt.Postaci.Hero));

            string pointJson = JsonSerializer.Serialize(sourcepoint);

            HttpContext.Session.SetString("EnemyPosition", pointJson);

            return RedirectToPage("/Fight",
                new { HeroData = heroJson, EnemyData = enemyJson, Source = "/Map2" });
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
        var bohater = JsonSerializer.Deserialize<Projekt.Postaci.Hero>(HeroData)!;

        Game2.Map.Remove(new Projekt.Point(null, null, 8, 0));
        Game2.Mappables[0] = bohater;
        Game2.Map.Add(bohater, new Projekt.Point(null, null, 8, 0));
    }

    private bool MapIsCleared()
    {
        if (Game2.Mappables.Count == 1)
            return true;
        return false;
    }
}
