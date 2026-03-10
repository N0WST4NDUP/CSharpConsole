using System.Text;

public class GameSystem
{
    private bool _isRunning = true;

    public bool IsRunning => _isRunning;
    public Render Renderer { get; }

    public GameSystem()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Title = "MyConsoleGame";
        Renderer = PreRendering;
    }

    public void Stop()
    {
        _isRunning = false;
        Console.CursorVisible = true;
    }

    private void PreRendering()
    {
        Console.SetCursorPosition(0, 0);
        Console.ResetColor();
    }

    public delegate void Render();
}