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
                        if (p.V == m.SizeX - 1 && p.W == m.SizeY/2 - 1)
                            return new Point(0, 0, null, null);
                        else if (p.W == m.SizeY/2 - 1)
                            return new Point(p.V + 1 , 0, null, null);
                        else if (p.V == m.SizeX - 1)
                            return new Point(0, p.W + 1, null, null);
                        return new Point( (p.X == null ? p.V + 1 : p.X + 1), 0, null, null);
                    }
                case Direction.TopLeft:
                    {
                        if (p.W == m.SizeY / 2 - 1)
                            return new Point(p.V, 0, null, null);
                        else if (p.X == 0)
                            return new Point(null, null, m.SizeX - 1, p.Y);
                        return new Point( (p.X == null ? p.V - 1 : p.X), 0, null, null);
                    }
                case Direction.Left:
                    {
                        if(p.V == null)
                            return new Point(m.SizeX - 1, p.Y, null, null);
                        return new Point(null, null, m.SizeX - 1, p.W);
                    }
                case Direction.Right:
                    {
                        if (p.V == null)
                            return new Point(0, p.Y, null, null);
                        return new Point(null, null, 0, p.W);
                    }
                case Direction.DownLeft:
                    {
                        if (p.X == 0 && p.Y == 0)
                            return new Point(null, null, m.SizeX - 1, m.SizeY / 2 - 1);
                        else if (p.Y == 0)
                            return new Point(null, null, p.X - 1, m.SizeY / 2 - 1);
                        else if (p.X == 0)
                            return new Point(null, null, m.SizeX - 1, p.Y - 1);
                        return new Point(null, null, p.X - 1, m.SizeY / 2);
                    }
                case Direction.DownRight:
                    {
                        if (p.Y == 0)
                            return new Point(null, null, p.X, m.SizeY / 2 - 1);
                        else if (p.V == m.SizeX - 1)
                            return new Point(0, p.W, null, null);
                        return new Point(null, null, p.X + 1, m.SizeY / 2);
                    }
            }
        }
        return p.Next(d);
    }
}
