using System;

namespace chess_bit
{
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

        private bool PawnWrapCheck(string grid, string comparedGrid, int expectedDifference)
        {
            int row = RowCheck(grid);                       // N%8==K,     N+8%8==K   (forward)
            if (comparedGrid == null)
            {
                return false;
            }
            int comparedRow = RowCheck(comparedGrid);       // N-1%8==K-1, N+7%8==K-1 (forward and left), Inverse this for right
            int expectedResult = row + expectedDifference;  // if K = 0 and K-1 != -1 then it has wrapped

            if (comparedRow == expectedResult)
            {
                return true;
            }
            return false;
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
        
        private int Max(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
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
            int i = 0;

            switch (selectedPiece.GetChessType())
            {
                case "King":
                    #region King //done
                    //OBS!!! Move to knight Class
                    string[] possibleMovementsKing = new string[8];//holds the grids for possible movements

                    possibleMovementsKing[0] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 9);//-1
                    possibleMovementsKing[1] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 1);//-1
                    possibleMovementsKing[2] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 7);//-1
                    possibleMovementsKing[3] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 8);//0
                    possibleMovementsKing[4] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 8);//0
                    possibleMovementsKing[5] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 7);//+1
                    possibleMovementsKing[6] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 1);//+1
                    possibleMovementsKing[7] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 9);//+1

                    for (; i < 3; i++)
                    {
                        bool occupied = false;
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (possibleMovementsKing[i] == piece.GetOccupiedGrid())
                            {
                                occupied = true;
                                if (piece.GetTeam() != color)
                                {
                                    Console.WriteLine("Can take on grid: " + possibleMovementsKing[i]);
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, possibleMovementsKing[i], -1))
                        {
                            if (!occupied)
                            {
                                Console.WriteLine("Can move to grid: " + possibleMovementsKing[i]);
                            }
                        }
                    }
                    for (; i < 5; i++)
                    {
                        bool occupied = false;
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (possibleMovementsKing[i] == piece.GetOccupiedGrid())
                            {
                                occupied = true;
                                if (piece.GetTeam() != color)
                                {
                                    Console.WriteLine("Can take on grid: " + possibleMovementsKing[i]);
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, possibleMovementsKing[i], 0))
                        {
                            if (!occupied)
                            {
                                Console.WriteLine("Can move to grid: " + possibleMovementsKing[i]);
                            }
                        }
                    }
                    for (; i < 8; i++)
                    {
                        bool occupied = false;
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (possibleMovementsKing[i] == piece.GetOccupiedGrid())
                            {
                                occupied = true;
                                if (piece.GetTeam() != color)
                                {
                                    Console.WriteLine("Can take on grid: " + possibleMovementsKing[i]);
                                }
                            }
                        }
                        if (!occupied)
                        {
                            if (PawnWrapCheck(grid, possibleMovementsKing[i], +1))
                            {
                                Console.WriteLine("Can move to grid: " + possibleMovementsKing[i]);
                            }
                        }
                    }
                    #endregion
                    break;
                case "Queen":
                    #region Queen //done
                    string[] possibleMovementsQueen = new string[27];//holds the grids for possible movements
                    int queenInt = 0;
                    bool occupiedQueen = false;

                    //populate Queen movement array
                    //Diagonals
                    for (i = 1; i < 8 && !occupiedQueen; i++)
                    {

                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) + i) * 8) + RowCheck(grid) + i);//1 right, 1 down
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, i))
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }
                    occupiedQueen = false;
                    for (i = 1; i < 8 && !occupiedQueen; i++)
                    {

                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) + i) * 8) + RowCheck(grid) - i);//1 right, 1 up
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, -i))
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, -i))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }
                    occupiedQueen = false;
                    for (i = 1; i < 8 && !occupiedQueen; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) - i) * 8) + RowCheck(grid) + i);//1 right, 1 down
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, i))
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }
                    occupiedQueen = false;
                    for (i = 1; i < 8 && !occupiedQueen; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) - i) * 8) + RowCheck(grid) - i);//1 right, 1 up
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, -i))
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, -i))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }
                    occupiedQueen = false;

                    //Straights
                    for (i = ColumnCheck(grid) + 1; i < 8 && !occupiedQueen; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), (i * 8) + RowCheck(grid));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, +0))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }
                    occupiedQueen = false;

                    for (i = ColumnCheck(grid) - 1; i >= 0 && !occupiedQueen; i--)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), (i * 8) + RowCheck(grid));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, +0))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }
                    occupiedQueen = false;

                    for (i = RowCheck(grid) + 1; i < 8 && !occupiedQueen; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), i + (ColumnCheck(grid) * 8));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i - RowCheck(grid)))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }
                    occupiedQueen = false;

                    for (i = RowCheck(grid) - 1; i >= 0 && !occupiedQueen; i--)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), i + (ColumnCheck(grid) * 8));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedQueen = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsQueen[queenInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsQueen[queenInt]);
                                    queenInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i - RowCheck(grid)))
                        {
                            if (!occupiedQueen)
                            {
                                possibleMovementsQueen[queenInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsQueen[queenInt]);
                                queenInt++;
                            }
                        }
                    }

                    #endregion
                    break;
                case "Bishop":
                    #region Bishop //done

                    string[] possibleMovementsBishop = new string[13];//holds the grids for possible movements
                    int bishopInt = 0;
                    bool occupiedBishop = false;

                    //populate bishop movement array
                    for (i = 1; i < 8 && !occupiedBishop; i++)
                    {

                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) + i) * 8) + RowCheck(grid) + i);//1 right, 1 down
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedBishop = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, i))
                                {
                                    possibleMovementsBishop[bishopInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsBishop[bishopInt]);
                                    bishopInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i))
                        {
                            if (!occupiedBishop)
                            {
                                possibleMovementsBishop[bishopInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsBishop[bishopInt]);
                                bishopInt++;
                            }
                        }
                    }
                    occupiedBishop = false;
                    for (i = 1; i < 8 && !occupiedBishop; i++)
                    {

                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) + i) * 8) + RowCheck(grid) - i);//1 right, 1 up
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedBishop = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, -i))
                                {
                                    possibleMovementsBishop[bishopInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsBishop[bishopInt]);
                                    bishopInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, -i))
                        {
                            if (!occupiedBishop)
                            {
                                possibleMovementsBishop[bishopInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsBishop[bishopInt]);
                                bishopInt++;
                            }
                        }
                    }
                    occupiedBishop = false;
                    for (i = 1; i < 8 && !occupiedBishop; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) - i) * 8) + RowCheck(grid) + i);//1 right, 1 down
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedBishop = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, i))
                                {
                                    possibleMovementsBishop[bishopInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsBishop[bishopInt]);
                                    bishopInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i))
                        {
                            if (!occupiedBishop)
                            {
                                possibleMovementsBishop[bishopInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsBishop[bishopInt]);
                                bishopInt++;
                            }
                        }
                    }
                    occupiedBishop = false;
                    for (i = 1; i < 8 && !occupiedBishop; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), ((ColumnCheck(grid) - i) * 8) + RowCheck(grid) - i);//1 right, 1 up
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedBishop = true;
                                if (piece.GetTeam() != color && PawnWrapCheck(grid, temp, -i))
                                {
                                    possibleMovementsBishop[bishopInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsBishop[bishopInt]);
                                    bishopInt++;
                                }
                                break;
                            }
                        }
                        if (PawnWrapCheck(grid, temp, -i))
                        {
                            if (!occupiedBishop)
                            {
                                possibleMovementsBishop[bishopInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsBishop[bishopInt]);
                                bishopInt++;
                            }
                        }
                    }
                    #endregion
                    break;
                case "Knight":
                    #region knight //done
                    //OBS!!! Move to knight Class
                    string[] possibleMovementsKnight = new string[8];//holds the grids for possible movements

                    possibleMovementsKnight[0] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 10);//-2
                    possibleMovementsKnight[1] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 6);//-2
                    possibleMovementsKnight[2] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 6);//+2
                    possibleMovementsKnight[3] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 10);//+2
                    possibleMovementsKnight[4] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 17);//-1
                    possibleMovementsKnight[5] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 15);//-1
                    possibleMovementsKnight[6] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) - 15);//+1
                    possibleMovementsKnight[7] = Enum.GetName(typeof(Program.BoardTile), (Program.BoardTile)Enum.Parse(typeof(Program.BoardTile), grid) + 17);//+1

                    for (; i < 2; i++)
                    {
                        bool occupied = false;
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (possibleMovementsKnight[i] == piece.GetOccupiedGrid())
                            {
                                occupied = true;
                                if (piece.GetTeam() != color)
                                {
                                    Console.WriteLine("Can take on grid: " + possibleMovementsKnight[i]);
                                }
                            }
                        }
                        if (!occupied)
                        {
                            if (PawnWrapCheck(grid, possibleMovementsKnight[i], -2))
                            {
                                Console.WriteLine("Can move to grid: " + possibleMovementsKnight[i]);
                            }
                        }
                    }
                    for (; i < 4; i++)
                    {
                        bool occupied = false;
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (possibleMovementsKnight[i] == piece.GetOccupiedGrid())
                            {
                                occupied = true;
                                if (piece.GetTeam() != color)
                                {
                                    Console.WriteLine("Can take on grid: " + possibleMovementsKnight[i]);
                                }
                            }
                        }
                        if (!occupied)
                        {
                            if (PawnWrapCheck(grid, possibleMovementsKnight[i], +2))
                            {
                                Console.WriteLine("Can move to grid: " + possibleMovementsKnight[i]);
                            }
                        }
                    }
                    for (; i < 6; i++)
                    {
                        bool occupied = false;
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (possibleMovementsKnight[i] == piece.GetOccupiedGrid())
                            {
                                occupied = true;
                                if (piece.GetTeam() != color)
                                {
                                    Console.WriteLine("Can take on grid: " + possibleMovementsKnight[i]);
                                }
                            }
                        }
                        if (!occupied)
                        {
                            if (PawnWrapCheck(grid, possibleMovementsKnight[i], -1))
                            {
                                Console.WriteLine("Can move to grid: " + possibleMovementsKnight[i]);
                            }
                        }
                    }
                    for (; i < 8; i++)
                    {
                        bool occupied = false;
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (possibleMovementsKnight[i] == piece.GetOccupiedGrid())
                            {
                                occupied = true;
                                if (piece.GetTeam() != color)
                                {
                                    Console.WriteLine("Can take on grid: " + possibleMovementsKnight[i]);
                                }
                            }
                        }
                        if (!occupied)
                        {
                            if (PawnWrapCheck(grid, possibleMovementsKnight[i], +1))
                            {
                                Console.WriteLine("Can move to grid: " + possibleMovementsKnight[i]);
                            }
                        }
                    }
                    #endregion
                    break;
                case "Rook":
                    #region Rook //done
                    //OBS!!! Move to rook Class
                    string[] possibleMovementsRook = new string[14];//holds the grids for possible movements
                    int rookInt = 0;
                    bool occupiedRook = false;

                    //populate rook movement array
                    for (i = ColumnCheck(grid) + 1; i < 8 && !occupiedRook; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), (i * 8) + RowCheck(grid));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedRook = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsRook[rookInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsRook[rookInt]);
                                    rookInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, +0))
                        {
                            if (!occupiedRook)
                            {
                                possibleMovementsRook[rookInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsRook[rookInt]);
                                rookInt++;
                            }
                        }
                    }
                    occupiedRook = false;

                    for (i = ColumnCheck(grid) - 1; i >= 0 && !occupiedRook; i--)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), (i * 8) + RowCheck(grid));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedRook = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsRook[rookInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsRook[rookInt]);
                                    rookInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, +0))
                        {
                            if (!occupiedRook)
                            {
                                possibleMovementsRook[rookInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsRook[rookInt]);
                                rookInt++;
                            }
                        }
                    }
                    occupiedRook = false;

                    for (i = RowCheck(grid) + 1; i < 8 && !occupiedRook; i++)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), i + (ColumnCheck(grid) * 8));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedRook = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsRook[rookInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsRook[rookInt]);
                                    rookInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i - RowCheck(grid)))
                        {
                            if (!occupiedRook)
                            {
                                possibleMovementsRook[rookInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsRook[rookInt]);
                                rookInt++;
                            }
                        }
                    }
                    occupiedRook = false;

                    for (i = RowCheck(grid) - 1; i >= 0 && !occupiedRook; i--)
                    {
                        string temp = Enum.GetName(typeof(Program.BoardTile), i + (ColumnCheck(grid) * 8));
                        foreach (var piece in _allPieces)//check all pieces to see if the grid is occupied or not
                        {
                            if (temp == piece.GetOccupiedGrid())
                            {
                                occupiedRook = true;
                                if (piece.GetTeam() != color)
                                {
                                    possibleMovementsRook[rookInt] = temp;
                                    Console.WriteLine("Can take on grid: " + possibleMovementsRook[rookInt]);
                                    rookInt++;
                                }
                            }
                        }
                        if (PawnWrapCheck(grid, temp, i - RowCheck(grid)))
                        {
                            if (!occupiedRook)
                            {
                                possibleMovementsRook[rookInt] = temp;
                                Console.WriteLine("Can move to grid: " + possibleMovementsRook[rookInt]);
                                rookInt++;
                            }
                        }
                    }
                    #endregion
                    break;
                case "Pawn":
                    #region Pawn //Move to Pawn class, needs refactoring, done
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
