namespace Projekt.Generators;
using Projekt.Postaci;
using Projekt.Mapy;

public static class EnemiesGenerator
{
    public static List<IMappable> Generate(Map mapa, Hero hero)
    {
        List<IMappable> lista = new();
        lista.Add(hero);

        Random random = new();

        while(lista.Count < 21)
        {
            int randomtype = random.Next(0, 2);
            
            if(mapa is FiniteMap)
            {
                //Łatwa mapa
                int randomlvl = random.Next(1, 6);
                if(randomtype == 1)
                {
                    //zakres 0.05 - 0.15
                    //Scout
                    double randomstat = random.NextDouble() * 0.02 + 0.02;
                    lista.Add(new Scout(randomlvl, Math.Round(randomstat * randomlvl, 2)));
                }
                else
                {
                    //zakres 0.1 - 0.25
                    //Knight
                    double randomstat = random.NextDouble() * 0.01 + 0.04;
                    lista.Add(new Knight(randomlvl, Math.Round(randomstat * randomlvl, 2)));
                }
            }
            else
            {
                //Trudna mapa
                int randomlvl = random.Next(6, 11);
                if (randomtype == 1)
                {
                    //zakres 0.20 - 0.33
                    //Scout
                    double randomstat = random.NextDouble() * 0.008 + 0.025;
                    lista.Add(new Scout(randomlvl, Math.Round(randomstat * randomlvl, 2)));
                }
                else
                {
                    //zakres 0.3 - 0.5
                    //Knight
                    double randomstat = random.NextDouble() * 0.01 + 0.04;
                    lista.Add(new Knight(randomlvl, Math.Round(randomstat*randomlvl, 2)));
                }
            }
        }

        return lista;
    }
}
