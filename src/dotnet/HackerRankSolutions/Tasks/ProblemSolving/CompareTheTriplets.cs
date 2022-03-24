using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving;

public class CompareTheTriplets : IProblem
{
    public void Solve(IReaderWriter readerWriter)
    {
        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

        var ret = new List<int>
        {
            0,
            0
        };

        var length = a.Count;
        for (var i = 0; i < length; i++)
        {
            if (a[i] < b[i])
                ret[1]++;

            if (a[i] > b[i])
                ret[0]++;
        }

        Console.WriteLine(ret);
    }
}