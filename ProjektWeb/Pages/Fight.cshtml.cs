using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Gra;
using System.Text.Json;

namespace ProjektWeb.Pages;

public class WalkaModel : PageModel
{
    public required Projekt.Postaci.Hero Hero { get; set; }
    public required Projekt.Postaci.Character Enemy { get; set; }


    [BindProperty(SupportsGet = true)]
    public required string HeroData { get; set; }

    [BindProperty(SupportsGet = true)]
    public required string EnemyData { get; set; } 

    public void OnGet()
    {
        Hero = JsonSerializer.Deserialize<Projekt.Postaci.Hero>(HeroData);
        Enemy = JsonSerializer.Deserialize<Projekt.Postaci.Character>(EnemyData);
    }
}
