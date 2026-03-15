using System;
using System.Text;

namespace Core
{
    public class GameSystem
    {
        private const string k_title = "SnakeGame";
        private const double k_fps = 60;
        private const double k_cycle = 0.4; // 업데이트: 0.3초

        private static GameSystem _instance;
        public static GameSystem Instance => _instance ??= new();

        public bool IsRunning { get; private set; } = true;

        // 렌더링 타이밍 (60 FPS)
        private long _lastTick = 0;
        public bool Wait
        {
            get
            {
                var now = Environment.TickCount64;
                var wait = now - _lastTick < 1000 / k_fps;
                if (!wait) _lastTick = now;
                return wait;
            }
        }

        private long _lastUpdateTick = 0;
        public bool UpdateCycle
        {
            get
            {
                var now = Environment.TickCount64;
                var canUpdate = now - _lastUpdateTick >= 1000 * k_cycle;
                if (canUpdate) _lastUpdateTick = now;
                return canUpdate;
            }
        }

        public GameSystem()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.Title = k_title;
        }

        public void Stop()
        {
            IsRunning = false;
            Console.CursorVisible = true;
        }

    }
}