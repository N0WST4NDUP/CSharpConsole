using System;
using System.Collections.Generic;
using Core;
using SnakeGame.Maps;

namespace SnakeGame.Characters
{
    public class Position
    {
        private (int X, int Y) _head = (5, 5);
        private Queue<(int X, int Y)> _tail = new();
        private Direction _direction = Direction.Up;
        private Direction _currDirection;

        public void ChangeDirection(Direction direction)
        {
            if ((int)direction == -(int)_currDirection) return;

            _direction = direction;
        }

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
            _currDirection = _direction;

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

        public void Subscribe()
        {
            GameManager.Instance.Update += UpdatePostion;
        }
        public void UnSubscribe()
        {
            GameManager.Instance.Update -= UpdatePostion;
        }

        public enum Direction
        {
            Up = -1,
            Down = 1,
            Left = -2,
            Right = 2

        }
    }
}