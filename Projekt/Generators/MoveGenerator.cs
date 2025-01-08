namespace Projekt.Generators;

public static class MoveGenerator
{
    public static Direction Generate()
    {
        Random randommove = new();
        int losowaliczba = randommove.Next(0, 6);

        switch (losowaliczba)
        {
            case 0:
                {
                    return Direction.Right;
                }
            case 1:
                {
                    return Direction.Left;
                }
            case 2:
                {
                    return Direction.TopLeft;
                }
            case 3:
                {
                    return Direction.TopRight;
                }
            case 4:
                {
                    return Direction.DownLeft;
                }
            case 5:
                {
                    return Direction.DownRight;
                }
            default:
                {
                    return Direction.Right;
                }
        }
    }
}
