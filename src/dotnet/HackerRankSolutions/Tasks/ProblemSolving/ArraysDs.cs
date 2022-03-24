using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving;

public class ArraysDs : IProblem
{
    public void Solve(IReaderWriter readerWriter)
    {
        var  arr =readerWriter.ReadLineToIntArray();

        var res = ReverseArray(arr);

        readerWriter.WriteLine(string.Join(" ", res));
    }

    private static IEnumerable<int> ReverseArray(IReadOnlyList<int> items)
    {
        var ret = new List<int>();

        for (var i = items.Count - 1; i >= 0; i--)
            ret.Add(items[i]);

        return ret;
    }
}