using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Dec2
{
    public class Submarine
    {
        private Vector2 _position = new Vector2(0, 0);

        public Vector2 GetPosition()
        {
            return _position;
        }

        public void MoveSubmarine(int magnitude, MovementDirection direction)
        {
            switch (direction)
            {
                case MovementDirection.forward:
                    _position.X += magnitude;
                    break;
                case MovementDirection.up:
                    _position.Y -= magnitude;
                    break;
                case MovementDirection.down:
                    _position.Y += magnitude;
                    break;
                default:
                    break;
            }
        }
    }
}
