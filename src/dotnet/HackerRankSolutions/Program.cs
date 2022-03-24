using System.Diagnostics;
using System.Numerics;
using HackerRankSolutions.ReaderWriter;
using HackerRankSolutions.Tasks.OneWeekPreparationKit.Day1;
using HackerRankSolutions.Tasks.ProblemSolving.ArraysDS;
using HackerRankSolutions.Tasks.ProblemSolving.MatrixLayerRotation;

namespace HackerRankSolutions;

internal class Solution
{
    // Implement this method to solve the puzzle. Use readerWriter methods to read input / write output.
    // For local runs: 
    //    place input in a file called "input.txt" alongside Program.cs. 
    //    optionally, place output in a file called "expectedOutput.txt" -- an error will be thrown as soon as an expected line doesn't match your output.
    //    Make sure the files are copied to the output directory (in properties).

    private static void SolvePuzzle(IReaderWriter readerWriter)
    {
        ArraysDs.Solve(readerWriter);
    }

    public static void Main(string[] args)
    {
        IReaderWriter? readerWriter = null;
        try
        {
            if (Debugger.IsAttached)
            {
                readerWriter = new TestFileReaderWriter();
            }
            else
            {
                readerWriter = new ConsoleReaderWriter();
            }

            SolvePuzzle(readerWriter);

            if (Debugger.IsAttached)
            {
                Console.WriteLine("All finished!");
                Console.ReadKey();
            }
        }
        finally
        {
            readerWriter?.Dispose();
        }
    }
}