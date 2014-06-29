using System;
using System.Collections.Generic;

namespace KnightTravails
{

    /// <summary>
    /// Abstract chess piece class. Individual pieces implement this class.
    /// </summary>
    abstract class Piece
    {
        /// <summary>
        /// (x, y) deltas that define the way in which the piece moves.
        /// This is defined by the pieces.
        /// </summary>
        protected abstract List<Tuple<int, int>> delta_moves
        {
            get;
        }

        /// <summary>
        /// Gets a list of squares that a piece could legally move to
        /// </summary>
        /// <param name="square">The square the piece will move from</param>
        /// <returns>List of all squares that the piece can move to</returns>
        public List<Square> get_possible_moves(Square square)
        {
            List<Square> adjacents = new List<Square>();

            //Loop through each of the possible ways the piece can move and return those that are valid
            foreach (Tuple<int, int> moves in delta_moves)
            {
                int delta_row = moves.Item1;
                int delta_col = moves.Item2;

                if (Square.is_valid_move(square, delta_row, delta_col))
                {
                    //It is valid to advance from this square in this way, add it to our list for return
                    adjacents.Add(new Square(square.Row + delta_row, square.Column + delta_col));
                }
            }

            return adjacents;
        }
    }

}
