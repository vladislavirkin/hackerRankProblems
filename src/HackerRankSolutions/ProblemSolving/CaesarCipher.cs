using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class CaesarCipher
{
    [Test]
    [TestCase("middle-Outz", 2, "okffng-Qwvb")]
    public void Solve(string s, int k, string expected)
    {
        var ret = new List<char>();
        var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        foreach (var symbol in s)
        {
            if (!alphabet.Contains(symbol))
            {
                ret.Add(symbol);
                continue;
            }

            for (var i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == symbol)
                {
                    if (i > 25)
                        ret.Add(alphabet[26 + (i + k) % (alphabet.Length / 2)]);
                    else
                        ret.Add(alphabet[(i + k) % (alphabet.Length / 2)]);
                    
                    break;
                }
            }
        }
        
        Assert.AreEqual(expected, new string(ret.ToArray()), "Result calculated incorrectly.");
    }
}