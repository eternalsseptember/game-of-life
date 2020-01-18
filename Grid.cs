using System;
using System.Collections.Generic;

namespace ConwayGameOfLife
{
    class Grid
    {
        public Cell[,] Cells;

        public int Generations { get; private set; }

        public int Width { get; }

        public int Height { get; }

        private readonly int _cellSize;

		private readonly List<Cell[,]> _history;

		/// <summary>
		/// Конструктор 
		/// </summary>
		/// <param name="width">Ширина 'сетки'</param>
		/// <param name="height">Высота 'сетки'</param>
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
        public bool NextStepGridUpdate()
        {
	        if (IsGridRepeated())
	        {
		        return false;
			}

			_history.Add(CopyCells(Cells));

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
            Generations++;
            return true;
        }

        private bool IsGridRepeated()
        {
	        foreach (var h in _history)
	        {
		        if (CellGridEquals(h, Cells))
		        {
			        return true;
		        }
	        }

	        return false;
        }

        /// <summary>
        /// Сравнение двух массивов клеток
        /// </summary>
        public bool CellGridEquals(Cell[,] cells1, Cell[,] cells2)
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
        /// Создание копии сетки
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
        /// Обновление 'сетки' на 1 шаг назад
        /// </summary>
        public void PrevStepGridUpdate()
        {
            int i = _history.Count - 1;
            if (i >= 0)
            {
                Cells = _history[i];
                _history.RemoveAt(i);
                Generations--;
            }
        }

        /// <summary>
        /// Рандомно заполняем сетку
        /// </summary>
        public void RandomPatternGrid()
        {
            var rnd = new Random();
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    var isAlive = Convert.ToBoolean(rnd.Next(0, 2));
                    Cells[i, j] = new Cell(isAlive);
                }
            }
        }

        /// <summary>
        /// Создает сетку полностью заполненную нулями
        /// </summary>
        public void CreateEmptyGrid()
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
        /// Проверка на то, что индекс внутри массива
        /// </summary>
        private bool IsInBoundaries(int x, int y)
        {
	        return y < Height && x < Width && x >= 0 && y >= 0;
        }

        /// <summary>
        /// Подсчет живых соседей у клетки и запись количества
        /// соседей в свойство CountNeighbors
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
        /// Конвертируем из рисунка в массив Cells
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
    }
}
