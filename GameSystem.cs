using System.Text;

public class GameSystem
{
    private bool _isRunning = true;

    public bool IsRunning => _isRunning;

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
}