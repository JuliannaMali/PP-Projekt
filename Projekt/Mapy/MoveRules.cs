
namespace Projekt.Mapy;

internal class MoveRules
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        if (m.Exist(p.Next(d)))
            return p.Next(d);
        return p;
    }

    public static Point CrossNext(Map m, Point p, Direction d)
    {
        if(!m.Exist(p.Next(d)))
        {
            switch(d)
            {
                case Direction.TopRight:
                    {
                        if (p.X == m.SizeX - 1 || p.V == m.SizeX - 1)
                            return new Point(0, 0, null, null);
                        return new Point( (p.X == null ? p.V + 1 : p.X + 1), 0, null, null );
                    }
                case Direction.TopLeft:
                    {
                        if (p.X == 0 || p.V == 0)
                            return new Point(m.SizeX - 1, 0, null, null);
                        return new Point( (p.X == null ? p.V - 1 : p.X - 1), 0, null, null);
                    }
                case Direction.Left:
                    {
                        if(p.V == null)
                            return new Point(m.SizeX - 1, p.Y, null, null);
                        return new Point(null, null, m.SizeX - 1, p.Y);
                    }
                case Direction.Right:
                    {
                        if (p.V == null)
                            return new Point(0, p.Y, null, null);
                        return new Point(null, null, 0, p.Y);
                    }
                case Direction.DownLeft:
                {
                        break;
                }
            }

            if(p.V == null)
            {
                switch(d)
                {
                    case Direction.DownLeft:
                        {
                            if (p.X == 0)
                                return new Point(m.SizeX - 1, m.SizeY/2, null, null);
                            return new Point(p.X - 1, m.SizeY/2, null, null);
                        }
                    case Direction.DownRight:
                        {
                            if (p.X == m.SizeX - 1)
                                return new Point(0, m.SizeY / 2, null, null);
                            return new Point(p.X + 1, m.SizeY / 2, null, null);
                        }
                }
            }
            else
            {
                switch (d)
                {
                    case Direction.DownLeft:
                        {
                            if (p.X == 0)
                                return new Point(m.SizeX - 1, m.SizeY / 2, null, null);
                            return new Point(p.X - 1, m.SizeY / 2, null, null);
                        }
                    case Direction.DownRight:
                        {
                            if (p.X == m.SizeX - 1)
                                return new Point(0, m.SizeY / 2, null, null);
                            return new Point(p.X + 1, m.SizeY / 2, null, null);
                        }
                }
            }
        }
        return p.Next(d);
    }
}
