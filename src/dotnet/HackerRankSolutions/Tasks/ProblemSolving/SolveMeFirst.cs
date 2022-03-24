using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving;

public class SolveMeFirst : IProblem
{
    public void Solve(IReaderWriter readerWriter)
    {
        var arr = readerWriter.ReadLineToIntArray();
        Console.WriteLine(arr[0] + arr[1]);
    }
}