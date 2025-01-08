using Projekt.Mapy;

namespace Projekt.Postaci;

public class Hero : Character, IMappable
{
    //Attrs
    private string name = "Bezimienny";

    private int exp_to_lvl_up = 50;
    private int exp_owned = 0;

    private double defense = 0;
    private double agility = 0;

    public bool isKnight;

    //Mthds
    public Hero(char t)
    {
        if (t == 'K')
        {
            defense = 0.05;
            isKnight = true;
        }
        else
        {
            agility = 0.03;
            isKnight = false;
        }
        lvl = 1;
        hp = lvl * 50;
    }
    public double Stat
    {
        get
        {
            if (isKnight)
                return defense;
            return agility;
        }
    }
    char IMappable.Symbol => 'H';
    public override string Info() => $"{Name}";

    public string Name
    {
        get => name;
        init
        {
            name = Name;
        }
    }

    public void Fight_won(int exp_gained)
    {
        exp_owned += exp_gained;
        do
        {
            if (exp_owned >= exp_to_lvl_up)
            //postać levelowała
            {
                Level_up();
            }
        } while (exp_owned >= exp_to_lvl_up);
    }

    public void Level_up()
    {
        lvl += lvl < 10 ? 1 : 0;
        hp += 50;
        exp_owned -= exp_to_lvl_up;
        exp_to_lvl_up += 50;

        if (isKnight)
        {
            defense = defense < 0.5 ? defense += 0.045 : defense;
        }
        else
        {
            agility = agility < 0.33 ? agility += 0.03 : agility;
        }
    }
}
