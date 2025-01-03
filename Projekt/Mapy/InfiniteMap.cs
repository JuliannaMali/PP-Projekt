namespace Projekt.Mapy;
public class InfiniteMap : Map
{
    public InfiniteMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MoveRules.CrossNext;
    }
}