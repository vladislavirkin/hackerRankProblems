using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving;

public class ExtraLongFactorials : IProblem
{
    public void Solve(IReaderWriter readerWriter)
    {
        var n = readerWriter.ReadLineToInt();

        var factorial = new List<int> {1};

        for (var i = 2; i <= n; i++)
        {
            for (var j = 0; j < factorial.Count; j++)
                factorial[j] *= i;

            for (var j = 0; j < factorial.Count; j++)
            {
                if (factorial[j] >= 10)
                {
                    if (j == factorial.Count - 1)
                        factorial.Add(0);

                    factorial[j + 1] += factorial[j] / 10;
                    factorial[j] %= 10;
                }
            }
        }

        for (var i = factorial.Count - 1; i >= 0; i--)
            Console.Write(factorial[i]);
    }
}