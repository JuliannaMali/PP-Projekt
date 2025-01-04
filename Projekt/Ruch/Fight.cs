using Projekt.Postaci;
using System;

namespace Projekt.Ruch;

public static class Fight
{
    public static void FightStart(Hero hero, Character enemy)
    {
        double hero_hp = hero.HP;
        double enemy_hp = enemy.HP;
        bool first_hit = true;

        if(enemy is Knight)
        {
            if(hero.isKnight)
            //Knight vs Knight
            {
                while (true)
                {
                    Status(hero_hp, hero.HP, enemy_hp, enemy.HP);

                    double rand = autoRand.NextDouble();
                    double hero_dmg = Math.Round(((hero.Level * 1.5) + (5 + hero.Level * rand) * (1 + hero.Stat)), 2);

                    rand = autoRand.NextDouble();
                    double enemy_dmg = Math.Round(((enemy.Level * 1.5) + (5 + enemy.Level * rand) * (1 + (enemy as Knight).Defense)), 2);

                    if (hero.Stat <= (enemy as Knight)?.Defense && first_hit)
                    {
                        double rand2 = autoRand.NextDouble();
                        double hero_dmg2 = Math.Round(((hero.Level * 1.5) + (5 + hero.Level * rand2) * (1 + hero.Stat)), 2);

                        enemy_hp -= hero_dmg2 * (1 - (enemy as Knight).Defense);
                        Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg2} obrażeń!");
                        
                        if (enemy_hp <= 0)
                        {
                            hero.fight_won(0);
                            Console.WriteLine("Wygrałeś!");
                            break;
                        }

                        first_hit = false;
                    }
                    Thread.Sleep(1500);
                    hero_hp -= enemy_dmg * (1 - hero.Stat);
                    Console.WriteLine($"{enemy.Info()} zadaje Ci {enemy_dmg} obrażeń!");

                    if (hero_hp <= 0)
                    {
                        Console.WriteLine("Przegrałeś!");
                    }
                    Thread.Sleep(1500);
                    enemy_hp -= hero_dmg * (1 - (enemy as Knight).Defense);
                    Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg} obrażeń!");

                    if (enemy_hp <= 0)
                    {
                        hero.fight_won(0);
                        Console.WriteLine("Wygrałeś!");
                        break;
                    }
                    Thread.Sleep(1500);
                }
            }
            else
            //Scout vs Knight
            {
                while (true)
                {
                    double rand = autoRand.NextDouble();
                    double hero_dmg = Math.Round(((hero.Level * 1.5) + (5 + hero.Level * rand) * (1 + hero.Stat)), 2);

                    rand = autoRand.NextDouble();
                    double enemy_dmg = Math.Round(((enemy.Level * 1.5) + (5 + enemy.Level * rand) * (1 + (enemy as Knight).Defense)), 2);


                    enemy_hp -= hero_dmg * (1 - (enemy as Knight).Defense);
                    Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg} obrażeń!");

                        if (enemy_hp <= 0)
                        {
                            hero.fight_won(0);
                            break;
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
                }
            }
        }
        else 
        {
            if (hero.isKnight)
            //Knight vs Scout
            {
                while (true)
                {
                    double rand = autoRand.NextDouble();
                    double hero_dmg = Math.Round(((hero.Level * 1.5) + (5 + hero.Level * rand) * (1 + hero.Stat)), 2);

                    rand = autoRand.NextDouble();
                    double enemy_dmg = Math.Round(((enemy.Level * 1.5) + (5 + enemy.Level * rand) * (1 + (enemy as Scout).Agility)), 2);


                    hero_hp -= enemy_dmg * (1 - hero.Stat);
                    Console.WriteLine($"{enemy.Info()} zadaje Ci {enemy_dmg} obrażeń!");

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


                    }

                    if (enemy_hp <= 0)
                    {
                        hero.fight_won(0);
                        break;
                    }
                }
            }
            else
            //Scout vs Scout
            {
                while (true)
                {
                    double rand = autoRand.NextDouble();
                    double hero_dmg = Math.Round(((hero.Level * 1.5) + (5 + hero.Level * rand) * (1 + hero.Stat)), 2);

                    rand = autoRand.NextDouble();
                    double enemy_dmg = Math.Round(((enemy.Level * 1.5) + (5 + enemy.Level * rand) * (1 + (enemy as Scout).Agility)), 2);

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
    public static bool Dodge(double chance)
    {
        Random autoRand = new Random();
        double rand = autoRand.NextDouble();

        Hero heros = new('T');
        var x = (heros as Character).HP;

        if(rand <= chance)
        {
            return true;
        }
        return false;
    }

    public static void Status(double hero_hp, int max_hero, double enemy_hp, int max_enemy)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Twoje HP: {Math.Round(hero_hp, 2)}/{max_hero}");
        Console.WriteLine($"Przeciwnika HP: {Math.Round(enemy_hp, 2)}/{max_enemy}");
        Console.ResetColor();
        Thread.Sleep(1500);
    }

    public static Dictionary<int, TurnCourse> DamageDealt(bool hero_moves_first, int h_lvl, int h_stat, bool h_dodge, double h_hp, int e_lvl, int e_stat, bool e_dodge, double e_hp)
    {
        Random autoRand = new Random();
        int counter = 0;

        Dictionary<int, TurnCourse> dict = new();


        while(true)
        {
            counter++;

            double rand = autoRand.NextDouble();
            double hero_dmg = Math.Round(((h_lvl * 1.5) + (5 + h_lvl * rand) * (1 + h_stat)), 2);

            rand = autoRand.NextDouble();
            double enemy_dmg = Math.Round(((e_lvl * 1.5) + (5 + e_lvl * rand) * (1 + e_stat)), 2);

            if(hero_moves_first)
            {
                double rand2 = autoRand.NextDouble();
                double hero_dmg2 = Math.Round(((h_lvl * 1.5) + (5 + h_lvl * rand2) * (1 + h_stat)), 2);

                if(e_dodge)
                {
                    if(Dodge(e_stat))
                    {
                        Console.WriteLine("Przeciwnik unika Twojego ciosu!");
                        hero_dmg2 = 0;
                    }
                    else
                    {
                        e_hp -= hero_dmg;
                        Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg2} obrażeń!");
                    }
                }
                else
                {
                    hero_dmg *= (1 - e_stat);
                    Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg2} obrażeń!");
                }
            }
            else
            {
                hero_dmg = -1;
            }

            hero_moves_first = true;
        
            if(h_dodge)
            {

            }
            else
            {

            }

            dict[counter] = new TurnCourse(hero_dmg, enemy_dmg);
        }

    }
}
