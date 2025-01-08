namespace Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;
using Projekt.Generators;
public class Game
{
    //Attrbs
    private int counter;
    public Map Map;
    public List<IMappable> Mappables;
    public List<Point> Positions;

    public bool HeroIsMoving = true;

    //Mthds
    public Game(Map mapa, List<IMappable> mappables, List<Point> positions)
    {
        counter = mappables.Count - 1;

        Map = mapa;
        Mappables = mappables;
        Positions = positions;        

        if(mappables.Count != positions.Count)
        {
            Console.WriteLine("Liczba pozycji i potworów jest różna!");
            Environment.Exit(0);
        }
        else
        {
            for(int i = 0; i < counter + 1; i++)
            {
                Map.Add(Mappables[i], Positions[i]);
            }
        }
    }

    public void Turn()
    {
        if (counter == 0)
        {
            //Mapa bez wrogów
            if(Map is FiniteMap)
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
            //Mapa z wrogami
            if(HeroIsMoving)
            {
                //Funkcja która zmienia <div ruch></div> na visible

                //Mappables[0].Go(&handler);
                HeroIsMoving = false;
            }
            else
            {
                for(int i = 1; i <= counter; i++)
                {
                    Direction dir = MoveGenerator.Generate();
                    Mappables[i].Go(dir);
                    Console.WriteLine($"{Mappables[i]} goes {dir}");
                }
                HeroIsMoving = true;
            }
        }
    }
}