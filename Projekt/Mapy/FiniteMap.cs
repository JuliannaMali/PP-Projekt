namespace Projekt.Mapy;
public class FiniteMap : Map
{
    public FiniteMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MoveRules.WallNext;
    }
}
