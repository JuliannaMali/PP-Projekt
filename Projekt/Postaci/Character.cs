using Projekt.Mapy;
using System.Text.Json.Serialization;

namespace Projekt.Postaci;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Knight), nameof(Knight))]
[JsonDerivedType(typeof(Scout), nameof(Scout))]
public abstract class Character : IMappable
{
    //Attributes
    [JsonIgnore]
    public Map? Map { get; private set; }
    [JsonIgnore]
    public Point Position { get; private set; }

    protected int hp;
    protected int lvl;

    //Methods, Interface implementations
    [JsonIgnore]
    public int HP 
    {
        get => hp; 
        set
        {
            hp = HP;
        }
    }
    [JsonInclude]
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
