using System;
using System.Text;

namespace Core
{
    public class GameSystem
    {
        private const string k_title = "MyConsoleGame";
        private const double k_fps = 30f;

        public bool IsRunning { get; private set; } = true;
        public long LastTick = 0;
        public bool Wait
        {
            get
            {
                var now = Environment.TickCount;
                var wait = now - LastTick < 1000f / k_fps;
                if (!wait) LastTick = now;
                return wait;
            }
        }
        public Render Renderer { get; private set; } = () =>
        {
            Console.SetCursorPosition(0, 0);
        };

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

        public void AddRederingProcess(Render rp) => Renderer += rp;

        public delegate void Render();
    }
}