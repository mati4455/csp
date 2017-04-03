using System;

namespace CSP
{
    public struct Point : IEquatable<Point>
    {
        private readonly int _x, _y;

        public int X => _x;
        public int Y => _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override int GetHashCode()
        {
            var hash = 17;
            if (X > Y)
            {
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
            }
            else
            {
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + X.GetHashCode();
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            return obj is Point && Equals((Point)obj);
        }

        public bool Equals(Point p)
        {
            return _x == p._x && _y == p._y || _x == p._y && _y == p._x;
        }

        public override string ToString()
        {
            return $"{_x}-{_y}";
        }
    }
}
