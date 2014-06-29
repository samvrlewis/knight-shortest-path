using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightTravails
{
    /// <summary>
    /// Class containing methods and helpers for solving the Knights Trevails problem
    /// </summary>
    static class KnightTravailsSolver
    {
        /// <summary>
        /// Uses a breadth first search to find a shortest path between two squares, given a certain chess piece
        /// </summary>
        /// <param name="start">The starting square</param>
        /// <param name="end">The ending square</param>
        /// <param name="piece">The piece that should be used to move between the squares</param>
        /// <returns>A list of squares, showing a shortest path if there is one or an empty list if there is no solution</returns>
        public static List<Square> find_shortest_solution(Square start, Square end, Piece piece)
        {
            //Queue of possible solutions. This allows a partly completed solution/path to be remembered so that when a solution is found, the path that was taken to the solution is known
            Queue<List<Square>> queue = new Queue<List<Square>>();
            List<Square> visited = new List<Square>(); //List of squares that have been visited
            
            //The first possible solution we'll try. This is just the first square and all solutions after this will branch out from this
            List<Square> start_solution = new List<Square>(); 
            start_solution.Add(start);

            queue.Enqueue(start_solution);
            visited.Add(start);

            while (queue.Count != 0)
            {
                List<Square> current_solution = queue.Dequeue(); //Get the partly completed path that's on top of the queue
                Square current_square = current_solution.Last(); 

                if ((current_square.Column == end.Column) && (current_square.Row == end.Row))
                {
                    //We've found a solution. Because BFS extends out uniformly, this has to be a shortest path because each movement has equal weight.
                    return current_solution;
                }

                foreach (Square adjacent_square in piece.get_possible_moves(current_square))
                {
                    //Find all the squares that the piece can move to from the current square

                    if (!visited.Any(square => (square.Row == adjacent_square.Row && square.Column == adjacent_square.Column)))
                    {
                        //If a square that the piece can move to hasn't been visited, branch out and make a new partly completed solution for investigation and add to queue
                        List<Square> branch = new List<Square>();
                        branch.AddRange(current_solution); //Add the solution we've taken up to here for the branch
                        branch.Add(adjacent_square); //Add the new square to the path

                        visited.Add(adjacent_square); //Mark new square as visited

                        queue.Enqueue(branch); //Add the branch to the queue for processing in a later iteration
                    }
                }
            }

            return new List<Square>(); //No solution found, return an empty list
        }

        /// <summary>
        /// Gets a string for printing of a solution
        /// </summary>
        /// <param name="solution">A list of squares showing a path between two points</param>
        /// <returns>A string of the solution</returns>
        public static string get_solution_string(List<Square> solution)
        {
            if (solution.Count == 0)
            {
                //Empty list indicates no solution found
                return "No solution found!";
            }
            
            string solution_string = "";

            solution_string = "An optimal path from " + solution.First().to_chess_notation() + " to " + solution.Last().to_chess_notation() + 
                              " found, containing " + (solution.Count - 1).ToString() + " steps: ";

            solution.RemoveAt(0); //Remove the first step as this should not be included in solution (is the starting square)

            foreach (Square square in solution)
            {
                solution_string += square.to_chess_notation() + " ";
            }

            return solution_string;
        }

    }

}
