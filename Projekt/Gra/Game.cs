namespace Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;
using Projekt.Generators;
using System;

public class Game
{
    //Attrbs
    private int counter;
    public Map Map;
    public List<IMappable> Mappables;
    public List<Point> Positions;

    public bool HeroIsMoving { get; set; } = true;

    //Mthds
    public Game(Map mapa, List<IMappable> mappables, List<Point> positions)
    {
        counter = mappables.Count - 1;

        Map = mapa;
        Mappables = mappables;
        Positions = positions;

        if (mappables.Count != positions.Count)
        {
            Console.WriteLine("Liczba pozycji i potworów jest różna!");
            Environment.Exit(0);
        }
        else
        {
            for (int i = 0; i < counter + 1; i++)
            {
                Map.Add(Mappables[i], Positions[i]);
            }
        }
    }

    public void HeroTurn(Direction herodir)
    {
        if (counter == 0)
        {
            //Mapa bez wrogów
            if (Map is FiniteMap)
            {
                //Mapa 1
            }
            else
            {
                //Mapa 2
            }
        }
        else
        {
            Point punkt = (Mappables[0] as Hero)!.Position;

            if ((Map.At(punkt.Next(herodir)) is Scout ||
                  Map.At(punkt.Next(herodir)) is Knight))
            {
                throw new FightException();
            }
            else
            {
                Mappables[0].Go(herodir);
            }
        }
    }

    public void EnemiesTurn(int index)
    {
        int proba = 0;
        while (true)
        {
            if (proba > 50) break;
            Direction dir = MoveGenerator.Generate();

            Point punkt = (Mappables[index] as Character)!.Position;

            if (!(Map.At(punkt.Next(dir)) is Scout ||
                   Map.At(punkt.Next(dir)) is Knight))
            {
                Mappables[index].Go(dir);
                break;
            }
            proba++;
        }
    }

    public class FightException : Exception
    {

    }
}