using System;
using Snake;

public class Apple
{
    private (int X, int Y) _curr;
    private readonly Random _rnd = new();

    private void UpdateApple(Map map)
    {
        if (map.GetPointState(_curr) == MapState.Apple) return;

        var point = map.GetAvailablePoint(_rnd.Next(map.EmptyCount));
        if (point != null)
        {
            _curr = point.Value;
            map.SetPointState(_curr, MapState.Apple);
        }
    }

    public void Subscribe()
    {
        GameManager.Instance.Update += UpdateApple;
    }
    public void UnSubscribe()
    {
        GameManager.Instance.Update -= UpdateApple;
    }
}