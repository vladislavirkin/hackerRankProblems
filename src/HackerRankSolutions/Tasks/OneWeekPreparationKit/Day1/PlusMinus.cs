using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.OneWeekPreparationKit.Day1;

public static class PlusMinus
{
    public static void Solve(IReaderWriter readerWriter)
    {
        var n = readerWriter.ReadLineToInt();
        var arr = readerWriter.ReadLineToIntArray();

        decimal positives = arr.Count(x => x>0);
        decimal negatives = arr.Count(x => x<0);
        decimal zeroes = arr.Count(x => x==0);

        positives /= n;
        negatives /= n;
        zeroes /= n;

        readerWriter.WriteLine($"{positives:N6}");
        readerWriter.WriteLine($"{negatives:N6}");
        readerWriter.WriteLine($"{zeroes:N6}");
    }
}