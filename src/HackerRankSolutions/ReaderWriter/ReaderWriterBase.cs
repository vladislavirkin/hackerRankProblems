namespace HackerRankSolutions.ReaderWriter;

/// <summary>
/// Read/write helper. 
/// </summary>
public abstract class ReaderWriterBase : IReaderWriter
{
    public abstract string ReadLine();
    public abstract void Write(string format, params object[] args);
    public abstract void WriteLine(string format, params object[] args);
    public void WriteLine(object o)
    {
        WriteLine(o.ToString());
    }

    public abstract void WriteLine();

    public int ReadLineToInt()
    {
        var line = ReadLine();
        return Convert.ToInt32(line.Trim());
    }

    public long ReadLineToLong()
    {
        string line = ReadLine();
        return long.Parse(line.Trim());
    }

    public int[] ReadLineToIntArray()
    {
        return Array.ConvertAll(ReadLine().Trim().Split(' '), int.Parse);
    }

    public bool[] ReadLineToBoolArray(Func<char, bool> converter)
    {
        return Array.ConvertAll(ReadLine().ToCharArray(), converter.Invoke);
    }
    
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose()
    {
        // no-op
    }
}