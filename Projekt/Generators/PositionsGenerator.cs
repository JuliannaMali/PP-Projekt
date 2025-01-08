namespace Projekt.Generators;
public static class PositionsGenerator
{
    public static List<Point> Generate(int count)
    {
        Random randomposition = new();
        List<Point> lista = new();
        lista.Add(new Point(null, null, 8, 0));

        while(lista.Count < count)
        {
            int x = randomposition.Next(0, 17);
            int y = randomposition.Next(3, 6);

            Point p = lista.Count % 2 == 0 ? new Point(x, y, null, null) : new Point(null, null, x, y);

            if (!lista.Contains(p))
            {
                lista.Add(p);
            }
        }

        return lista;
    }
}
