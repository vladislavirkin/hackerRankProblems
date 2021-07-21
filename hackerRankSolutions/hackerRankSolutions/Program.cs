using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    private static bool isGmailProvider(string email)
    {       
        String[] s1array = email.Split("@");        

        return s1array[1] == "gmail.com";
    }

    public static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> names = new List<string>();

        for (int NItr = 0; NItr < N; NItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            string firstName = firstMultipleInput[0];

            string emailID = firstMultipleInput[1];

            if (isGmailProvider(emailID))
            {
                names.Add(firstName);
            }
        }
        names.Sort();

        foreach (var item in names)
        {
            Console.WriteLine(item);
        }
    }
}
