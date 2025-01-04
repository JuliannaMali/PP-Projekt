using Projekt.Mapy;

namespace Projekt.Postaci;

public class Knight : Character, IMappable
{
    //Attrs
    private double defense;

    //Mthds
    public Knight(int level, double def)
    {
        defense = def;
        hp = level * 50;
        lvl = level;
    }
    public double Defense
    {
        get => defense;
        set
        {
            defense = Defense;
        }
    }
    char IMappable.Symbol => 'K';
    public override string Info() => "Wrogi rycerz";

}
