using System;

namespace Reversi.Model
{
    // TODO: Size BASED constructors
    public class Table
    {
        private Tile[,] _tiles = null!;

        public readonly int Size = 8;

        public Table()
        {
            _tiles = new Tile[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _tiles[i, j] = new Tile(TileValue.EMPTY);
                }
            }
            int k = (Size - 2) / 2;
            _tiles[k, k].Value = TileValue.BLACK;
            _tiles[k + 1, k + 1].Value = TileValue.BLACK;
            _tiles[k + 1, k].Value = TileValue.WHITE;
            _tiles[k, k + 1].Value = TileValue.WHITE;
        }

        public static Table CopyTable(Table table)
        {
            Table result = new Table();

            for (int i = 0; i < table.Size; i++)
            {
                for (int j = 0; j < table.Size; j++)
                {
                    switch (table._tiles[i, j].Value)
                    {
                        case TileValue.BLACK:
                            result._tiles[i, j].Value = TileValue.BLACK; break;
                        case TileValue.WHITE:
                            result._tiles[i, j].Value = TileValue.WHITE; break;
                        case TileValue.EMPTY:
                            result._tiles[i, j].Value = TileValue.EMPTY; break;
                        default: break;
                    }
                }
            }

            return result;
        }

        public TileValue? TileAt(int i, int j)
        {
            if (-1 < i && i < Size && -1 < j && j < Size)
            {
                return _tiles[i, j].Value;
            }
            return null;
        }

        public void ChangeTileAt(int i, int j, TileValue value)
        {
            if (-1 < i && i < Size && -1 < j && j < Size)
            {
                _tiles[i, j].Value = value;
            }
        }

        public int CountBlacks()
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_tiles[i, j].Value == TileValue.BLACK) count++;
                }
            }
            return count;
        }


        public int CountWhites()
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_tiles[i, j].Value == TileValue.WHITE) count++;
                }
            }
            return count;
        }
    }
}
