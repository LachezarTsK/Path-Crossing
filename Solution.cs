
using System;
using System.Collections.Generic;

public class Solution
{
    /*
    Alternatively, without implementing 'Equals()' and 'GetHashCode()' methods
    we could apply the immutable class 'record' or struct(since all fields are value based).
     */
    private sealed class Point
    {

        readonly int x;
        readonly int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (!(obj is Point))
            {
                return false;
            }
            Point other = (Point)obj;
            return this.x == other.x && this.y == other.y;
        }


        public override int GetHashCode()
        {
            int hash = 19;
            hash = 89 * hash + this.x;
            hash = 89 * hash + this.y;
            return hash;
        }
    }

    private readonly Dictionary<char, int[]> moves = new Dictionary<char, int[]>()
    {
        ['N'] = new int[] { -1, 0 },
        ['S'] = new int[] { 1, 0 },
        ['E'] = new int[] { 0, 1 },
        ['W'] = new int[] { 0, -1 }
    };

    public bool IsPathCrossing(string path)
    {
        HashSet<Point> visited = new HashSet<Point>();
        int previousX = 0;
        int previousY = 0;
        visited.Add(new Point(previousX, previousY));

        foreach (char direction in path)
        {
            int nextX = previousX + moves[direction][0];
            int nextY = previousY + moves[direction][1];
            if (!visited.Add(new Point(nextX, nextY)))
            {
                return true;
            }

            previousX = nextX;
            previousY = nextY;
        }

        return false;
    }
}
