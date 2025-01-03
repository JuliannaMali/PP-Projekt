using Projekt.Mapy;

namespace Projekt.Postaci;

public abstract class Character : IMappable
{
    //Attributes
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    protected int hp;
    protected int lvl;

    //Methods, Interface implementations
    public char Symbol => 'C';

    public int HP 
    {
        get => hp; 
        set
        {
            hp = HP;
        }
    }
    public int Level { get => lvl; }

    public virtual String Info() => "Postać bez klasy";

    void IMappable.Go(Direction direction)
    {
        try
        {
            Map?.Move(this, Position, Map.Next(Position, direction));
        }
        catch (NullReferenceException)
        {
            Console.WriteLine($"This creature is not on any map!");
        }
    }
    void IMappable.InitMapAndPosition(Map map, Point p)
    {
        Map = map;
        Position = p;
    }
}
