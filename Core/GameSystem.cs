using System.Text;

namespace Core
{
    public class GameSystem
    {
        private bool _isRunning = true;

        public bool IsRunning => _isRunning;
        public Render Renderer { get; private set; } = () => { Console.SetCursorPosition(0, 0); };

        public GameSystem()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.Title = "MyConsoleGame";
        }

        public void Stop()
        {
            _isRunning = false;
            Console.CursorVisible = true;
        }

        public void AddRederingProcess(Render rp) => Renderer += rp;

        public delegate void Render();
    }
}