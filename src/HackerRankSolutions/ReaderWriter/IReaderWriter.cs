﻿namespace HackerRankSolutions.ReaderWriter;

/// <summary>
/// Interface for read/write helper.
/// </summary>
public interface IReaderWriter : IDisposable
{
    string ReadLine();
    
    int ReadLineToInt();
    
    long ReadLineToLong();
    
    int[] ReadLineToIntArray();
    
    bool[] ReadLineToBoolArray(Func<char, bool> converter);
    
    void WriteLine();
    
    void Write(string format, params object[] args);
    
    void WriteLine(string format, params object[] args);
    
    void WriteLine(object o);
}