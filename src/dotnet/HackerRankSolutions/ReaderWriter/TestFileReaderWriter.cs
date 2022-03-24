using System.Text;

namespace HackerRankSolutions.ReaderWriter;

/// <summary>
/// Text file reade/write helper.
/// </summary>
public class TestFileReaderWriter : ReaderWriterBase
{
    private readonly TextReader _myReader = File.OpenText("input.txt");
    private readonly TextReader _myOutputReader = File.Exists("expectedOutput.txt") ? File.OpenText("expectedOutput.txt") : null;
    private readonly StringBuilder _currentLine = new();
    private int currentLineNumber = 1;
    public override string ReadLine()
    {
        return _myReader.ReadLine();
    }

    public override void WriteLine()
    {
        Console.WriteLine(_currentLine);
        if (_myOutputReader != null)
        {
            CheckCurrentLine();
            _currentLine.Clear();
        }
        currentLineNumber++;
    }

    public override void Write(string format, params object[] args)
    {
        _currentLine.AppendFormat(format, args);
    }

    public override void WriteLine(string format, params object[] args)
    {
        Write(format, args);
        WriteLine();
    }

    private void CheckCurrentLine()
    {
        var nextLine = _myOutputReader.ReadLine().Trim();
        var currentLine = _currentLine.ToString().Trim();

        if (nextLine != currentLine) { throw new Exception("oy: line " + currentLineNumber); }
    }

    public override void Dispose()
    {
        foreach (var tr in new[] { _myReader, _myOutputReader })
        {
            if (tr != null)
            {
                tr.Close();
                tr.Dispose();
            }
        }
    }
}