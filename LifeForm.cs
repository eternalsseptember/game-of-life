﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConwayGameOfLife
{
	public partial class LifeForm : Form
	{
		private int CellsCount { get; set; }

		private int CellSize { get; } = 5;

		private Grid LifeGrid { get; set; }

		private Bitmap LifeBitmap { get; set; }

		private SolidBrush BrushCell { get; set; }

		private SolidBrush BrushGrid { get; set; }

		private Graphics PanelGraphics { get; set; }

		private Graphics BitmapGraphics { get; set; }

		private byte[,] CurrentPattern { get; set; } = Patterns.OneCell;

		private TimerState CurrentTimerState { get; set; } = 0;

		private enum TimerState
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
			LifeGrid.CreateEmptyCells();
		}

		private void ClearGrid()
		{
			CellsCount = 0;
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
					if (LifeGrid.Cells[x, y].IsAlive)
					{
						BitmapGraphics.FillRectangle(BrushCell, x * CellSize, y * CellSize, CellSize, CellSize);
						CellsCount++;
					}
				}
			}

			PanelGraphics.DrawImage(LifeBitmap, 0, 0);
		}

		private void NewGameClick(object sender, EventArgs e)
		{
			EnableControlsWhenStartGame();
			gameTimer.Start();
			CurrentTimerState = TimerState.On;
		}

		private void TimerTick(object sender, EventArgs e)
		{
			if (LifeGrid.IsGridRepeated())
			{
				ClearGameWhenGameOver();
				gameTimer.Stop();
				return;
			}

			LifeGrid.UpdateGridNextStep();
			UpdateGameStep();

			if (CellsCount == 0)
			{
				ClearGameWhenGameOver();
				gameTimer.Stop();
			}
		}

		private void EnableControlsWhenStartGame()
		{
			nextBtn.Enabled = true;
			pauseBtn.Enabled = true;
			resetBtn.Enabled = true;
			prevBtn.Enabled = true;
			randomBtn.Enabled = false;
			newGameBtn.Enabled = false;
		}

		private void DisableControlsWhenGameOver()
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

				LifeGrid.DrawPatternOnCells(e.X, e.Y, CurrentPattern);
				ClearGrid();
				DrawGrid();
			}

			popLabel.Text = CellsCount.ToString();
		}

		private void PauseClick(object sender, EventArgs e)
		{
			if (CurrentTimerState == TimerState.On)
			{
				gameTimer.Stop();
				CurrentTimerState = TimerState.Off;
			}
			else
			{
				gameTimer.Start();
				CurrentTimerState = TimerState.On;
			}
		}

		private void NextStepBtnClick(object sender, EventArgs e)
		{
			if (LifeGrid.IsGridRepeated())
			{
				ClearGameWhenGameOver();
				return;
			}

			LifeGrid.UpdateGridNextStep();
			UpdateGameStep();
		}

		private void ResetBtnClick(object sender, EventArgs e)
		{
			LifeGrid = null;
			gameTimer.Stop();
			ClearGrid();
			genLabel.Text = "0";
			popLabel.Text = "0";
			LifeGrid = new Grid(gamePanel.Width, gamePanel.Height, CellSize);
			LifeGrid.CreateEmptyCells();
			DrawGrid();
			DisableControlsWhenGameOver();
		}

		private void RandomPatternClick(object sender, EventArgs e)
		{
			LifeGrid.SetRandomPatternOnCells();
			EnableControlsWhenStartGame();
			gameTimer.Start();
			CurrentTimerState = TimerState.On;
		}

		private void PreviousStepBtnClick(object sender, EventArgs e)
		{
			LifeGrid.UpdateGridPreviousStep();
			UpdateGameStep();
		}

		private void ClearGameWhenGameOver()
		{
			DisableControlsWhenGameOver();
			CurrentTimerState = TimerState.Off;
			ClearGrid();
			LifeGrid = new Grid(gamePanel.Width, gamePanel.Height, CellSize);
			LifeGrid.CreateEmptyCells();
			DrawGrid();
		}

		private void UpdateGameStep()
		{
			ClearGrid();
			DrawGrid();
			genLabel.Text = LifeGrid.Generations.ToString();
			popLabel.Text = CellsCount.ToString();
		}
	}
}