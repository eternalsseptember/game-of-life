namespace ConwayGameOfLife
{
    public class Cell
    {
        public int CountNeighbors { get; private set; }

        public bool IsAlive { get; set; }

        public Cell(bool isAlive)
        {
            this.IsAlive = isAlive;
        }

        public void SetAliveNeighbors(int count)
        {
	        CountNeighbors = count;
		}

        public void UpdateState()
        {
	        IsAlive = GetNextState();
        }

		private bool GetNextState()
        {
	        switch (CountNeighbors)
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
