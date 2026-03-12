using System;
using System.Text;
using Core;

namespace Snake
{
    public class Map
    {
        private MapState[,] _map;

        public void Subscribe() => GameManager.Instance.Render += PrintMap;
        public void UnSubscribe() => GameManager.Instance.Render -= PrintMap;

        public void Initialize(int width, int height)
        {
            _map = new MapState[height, width];
            _map[5, 5] = MapState.Snake;
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
    }
}