using HackerRankSolutions.ReaderWriter;

namespace HackerRankSolutions.Tasks.ProblemSolving.MatrixLayerRotation;

public static class MatrixLayerRotation
{
    private static List<List<int>> _rotatedMatrix;
    private static int _columns, _rows, _rotate;
    
    public static void Solve(IReaderWriter readerWriter)
    {
        var firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        var m = Convert.ToInt32(firstMultipleInput[0]);

        var n = Convert.ToInt32(firstMultipleInput[1]);

        var r = Convert.ToInt32(firstMultipleInput[2]);

        var matrix = new List<List<int>>();

        for (var i = 0; i < m; i++)
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());

        _rotatedMatrix = matrix;

        _rows = _rotatedMatrix.Count - 1;
        _columns = _rotatedMatrix[0].Count - 1;
        _rotate = r;

        var quantity = Math.Min(_rows + 1, _columns + 1) / 2;        

        for (var i = 0; i < quantity; i++)
        {
            var pos = CalculateDeltaForRect(i);

            var rect = FillRect(i);
            rect = ShiftRect(rect, pos);
            FillRotatedMatrix(rect, i);
        }

        PrintMatrix();
    }

    private static int CalculateDeltaForRect(int bottom)
    {      
        // sides of current rect
        var x = _rows - bottom*2;
        var y = _columns - bottom*2;

        // r % perimeter of current rect = item position on rect
        var p = 2 * (x + y);
        return p == 0 ? 1 : _rotate % p;
    }        

    private static List<int> ShiftRect(List<int> items, int places)
    {
        return items.Select((t, i) => items[(i + Math.Abs(items.Count - places)) % items.Count]).ToList();
    }

    private static List<int> FillRect(int bottom)
    {
        var result = new List<int>();

        var x = _rows - bottom;
        var y = _columns - bottom;

        for (var i = bottom; i < x; i++)
            result.Add(_rotatedMatrix[i][bottom]);

        for (var i = bottom; i < y; i++)
            result.Add(_rotatedMatrix[x][i]);

        for (var i = x; i > bottom; i--)
            result.Add(_rotatedMatrix[i][y]);

        for (var i = y; i > bottom; i--)
            result.Add(_rotatedMatrix[bottom][i]);

        return result;
    }

    private static void FillRotatedMatrix(List<int> rect, int bottom)
    {
        var x = _rows - bottom;
        var y = _columns - bottom;

        var counter = 0;

        for (var i = bottom; i < x; i++)
        {
            _rotatedMatrix[i][bottom] = rect[counter];
            counter++;
        }

        for (var i = bottom; i < y; i++)
        {
            _rotatedMatrix[x][i] = rect[counter];
            counter++;            
        }

        for (var i = x; i > bottom; i--)
        {
            _rotatedMatrix[i][y] = rect[counter];
            counter++;            
        }

        for (var i = y; i > bottom; i--)
        {
            _rotatedMatrix[bottom][i] = rect[counter];
            counter++;            
        }
    }
    
    private static void PrintMatrix()
    {        
        foreach (var item in _rotatedMatrix)
        {
            foreach (var elem in item)
            {
                Console.Write(elem);
                Console.Write(" ");
            }
            Console.Write("\n");
        }
    }
}