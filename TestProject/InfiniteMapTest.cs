using Projekt;
using Projekt.Mapy;
using Xunit.Sdk;

namespace TestProject;

public class InfiniteMapTest
{
    [Theory]

    //top-right
    [InlineData(null, null, 4, 2, Direction.TopRight, 0, 0, null, null)]
    [InlineData(null, null, 3, 2, Direction.TopRight, 4, 0, null, null)]
    [InlineData(null, null, 2, 2, Direction.TopRight, 3, 0, null, null)]
    [InlineData(null, null, 1, 2, Direction.TopRight, 2, 0, null, null)]
    [InlineData(null, null, 0, 2, Direction.TopRight, 1, 0, null, null)]

    [InlineData(null, null, 4, 0, Direction.TopRight, 0, 1, null, null)]
    [InlineData(null, null, 4, 1, Direction.TopRight, 0, 2, null, null)]

    [InlineData(4, 0, null, null, Direction.TopRight, null, null, 4, 0)]
    [InlineData(4, 1, null, null, Direction.TopRight, null, null, 4, 1)]

    //top-left
    [InlineData(null, null, 4, 2, Direction.TopLeft, 4, 0, null, null)]
    [InlineData(null, null, 3, 2, Direction.TopLeft, 3, 0, null, null)]
    [InlineData(null, null, 2, 2, Direction.TopLeft, 2, 0, null, null)]
    [InlineData(null, null, 1, 2, Direction.TopLeft, 1, 0, null, null)]
    [InlineData(null, null, 0, 2, Direction.TopLeft, 0, 0, null, null)]

    [InlineData(0, 0, null, null, Direction.TopLeft, null, null, 4, 0)]
    [InlineData(0, 1, null, null, Direction.TopLeft, null, null, 4, 1)]

    [InlineData(3, 0, null, null, Direction.TopLeft, null, null, 2, 0)]
    [InlineData(2, 0, null, null, Direction.TopLeft, null, null, 1, 0)]

    //left
    [InlineData(0, 0, null, null, Direction.Left, 4, 0, null, null)]
    [InlineData(null, null, 0, 0, Direction.Left, null, null, 4, 0)]

    //right
    [InlineData(4, 0, null, null, Direction.Right, 0, 0, null, null)]
    [InlineData(null, null, 4, 0, Direction.Right, null, null, 0, 0)]

    //down-left
    [InlineData(0, 0, null, null, Direction.DownLeft, null, null, 4, 2)]
    [InlineData(1, 0, null, null, Direction.DownLeft, null, null, 0, 2)]
    [InlineData(2, 0, null, null, Direction.DownLeft, null, null, 1, 2)]
    [InlineData(3, 0, null, null, Direction.DownLeft, null, null, 2, 2)]
    [InlineData(4, 0, null, null, Direction.DownLeft, null, null, 3, 2)]

    [InlineData(0, 1, null, null, Direction.DownLeft, null, null, 4, 0)]
    [InlineData(0, 2, null, null, Direction.DownLeft, null, null, 4, 1)]

    [InlineData(null, null, 1, 1, Direction.DownLeft, 1, 1, null, null)]
    [InlineData(1, 1, null, null, Direction.DownLeft, null, null, 0, 0)]

    //down-right
    [InlineData(0, 0, null, null, Direction.DownRight, null, null, 0, 2)]
    [InlineData(1, 0, null, null, Direction.DownRight, null, null, 1, 2)]
    [InlineData(2, 0, null, null, Direction.DownRight, null, null, 2, 2)]
    [InlineData(3, 0, null, null, Direction.DownRight, null, null, 3, 2)]
    [InlineData(4, 0, null, null, Direction.DownRight, null, null, 4, 2)]

    [InlineData(null, null, 4, 0, Direction.DownRight, 0, 0, null, null)]
    [InlineData(null, null, 4, 1, Direction.DownRight, 0, 1, null, null)]

    [InlineData(2, 1, null, null, Direction.DownRight, null, null, 2, 0)]
    [InlineData(null, null, 2, 1, Direction.DownRight, 3, 1, null, null)]


    public void CrossNext_ShouldReturnCorrectValues(int? x, int? y, int? v, int? w, Direction d, int? expX, int? expY, int? expV, int? expW)
    {
        var map = new InfiniteMap(5, 6);
        var p = new Point(x, y, v, w);
        var exp = new Point(expX, expY, expV, expW);

        var result = map.Next(p, d);

        Assert.Equal(exp, result);
    }
}
