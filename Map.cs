using System;
using System.Collections.Generic;
using SnakeGame.Characters;

namespace SnakeGame.Maps
{
    /// <summary>
    /// TODO - 일단 기본적인 DefaultMap이자 부모가 될 클래스<br/>
    /// 나중에 게임 모드 추가할 때 상속 구현
    /// </summary>
    public class Map
    {
        protected MapState[,] _map;
        protected readonly List<(int x, int y)> _available = new();

        public int MaxY => _map.GetLength(0) - 1;
        public int MaxX => _map.GetLength(1) - 1;
        public int EmptyCount => _available.Count;

        /// <summary>
        /// TODO - 재사용 가능한 Initializer.<br/>
        /// 나중에 옵션으로 조정할 수 있게 수정
        /// </summary>
        /// <param name="size">정사각형 크기</param>
        public virtual void Initialize(int size)
        {
            _map = new MapState[size, size];
            _available.Clear();
            for (int y = 0; y < _map.GetLength(0); y++)
            {
                for (int x = 0; x < _map.GetLength(1); x++)
                {
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
            if (count == 0) return null;

            return _available[count];
        }

        protected virtual void PrintMap(Position p)
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