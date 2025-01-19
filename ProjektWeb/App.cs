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

        Game1 = new Game(
            new FiniteMap(17, 14),
            Projekt.Generators.EnemiesGenerator.Generate(new FiniteMap(17, 14), heros),
            Projekt.Generators.PositionsGenerator.Generate(21)
            );        
        
        Game1 = new Game(
            new FiniteMap(5, 6),
            new List<IMappable> {
                heros,
                new Scout(2, 0.00),
                new Scout(2, 0.00)},
            new List<Point> {
                new Point(2, 0, null, null),
                new Point(2, 0, null, null),
                new Point(3, 0, null, null)}
            );

        Game2 = new Game(
            new InfiniteMap(17, 14),
            Projekt.Generators.EnemiesGenerator.Generate(new InfiniteMap(17, 14), heros),
            Projekt.Generators.PositionsGenerator.Generate(21)
            );

        Demo = new Game(
            new FiniteMap(5, 6),
            new List<IMappable> { 
                heros, 
                new Scout(10, 0.5), 
                new Knight(1, 0.01, true), 
                new Knight(1, 0.01)},
            new List<Point> { 
                new Point(2, 0, null, null), 
                new Point(0, 2, null, null),
                new Point(2, 2, null, null),
                new Point(4 ,2 ,null, null)}
            );

    }
}
