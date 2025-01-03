using Projekt.Mapy;

namespace Projekt.Postaci;

public class Hero : Character, IMappable
{
    //Attrs
    private string name = "Bezimienny";

    private int exp_to_lvl_up = 10;
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

    public void fight_won(int exp_gained)
    {
        if(exp_owned + exp_gained >= exp_to_lvl_up)
        //postać levelowała
        {
            level_up(exp_gained);
        }
        else
        //postać nie levelowała
        {
            exp_owned += exp_gained;
        }
    }

    public void level_up(int exp_gained)
    {
        lvl++;
        hp += 50;
        exp_to_lvl_up += 10;
        exp_owned += exp_gained - exp_to_lvl_up;

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
