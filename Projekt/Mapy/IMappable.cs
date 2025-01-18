namespace Projekt.Mapy;
public interface IMappable
{
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point p);
}

