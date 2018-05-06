using System;

namespace ConwayGameOfLife
{
    public class Cell
    {
        public byte CountNeighbors { get; set; }

        public byte IsAlive { get; set; }

        public Cell(byte IsAlive)
        {
            this.IsAlive = IsAlive;
        }
    }
}
