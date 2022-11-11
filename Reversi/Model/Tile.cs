using System;

namespace Reversi.Model
{
    public enum TileValue
    {
        EMPTY, BLACK, WHITE
    }

    public class Tile
    {
        public TileValue Value { get; set; }

        public static TileValue MakeTileValue(Player player)
        {
            if (player == Player.BLACK) return TileValue.BLACK;
            return TileValue.WHITE;
        }

        public static TileValue MakeTileValue(string value)
        {
            if (value == "black") return TileValue.BLACK;
            if (value == "white") return TileValue.WHITE;
            return TileValue.EMPTY;
        }

        public Tile(TileValue value)
        {
            Value = value;
        }

        public bool isEmpty() { return Value == TileValue.EMPTY; }
    }
}
