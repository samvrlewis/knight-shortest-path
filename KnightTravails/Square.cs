using System;
using System.Collections.Generic;

namespace KnightTravails
{
    /// <summary>
    /// Represents a square on a chess board. 
    /// </summary>
    class Square
    {
        //Number of rows and columns in the board
        private static readonly int MAX_ROWS = 8;
        private static readonly int MAX_COLS = 8;

        //Ways the first row and column are represented in chess notation
        private static readonly char MIN_ROW_CHAR = 'A';
        private static readonly char MIN_COL_CHAR = '1';

        //The row and column of the chess board, 0 indexed
        private int row;
        private int column;

        /// <summary>
        /// Constructor for square. Takes a non sanitised string indicating the square location in chess notation.
        /// </summary>
        /// <param name="position">Square location in chess notation. Eg: "A8" or "H2"</param>
        public Square(string position)
        {
            //Make sure the location string is in upper case, this makes it easier later
            position = position.ToUpper();

            //Check that the position is of the right form
            if (position.Length != 2)
            {
                throw new ArgumentException("Not valid chess string.");
            }

            //Use the properties of ASCII to find if the input string is a valid chess string
            if (position[0] >= MIN_ROW_CHAR + MAX_ROWS || position[0] < MIN_ROW_CHAR)
            {
                throw new ArgumentException("Not valid chess string");
            }

            if (position[1] >= MIN_COL_CHAR + MAX_COLS || position[1] < MIN_COL_CHAR)
            {
                throw new ArgumentException("Not valid chess string");
            }

            //Inputs seem valid, use ascii properties to find the row and column 
            this.row = position[0] - MIN_ROW_CHAR;
            this.column = position[1] - MIN_COL_CHAR;
        }

        /// <summary>
        /// Alternate Square constructor that takes integer representations of the row and column.
        /// </summary>
        /// <param name="row">Row between 0 and MAX_ROWS</param>
        /// <param name="column">Column between 0 and MAX_COLUMN</param>
        public Square(int row, int column)
        {
            if ((row >= 0 && row < MAX_ROWS) && (column >= 0 && column < MAX_COLS))
            {
                this.row = row;
                this.column = column;
            }
            else
            {
                throw new ArgumentException("Row and column need to be between 0 and MAX_ROW/COL");
            }
        }

        //Public accessors
        public int Row { get { return this.row; } }
        public int Column { get { return this.column; } }

        /// <summary>
        /// Gets the representation of the square in chess notation
        /// </summary>
        /// <returns>A string of the square in chess notation, eg "A8"</returns>
        public string to_chess_notation()
        {
            //Again use the ascii properties of the chars
            char[] chars = { (char)(this.Row + MIN_ROW_CHAR), (char)(this.Column + MIN_COL_CHAR) };

            return new string(chars);
        }

        /// <summary>
        /// Finds if it is valid to move in a certain way from a square. 
        /// </summary>
        /// <param name="square">The square to move from</param>
        /// <param name="row_move">Number of steps to move in the row direction</param>
        /// <param name="col_move">Number of steps to move in the column direction</param>
        /// <returns>Whether the move is valid</returns>
        public static bool is_valid_move(Square square, int row_move, int col_move)
        {
            //Check if the row and column move keep the piece within the bounds of the board
            bool legal_row = (square.row + row_move >= 0) && (square.row + row_move < MAX_ROWS);
            bool legal_col = (square.column + col_move >= 0) && (square.column + col_move < MAX_COLS);

            return (legal_col && legal_row);
        }
    }
}
