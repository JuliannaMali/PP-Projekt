using Projekt;
using Projekt.Mapy;
using Projekt.Postaci;

namespace ProjektWeb;

public static class App
{
    public readonly static FiniteMap _finiteMap;

    public readonly static InfiniteMap _infiniteMap;

    static App()
    {
        _finiteMap = new FiniteMap(17, 12);
        _infiniteMap = new InfiniteMap(17, 12);
    }
}
