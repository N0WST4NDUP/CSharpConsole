using System.Collections.Generic;
using Core;

namespace Snake
{
    public class Position
    {
        private (int X, int Y) _head = (5, 5);
        private Queue<(int X, int Y)> _tail = new();
        public Direction _direction = Direction.Up;

        public Position()
        {
            _tail.Enqueue((4, 8));
            _tail.Enqueue((5, 8));
            _tail.Enqueue((5, 7));
            _tail.Enqueue((5, 6));
        }

        public void ChangeDirection(Direction direction) => _direction = direction;

        private void UpdatePostion(Map map)
        {
            _tail.Enqueue(_head);
            var target = _head;
            switch (_direction)
            {
                case Direction.Up:
                    target.Y--;
                    if (target.Y < 0)
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
                    break;
                case Direction.Down:
                    target.Y++;
                    if (target.Y > map.MaxY)
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
                    break;
                case Direction.Left:
                    target.X--;
                    if (target.X < 0)
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
                    break;
                case Direction.Right:
                    target.X++;
                    if (target.X > map.MaxX)
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
                    break;
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