using Projekt.Postaci;
using System;
using System.Diagnostics.Metrics;

namespace Projekt.Ruch;

public static class Fight
{
    public static object[] FightStart(Hero hero, Character enemy)
    {
        object[] tablica = new object[2]; 

        double enemy_stat;

        bool hero_is_first;
        bool unik_e;
        bool unik_h;

        if(enemy is Knight k)
        {
            enemy_stat = k.Defense;
            unik_e = false;

            if(hero.isKnight)
            //Knight vs Knight
            {
                if (hero.Stat <= enemy_stat)
                    hero_is_first = !k.IsKing;
                else
                    hero_is_first = false;
                unik_h = false;
            }
            else
            //Scout vs Knight
            {
                hero_is_first = !k.IsKing;
                unik_h = true;
            }
        }
        else 
        {
            enemy_stat = (enemy as Scout)!.Agility;
            unik_e = true;

            if (hero.isKnight)
            //Knight vs Scout
            {
                hero_is_first = false;
                unik_h = false;
            }
            else
            //Scout vs Scout
            {
                if (hero.Stat >= enemy_stat)
                    hero_is_first = true;
                else
                    hero_is_first = false;
                unik_h = true;
            }
        }
        tablica[0] = new WhoIsFighting(hero, enemy);
        tablica[1] = DamageDealt(hero_is_first, hero.Level, hero.Stat, unik_h, enemy.Level, enemy_stat, unik_e);

        return tablica;
    }
    public static bool Dodge(double chance)
    {
        Random autoRand = new Random();
        double rand = autoRand.NextDouble();

        if(rand <= chance)
        {
            return true;
        }
        return false;
    }

    public static Dictionary<int, TurnCourse> DamageDealt(
        bool hero_moves_first, 
        int h_lvl, double h_stat, bool h_dodge, 
        int e_lvl, double e_stat, bool e_dodge)
    {
        Random autoRand = new Random();
        int counter = -1;

        double h_hp = h_lvl * 50;
        double e_hp = e_lvl * 50;

        Dictionary<int, TurnCourse> dict = new();

        while(true)
        {
            //Status(h_hp, h_lvl * 50, e_hp, e_lvl * 50);
            counter++;

            double rand = autoRand.NextDouble();
            double hero_dmg = Math.Round(((h_lvl * 1.5) + (5 + h_lvl * rand) * (1 + h_stat)), 2);

            rand = autoRand.NextDouble();
            double enemy_dmg = Math.Round(((e_lvl * 1.5) + (5 + e_lvl * rand) * (1 + e_stat)), 2);

            
            //Uderzasz przeciwnika
            if(hero_moves_first)
            {
                if(e_dodge)
                {
                    // Hero vs Scout
                    if(Dodge(e_stat))
                    {
                        hero_dmg = 0;
                    }
                    else
                    {
                        e_hp -= hero_dmg;
                    }
                }
                else
                {
                    // Hero vs Knight
                    hero_dmg = Math.Round(hero_dmg * (1 - e_stat), 2);
                    e_hp -= hero_dmg;
                }
            }
            else
            {
                hero_dmg = -10;
            }

            hero_moves_first = true;
        

            //Przeciwnik Cię uderza
            if(h_dodge)
            {
                //Scout vs Enemy
                if (Dodge(h_stat))
                {
                    enemy_dmg = 0;
                }
                else
                {
                    h_hp -= enemy_dmg;
                }
            }
            else
            {
                //Knight vs Enemy
                enemy_dmg = Math.Round(enemy_dmg * (1 - h_stat), 2);
                h_hp -= enemy_dmg;
            }

            dict[counter] = new TurnCourse(
                hero_dmg, enemy_dmg, 
                counter == 0 ? h_lvl * 50 : dict[counter-1].curr_hero_hp - enemy_dmg, 
                counter == 0 ? e_lvl * 50 : dict[counter-1].curr_enem_hp - (hero_dmg < 0 ? 0 : hero_dmg));

            if (dict[counter].curr_hero_hp <= 0 || dict[counter].curr_enem_hp <= 0)
                break;
        }
        return dict;
    }

    public struct WhoIsFighting
    {
        public readonly string hero_name;
        public readonly List<object> hero_stats;

        public readonly string enemy_name;
        public readonly List<object> enemy_stats;

        public WhoIsFighting(Hero hero, Character enemy) =>
            (hero_name, hero_stats, enemy_name, enemy_stats) =
            (hero.Info(), new List<object> { hero.Level, hero.Stat },
            enemy.Info(), new List<object> { enemy.Level, enemy is Knight ? (enemy as Knight)!.Defense : (enemy as Scout)!.Agility });
    }
}