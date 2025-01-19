using Projekt.Mapy;
using System.Text.Json.Serialization;

namespace Projekt.Postaci;

public class Scout : Character, IMappable
{
    //Attrs
    private double agility;

    //Mthds
    public Scout(int level, double agi)
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
            agility = value;
        }
    }
    public override string Info() => "Wrogi zwiadowca";

    [JsonConstructor]
    public Scout(double Agility, int Level) 
    {
        this.hp = Level * 50;
        this.agility = Agility;
        this.lvl = Level;
    }
}