using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving;

public class AVeryBigSum : IProblem
{
    public void Solve(IReaderWriter readerWriter)
    {
        var arCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> items = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt64(arTemp)).ToList();

        Console.WriteLine(items.Sum());
    }
}