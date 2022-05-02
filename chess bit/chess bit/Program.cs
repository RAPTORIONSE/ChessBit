
namespace chess_bit
{
    class Program
    {
        public static bool running = true;
        static void Main(string[] args)
        {
            GameHandler gameHandler = new GameHandler();

            #region Commented code

            #region Defining Piece Type
            /*

            if (piece.bitArray[0] == true)
            {
                var b = ((Pawn)piece).bitArray[0];
            }

            else if (piece.bitArray[1])
            {
                if (piece.bitArray[2])
                {
                    var b = ((Queen)piece).bitArray[0];
                }
                else
                {
                    var b = ((Bishop)piece).bitArray[0];
                }
            }
            else if (piece.bitArray[2])
            {
                var b = ((Rook)piece).bitArray[0];
            }
            else if (piece.bitArray[3])
            {
                var b = ((Knight)piece).bitArray[0];
            }
            else
            {
                var b = ((King)piece).bitArray[0];
            }
            */
            #endregion

            #region Defining Board Byte Positions
            /*
            const byte GRID_0_A = 0b_00_0000;
            const byte GRID_1_A = 0b_10_0000;
            const byte GRID_2_A = 0b_01_0000;
            const byte GRID_3_A = 0b_11_0000;
            const byte GRID_4_A = 0b_00_1000;
            const byte GRID_5_A = 0b_10_1000;
            const byte GRID_6_A = 0b_01_1000;
            const byte GRID_7_A = 0b_11_1000;

            const byte GRID_0_B = 0b_00_0100;
            const byte GRID_1_B = 0b_10_0100;
            const byte GRID_2_B = 0b_01_0100;
            const byte GRID_3_B = 0b_11_0100;
            const byte GRID_4_B = 0b_00_1100;
            const byte GRID_5_B = 0b_10_1100;
            const byte GRID_6_B = 0b_01_1100;
            const byte GRID_7_B = 0b_11_1100;

            const byte GRID_0_C = 0b_00_0010;
            const byte GRID_1_C = 0b_10_0010;
            const byte GRID_2_C = 0b_01_0010;
            const byte GRID_3_C = 0b_11_0010;
            const byte GRID_4_C = 0b_00_1010;
            const byte GRID_5_C = 0b_10_1010;
            const byte GRID_6_C = 0b_01_1010;
            const byte GRID_7_C = 0b_11_1010;

            const byte GRID_0_D = 0b_00_0110;
            const byte GRID_1_D = 0b_10_0110;
            const byte GRID_2_D = 0b_01_0110;
            const byte GRID_3_D = 0b_11_0110;
            const byte GRID_4_D = 0b_00_1110;
            const byte GRID_5_D = 0b_10_1110;
            const byte GRID_6_D = 0b_01_1110;
            const byte GRID_7_D = 0b_11_1110;

            const byte GRID_0_E = 0b_00_0001;
            const byte GRID_1_E = 0b_10_0001;
            const byte GRID_2_E = 0b_01_0001;
            const byte GRID_3_E = 0b_11_0001;
            const byte GRID_4_E = 0b_00_1001;
            const byte GRID_5_E = 0b_10_1001;
            const byte GRID_6_E = 0b_01_1001;
            const byte GRID_7_E = 0b_11_1001;

            const byte GRID_0_F = 0b_00_0101;
            const byte GRID_1_F = 0b_10_0101;
            const byte GRID_2_F = 0b_01_0101;
            const byte GRID_3_F = 0b_11_0101;
            const byte GRID_4_F = 0b_00_1101;
            const byte GRID_5_F = 0b_10_1101;
            const byte GRID_6_F = 0b_01_1101;
            const byte GRID_7_F = 0b_11_1101;

            const byte GRID_0_G = 0b_00_0011;
            const byte GRID_1_G = 0b_10_0011;
            const byte GRID_2_G = 0b_01_0011;
            const byte GRID_3_G = 0b_11_0011;
            const byte GRID_4_G = 0b_00_1011;
            const byte GRID_5_G = 0b_10_1011;
            const byte GRID_6_G = 0b_01_1011;
            const byte GRID_7_G = 0b_11_1011;

            const byte GRID_0_H = 0b_00_0111;
            const byte GRID_1_H = 0b_10_0111;
            const byte GRID_2_H = 0b_01_0111;
            const byte GRID_3_H = 0b_11_0111;
            const byte GRID_4_H = 0b_00_1111;
            const byte GRID_5_H = 0b_10_1111;
            const byte GRID_6_H = 0b_01_1111;
            const byte GRID_7_H = 0b_11_1111;
            */
            #endregion

            #region Defining Team
            /*
            if (piece.bitArray[4])
            {
                piece.GetTeam();
            }
            else
            {
                piece.GetTeam();
            }
            */
            #endregion

            #region Define Active
            /*
            if (piece.bitArray[5])
            {
                piece.GetActive();
            }
            else
            {
                piece.GetActive();
            }
            */
            #endregion

            #region All game pieces //111_1_1_00000_111111  Type_Team_Alive_Unassigned_location

            /*
            const byte KING_WHITE_ALIVE = 0b_000_11;
            const byte QUEEN_WHITE_ALIVE = 0b_111_11;
            const byte BISHOP_WHITE_ALIVE = 0b_100_11;
            const byte KNIGHT_WHITE_ALIVE = 0b_010_11;
            const byte ROOK_WHITE_ALIVE = 0b_001_11;
            const byte PAWN_WHITE_ALIVE = 0b_101_11;
            */

            #endregion

            #endregion
        }
        #region enumerables
        public enum Team
        {
            White,
            Black
        };

        public enum Active
        {
            Alive,
            Dead
        };

        public enum BoardTile :
            byte
        {
            GRID_1_A = 0b_00_0000,
            GRID_1_B = 0b_00_0001,
            GRID_1_C = 0b_00_0010,
            GRID_1_D = 0b_00_0011,
            GRID_1_E = 0b_00_0100,
            GRID_1_F = 0b_00_0101,
            GRID_1_G = 0b_00_0110,
            GRID_1_H = 0b_00_0111,

            GRID_2_A = 0b_00_1000,
            GRID_2_B = 0b_00_1001,
            GRID_2_C = 0b_00_1010,
            GRID_2_D = 0b_00_1011,
            GRID_2_E = 0b_00_1100,
            GRID_2_F = 0b_00_1101,
            GRID_2_G = 0b_00_1110,
            GRID_2_H = 0b_00_1111,

            GRID_3_A = 0b_01_0000,
            GRID_3_B = 0b_01_0001,
            GRID_3_C = 0b_01_0010,
            GRID_3_D = 0b_01_0011,
            GRID_3_E = 0b_01_0100,
            GRID_3_F = 0b_01_0101,
            GRID_3_G = 0b_01_0110,
            GRID_3_H = 0b_01_0111,

            GRID_4_A = 0b_01_1000,
            GRID_4_B = 0b_01_1001,
            GRID_4_C = 0b_01_1010,
            GRID_4_D = 0b_01_1011,
            GRID_4_E = 0b_01_1100,
            GRID_4_F = 0b_01_1101,
            GRID_4_G = 0b_01_1110,
            GRID_4_H = 0b_01_1111,

            GRID_5_A = 0b_10_0000,
            GRID_5_B = 0b_10_0001,
            GRID_5_C = 0b_10_0010,
            GRID_5_D = 0b_10_0011,
            GRID_5_E = 0b_10_0100,
            GRID_5_F = 0b_10_0101,
            GRID_5_G = 0b_10_0110,
            GRID_5_H = 0b_10_0111,

            GRID_6_A = 0b_10_1000,
            GRID_6_B = 0b_10_1001,
            GRID_6_C = 0b_10_1010,
            GRID_6_D = 0b_10_1011,
            GRID_6_E = 0b_10_1100,
            GRID_6_F = 0b_10_1101,
            GRID_6_G = 0b_10_1110,
            GRID_6_H = 0b_10_1111,

            GRID_7_A = 0b_11_0000,
            GRID_7_B = 0b_11_0001,
            GRID_7_C = 0b_11_0010,
            GRID_7_D = 0b_11_0011,
            GRID_7_E = 0b_11_0100,
            GRID_7_F = 0b_11_0101,
            GRID_7_G = 0b_11_0110,
            GRID_7_H = 0b_11_0111,

            GRID_8_A = 0b_11_1000,
            GRID_8_B = 0b_11_1001,
            GRID_8_C = 0b_11_1010,
            GRID_8_D = 0b_11_1011,
            GRID_8_E = 0b_11_1100,
            GRID_8_F = 0b_11_1101,
            GRID_8_G = 0b_11_1110,
            GRID_8_H = 0b_11_1111
        };

        public enum ChessType : int
        {
            King = 0b_000,
            Queen = 0b_111,
            Bishop = 0b_100,
            Knight = 0b_010,
            Rook = 0b_001,
            Pawn = 0b_101
        };
        #endregion

    }
}