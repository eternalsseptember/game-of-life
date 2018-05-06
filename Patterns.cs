
namespace ConwayGameOfLife
{
    class Patterns
    {
        static public byte[,] OneCell = new byte[,] { { 1 } };

        static public byte[,] Blinker = new byte[,] { { 1, 1, 1 } };

        static public byte[,] Block = new byte[,] { { 1, 1 }, { 1, 1 } };

        static public byte[,] Glider = new byte[,] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 } };

        static public byte[,] Python = new byte[,] { { 0, 0, 0, 1, 1 }, { 1, 0, 1, 0, 1 }, { 1, 1, 0, 0, 0 } };

        static public byte[,] ZdrShip = new byte[,] { { 0, 1, 1, 0, 0, 1, 1, 0},
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
