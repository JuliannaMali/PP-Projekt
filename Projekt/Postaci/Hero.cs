﻿using Projekt.Mapy;
using System.Text.Json.Serialization;

namespace Projekt.Postaci;

public class Hero : Character, IMappable
{
    //Attrs
    private string name = "Bezimienny";

    private int exp_to_lvl_up = 50;
    private int exp_owned = 0;

    private double defense = 0;
    private double agility = 0;

    [JsonInclude]
    public bool isKnight;

    //Mthds

    public int Exp_to_lvl_up { get => exp_to_lvl_up; }
    public int Exp_owned { get => exp_owned; }     
    public Hero(char t)
    {
        if (t == 'K')
        {
            defense = 0.05;
            isKnight = true;
        }
        else
        {
            agility = 0.06;
            isKnight = false;
        }
        lvl = 1;
        hp = lvl * 50;
    }

    [JsonConstructor]
    public Hero(int Exp_to_lvl_up, int Exp_owned, double Stat, string Name, bool isKnight, int Level) 
    {
        this.exp_to_lvl_up = Exp_to_lvl_up;
        this.exp_owned = Exp_owned;
        this.name = Name;
        this.isKnight = isKnight;
        this.lvl = Level;
        if (isKnight)
            this.defense = Stat;
        else
            this.agility = Stat;

        this.hp = lvl * 50;
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
    public override string Info() => $"{name}";

    public string Name
    {
        get => name;
        set
        {
            name = value;
        }
    }

    public void Fight_won(int exp_gained)
    {
        this.exp_owned += exp_gained;
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
        lvl++;
        hp += hp < 500 ? 50 : 25;
        exp_owned -= exp_to_lvl_up;
        exp_to_lvl_up += 50;

        if (isKnight)
        {
            defense = defense < 0.5 ? defense += 0.05 : defense;
            defense = Math.Round(defense, 2);
        }
        else
        {
            agility = agility < 0.33 ? agility += 0.03 : agility;
            agility = Math.Round(agility, 3);
        }
    }
}
