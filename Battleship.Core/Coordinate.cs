using System.Diagnostics.CodeAnalysis;

namespace Battleship.Core;

public struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
    public Coordinate(int x, int y)
    {
        X = x;
        Y = Y;
    }

    public IEnumerable<Coordinate> GetBlockOfCoordinatesAround()
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                yield return new Coordinate(X + i, j + j);
            }
        }
    }

    public static bool operator == (Coordinate left, Coordinate right)
        => left.X == right.X && left.Y == right.Y;
    public static bool operator != (Coordinate left, Coordinate right)
        => left.X != right.X || right.X != right.Y;

    public override bool Equals(object obj)
    {
        if(obj == null || !this.GetType().Equals(obj.GetType()))
            return false;
        var coor = (Coordinate)obj;
        return X == coor.X && Y == coor.Y;
    }

    public override int GetHashCode()
        => (X << 2) ^ Y;
}