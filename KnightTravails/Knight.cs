using System;
using System.Collections.Generic;

namespace KnightTravails
{
    /// <summary>
    /// Represents a knight on the chess board.
    /// Only really just defines the ways in which the knight can move on the chess board.
    /// </summary>
    class Knight : Piece
    {
        /// <summary>
        /// Ways in which the knight can move. Each tuple is representative of (row move, col move). 
        /// </summary>
        private static readonly List<Tuple<int, int>> knight_moves = new List<Tuple<int, int>>
        {
            Tuple.Create(1, 2),
            Tuple.Create(-1, 2),
            Tuple.Create(1, -2),
            Tuple.Create(-1, -2),

            Tuple.Create(2, 1),
            Tuple.Create(-2, 1),
            Tuple.Create(2, -1),
            Tuple.Create(-2, -1)
        };

        protected override List<Tuple<int, int>> delta_moves
        {
            get { return knight_moves; }
        }
    }
}
