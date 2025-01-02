
namespace Projekt.Mapy;

public interface IMappable
{
    public char Symbol { get; }
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point p);
}

