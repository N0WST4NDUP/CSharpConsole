using System;
using System.Text;
using Core;

namespace Snake
{
    public class Map
    {
        private char[,] _map;

        public Map()
        {
            GameSystem.Instance.AddRederingProcess(PrintMap);
        }

        public void Initialize(int width, int height)
        {
            _map = new char[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == 0 || y == height - 1 || x == 0 || x == width - 1) _map[y, x] = '#';
                    else _map[y, x] = ' ';
                }
            }
        }

        public void PrintMap(Position p)
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < _map.GetLength(0); y++)
            {
                sb.Clear();
                for (int x = 0; x < _map.GetLength(1); x++)
                {
                    sb.Append(' ');
                    sb.Append((p.X != x || p.Y != y) ? _map[y, x] : '@');
                }
                string row = sb.ToString().PadRight(_map.GetLength(1));
                Console.WriteLine(row);
            }
        }
    }
}