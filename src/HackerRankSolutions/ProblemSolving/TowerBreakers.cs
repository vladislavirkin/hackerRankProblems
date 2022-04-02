using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class TowerBreakers
{
    /*
     * So basically, there are two cases here.
     * Both cases rely heavily on the idea that an even number of towers (say 2n)
     * can be thought of as a collection of n pairs of towers.
     *
     * CASE 1)
     * If there are an even number of towers Player 1 will go first, and Player 2 will basically copy player 1.
     * Whatever player 1 does to a tower, player 2 will do the exact same thing to the other tower belonging
     * to the same pair. In this case Player 2 will always win.
     *
     * CASE 2) If there are an odd number of towers Player 1 will go first, and simply destroy any single tower
     * by setting it equal to 1. Now we again have the same situation from CASE 1
     * but this time the roles of both players have been reversed. In this case Player 1 will always win.
     *
     * Finally, there is also the trivial case where n does not matter because m = 1.
     * In this case Player 2 will obviously always win.
     */
    [Test]
    [TestCase(2, 2, 2)]
    [TestCase(1, 4, 1)]
    public void Solve(int n, int m, int expected)
    {
        var ret = n % 2 == 0 ? 2 : 1;
        if (m == 1)
            ret = 2;
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
}