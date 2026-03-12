using System.Collections.Generic;

namespace Snake
{
    public class Position
    {
        private (int X, int Y) _head = (5, 5);
        private Queue<(int X, int Y)> _tail = new();
        public Direction _direction = Direction.Up;

        public void ChangeDirection(Direction direction) => _direction = direction;

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right

        }
    }
}