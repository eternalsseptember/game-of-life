namespace ConwayGameOfLife
{
	class Patterns
	{
		public static byte[,] OneCell = {{1}};

		public static byte[,] Blinker = {{1, 1, 1}};

		public static byte[,] Block = {{1, 1}, {1, 1}};

		public static byte[,] Glider = {{1, 1, 1}, {1, 0, 0}, {0, 1, 0}};

		public static byte[,] Python = {{0, 0, 0, 1, 1}, {1, 0, 1, 0, 1}, {1, 1, 0, 0, 0}};

		public static byte[,] ZdrShip =
		{
			{0, 1, 1, 0, 0, 1, 1, 0},
			{0, 0, 0, 1, 1, 0, 0, 0},
			{0, 0, 0, 1, 1, 0, 0, 0},
			{1, 0, 1, 0, 0, 1, 0, 1},
			{1, 0, 0, 0, 0, 0, 0, 1},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{1, 0, 0, 0, 0, 0, 0, 1},
			{0, 1, 1, 0, 0, 1, 1, 0},
			{0, 0, 1, 1, 1, 1, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 1, 1, 0, 0, 0},
			{0, 0, 0, 1, 1, 0, 0, 0}
		};
	}
}