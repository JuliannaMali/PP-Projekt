using Projekt.Mapy;
using System.Text.Json.Serialization;

namespace Projekt.Postaci;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Knight), nameof(Knight))]
[JsonDerivedType(typeof(Scout), nameof(Scout))]
[JsonDerivedType(typeof(Hero), nameof(Hero))]
public abstract class Character : IMappable
{
    //Attributes, properties

    protected int hp;
    protected int lvl;

    [JsonIgnore]
    public int HP 
    {
        get => hp; 
    }

    [JsonIgnore]
    public Map? Map { get; private set; }
    [JsonIgnore]
    public Point Position { get; private set; }

    //Methods, Interface implementations
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
