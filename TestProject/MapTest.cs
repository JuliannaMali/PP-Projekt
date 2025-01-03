using Projekt;
using Projekt.Mapy;

namespace TestProject;

public class MapTest
{
    [Theory]
    [InlineData(5, 7)]
    [InlineData(4, 6)]

    public void IncorrectSize_ShouldThrowExceptions(int x, int y)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new FiniteMap(x, y));
    }
    
    
    [Theory]
    [InlineData(null, null, 0, 0, true)]
    [InlineData(2, 1, null, null, true)]
    [InlineData(null, null, 4, 2, true)]
    [InlineData(0, -1, null, null, false)]
    [InlineData(null, null, 3, 3, false)]

    public void Exist(int? x, int? y, int? v, int? w, bool exp)
    {
        var map = new FiniteMap(6, 6);
        bool result = map.Exist(new Point(x, y, v, w));

        Assert.Equal(exp, result);
    }

    
}
