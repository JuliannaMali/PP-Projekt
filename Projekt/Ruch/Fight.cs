using Projekt.Postaci;

namespace Projekt.Ruch;

public abstract class Fight
{
    public void FightStart(Hero hero, Character enemy)
    {
        double hero_hp = hero.HP;
        double enemy_hp = enemy.HP;
        Random autoRand = new Random();

        if(enemy is Knight)
        {
            if(hero.isKnight)
            //Knight vs Knight
            {

                //no dublowanie kodu to średnio to wygląda


                while(true)
                {
                    double rand = autoRand.NextDouble();
                    double hero_dmg = Math.Round(((hero.Level * 1.5) + (5 + hero.Level * rand) * (1 + hero.Stat)), 2);

                    rand = autoRand.NextDouble();
                    double enemy_dmg = Math.Round(((enemy.Level * 1.5) + (5 + enemy.Level * rand) * (1 + (enemy as Knight).Defense)), 2);

                    if (hero.Stat <= (enemy as Knight)?.Defense)
                    {
                        enemy_hp -= hero_dmg * (1 - (enemy as Knight).Defense);
                        Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg} obrażeń!");

                        if (enemy_hp < 0)
                        {
                            hero.fight_won(X);
                            break;
                        }

                        hero_hp -= enemy_dmg * (1 - hero.Stat);
                        Console.WriteLine($"{enemy.Info} zadaje Ci {enemy_dmg} obrażeń!");

                        if (hero_hp < 0)
                        {
                            //game over
                        }
                    }
                    else
                    {
                        hero_hp -= enemy_dmg * (1 - hero.Stat);
                        Console.WriteLine($"{enemy.Info} zadaje Ci {enemy_dmg} obrażeń!");

                        if (hero_hp < 0)
                        {
                            //game over
                        }

                        enemy_hp -= hero_dmg * (1 - (enemy as Knight).Defense);
                        Console.WriteLine($"Zadajesz przeciwnikowi {hero_dmg} obrażeń!");

                        if (enemy_hp < 0)
                        {
                            hero.fight_won(X);
                            break;
                        }
                    }


                }

                if(hero_hp <= 0)
                {
                    //game over
                }
            }
            else
            //Scout vs Knight
            {

            }
        }
        else 
        {
            if (hero.isKnight)
            //Knight vs Scout
            {

            }
            else
            //Scout vs Scout
            {

            }
        }
    }
}
