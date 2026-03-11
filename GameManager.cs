using System;
using Core;

namespace Snake
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new();

        private readonly int _width = 22, _height = 22;

        private Map _map = new();
        private Position _snake = new();

        public void Run()
        {
            _map.Initialize(_width, _height);

            while (GameSystem.Instance.IsRunning)
            {
                if (GameSystem.Instance.Wait) continue;

                HandleInput();
                Update();
                Render();
            }
        }

        private void HandleInput()
        {
            if (!Console.KeyAvailable) return;
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow: _snake.X = Math.Max(_snake.X - 1, 1); return;
                case ConsoleKey.UpArrow: _snake.Y = Math.Max(_snake.Y - 1, 1); return;
                case ConsoleKey.RightArrow: _snake.X = Math.Min(_snake.X + 1, _width - 2); return;
                case ConsoleKey.DownArrow: _snake.Y = Math.Min(_snake.Y + 1, _height - 2); return;
                case ConsoleKey.Escape: GameSystem.Instance.Stop(); return;
            }
        }

        private void Update()
        {
            // 게임 업데이트
        }

        private void Render() => GameSystem.Instance.Renderer(_snake);
    }
}