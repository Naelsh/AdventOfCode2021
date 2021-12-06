using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec5
{
    public class Vent
    {
        public Vector2 StartPosition { get; set; }
        public Vector2 EndPosition { get; set; }

        public Vent()
        {
            StartPosition = new Vector2(0, 0);
            EndPosition = new Vector2(0, 0);
        }

        public Direction GetDirection()
        {
            if (StartPosition.X == EndPosition.X)
            {
                if (StartPosition.Y < EndPosition.Y)
                {
                    return Direction.VerticalUp;
                }
                else if (StartPosition.Y > EndPosition.Y)
                {
                    return Direction.VerticalDown;
                }
            }
            else if (StartPosition.Y == EndPosition.Y)
            {
                if (StartPosition.X < EndPosition.X)
                {
                    return Direction.HorizontalRight;
                }
                else if (StartPosition.X > EndPosition.X)
                {
                    return Direction.HorizontalLeft;
                }
            }
            return Direction.Diagonal;
        }

        public int GetLength()
        {
            switch (GetDirection())
            {
                case Direction.HorizontalRight:
                    return (int)Math.Abs(StartPosition.X - EndPosition.X) + 1;
                case Direction.VerticalDown:
                    return (int)Math.Abs(StartPosition.Y - EndPosition.Y) + 1;
                case Direction.Diagonal:
                    return (int)Math.Abs(StartPosition.Y - EndPosition.Y) + 1;
                case Direction.HorizontalLeft:
                    return (int)Math.Abs(StartPosition.X - EndPosition.X) + 1;
                case Direction.VerticalUp:
                    return (int)Math.Abs(StartPosition.Y - EndPosition.Y) + 1;
                default:
                    break;
            }
            return 0;
        }
    }
}
