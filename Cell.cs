namespace ConwayGameOfLife
{
	/// <summary>
	/// Клетка
	/// </summary>
	public class Cell
	{
		/// <summary>
		/// Количество живых соседей у клетки
		/// </summary>
		public int AliveNeighborsCount { get; private set; }

		/// <summary>
		/// Флаг живой клетки
		/// </summary>
		public bool IsAlive { get; set; }

		public Cell(bool isAlive)
		{
			this.IsAlive = isAlive;
		}

		/// <summary>
		/// Заполнение количества живых соседей у клетки
		/// </summary>
		public void SetAliveNeighbors(int count)
		{
			AliveNeighborsCount = count;
		}

		/// <summary>
		/// Обновление состояния клетки
		/// </summary>
		public void UpdateState()
		{
			IsAlive = GetNextState();
		}

		/// <summary>
		/// Вычисление состояния клетки по количеству живых соседей у клетки
		/// </summary>
		private bool GetNextState()
		{
			switch (AliveNeighborsCount)
			{
				case 2:
					return IsAlive;
				case 3:
					return true;
				default:
					return false;
			}
		}
	}
}