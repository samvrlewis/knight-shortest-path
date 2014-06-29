using System;
using System.Collections.Generic;

namespace KnightTravails
{
    class Program
    {
        const int NUM_ARGUMENTS = 2; //Number of arguments required
        const int FROM_SQUARE_INDEX = 0; //Index to args for the from square
        const int TO_SQUARE_INDEX = 1; //Index to args for the to square

        /// <summary>
        /// Prints the program's usage
        /// </summary>
        static void print_usage()
        {
            string usage = "Knight Trevails: Finds a shortest path between two chess squares." + System.Environment.NewLine +
                           "Usage : KnightTrevails.exe FromSquare ToSquare." + System.Environment.NewLine + 
                           "Eg: KnightTrevails.exe A1 H8";

            Console.Write(usage);
        }

        static void Main(string[] args)
        {
            if (args.Length != NUM_ARGUMENTS)
            {
                //Invalid amount of input arguments
                print_usage();
                Environment.Exit(0);
            }

            Square start = null;
            Square end = null;

            try
            {
                //Attempt to load the squares using the supplied arguments
                //These arguments are suplied by the user so could be wrong
                start = new Square(args[FROM_SQUARE_INDEX]);
                end = new Square(args[TO_SQUARE_INDEX]); 
            } catch (ArgumentException ex) {
                Console.WriteLine("Argument Exception: " + ex.Message); 
                print_usage();
                Environment.Exit(-1);
            }

            List<Square> solved = KnightTravailsSolver.find_shortest_solution(start, end, new Knight());
            string solution = KnightTravailsSolver.get_solution_string(solved); 
            Console.Write(solution);
        }
    }
}

