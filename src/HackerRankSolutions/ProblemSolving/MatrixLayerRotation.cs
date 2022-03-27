using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class MatrixLayerRotation
{
    private List<List<int>> _rotatedMatrix;
    private int _columns, _rows, _rotate;
    
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(
            new List<List<int>> { new() { 1, 2, 3, 4 }, new() { 5, 6, 7, 8 }, new() { 9, 10, 11, 12 }, new() { 13, 14, 15, 16 } }, 
            2, 
            new List<List<int>> { new() { 3, 4, 8, 12 }, new() { 2, 11, 10, 16 }, new() { 1, 7, 6, 15 }, new() { 5, 9, 13, 14 } });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void RotateMatrix(List<List<int>> matrix, int r, List<List<int>> expected)
    {
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

        CollectionAssert.AreEqual(expected, _rotatedMatrix, "Rotated matrix calculated incorrectly.");
    }

    private int CalculateDeltaForRect(int bottom)
    {      
        // sides of current rect
        var x = _rows - bottom*2;
        var y = _columns - bottom*2;

        // r % perimeter of current rect = item position on rect
        var p = 2 * (x + y);
        return p == 0 ? 1 : _rotate % p;
    }        

    private List<int> ShiftRect(List<int> items, int places)
    {
        return items.Select((t, i) => items[(i + Math.Abs(items.Count - places)) % items.Count]).ToList();
    }

    private List<int> FillRect(int bottom)
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

    private void FillRotatedMatrix(List<int> rect, int bottom)
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
}