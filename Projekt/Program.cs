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
        bohater.Name = "Szyszka";



        for (int i = 0; i <= 15; i++)
        {
            bohater.Fight_won(i * 50);
            Console.WriteLine($"{bohater.Level} - {bohater.Stat} - {bohater.HP}");
        }

        Environment.Exit(0);


        InfiniteMap mapa1 = new(10, 10);

        List<IMappable> mapp = EnemiesGenerator.Generate(mapa1, bohater);
        List<Point> pos = PositionsGenerator.Generate(mapp.Count);


        Game newgame = new(mapa1, mapp, pos);

        bohater.Fight_won(50 * 50);


        for (int i = 0; i < pos.Count; i++)
        {
            if (mapp[i] is Scout)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{(mapp[i] as Character)!.Info()} lvl: {(mapp[i] as Character)!.Level} - agility: {(mapp[i] as Scout)!.Agility}");
            }
            else if (mapp[i] is Knight)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{(mapp[i] as Character)!.Info()}    lvl: {(mapp[i] as Character)!.Level} - defence: {(mapp[i] as Knight)!.Defense}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{(mapp[i] as Character)!.Info()}      lvl: {(mapp[i] as Character)!.Level} - agility: {(mapp[i] as Hero)!.Stat}");
            }


            Console.ResetColor();
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