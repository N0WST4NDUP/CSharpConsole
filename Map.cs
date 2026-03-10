using System;
using Core;

public class Map
{
    private char[,] _map;
    private Position _player;

    public Map()
    {
        GameSystem.Instance.AddRederingProcess(PrintMap);
    }

    public Map Initialize(int width, int height)
    {
        _map = new char[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j == 0 || j == width - 1) _map[i, j] = '#';
                else _map[i, j] = ' ';
            }
        }
        _player = new Position(_map.GetLength(0) - 1, _map.GetLength(1) / 2);

        return this;
    }

    private void PrintMap()
    {
        for (int i = 0; i < _map.GetLength(0); i++)
        {
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                // if (i == _player.Y && j == _player.X) Console.Write('@');
                Console.Write(_map[i, j]);
            }
            Console.WriteLine();
        }
    }
}