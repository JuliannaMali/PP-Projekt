using Projekt.Gra;
using Projekt.Mapy;
using Projekt.Postaci;
using Projekt.Ruch;
using Projekt.Generators;
using System;

namespace Projekt;

public class Program
{
    public static void Main(string[] args)
    {
        Hero bohater = new('S');

        FiniteMap mapa1 = new(10, 10);
        List<IMappable> mapp = new List<IMappable>
        {
            bohater,
            new Scout(1, 0.1),
            new Knight(2, 0.4),
            new Scout(3, 0.1),
            new Knight(4, 0.4),
            new Scout(5, 0.1)
        };

        List<Point> pos = PositionsGenerator.Generate(mapp.Count);


        Game newgame = new(mapa1, mapp, pos);

        for(int i = 0; i < 6; i++)
        {
            Console.WriteLine($"{mapp[i]} - {pos[i]}");
        }

        Environment.Exit(0);

        for(int i = 0; i <= 15; i++)
        {
            bohater.Fight_won(i*50);
            Console.WriteLine(bohater.Level);
            Console.WriteLine(bohater.Stat);
        }


        Knight knight = new(1, 0.05);
        Scout scout = new(10, 0.5);

        var x = Fight.FightStart(bohater, scout)[1];

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
            Console.WriteLine($"\nTura: {element.Key}");
            Console.WriteLine($"Obrażenia bohatera: {element.Value.hero_dmg}");
            Console.WriteLine($"Obrażenia przeciwnika: {element.Value.enem_dmg}");

            if (element.Value.curr_hero_hp <= 0)
            {
                //game_over
                Console.WriteLine("lost");
                Environment.Exit(0);
            }
            else
            {
                //walka toczy się dalej, chyba że przeciwnik umarł
                Console.WriteLine($"Życie bohatera:{element.Value.curr_hero_hp}");
            }

            if (element.Value.curr_enem_hp <= 0)
            {
                //wygrana walka
                bohater.Fight_won((int)(((Dictionary<int, TurnCourse>)x)[1].curr_hero_hp/50) * 15);
                Console.WriteLine($"win, zdobyłeś {knight.Level * 15} exp"); 
            }
            else
            {
                //walka toczy się dalej
                Console.WriteLine($"Życie przeciwnika:{element.Value.curr_enem_hp}");
            }
        }
    }
}