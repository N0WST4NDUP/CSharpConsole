using System;
using Core;
using SnakeGame.Characters;
using SnakeGame.Items;
using SnakeGame.Maps;

namespace SnakeGame
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new();

        private Map _map = new DefaultMap();
        private Position _snake = new();
        private Apple _apple = new();

        public event Action<Map> Update;
        public event Action<Position> Render;

        private GameManager()
        {
            _map.Initialize(10, 10);

            Render += (p) => Console.SetCursorPosition(0, 0);
        }

        public void Run()
        {
            _map.Subscribe();
            _snake.Subscribe();
            _apple.Subscribe();

            while (GameSystem.Instance.IsRunning)
            {
                HandleInput();

                if (GameSystem.Instance.Wait) continue;

                if (GameSystem.Instance.UpdateCycle) Update?.Invoke(_map);

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