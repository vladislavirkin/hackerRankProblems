using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving;

public class SimpleArraySum : IProblem
{
    public void Solve(IReaderWriter readerWriter)
    {
        var items = readerWriter.ReadLineToIntArray();
        Console.WriteLine(items.Sum());
    }
}