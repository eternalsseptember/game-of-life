using System;
using System.Collections.Generic;

namespace ConwayGameOfLife
{
    class Grid
    {
        private int CellSize { get; set; }
        public Cell[,] Cells;
        public int Generations { get; private set; } = 0;
        public int Width { get; private set; }
        public int Height { get; private set; }

        private List<Cell[,]> History { get; set; }

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="width">Ширина 'сетки'</param>
        /// <param name="height">Высота 'сетки'</param>
        public Grid(int width, int height, int cellSize)
        {
            this.CellSize = cellSize;
            this.Cells = new Cell[width / CellSize, height / CellSize];
            this.Width = width / CellSize;
            this.Height = height / CellSize;
            this.History = new List<Cell[,]>();
        }

        /// <summary>
        /// Обновление 'сетки' на 1 шаг вперёд
        /// </summary>
        public bool NextStepGridUpdate()
        {
            foreach (Cell[,] h in History)
            {
                if (CustomEquals(h, Cells))
                {
                    return false;
                }
            }

            Cell[,] TempForHistory = CopyCells(Cells);
            History.Add(TempForHistory);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    GetNeighbors(x, y);
                }
            }

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cells[x, y].IsAlive = Convert.ToByte(GetState(x, y));
                }
            }
            Generations++;
            return true;
        }

        /// <summary>
        /// Сравнение двух массивов
        /// </summary>
        public bool CustomEquals(Cell[,] cells1, Cell[,] cells2)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (cells1[i, j].IsAlive != cells2[i, j].IsAlive)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Создание копии сетки
        /// </summary>
        /// <param name="RefGrid">Сетка, которую нужно скопировать</param>
        /// <returns></returns>
        private Cell[,] CopyCells(Cell[,] RefGrid)
        {
            Cell[,] TempGrid = new Cell[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    TempGrid[i, j] = new Cell(RefGrid[i, j].IsAlive);
                }
            }
            return TempGrid;
        }

        /// <summary>
        /// Обновление 'сетки' на 1 шаг назад
        /// </summary>
        public void PrevStepGridUpdate()
        {
            int i = History.Count - 1;
            if (i >= 0)
            {
                Cells = History[i];
                History.RemoveAt(i);
                Generations--;
            }
        }

        /// <summary>
        /// Рандомно заполняем сетку
        /// </summary>
        public void RandomPatternGrid()
        {
            Random rnd = new Random();
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    byte rNum = Convert.ToByte(rnd.Next(0, 2));
                    Cells[i, j] = new Cell(rNum);
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
                    Cells[i, j] = new Cell(0);
                }
            }
        }

        /// <summary>
        /// Проверка индексов массива
        /// </summary>
        private bool CheckOutOfRange(int x, int y)
        {
            if (y < Height && x < Width && x >= 0 && y >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Подсчет живых соседей у клетки и запись количества
        /// соседей в свойство CountNeighbors
        /// </summary>
        private void GetNeighbors(int x, int y)
        {
            byte count = 0;
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (i == x && j == y)
                    {
                        continue;
                    }
                    if (CheckOutOfRange(i, j))
                    {
                        count += Convert.ToByte(Cells[i, j].IsAlive);
                    }
                }
            }
            Cells[x, y].CountNeighbors = count;
        }

        private bool GetState(int x, int y)
        {
            switch (Cells[x, y].CountNeighbors)
            {
                case 2:
                    return Convert.ToBoolean(Cells[x, y].IsAlive);
                case 3:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Конвертируем из рисунка в массив Cells
        /// </summary>
        public void SetCellsIntoDrawPanel(int x, int y, byte[,] pattern)
        {
            x = x / CellSize;
            y = y / CellSize;
            int patternWidth = pattern.GetLength(0);
            int patternHeight = pattern.GetLength(1);

            if (patternWidth <= Width && patternHeight <= Height)
            {
                for (int i = 0; i < patternWidth; i++)
                {
                    for (int j = 0; j < patternHeight; j++)
                    {
                        if (x + i < Width && y + j < Height)
                        {
                            Cells[x + i, y + j].IsAlive = pattern[i, j];
                        }
                    }
                }
            }
        }
    }
}
