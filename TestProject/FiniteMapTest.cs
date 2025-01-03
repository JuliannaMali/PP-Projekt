using Projekt;
using Projekt.Mapy;

namespace TestProject;

public class FiniteMapTest
{
    [Theory]
    [InlineData(null, null, 1, 0, Direction.TopRight, 2, 1, null, null)]
    [InlineData(null, null, 2, 1, Direction.Left, null, null, 1, 1)]
    [InlineData(null, null, 4, 2, Direction.TopLeft, null, null, 4, 2)]
    [InlineData(1, 0, null, null, Direction.DownRight, 1, 0, null, null)]
    [InlineData(4, 1, null, null, Direction.Right, 4, 1, null, null)]
    [InlineData(null, null, 0, 2, Direction.Left, null, null, 0, 2)]

    public void WallNext_ShouldReturnCorrectValues(int? x, int? y, int? v, int? w, Direction d, int? expX, int? expY, int? expV, int? expW)
    {
        var map = new FiniteMap(5, 6);
        var p = new Point(x, y, v, w);
        var exp = new Point(expX, expY, expV, expW);

        var result = map.Next(p, d);

        Assert.Equal(exp, result);
    }

}
