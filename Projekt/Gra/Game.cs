namespace Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;

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
                    Direction dir = MoveGenerator();
                    Mappables[i].Go(dir);
                    Console.WriteLine($"{Mappables[i]} goes {dir}");
                }
                HeroIsMoving = true;
            }
        }
    }
    protected static Direction MoveGenerator()
    {
        Random randommove = new();
        int losowaliczba = randommove.Next(0, 6);

        switch(losowaliczba)
        {
            case 0:
                {
                    return Direction.Right;
                }
            case 1:
                {
                    return Direction.Left;
                }
            case 2:
                {
                    return Direction.TopLeft;
                }
            case 3:
                {
                    return Direction.TopRight;
                }
            case 4:
                {
                    return Direction.DownLeft;
                }
            case 5:
                {
                    return Direction.DownRight;
                }
            default:
                {
                    return Direction.Right;
                }
        }
    }
}
