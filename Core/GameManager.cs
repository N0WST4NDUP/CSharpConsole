namespace Core
{
    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new GameManager();

        private GameSystem _system;

        private GameManager()
        {
            _system = new();
        }

        public void Run()
        {
            while (_system.IsRunning)
            {
                long currentTick = Environment.TickCount;
                if (currentTick - lastTick < waitTick) continue;
                lastTick = currentTick;

                HandleInput();
                Update();
                Render();
            }
        }

        private long lastTick = 0;
        private const float waitTick = 1000f / 30f;  // 30 FPS

        private void HandleInput()
        {
            if (!Console.KeyAvailable) return;
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Escape: _system.Stop(); return;
            }
        }

        private void Update()
        {
            // 게임 업데이트
        }

        private void Render() => _system.Renderer();

    }
}