using Projekt;
using Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;

namespace ProjektWeb;

public static class App
{
    public static readonly Game Game1;
    public static readonly Game Game2;

    static App()
    {
        Hero heros = new('S');
        heros.Name = "Artur";

        Game1 = new Game(
            new FiniteMap(17, 14),
            new List<IMappable> { },
            new List<Point> { }
            );

        Game2 = new Game(
            new InfiniteMap(17, 14),
            Projekt.Generators.EnemiesGenerator.Generate(new InfiniteMap(17, 14), heros),
            Projekt.Generators.PositionsGenerator.Generate(21)
            );
    }
}
