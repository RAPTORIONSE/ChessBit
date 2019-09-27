using System;
using System.Collections;
using System.Collections.Generic;


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

    internal class Piece
    {
        public BitArray bitArray = new BitArray(16);

        public Piece(Program.Team team, Program.Active active, Program.ChessType chessType, Program.BoardTile boardTile)
        {
            SetChessType(chessType);
            SetOccupiedGrid(boardTile);
            SetTeam((int)team);
            SetActive((int)active);
        }

        #region OccupiedGrid

        public string GetOccupiedGrid()
        {
            //takes the bits allocated for position management gives the name of the grid
            return Enum.GetName(typeof(Program.BoardTile), ToByte(bitArray[10]) << 5 | ToByte(bitArray[11]) << 4 | ToByte(bitArray[12]) << 3 | ToByte(bitArray[13]) << 2 | ToByte(bitArray[14]) << 1 | ToByte(bitArray[15]));
        }

        public void SetOccupiedGrid(Program.BoardTile boardTile)
        {
            int[] intArray = new int[6];
            int[] splitBytes = SplitEnum((int)boardTile); //the creation of lacking zeroes is done with creation of length == 6 array.
            Array.Copy(splitBytes, 0, intArray, 6 - splitBytes.Length, splitBytes.Length);
            bitArray.Set(10, ToBool(intArray[0]));
            bitArray.Set(11, ToBool(intArray[1]));
            bitArray.Set(12, ToBool(intArray[2]));
            bitArray.Set(13, ToBool(intArray[3]));
            bitArray.Set(14, ToBool(intArray[4]));
            bitArray.Set(15, ToBool(intArray[5]));
        }

        #endregion

        #region ChessType

        public string GetChessType()
        {
            //takes the bits allocated for type management gives the name for the chess type
            return Enum.GetName(typeof(Program.ChessType), ToByte(bitArray[0]) << 2 | ToByte(bitArray[1]) << 1 | ToByte(bitArray[2]));
        }

        public void SetChessType(Program.ChessType chessType)
        {
            int[] intArray = new int[3];
            int[] splitBytes = SplitEnum((int)chessType);
            Array.Copy(splitBytes, 0, intArray, 3 - splitBytes.Length, splitBytes.Length);
            bitArray.Set(0, ToBool(intArray[0]));
            bitArray.Set(1, ToBool(intArray[1]));
            bitArray.Set(2, ToBool(intArray[2]));
        }

        #endregion

        #region Team

        public string GetTeam()
        {
            return Enum.GetName(typeof(Program.Team), ToByte(bitArray[4]));
        }

        public void SetTeam(int b)
        {
            bitArray.Set(4, ToBool(b));
        }
        #endregion

        #region Active

        public string GetActive()
        {
            return Enum.GetName(typeof(Program.Active), ToByte(bitArray[5]));
        }

        public void SetActive(int b)
        {
            bitArray.Set(5, ToBool(b));
        }

        #endregion

        #region Utility methodes

        public int ToByte(bool b)
        {
            return b ? 1 : 0; //returns 1 if b is true and 0 if b is false
        }

        public bool ToBool(int b)
        {
            return b == 1;
        }

        public int ToBinary(int b)
        {
            return Convert.ToInt32(Convert.ToString(b, 2));

            #region Old conversion code unsure why not work

            /*
            int result = 0;
            bool firstOne = false;
            int passesWithZero = 0;
            while (b > 0)
            {
                int remainder = (b % 2);
                b /= 2;
                if (!firstOne)
                {
                    if (remainder == 0)
                    {
                        passesWithZero++;
                    }
                    else
                    {
                        firstOne = true;
                    }
                }
                result = (result * 10 + remainder);
            }

            for (int i = 0; i < passesWithZero; i++)// fel här?? förändrar representation
            {
                result = result * 10;
            }

            return result;
            */
            #endregion
        }

        public int[] SplitEnum(int number)
        {
            number = ToBinary(number);
            Stack<int> stack = new Stack<int>(); //used as the rightmost value gets separated out first until value is less then 0
            while (number > 0)
            {
                stack.Push(number % 10);
                number = (int)(number / 10);
            }
            int[] intArray = new int[stack.Count];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = (int)stack.Pop();

            }
            return intArray;
        }
        #endregion
    }

    #region Piece derived classes
    //internal class Knight : Piece
    //{

    //}

    //internal class Rook : Piece
    //{

    //}

    //internal class Bishop : Piece
    //{

    //}

    //internal class Queen : Piece
    //{

    //}

    //internal class King : Piece
    //{

    //}

    //internal class Pawn : Piece
    //{

    //}
    #endregion

    #region Handler

    public class GameHandler
    {
        Piece[] _allPieces = new Piece[32];
        Piece selectedPiece;

        public GameHandler()
        {
            Initialize();
            do
            {
                Clear();
                Update();
                Draw();
            } while (true);
        }

        #region Wrapping checks

        private int RowCheck(string grid) //returns the row
        {
            int row = ((int)((Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid))) % 8; //gets the value of the row with 0 being leftmost and 7 being rightmost
            return row;
        }

        private int ColumnCheck(string grid)//return the column
        {
            int column = ((int)((Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid))) / 8;//gets the value of the Column with 0 being bottom and 7 being top
            return column;
        }

        private bool PawnWrapCheck(string grid, string comparedGrid, int expectedDifference) //OBS!!! Generic wrap check
        {
            int row = RowCheck(grid);                       // N%8==K,     N+8%8==K   (forward)
            int comparedRow = RowCheck(comparedGrid);       // N-1%8==K-1, N+7%8==K-1 (forward and left), Inverse this for right
            int expectedResult = row + expectedDifference;  // if K = 0 and K-1 != -1 then it has wrapped

            if (comparedRow == expectedResult)
            {
                return true;
            }

            return false;
        }

        private bool RookPathing(string grid, string color, ref int gridsUpp, byte direction)
        {
            //recursive function
            string eval = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - direction); //gets the tile upp from grid

            if (PawnWrapCheck(grid, eval, direction))//if it wrapes then, don't check anymore
            {
                foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                {
                    if (eval == piece.GetOccupiedGrid())
                    {
                        if (piece.GetTeam() != color) //check so it's an enemy
                        {
                            return true;//hostile at evaluated square
                        }

                        break;//stop recursive check
                    }
                    else
                    {
                        gridsUpp++;
                        RookPathing(grid, color, ref gridsUpp, direction);
                        break;//stop recursive check
                    }
                }
            }
            return false; //stop recursive check, no hostile found

        }

        #endregion

        private void Initialize()
        {
            #region White Pieces

            var boardTile = Program.BoardTile.GRID_2_A;
            for (int i = 0; i < 8; i++)
            {
                _allPieces[i] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Pawn, boardTile);

                boardTile = boardTile + 0b1;
            }
            _allPieces[8] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Rook, Program.BoardTile.GRID_1_A);
            _allPieces[9] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Knight, Program.BoardTile.GRID_1_B);
            _allPieces[10] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Bishop, Program.BoardTile.GRID_1_C);
            _allPieces[11] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Queen, Program.BoardTile.GRID_1_D);
            _allPieces[12] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.King, Program.BoardTile.GRID_1_E);
            _allPieces[13] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Bishop, Program.BoardTile.GRID_1_F);
            _allPieces[14] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Knight, Program.BoardTile.GRID_1_G);
            _allPieces[15] = new Piece(Program.Team.White, Program.Active.Alive, Program.ChessType.Rook, Program.BoardTile.GRID_1_H);

            #endregion

            #region Black Pieces

            boardTile = Program.BoardTile.GRID_7_A;
            for (int i = 16; i < 24; i++)
            {
                _allPieces[i] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Pawn, boardTile);

                boardTile = boardTile + 0b1;
            }
            _allPieces[24] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Rook, Program.BoardTile.GRID_8_A);
            _allPieces[25] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Knight, Program.BoardTile.GRID_8_B);
            _allPieces[26] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Bishop, Program.BoardTile.GRID_8_C);
            _allPieces[27] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Queen, Program.BoardTile.GRID_8_D);
            _allPieces[28] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.King, Program.BoardTile.GRID_8_E);
            _allPieces[29] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Bishop, Program.BoardTile.GRID_8_F);
            _allPieces[30] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Knight, Program.BoardTile.GRID_8_G);
            _allPieces[31] = new Piece(Program.Team.Black, Program.Active.Alive, Program.ChessType.Rook, Program.BoardTile.GRID_8_H);


            #endregion
        }

        private void Update()
        {
            foreach (var piece in _allPieces)
            {
                Console.WriteLine(piece.GetChessType() + " " + piece.GetTeam() + " " + piece.GetActive() + " " + piece.GetOccupiedGrid());
            }
            InputTaskSender();
        }

        private void Draw()
        {

        }

        private void Clear()
        {
            Console.Clear();
        }

        private void InputTaskSender()
        {
            bool endTurn = false;
            do
            {
                Console.WriteLine("Start of new input");
                string userInput = Console.ReadLine();
                userInput.ToUpper();
                var userInputs = userInput.Split(' ');
                switch (userInputs[0])
                {
                    case "SELECT":
                        Console.WriteLine("Entered select");
                        Select(userInputs[1]);
                        break;
                    case "MOVE":
                        Console.WriteLine("Entered Move");
                        endTurn = Move(userInputs[1]);
                        break;
                    case "TAKE":
                        Console.WriteLine("entered Take");
                        endTurn = Take(userInputs[1]);
                        break;
                    default:
                        break;
                }

            } while (!endTurn);
        }

        private void Select(string gridFrom)
        {
            foreach (var piece in _allPieces)
            {
                if (piece.GetOccupiedGrid() == gridFrom)
                {
                    if (piece.GetActive() == "Alive")
                    {
                        selectedPiece = piece;
                        Clear();
                        Console.WriteLine("Selected " + selectedPiece.GetChessType() + " at " + selectedPiece.GetOccupiedGrid() + " of color " + selectedPiece.GetTeam());
                        ShowLegalMoves();
                        return;
                    }
                }
            }
            Console.WriteLine("Failed to select piece");
        }

        private void ShowLegalMoves()
        {
            var grid = selectedPiece.GetOccupiedGrid();
            var color = selectedPiece.GetTeam();
            switch (selectedPiece.GetChessType())
            {
                case "King":
                    break;
                case "Queen":
                    break;
                case "Bishop":
                    break;
                case "Knight":
                    break;
                case "Rook":
                    #region rook
                    int upp = 0;
                    int down = 0;
                    int left = 0;
                    int right = 0;

                    //recursive function
                    bool enemyUppRookPathing = RookPathing(grid, color, ref upp, unchecked((byte)-1));
                    bool enemyDownRookPathing = RookPathing(grid, color, ref down, (byte)+1);
                    bool enemyLeftRookPathing = RookPathing(grid, color, ref left, unchecked((byte)-8));
                    bool enemyRightRookPathing1 = RookPathing(grid, color, ref right, (byte)+8);

                    for (byte i = 0; i < upp; i++)
                    {
                        Console.WriteLine("Can move to grid: " + Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - i));
                    }
                    for (byte i = 0; i < down; i++)
                    {
                        Console.WriteLine("Can move to grid: " + Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + i));
                    }
                    for (byte i = 0; i < left; i++)
                    {
                        Console.WriteLine("Can move to grid: " + Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - unchecked((byte)(i * 8))));
                    }
                    for (byte i = 0; i < right; i++)
                    {
                        Console.WriteLine("Can move to grid: " + Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + (byte)(i * 8)));
                    }


                    #endregion
                    break;
                case "Pawn":
                    #region Pawn //Move to Pawn class
                    //OBS!!! Move to pawn Class
                    string forwardOne = "";//holds the grids for possible movements
                    string takeUpp = "";
                    string takeDown = "";
                    bool fowardOneOccupied = false; //used to return valid moves to user.
                    bool enemyUpp = false;
                    bool enemyDown = false;

                    switch (color)//black moves down and white upp
                    {
                        //Get grids for possible movement, 8 is forward, 7&9 is sideways.
                        case "Black":
                            forwardOne = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 8);
                            takeDown = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 7);
                            takeUpp = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 9);
                            break;
                        //NOTICE that takeUpp and takeDown is swapped for white and black
                        case "White":
                            forwardOne = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 8);
                            takeUpp = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 7);
                            takeDown = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 9);
                            break;
                    }

                    foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                    {
                        if (forwardOne == piece.GetOccupiedGrid())
                        {
                            fowardOneOccupied = !fowardOneOccupied;
                        }

                        if (PawnWrapCheck(grid, takeUpp, -1))//think of a way to only do this check once as if it is false the move is illegal
                        {
                            if (takeUpp == piece.GetOccupiedGrid())
                            {
                                if (piece.GetTeam() != color) //check so it's an enemy
                                {
                                    enemyUpp = !enemyUpp;
                                }
                            }
                        }

                        if (PawnWrapCheck(grid, takeDown, 1))//think of a way to only do this check once as if it is false the move is illegal
                        {
                            if (takeDown == piece.GetOccupiedGrid())
                            {
                                if (piece.GetTeam() != color) //check so it's an enemy
                                {
                                    enemyDown = !enemyDown;
                                }
                            }
                        }
                    }
                    //printout of legal moves.
                    if (!fowardOneOccupied)
                    {
                        Console.WriteLine("Can move to grid: " + forwardOne);
                    }

                    if (enemyUpp)
                    {
                        Console.WriteLine("Can take on grid: " + takeUpp);
                    }
                    if (enemyDown)
                    {
                        Console.WriteLine("Can take on grid: " + takeDown);
                    }
                    //Check to see if grid in front is occupied + if has not moved check 2 grids in front
                    //check to see if grid diagonal in front is occupied by hostile
                    #endregion
                    break;

            }
        }

        private bool Take(string gridTo) // take user command, orders the selected piece to occupy a grid of a hostile piece
        {
            if (selectedPiece == null)
            {
                return false;
            }
            foreach (var piece in _allPieces)
            {
                if (piece.GetOccupiedGrid() == gridTo && piece.GetTeam() != selectedPiece.GetTeam())
                {
                    piece.SetActive(1);
                    Console.WriteLine("Took " + piece.GetChessType() + " on " + piece.GetOccupiedGrid() + " with " + selectedPiece.GetChessType() + " from " + selectedPiece.GetOccupiedGrid());
                    selectedPiece.SetOccupiedGrid((Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), gridTo));
                    Clear();
                    selectedPiece = null;
                    return true;
                }
            }
            Console.WriteLine("Unable to take");
            return false;

        }

        private bool Move(string gridTo) // take user command, orders the selected piece to occupy a specific unoccupied grid
        {
            if (selectedPiece == null)
            {
                return false;
            }
            //Parse Move Grid_A_3 to Grid_A_4
            //Select piece Grid_A_3
            //SetGrid Grid_A_4
            foreach (var piece in _allPieces)
            {
                if (piece.GetOccupiedGrid() == gridTo && piece.GetActive() == "Alive")//might be a dead piece on that grid.
                {
                    Console.WriteLine("Illegal move entered");
                    return false;
                }
            }
            selectedPiece.SetOccupiedGrid((Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), gridTo));
            Clear();
            Console.WriteLine("Moved " + selectedPiece.GetChessType() + " to " + selectedPiece.GetOccupiedGrid());
            selectedPiece = null;
            return true;
        }
    }
}
#endregion
