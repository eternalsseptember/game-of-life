using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwayGameOfLife
{
	/// <summary>
	/// Сетка
	/// </summary>
	class Grid
	{
		/// <summary>
		/// Размер клетки
		/// </summary>
		private readonly int _cellSize;

		/// <summary>
		/// История
		/// </summary>
		private readonly List<Cell[,]> _history;

		/// <summary>
		/// Массив клеток
		/// </summary>
		public Cell[,] Cells;

		/// <summary>
		/// Счетчик поколения
		/// </summary>
		public int Generations { get; private set; }

		/// <summary>
		/// Ширина сетки
		/// </summary>
		public int Width { get; }

		/// <summary>
		/// Высота сетки
		/// </summary>
		public int Height { get; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="width">Ширина сетки</param>
		/// <param name="height">Высота сетки</param>
		/// <param name="cellSize">Размер клетки</param>
		public Grid(int width, int height, int cellSize)
		{
			Cells = new Cell[width / cellSize, height / cellSize];
			Width = width / cellSize;
			Height = height / cellSize;

			_cellSize = cellSize;
			_history = new List<Cell[,]>();
		}

		/// <summary>
		/// Обновление сетки на 1 шаг вперёд
		/// </summary>
		public void UpdateGridNextStep()
		{
			_history.Add(CopyCells(Cells));
			UpdateNextStepCells();
			Generations++;
		}

		/// <summary>
		/// Обновление сетки на 1 шаг назад
		/// </summary>
		public void UpdateGridPreviousStep()
		{
			var index = _history.Count - 1;
			if (index >= 0)
			{
				Cells = _history[index];
				_history.RemoveAt(index);
				Generations--;
			}
		}

		/// <summary>
		/// Заполнение массива клеток случайными значениями
		/// </summary>
		public void SetRandomPatternOnCells()
		{
			var random = new Random();
			for (int i = 0; i < Cells.GetLength(0); i++)
			{
				for (int j = 0; j < Cells.GetLength(1); j++)
				{
					var isAlive = Convert.ToBoolean(random.Next(0, 2));
					Cells[i, j] = new Cell(isAlive);
				}
			}
		}

		/// <summary>
		/// Создание массива клеток заполненного нулями
		/// </summary>
		public void CreateEmptyCells()
		{
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					Cells[i, j] = new Cell(false);
				}
			}
		}

		/// <summary>
		/// Конвертация из рисунка в массив Cells
		/// </summary>
		public void DrawPatternOnCells(int x, int y, byte[,] pattern)
		{
			x /= _cellSize;
			y /= _cellSize;
			var patternWidth = pattern.GetLength(0);
			var patternHeight = pattern.GetLength(1);

			for (int i = 0; i < patternWidth; i++)
			{
				for (int j = 0; j < patternHeight; j++)
				{
					if (x + i < Width && y + j < Height)
					{
						Cells[x + i, y + j].IsAlive = Convert.ToBoolean(pattern[i, j]);
					}
				}
			}
		}

		/// <summary>
		/// Проверка на повторение массива клеток за игру (периодическая конфигурация)
		/// </summary>
		/// <returns>Возвращает true, если сложилась периодическая конфигурация</returns>
		public bool IsGridRepeated()
		{
			return _history.Any(h => CellsEquals(h, Cells));
		}

		/// <summary>
		/// Сравнение двух массивов клеток
		/// </summary>
		/// <returns>Возвращает true, если массивы клеток равны</returns>
		private bool CellsEquals(Cell[,] cells1, Cell[,] cells2)
		{
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					if (cells1[i, j].IsAlive != cells2[i, j].IsAlive)
					{
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Создание копии массива клеток
		/// </summary>
		private Cell[,] CopyCells(Cell[,] cells)
		{
			var copiedCells = new Cell[Width, Height];
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					copiedCells[i, j] = new Cell(cells[i, j].IsAlive);
				}
			}

			return copiedCells;
		}

		/// <summary>
		/// Обновление живых соседей у клетки
		/// </summary>
		private void UpdateNeighbors(int x, int y)
		{
			var count = 0;
			for (int i = x - 1; i < x + 2; i++)
			{
				for (int j = y - 1; j < y + 2; j++)
				{
					if (i == x && j == y)
					{
						continue;
					}

					if (IsInBoundaries(i, j) && Cells[i, j].IsAlive)
					{
						count++;
					}
				}
			}

			Cells[x, y].SetAliveNeighbors(count);
		}

		/// <summary>
		/// Проверка на то, что индекс внутри массива
		/// </summary>
		private bool IsInBoundaries(int x, int y)
		{
			return y < Height && x < Width && x >= 0 && y >= 0;
		}

		/// <summary>
		/// Обновление массива клеток на 1 шаг вперёд
		/// </summary>
		private void UpdateNextStepCells()
		{
			for (int x = 0; x < Width; x++)
			{
				for (int y = 0; y < Height; y++)
				{
					UpdateNeighbors(x, y);
				}
			}

			for (int x = 0; x < Width; x++)
			{
				for (int y = 0; y < Height; y++)
				{
					Cells[x, y].UpdateState();
				}
			}
		}
	}
}