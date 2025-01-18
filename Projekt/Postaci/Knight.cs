using Projekt.Mapy;
using System.Text.Json.Serialization;

namespace Projekt.Postaci;

public class Knight : Character, IMappable
{
    //Attrs
    private double defense;
    private bool isKing;

    //Mthds
    public Knight(int level, double def, bool isking = false)
    {
        defense = def;
        hp = level * 50;
        lvl = level;
        isKing = isking;
    }
    public double Defense
    {
        get => defense;
    }
    public bool IsKing
    {
        get => isKing;
    }
    public override string Info() => "Wrogi rycerz";

    [JsonConstructor]
    public Knight() { } 
}
