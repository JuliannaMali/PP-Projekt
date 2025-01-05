using Projekt.Postaci;
using Projekt.Ruch;
using System;

namespace Projekt;

public class Program
{
    public static void Main(string[] args)
    {
        Hero bohater = new('K');
        bohater.level_up(400);
        bohater.level_up(400);
        bohater.level_up(400);
        bohater.level_up(400);
        bohater.level_up(400);

        Knight knight = new(1, 0.01);
        Scout scout = new(10, 0.5);

        var x = Fight.FightStart(bohater, knight)[1];

        //foreach(KeyValuePair<int, TurnCourse> element in (Dictionary<int, TurnCourse>)x)
        //{
        //    Console.WriteLine($"Tura: {element.Key}");
        //    Console.WriteLine($"Obrażenia bohatera: {element.Value.hero_dmg}");
        //    Console.WriteLine($"Obrażenia przeciwnika: {element.Value.enem_dmg}");
        //    Console.WriteLine($"Życie bohatera:{element.Value.curr_hero_hp}");
        //    Console.WriteLine($"Życie przeciwnika:{element.Value.curr_enem_hp}\n");
        //}

        x = Fight.FightStart(bohater, scout)[1];

        foreach (KeyValuePair<int, TurnCourse> element in (Dictionary<int, TurnCourse>)x)
        {
            Console.WriteLine($"Tura: {element.Key}");
            Console.WriteLine($"Obrażenia bohatera: {element.Value.hero_dmg}");
            Console.WriteLine($"Obrażenia przeciwnika: {element.Value.enem_dmg}");
            Console.WriteLine($"Życie bohatera:{element.Value.curr_hero_hp}");
            Console.WriteLine($"Życie przeciwnika:{element.Value.curr_enem_hp}");
        }
    }
}