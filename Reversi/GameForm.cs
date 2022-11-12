using Reversi.Model;
using Timer = System.Windows.Forms.Timer;

namespace Reversi
{
    public partial class GameForm : Form
    {
        private readonly Game _model; // Games model

        private Button[,] _buttonGrid = null!;

        private readonly Timer MoveTimer;
        private bool OnePlayer;

        public GameForm()
        {
            InitializeComponent(); ContextMenuStrip = contextMenu;

            _model = new Game();
            _model.TilesChanged += new EventHandler<TilesChangedEventArgs>(Game_TileChanged);
            _model.GameEnded += new EventHandler(Game_GameEnded);

            MoveTimer = new Timer {Interval = 1000};
            OnePlayer = false;

            MoveTimer.Tick += new EventHandler(MoveTimer_Tick);

            InitializeButtonGrid();
        }

        private void MoveTimer_Tick(object? sender, EventArgs e)
        {
            if (OnePlayer)
            {
                MoveTimer.Stop();
                //_model.RandomMove();
                _model.BestMove();
                UpdateButtonGrid(); UpdateStatusLabels();
                panel.Enabled = true;
            }
        }

        /// Model Event Handlers
        private void Game_GameEnded(object? sender, EventArgs e)
        {
            if (MoveTimer.Enabled) MoveTimer.Stop();
            UpdateStatusLabels();
            if (_model.BlackCount > _model.WhiteCount) // if black won
            {
                MessageBox.Show("Black won.", "Game over");
            }
            if (_model.BlackCount < _model.WhiteCount) // if white won
            {
                MessageBox.Show("White won.", "Game over");
            }
            if (_model.BlackCount == _model.WhiteCount) // on draw
            {
                MessageBox.Show("Draw.", "Game over");
            }
            RestartGame();
        }

        private void Game_TileChanged(object? sender, TilesChangedEventArgs e)
        {
            foreach (Point p in e.Points)
            {
                _buttonGrid[p.X, p.Y].BackgroundImage = e.Value == TileValue.BLACK
                    ? Image.FromFile(@".\resources\black.png")
                    : Image.FromFile(@".\resources\white.png");
            }
        }

        /// Private Methods
        private void InitializeButtonGrid()
        {
            int size = _model.Size;
            int bx = panel.Width  / size;
            int by = panel.Height / size;

            _buttonGrid = new Button[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Button button = new()
                    {
                        FlatStyle = FlatStyle.Flat,
                        Location  = new Point(j * bx, i * by),
                        Size      = new Size(bx, by),
                        Tag       = new Point(i, j)
                    };
                    button.FlatAppearance.BorderSize = 1;

                    if (_model.TileAt(i, j) == TileValue.BLACK) button.BackgroundImage = Image.FromFile(@".\resources\black.png");
                    if (_model.TileAt(i, j) == TileValue.WHITE) button.BackgroundImage = Image.FromFile(@".\resources\white.png");

                    button.Click += GameTableButton_Click;

                    _buttonGrid[i, j] = button;
                    panel.Controls.Add(button);
                }
            }

            UpdateButtonGrid();
        }
        
        private void UpdateButtonGrid() // updates available points on button grid
        {
            foreach (Button button in _buttonGrid)
            {
                Point coords = (Point) button.Tag;
                
                if (_model.TileAt(coords.X, coords.Y) == TileValue.EMPTY)
                {
                    button.BackgroundImage = null;
                }
            }

            List<Point> points = _model.AvailableTiles();

            //Console.Write("\nAvailable:\n"); // for debugging
            foreach (Point point in points)
            {
                _buttonGrid[point.X, point.Y].BackgroundImage = _model.CurrentPlayer == Player.BLACK
                    ? Image.FromFile(@".\resources\blackp.png")
                    : Image.FromFile(@".\resources\whitep.png");

                //Console.Write($"({point.X},{point.Y});"); // for debugging
            }
        }

        private void ResetButtonGrid()
        {
            for (int i = 0; i < _model.Size; i++)
            {
                for (int j = 0; j < _model.Size; j++)
                {
                    if (_model.TileAt(i, j) == TileValue.BLACK) _buttonGrid[i, j].BackgroundImage = Image.FromFile(@".\resources\black.png");
                    if (_model.TileAt(i, j) == TileValue.WHITE) _buttonGrid[i, j].BackgroundImage = Image.FromFile(@".\resources\white.png");
                }
            }
        }

        private void UpdateStatusLabels()
        {
            toolStripBlackCount.Text = $"Black: {_model.BlackCount}";
            toolStripWhiteCount.Text = $"White: {_model.WhiteCount}";
            toolStripPlayerLabel.Text = $"Player: {_model.CurrentPlayer}";
        }

        private void RestartGame()
        {
            _model.StartGame();
            ResetButtonGrid(); UpdateButtonGrid(); UpdateStatusLabels();
        }

        /// Form Event Handlers
        private void GameTableButton_Click(object? sender, EventArgs e)
        {
            Player player = _model.CurrentPlayer;

            if (sender is Button button)
            {
                Point? coords = (Point) button.Tag;

                if (coords != null)
                {
                    _model.Move(coords.Value.X, coords.Value.Y);
                    UpdateButtonGrid(); UpdateStatusLabels();
                }
            }
            if (OnePlayer && player != _model.CurrentPlayer) // if one player and actually moved
            {
                MoveTimer.Start(); panel.Enabled = false;
            }
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Restart") { RestartGame(); }

            if (e.ClickedItem.Text == "Exit") { Close(); }
        }

        private void contextMenuSetting_Click(object sender, EventArgs e) { }

        private void onePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnePlayer = true;
            RestartGame();
        }

        private void twoPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnePlayer = false;
            RestartGame();
        }
    }
}
