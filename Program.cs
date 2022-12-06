using SolverLibrary;

namespace AdventProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Solvers solvers = new Solvers();
            Console.WriteLine("Advent of Code 2022");
            while (!endApp)
            {
                solvers.Solver06B();
                endApp = true;
            }
            Console.WriteLine("\n");
            return;
        }

    }
}