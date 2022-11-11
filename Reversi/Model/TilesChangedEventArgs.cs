using System;

namespace Reversi.Model
{
    public class TilesChangedEventArgs : EventArgs
    {
        public List<Point> Points { get; private set; }

        public TileValue Value { get; private set; }

        public TilesChangedEventArgs(List<Point> points, TileValue value)
        {
            Points = points;
            Value  = value;
        }
    }
}
