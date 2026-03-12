using System;
using Core;

namespace Snake
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new();

        private readonly int _width = 10, _height = 10;

        private Map _map = new();
        private Position _snake = new();

        public event Action<Map> Update;
        public event Action<Position> Render;

        private GameManager()
        {
            _map.Initialize(_width, _height);

            Render += (p) => Console.SetCursorPosition(0, 0);
        }

        public void Run()
        {
            _map.Subscribe();
            _snake.Subscribe();

            while (GameSystem.Instance.IsRunning)
            {
                HandleInput();

                if (GameSystem.Instance.Wait) continue;

                Update?.Invoke(_map);
                Render?.Invoke(_snake);
            }
        }

        private void HandleInput()
        {
            if (!Console.KeyAvailable) return;
            var key = Console.ReadKey(true).Key;

            switch (key)
            {

                case ConsoleKey.UpArrow: _snake.ChangeDirection(Position.Direction.Up); return;
                case ConsoleKey.DownArrow: _snake.ChangeDirection(Position.Direction.Down); return;
                case ConsoleKey.LeftArrow: _snake.ChangeDirection(Position.Direction.Left); return;
                case ConsoleKey.RightArrow: _snake.ChangeDirection(Position.Direction.Right); return;
                case ConsoleKey.Escape: GameSystem.Instance.Stop(); return;
            }
        }
    }
}