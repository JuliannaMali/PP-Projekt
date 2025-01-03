namespace Projekt.Mapy;
public abstract class Map
{
    //Attributes

    protected Dictionary<Point, List<IMappable>>? _fields = new();
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    protected Func<Map, Point, Direction, Point>? FNext { get; set; }

    //Methods
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow (X)");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short (Y)");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    public void Add(IMappable mappable, Point p)
    {
        try
        {
            _fields?[p].Add(mappable);
        }
        catch (KeyNotFoundException)
        {
            _fields[p] = new List<IMappable>();
            _fields[p].Add(mappable);
        }
        mappable.InitMapAndPosition(this, p);
    }
    public void Remove(IMappable mappable, Point p)
    {
        _fields?[p].Remove(mappable);
        mappable.InitMapAndPosition(this, default);
    }
    public void Move(IMappable mappable, Point source, Point dest)
    {
        Remove(mappable, source);
        Add(mappable, dest);
    }
    public List<IMappable>? At(Point p)
    {
        try
        {
            return _fields?[p];
        }
        catch (KeyNotFoundException)
        {
            return new List<IMappable>();
        }
    }
    public List<IMappable>? At(int? x, int? y, int? v, int? w)
    {
        try
        {
            return _fields?[new Point(x, y, v, w)];
        }
        catch (KeyNotFoundException)
        {
            return new List<IMappable>();
        }
    }
    public virtual bool Exist(Point p)
    {
        if(p.X == null)
        {
            return ((p.V < this.SizeX && p.W < this.SizeY/2) && (p.V >= 0 && p.W >= 0)); 
        }
        else
        {
            return ((p.X < this.SizeX && p.Y < this.SizeY/2) && (p.X >= 0 && p.Y >= 0));
        }
    }
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;
}
