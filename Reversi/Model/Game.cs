using System;

namespace Reversi.Model
{
    public enum Player
    {
        BLACK, WHITE
    }

    public class Game
    {
        /// Events
        public event EventHandler<TilesChangedEventArgs>? TilesChanged;
        public event EventHandler? GameEnded;
        ///

        private Table _table;

        public Player CurrentPlayer { get; private set; }

        public int Size { get; private set; }

        public int BlackCount { get; private set; }
        public int WhiteCount { get; private set; }

        public Game()
        {
            _table = new Table();
            Size = _table.Size;
            CurrentPlayer = Player.BLACK;
            BlackCount = 2; WhiteCount = 2;
        }

        public void StartGame()
        {
            _table = new Table();
            CurrentPlayer = Player.BLACK;
            BlackCount = 2; WhiteCount = 2;
        }

        // returns the coords of all available (empty) spaces
        public List<Point> AvailableTiles()
        {
            List<Point> points = new();

            TileValue targetTile = Tile.MakeTileValue(CurrentPlayer); // get the target tile value

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_table.TileAt(i, j) == targetTile)
                    {
                        List<Point> some = AvailableTiles(i, j);
                        points.AddRange(some);
                    }
                }
            }
            return points;
        }

        private List<Point> AvailableTiles(int i, int j)
        {
            if (i > Size - 1 || j > Size - 1 || i < 0 || j < 0)
            {
                return new List<Point>(); // maybe throw exception for index out of bounds if necessary
            }

            List<Point> points = new();

            TileValue target = CurrentPlayer == Player.BLACK ? TileValue.WHITE : TileValue.BLACK; // the targets are tiles of the OTHER player

            // check vertical below
            {
                int k = i + 1;
                while (k < Size && _table.TileAt(k, j) == target) k++;
                
                if (i + 1 < k && k < Size) points.Add(new Point(k, j));
            }
            // check vertical over
            {
                int k = i - 1;
                while (-1 < k && _table.TileAt(k , j) == target) k--;
                
                if (-1 < k && k < i - 1) points.Add(new Point(k, j));
            }
            // check left horizontal
            {
                int k = j - 1;
                while (-1 < k && _table.TileAt(i, k) == target) k--;

                if (-1 < k && k < j - 1) points.Add(new Point(i, k));
            }
            // check right horizontal
            {
                int k = j + 1;
                while (k < Size && _table.TileAt(i, k) == target) k++;

                if (j + 1 < k && k < Size) points.Add(new Point(i, k));
            }
            // check left-left diagonal
            {
                int k = i + 1, l = j + 1;
                while (k < Size && l < Size && _table.TileAt(k, l) == target)
                {
                    k++; l++;
                }
                if (k > i + 1 && l > j + 1 && k < Size && l < Size) points.Add(new Point(k, l));
            }
            // check upper-left diagonal
            {
                int k = i - 1, l = j - 1;
                while (k < Size && l < Size && _table.TileAt(k, l) == target)
                {
                    k--; l--;
                }
                if (k < i - 1 && l < j - 1 && k > -1 && l < Size) points.Add(new Point(k, l));
            }
            // check upper-rigth diagonal
            {
                int k = i - 1, l = j + 1;
                while (k > -1 && l < Size && _table.TileAt(k, l) == target)
                {
                    k--; l++;
                }
                if (k < i - 1 && l > j + 1 && k > -1 && l < Size) points.Add(new Point(k, l));
            }
            // check lower-rigth diagonal
            {
                int k = i + 1, l = j - 1;
                while (k < Size && l > -1 && _table.TileAt(k, l) == target)
                {
                    k++; l--;
                }
                if (k > i + 1 && l < j - 1 && k < Size && l > -1) points.Add(new Point(k, l));
            }
            // remove occupied points
            points.RemoveAll(elem => _table.TileAt(elem.X, elem.Y) != TileValue.EMPTY);

            return points;
        }

        private Player OtherPlayer()
        {
            if (CurrentPlayer == Player.BLACK) return Player.WHITE;
            return Player.BLACK;
        }

        private void PaintTiles(int row, int col, List<Point> points, Table table) // changes tiles 
        {
            List<Point> coords = new();

            TileValue other = Tile.MakeTileValue(OtherPlayer());
            TileValue thisp = Tile.MakeTileValue(CurrentPlayer);
            
            int i, j;

            ///////////////////////////
            /// Verticals, horizontals
            //////////////////////////
            for (i = row + 1; i < table.Size && table.TileAt(i, col) == other; i++) // vertical1
            {
                coords.Add(new Point(i, col));
            }
            if (table.TileAt(i, col) == thisp) points.AddRange(coords);

            coords.Clear();
            for (i = row - 1; i > -1 && table.TileAt(i, col) == other; i--) // vertical2
            {
                coords.Add(new Point(i, col));
            }
            if (table.TileAt(i, col) == thisp) points.AddRange(coords);

            coords.Clear();
            for (i = col + 1; i < table.Size && table.TileAt(row, i) == other; i++) // horizontal1
            {
                coords.Add(new Point(row, i));
            }
            if (table.TileAt(row, i) == thisp) points.AddRange(coords);

            coords.Clear();
            for (i = col - 1; i > -1 && table.TileAt(row, i) == other; i--) // horizontal2
            {
                coords.Add(new Point(row, i));
            }
            if (table.TileAt(row, i) == thisp) points.AddRange(coords);

            //////////////
            /// Diagonals
            /////////////
            coords.Clear();
            for (i = row + 1, j = col + 1; i < table.Size && j < table.Size && table.TileAt(i, j) == other; i++, j++) // leftdiag1
            {
                coords.Add(new Point(i, j));
            }
            if (table.TileAt(i, j) == thisp) points.AddRange(coords);

            coords.Clear();
            for (i = row - 1, j = col - 1; i > -1 && j > -1 && table.TileAt(i, j) == other; i--, j--) // leftdiag2
            {
                coords.Add(new Point(i, j));
            }
            if (table.TileAt(i, j) == thisp) points.AddRange(coords);

            coords.Clear();
            for (i = row - 1, j = col + 1; i > -1 && j < table.Size && table.TileAt(i, j) == other; i--, j++) // rightdiag1
            {
                coords.Add(new Point(i, j));
            }
            if (table.TileAt(i, j) == thisp) points.AddRange(coords);

            coords.Clear();
            for (i = row + 1, j = col - 1; i < table.Size && j > -1 && table.TileAt(i, j) == other; i++, j--) // rightdiag2
            {
                coords.Add(new Point(i, j));
            }
            if (table.TileAt(i, j) == thisp) points.AddRange(coords);

            foreach (Point p in points) table.ChangeTileAt(p.X, p.Y, thisp);
        }

        private int CountPlayer(Player player)
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (_table.TileAt(i, j) == Tile.MakeTileValue(player)) count++;
                }
            }
            return count;
        }

        /// Public Methods
        public TileValue? TileAt(int i, int j)
        {
            return _table.TileAt(i, j);
        }

        public void Move(int i, int j)
        {
            if (i < 0 || j < 0 || i > Size - 1 || j > Size - 1) return;

            if (AvailableTiles().Count == 0)
            {
                CurrentPlayer = OtherPlayer(); // change current player to pass

                if (AvailableTiles().Count == 0) { OnGameEnded(); } // game over
            }
            else if (AvailableTiles().Contains(new Point(i, j)))
            {
                _table.ChangeTileAt(i, j, Tile.MakeTileValue(CurrentPlayer)); // change the selected tile
                List<Point> changed = new(); PaintTiles(i, j, changed, _table); // change and paint others
                changed.Add(new Point(i, j)); // because [i,j] also changed ...
                
                BlackCount = CountPlayer(Player.BLACK);
                WhiteCount = CountPlayer(Player.WHITE);
                
                CurrentPlayer = OtherPlayer(); // change current player

                OnTilesChanged(changed, Tile.MakeTileValue(OtherPlayer()));
                if (WhiteCount + BlackCount == Size * Size) { OnGameEnded(); }
            }
        }

        public void RandomMove()
        {
            if (AvailableTiles().Count == 0)
            {
                CurrentPlayer = OtherPlayer(); // change current player to pass

                if (AvailableTiles().Count == 0) { OnGameEnded(); } // game ends on double pass
            }
            else // TODO: Actually compute best move
            {
                List<Point> availables = AvailableTiles();

                Random random = new();

                int ind = random.Next(0, availables.Count);
                int x = availables[ind].X;
                int y = availables[ind].Y;

                _table.ChangeTileAt(x, y, Tile.MakeTileValue(CurrentPlayer));
                List<Point> changed = new(); PaintTiles(x, y, changed, _table); // change and paint others
                changed.Add(new Point(x, y)); // because [i,j] also changed ...

                BlackCount = CountPlayer(Player.BLACK);
                WhiteCount = CountPlayer(Player.WHITE);

                CurrentPlayer = OtherPlayer();// change current player

                OnTilesChanged(changed, Tile.MakeTileValue(OtherPlayer()));
                if (WhiteCount + BlackCount == Size * Size) { OnGameEnded(); }
            }
        }

        public void BestMove()
        {
            if (AvailableTiles().Count == 0)
            {
                CurrentPlayer = OtherPlayer(); // change current player to pass

                if (AvailableTiles().Count == 0) { OnGameEnded(); } // game ends on double pass
            }
            else // TODO: Actually compute best move
            {
                List<Point> availables = AvailableTiles();

                List<Table> tables = new();

                int maxScore = 0;
                int maxIndex = 0; // index to coordinates for best move
                for (int i = 0; i < availables.Count; i++)
                {
                    tables.Add(Table.CopyTable(_table));
                }
                for (int i = 0; i < availables.Count; i++)
                {
                    int x = availables[i].X; int y = availables[i].Y;
                    tables[i].ChangeTileAt(x, y, Tile.MakeTileValue(CurrentPlayer));
                    List<Point> points = new(); PaintTiles(x, y, points, tables[i]); points.Add(new Point(x, y));

                    if (points.Count > maxScore)
                    {
                        maxScore = points.Count; maxIndex = i;
                    }
                }

                int mx = availables[maxIndex].X;
                int my = availables[maxIndex].Y;

                _table.ChangeTileAt(mx, my, Tile.MakeTileValue(CurrentPlayer));
                List<Point> changed = new(); PaintTiles(mx, my, changed, _table); // change and paint others
                changed.Add(new Point(mx, my)); // because [i,j] also changed ...

                BlackCount = CountPlayer(Player.BLACK);
                WhiteCount = CountPlayer(Player.WHITE);

                CurrentPlayer = OtherPlayer();// change current player

                OnTilesChanged(changed, Tile.MakeTileValue(OtherPlayer()));
                if (WhiteCount + BlackCount == Size * Size) { OnGameEnded(); }
            }
        }

        /// Event triggers
        private void OnTilesChanged(List<Point> points, TileValue value) // tile changed trigger
        {
            TilesChanged?.Invoke(this, new TilesChangedEventArgs(points, value)); // invokes if not null
        }

        private void OnGameEnded() // game end trigger
        {
            GameEnded?.Invoke(this, EventArgs.Empty);
        }
        ///
    }
}
