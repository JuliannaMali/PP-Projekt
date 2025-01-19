using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;
using System.Text.Json;

namespace ProjektWeb.Pages;

public class WalkaModel : PageModel
{
    public required Projekt.Postaci.Hero Hero { get; set; }
    public required Projekt.Postaci.Character Enemy { get; set; }

    [BindProperty(SupportsGet = true)]
    public required string Source { get; set; }

    [BindProperty(SupportsGet = true)]
    public required string HeroData { get; set; }

    [BindProperty(SupportsGet = true)]
    public required string EnemyData { get; set; } 

    public void OnGet()
    {
        var jsonOptions = new JsonSerializerOptions { IncludeFields = true };

        List<Projekt.Mapy.IMappable> deserializedenemy = JsonSerializer.Deserialize<List<Projekt.Mapy.IMappable>>(EnemyData, jsonOptions)!;

        Enemy = (deserializedenemy[0] as Character)!;
        Hero = JsonSerializer.Deserialize<Projekt.Postaci.Hero>(HeroData);
    }
}
