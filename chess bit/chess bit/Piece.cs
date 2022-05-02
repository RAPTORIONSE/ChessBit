using System;
using System.Collections;
using System.Collections.Generic;

namespace chess_bit
{
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
}
