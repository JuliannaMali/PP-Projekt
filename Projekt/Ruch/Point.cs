﻿using System.Text.Json.Serialization;

namespace Projekt;

public readonly struct Point
{
    [JsonInclude]
    public readonly int? X, Y, V, W;

    [JsonConstructor]
    public Point(int? x, int? y, int? v, int? w) => (X, Y, V, W) = (x, y, v, w);

    public override string ToString() => $"({X}, {Y}, {V}, {W})";

    public Point Next(Direction direction)
    {
        Point outcome = default;
        switch (direction)
        {
            case (Direction)0:
                {
                    if (this.V == null)
                    {
                        outcome = new(this.X + 1, this.Y, null, null);
                    }
                    else
                    {
                        outcome = new(null, null, this.V + 1, this.W);
                    }
                    break;
                }
            case (Direction)1:
                {
                    if (this.V == null)
                    {
                        outcome = new(this.X - 1, this.Y, null, null);
                    }
                    else
                    {
                        outcome = new(null, null, this.V - 1, this.W);
                    }
                    break;
                }
            case (Direction)2:
                {
                    if (this.V == null)
                    {
                        outcome = new(null, null, this.X - 1, this.Y);
                    }
                    else
                    {
                        outcome = new(this.V, this.W + 1, null, null);
                    }
                    break;
                }
            case (Direction)3:
                {
                    if (this.V == null)
                    {
                        outcome = new(null, null, this.X, this.Y);
                    }
                    else
                    {
                        outcome = new(this.V + 1, this.W + 1, null, null);
                    }
                    break;
                }
            case (Direction)4:
                {
                    if (this.V == null)
                    {
                        outcome = new(null, null, this.X - 1, this.Y - 1);
                    }
                    else
                    {
                        outcome = new(this.V, this.W, null, null);
                    }
                    break;
                }
            case (Direction)5:
                {
                    if (this.V == null)
                    {
                        outcome = new(null, null, this.X, this.Y - 1);
                    }
                    else
                    {
                        outcome = new(this.V + 1, this.W, null, null);
                    }
                    break;
                }
            default:
                {
                    outcome = default;
                    break;
                }
        }
        return outcome;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point other && 
            X == other.X && 
            Y == other.Y &&
            V == other.V &&
            W == other.W;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, V, W);
    }

}