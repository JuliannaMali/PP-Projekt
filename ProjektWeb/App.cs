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
        Game1 = new Game(
            new FiniteMap(17, 14),
            new List<IMappable> { },
            new List<Point> { }
            );

        Game2 = new Game(
            new InfiniteMap(17, 14),
            new List<IMappable> {
                new Hero('S'),
                new Scout(2, 2),
                new Knight(3, 3)
            },
            new List<Point> { 
                new Point(4, 4, null, null),
                new Point(null, null, 0, 0),
                new Point(3, 3, null, null)
            }
            );
    }
}
