namespace ConwayGameOfLife
{
    class Patterns
    {
        public static byte[,] OneCell = new byte[,] { { 1 } };

        public static byte[,] Blinker = new byte[,] { { 1, 1, 1 } };

        public static byte[,] Block = new byte[,] { { 1, 1 }, { 1, 1 } };

        public static byte[,] Glider = new byte[,] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 } };

        public static byte[,] Python = new byte[,] { { 0, 0, 0, 1, 1 }, { 1, 0, 1, 0, 1 }, { 1, 1, 0, 0, 0 } };

        public static byte[,] ZdrShip = new byte[,] { { 0, 1, 1, 0, 0, 1, 1, 0},
                                                      { 0, 0, 0, 1, 1, 0, 0, 0},
                                                      { 0, 0, 0, 1, 1, 0, 0, 0},
                                                      { 1, 0, 1, 0, 0, 1, 0, 1},
                                                      { 1, 0, 0, 0, 0, 0, 0, 1},
                                                      { 0, 0, 0, 0, 0, 0, 0, 0},
                                                      { 1, 0, 0, 0, 0, 0, 0, 1},
                                                      { 0, 1, 1, 0, 0, 1, 1, 0},
                                                      { 0, 0, 1, 1, 1, 1, 0, 0},
                                                      { 0, 0, 0, 0, 0, 0, 0, 0},
                                                      { 0, 0, 0, 1, 1, 0, 0, 0},
                                                      { 0, 0, 0, 1, 1, 0, 0, 0} };
    }
}
