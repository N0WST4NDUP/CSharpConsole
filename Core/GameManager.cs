using System;

namespace Core
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new();

        Map map = new Map().Initialize(20, 15);

        public void Run()
        {
            Map map = new();
            map.Initialize(40, 30);
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
                case ConsoleKey.Escape: GameSystem.Instance.Stop(); return;
            }
        }

        private void Update()
        {
            // 게임 업데이트
        }

        private void Render() => GameSystem.Instance.Renderer();
    }
}