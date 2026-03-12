using System.Collections.Generic;
using Core;

namespace Snake
{
    public class Position
    {
        private (int X, int Y) _head = (5, 5);
        private Queue<(int X, int Y)> _tail = new();
        private Direction _direction = Direction.Up;

        public void ChangeDirection(Direction direction) => _direction = direction;

        private void UpdatePostion(Map map)
        {
            _tail.Enqueue(_head);
            var target = _head;
            switch (_direction)
            {
                case Direction.Up: target.Y--; break;
                case Direction.Down: target.Y++; break;
                case Direction.Left: target.X--; break;
                case Direction.Right: target.X++; break;
            }

            if (target.X < 0 || target.Y < 0 || target.X > map.MaxX || target.Y > map.MaxY)
            {
                GameSystem.Instance.Stop();
                return;
            }

            switch (map.GetPointState(target))
            {
                case MapState.None:
                    map.SetPointState(target, MapState.Snake);
                    map.SetPointState(_tail.Dequeue(), MapState.None);
                    break;
                case MapState.Apple:
                    map.SetPointState(target, MapState.Snake);
                    break;
                case MapState.Snake:
                    GameSystem.Instance.Stop();
                    return;
            }
            _head = target;
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right

        }

        public void Subscribe()
        {
            GameManager.Instance.Update += UpdatePostion;
        }
        public void UnSubscribe()
        {
            GameManager.Instance.Update -= UpdatePostion;
        }
    }
}