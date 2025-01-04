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
        Scout scout = new(1, 0.33);

        Fight.FightStart(bohater, knight);
        //Fight.FightStart(bohater, scout);



        //Scout vs Scout
        {
            while (true)
            {

                if (hero.Stat >= (enemy as Scout).Agility && first_hit)
                {
                    if (Dodge((enemy as Scout).Agility))
                    {
                        Console.WriteLine("Przeciwnik unika Twojego ciosu!");
                    }
                    else
                    {
                        enemy_hp -= hero_dmg;
                        Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg} obrażeń!");

                        if (enemy_hp <= 0)
                        {
                            hero.fight_won(0);
                            break;
                        }
                    }
                    first_hit = false;
                }

                if (Dodge(hero.Stat))
                {
                    Console.WriteLine("Unikasz ciosu przeciwnika!");
                }
                else
                {
                    hero_hp -= enemy_dmg;
                    Console.WriteLine($"{enemy.Info()} zadaje Ci {enemy_dmg} obrażeń!");
                }

                if (hero_hp <= 0)
                {
                    //game over
                }

                if (Dodge((enemy as Scout).Agility))
                {
                    Console.WriteLine("Przeciwnik unika Twojego ciosu!");
                }
                else
                {
                    enemy_hp -= hero_dmg;
                    Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg} obrażeń!");

                    if (enemy_hp <= 0)
                    {
                        hero.fight_won(0);
                        break;
                    }
                }
            }
        }
    }
}


