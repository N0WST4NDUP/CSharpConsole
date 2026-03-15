using System.Collections.Generic;

namespace SnakeGame.Maps
{
    /// <summary>
    /// 멀티플레이 모드용 맵, Map객체 상속<br/>
    /// </summary>
    public class MultiMap : Map
    {
        private MapState[,] _map2;
        private readonly List<(int x, int y)> _available2 = new();
        public int EmptyCount2 => _available2.Count;

        public override void Initialize(int size)
        {
            base.Initialize(size);

            _map2 = new MapState[size, size];
            _available2.Clear();
            for (int y = 0; y < _map2.GetLength(0); y++)
            {
                for (int x = 0; x < _map2.GetLength(1); x++)
                {
                    _available2.Add((x, y));
                }
            }
        }
    }
}