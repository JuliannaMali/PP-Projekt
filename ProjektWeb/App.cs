using Projekt;
using Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;

namespace ProjektWeb;

public static class App
{
    public static readonly Game Game1;
    public static readonly Game Game2;
    public static readonly Game Demo;

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

        Demo = new Game(
            new FiniteMap(5, 6),
            new List<IMappable> { heros, new Scout(5, 0.5), new Knight(1, 0), new Knight(5, 0.5)},
            new List<Point> { new Point(0, 0, null, null), new Point(null, null, 2, 2), new Point(null, null, 4, 2), new Point(3,2,null,null)}
            );

    }
}
