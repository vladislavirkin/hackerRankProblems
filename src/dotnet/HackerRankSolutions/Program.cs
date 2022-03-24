using System.Diagnostics;
using System.Numerics;
using HackerRankSolutions.ReaderWriter;
using HackerRankSolutions.Tasks.OneWeekPreparationKit.Day1;
using HackerRankSolutions.Tasks.ProblemSolving;

namespace HackerRankSolutions;

internal class Solution
{
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


            IProblem problem = new ExtraLongFactorials();
            problem.Solve(readerWriter);

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