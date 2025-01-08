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

        while(lista.Count < 20)
        {
            int randomtype = random.Next(0, 2);
            
            if(mapa is FiniteMap)
            {
                //Łatwa mapa
                int randomlvl = random.Next(1, 6);
                if(randomtype == 1)
                {
                    //zakres 0.05 - 0.15
                    double randomstat = random.NextDouble() * ();
                    lista.Add(new Scout(randomlvl, randomstat));
                }
                else
                {

                }
            }
            else
            {
                //Trudna mapa
            }
        }

        return lista;
    }
}
