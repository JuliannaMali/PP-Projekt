using Projekt;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace TestProject;

public class PointTest
{
    [Theory]
    [InlineData(null, null, 1, 0, Direction.TopRight, 2, 1, null, null)]
    [InlineData(null, null, 1, 0, Direction.Right, null, null, 2, 0)]
    [InlineData(null, null, 1, 0, Direction.DownRight, 2, 0, null, null)]
    [InlineData(null, null, 1, 0, Direction.DownLeft, 1, 0, null, null)]
    [InlineData(null, null, 1, 0, Direction.Left, null, null, 0, 0)]
    [InlineData(null, null, 1, 0, Direction.TopLeft, 1, 1, null, null)]
    [InlineData(0, 0, null, null, Direction.DownRight, null, null, 0, -1)]

    public void Next_ShouldReturnCorrectPoint(int? x, int? y, int? v, int? w, Direction d, int? expX, int? expY, int? expV, int? expW)
    {
        var p = new Point(x, y, v, w);
        var e = new Point(expX, expY, expV, expW);


        var next = p.Next(d);

        Assert.Equal(e, next);
    }


}