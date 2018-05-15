using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConwayGameOfLife
{
    public partial class LifeForm : Form
    {
        private int CountCells { get; set; }
        private int CellSize { get; set; } = 5;

        private Grid LifeGrid { get; set; }
        private Bitmap LifeBitmap { get; set; }
        private SolidBrush BrushCell { get; set; }
        private SolidBrush BrushGrid { get; set; }
        private Graphics PanelGraphics { get; set; }
        private Graphics BitmapGraphics { get; set; }

        private byte[,] CurrentPattern { get; set; } = Patterns.OneCell;
        private byte CurrTimerState { get; set; } = 0;


        private enum TimerState : byte
        {
            On = 1,
            Off = 0
        }

        public LifeForm()
        {
            InitializeComponent();
        }

        private void Loading(object sender, EventArgs e)
        {
            LifeGrid = new Grid(gamePanel.Width, gamePanel.Height, CellSize);
            PanelGraphics = gamePanel.CreateGraphics();
            LifeBitmap = new Bitmap(gamePanel.Width, gamePanel.Height);
            BrushCell = new SolidBrush(Color.WhiteSmoke);
            BrushGrid = new SolidBrush(Color.Black);
            LifeGrid.CreateEmptyGrid();
        }

        private void CleanGrid()
        {
            CountCells = 0;
            LifeBitmap = new Bitmap(gamePanel.Width, gamePanel.Height);
            BitmapGraphics = Graphics.FromImage(LifeBitmap);
            BitmapGraphics.Clear(gamePanel.BackColor);
        }

        private void DrawGrid()
        {
            for (int x = 0; x < LifeGrid.Width; x++)
            {
                for (int y = 0; y < LifeGrid.Height; y++)
                {
                    if (LifeGrid.Cells[x, y].IsAlive == 1)
                    {
                        BitmapGraphics.FillRectangle(BrushCell, x * CellSize, y * CellSize, CellSize, CellSize);
                        CountCells++;
                    }
                }
            }
            PanelGraphics.DrawImage(LifeBitmap, 0, 0);
        }

        private void NewGameClick(object sender, EventArgs e)
        {

            StartedGameEnableControls();
            gameTimer.Start();
            CurrTimerState = (byte)(TimerState.On);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            // Если сетка повторилась
            if (!LifeGrid.NextStepGridUpdate())
            {
                GameOverDisableControls();
                gameTimer.Stop();
                CurrTimerState = (byte)(TimerState.Off);
                CleanGrid();
                LifeGrid.CreateEmptyGrid();
                DrawGrid();
                return;
            }
            CleanGrid();
            DrawGrid();
            genLabel.Text = LifeGrid.Generations.ToString();
            popLabel.Text = CountCells.ToString();
            // Если не осталось живых ячеек
            if (CountCells == 0)
            {
                GameOverDisableControls();
                gameTimer.Stop();
                CurrTimerState = (byte)(TimerState.Off);
            }
        }

        private void StartedGameEnableControls()
        {
            nextBtn.Enabled = true;
            pauseBtn.Enabled = true;
            resetBtn.Enabled = true;
            prevBtn.Enabled = true;
            randomBtn.Enabled = false;
            newGameBtn.Enabled = false;
        }

        private void GameOverDisableControls()
        {
            nextBtn.Enabled = false;
            pauseBtn.Enabled = false;
            resetBtn.Enabled = false;
            prevBtn.Enabled = false;
            newGameBtn.Enabled = true;
            randomBtn.Enabled = true;
            genLabel.Text = "0";
            popLabel.Text = "0";
        }

        private void TimeScroll(object sender, EventArgs e)
        {
            gameTimer.Interval = UPSControl.Maximum - UPSControl.Value + 1;
        }

        private void GridClick(object sender, MouseEventArgs e)
        {
            if (LifeGrid != null)
            {
                switch (patternBox.SelectedIndex)
                {
                    case 0:
                        CurrentPattern = Patterns.OneCell;
                        break;
                    case 1:
                        CurrentPattern = Patterns.Blinker;
                        break;
                    case 2:
                        CurrentPattern = Patterns.Block;
                        break;
                    case 3:
                        CurrentPattern = Patterns.Glider;
                        break;
                    case 4:
                        CurrentPattern = Patterns.Python;
                        break;
                    case 5:
                        CurrentPattern = Patterns.ZdrShip;
                        break;
                    default:
                        CurrentPattern = Patterns.OneCell;
                        break;
                }
                LifeGrid.SetCellsIntoDrawPanel(e.X, e.Y, CurrentPattern);
                CleanGrid();
                DrawGrid();
            }
            popLabel.Text = CountCells.ToString();
        }

        private void PauseClick(object sender, EventArgs e)
        {
            if (CurrTimerState == 1)
            {
                gameTimer.Stop();
                CurrTimerState = (byte)(TimerState.Off);
            }
            else
            {
                gameTimer.Start();
                CurrTimerState = (byte)(TimerState.On);
            }
        }

        private void NextStepBtnClick(object sender, EventArgs e)
        {
            // Если сетка повторилась
            if (!LifeGrid.NextStepGridUpdate())
            {
                GameOverDisableControls();
                CurrTimerState = (byte)(TimerState.Off);
                CleanGrid();
                LifeGrid.CreateEmptyGrid();
                DrawGrid();
                return;
            }
            CleanGrid();
            DrawGrid();
            genLabel.Text = LifeGrid.Generations.ToString();
            popLabel.Text = CountCells.ToString();
        }

        private void ResetBtnClick(object sender, EventArgs e)
        {
            LifeGrid = null;
            gameTimer.Stop();
            CleanGrid();
            genLabel.Text = "0";
            popLabel.Text = "0";
            LifeGrid = new Grid(gamePanel.Width, gamePanel.Height, CellSize);
            LifeGrid.CreateEmptyGrid();
            DrawGrid();
            GameOverDisableControls();
        }

        private void RandomPatternClick(object sender, EventArgs e)
        {
            LifeGrid.RandomPatternGrid();
            StartedGameEnableControls();
            gameTimer.Start();
            CurrTimerState = (byte)(TimerState.On);
        }

        private void PrevStepBtnClick(object sender, EventArgs e)
        {
            LifeGrid.PrevStepGridUpdate();
            CleanGrid();
            DrawGrid();
            genLabel.Text = LifeGrid.Generations.ToString();
            popLabel.Text = CountCells.ToString();

        }
    }
}
