using System;
using System.Text;
using Snake;

namespace Core
{
    public class GameSystem
    {
        private const string k_title = "SnakeGame";
        private const double k_fps = 30f;

        private static GameSystem _instance;
        public static GameSystem Instance => _instance ??= new();

        public bool IsRunning { get; private set; } = true;
        public long LastTick = 0;
        public bool Wait
        {
            get
            {
                var now = Environment.TickCount64;
                var wait = now - LastTick < 1000f / k_fps;
                if (!wait) LastTick = now;
                return wait;
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