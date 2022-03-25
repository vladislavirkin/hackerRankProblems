using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving;

public class SherlockAndAnagrams : IProblem
{
    public void Solve(IReaderWriter readerWriter)
    {
        var strings = new List<string>();
        var queriesCount = readerWriter.ReadLineToInt();
        for (var i = 0; i < queriesCount; i++)
            strings.Add(readerWriter.ReadLine());

        foreach (var str in strings)
            Console.WriteLine(CountAnagrams(str));

    }

    private int CountAnagrams(string s)
    {
        var ret = 0;
        
        var length = s.Length;
        var anagrams = new Dictionary<string, int>();
        for (var len = 1; len <= length - 1; len++)
        {
            for (var i = 0; i <= length - len; i++)
            {
                var item = new string(s.Substring(i, len).OrderBy(c => c).ToArray());
                if (anagrams.ContainsKey(item))
                {
                    ret += anagrams[item];
                    anagrams[item] += 1;
                }
                else
                    anagrams[item] = 1;
            }
            anagrams.Clear();
        }
        
        return ret;
    }
}