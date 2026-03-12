using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Snake
{
    public class Map
    {
        private MapState[,] _map;
        private HashSet<(int x, int y)> _available = new();

        public int MaxY => _map.GetLength(0) - 1;
        public int MaxX => _map.GetLength(1) - 1;
        public int EmptyCount => _available.Count;

        public void Initialize(int width, int height)
        {
            _map = new MapState[height, width];
            _available.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _map[y, x] = MapState.None;
                    _available.Add((x, y));
                }
            }
        }

        public MapState GetPointState((int x, int y) point) => GetPointState(point.x, point.y);
        public MapState GetPointState(int x, int y) => _map[y, x];

        public void SetPointState((int x, int y) point, MapState state) => SetPointState(point.x, point.y, state);
        public void SetPointState(int x, int y, MapState state)
        {
            _map[y, x] = state;
            switch (state)
            {
                case MapState.None:
                    _available.Add((x, y));
                    break;
                default:
                    _available.Remove((x, y));
                    break;
            }
        }

        public (int x, int y)? GetAvailablePoint(int count)
        {
            foreach (var point in _available)
            {
                if (count-- == 0) return point;
            }
            return null;
        }

        private void PrintMap(Position p)
        {
            for (int y = 0; y < _map.GetLength(0); y++)
            {
                for (int x = 0; x < _map.GetLength(1); x++)
                {
                    Console.Write(' ');
                    switch (_map[y, x])
                    {
                        case MapState.None when Console.ForegroundColor != ConsoleColor.White:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case MapState.Snake when Console.ForegroundColor != ConsoleColor.DarkGreen:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;
                        case MapState.Apple when Console.ForegroundColor != ConsoleColor.DarkRed:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                    }
                    Console.Write('●');
                }
                Console.WriteLine();
            }
        }

        public void Subscribe()
        {
            GameManager.Instance.Render += PrintMap;
        }
        public void UnSubscribe()
        {
            GameManager.Instance.Render -= PrintMap;
        }
    }
}