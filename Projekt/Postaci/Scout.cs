using Projekt.Mapy;

namespace Projekt.Postaci;

public class Scout : Character, IMappable
{
    //Attrs
    private double agility;

    //Mthds
    public Scout(int level, int agi)
    {
        agility = agi;
        hp = level * 50;
        lvl = level;
    }
    public double Agility
    {
        get => agility;
        set
        {
            agility = Agility;
        }
    }
    char IMappable.Symbol => 'S';
    public override string Info() => "Wrogi zwiadowca";
}
