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
        private int _aim = 0;

        public Vector2 GetPosition()
        {
            return _position;
        }

        public void HandleCommand(Movement movement)
        {
            switch (movement.direction)
            {
                case MovementDirection.forward:
                    _position.X += movement.magnitude;
                    _position.Y += (_aim * movement.magnitude);
                    break;
                case MovementDirection.up:
                    _aim -= movement.magnitude;
                    break;
                case MovementDirection.down:
                    _aim += movement.magnitude;
                    break;
                default:
                    break;
            }
        }

        public void HandleCommands(Movement[] movements)
        {
            foreach (Movement movement in movements)
            {
                HandleCommand(movement);
            }
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

        public void MoveSubmarine(Movement movement)
        {
            switch (movement.direction)
            {
                case MovementDirection.forward:
                    _position.X += movement.magnitude;
                    break;
                case MovementDirection.up:
                    _position.Y -= movement.magnitude;
                    break;
                case MovementDirection.down:
                    _position.Y += movement.magnitude;
                    break;
                default:
                    break;
            }
        }

        public void Reset()
        {
            _aim = 0;
            _position.X = 0;
            _position.Y = 0;
        }

        public void MoveSubmarine(Movement[] movements)
        {
            foreach (Movement movement in movements)
            {
                MoveSubmarine(movement);
            }
        }

        public int GetAim()
        {
            return _aim;
        }

        public int GetHorizontalPosition()
        {
            return (int)_position.X * (int)_position.Y;
        }
    }
}
