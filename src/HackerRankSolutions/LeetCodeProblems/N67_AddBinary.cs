using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// RT = 3 ms, beats 26%.
/// M = 41 MB, beats 43%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/add-binary/")]
public class N67_AddBinary
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("11", "1", "100");
        yield return new TestCaseData("1", "111", "1000");
        yield return new TestCaseData("1010", "1011", "10101");
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string a, string b, string expected)
    {
        var ret = AddBinary(a, b);
        // var ret = AddBinaryBestRT(a, b);
        // var ret = AddBinaryBestM(a, b);
        // var ret = AddBinaryCheat(a, b);

        Assert.That(ret, Is.EquivalentTo(expected), "Result length calculated incorrectly.");
    }
    
    /// <summary>
    /// RT = 0 ms, beats 100%.
    /// M = 42 MB, beats 43%.
    /// </summary>
    public string AddBinaryBestRT(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;

        char[] result = new char[Math.Max(a.Length, b.Length) + 1];
        int k = result.Length - 1;
        int carry = 0;
        while(i >= 0 || j >= 0 || carry > 0)
        {
            int x = i >= 0 ? a[i] - '0' : 0;
            int y = j >= 0 ? b[j] - '0' : 0;

            int sum = x + y + carry;

            result[k] = (char)(sum % 2 + '0');
            carry = sum / 2;

            i--;
            j--;
            k--;
        }
        
        return new string(result, k + 1, result.Length - 1 - k);
    }
    
    /// <summary>
    /// RT = 1 ms, beats 91%.
    /// M = 41 MB, beats 89%.
    /// </summary>
    public string AddBinaryBestM(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;

        var result = new System.Text.StringBuilder();

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int sum = carry;

            if (i >= 0) sum += a[i--] - '0';
            if (j >= 0) sum += b[j--] - '0';

            result.Insert(0, sum % 2);
            carry = sum / 2;          
        }

        return result.ToString();
    }
    
    public string AddBinary(string a, string b)
    {
        return a.Length > b.Length ? AddChars(a, b) : AddChars(b, a);
    }

    private string AddChars(string big, string small)
    {
        var chars = big.ToCharArray();
        var carry = '0';

        var j = big.Length - 1;
        for (int i = small.Length - 1; i >= 0; i--)
        {
            (chars[j], carry) = Add(big[j], small[i], carry);
            j--;
        }

        for (int k = j; k >= 0; k--)
            (chars[k], carry) = Add(chars[k], carry, '0');

        var ret = string.Join("", chars);

        return carry == '1' ? carry + ret : ret;
    }

    private (char, char) Add(char a, char b, char carry)
    {
        char ret;
        char retCurry = '0';
        if (a == '0')
            ret = b == '0' ? '0' : '1';
        else
        {
            if (b == '0')
                ret = '1';
            else
            {
                ret = '0';
                retCurry = '1';
            }
        }
        
        if (carry == '0')
            return (ret, retCurry);
        
        return ret == '0' ? (carry, retCurry ) : ('0', '1');
    }
    
    public string AddBinaryCheat(string a, string b)
    {
        var avalue = Convert.ToInt32(a, 2);
        var bvalue = Convert.ToInt32(b, 2);
        
        return Convert.ToString(avalue + bvalue, 2);
    }
}