namespace L4D2PlayStats.UnitTest;

[TestClass]
public class ScoringTests
{
    [TestMethod]
    public void GivenValidLineShouldBeAbleToExtractValues()
    {
        const string line = "A;-1443;301;B;-1501;392;";

        var scoring = new Scoring(line);

        var teamA = scoring.TeamA;
        Assert.IsNotNull(teamA);
        Assert.AreEqual('A', teamA.Letter);
        Assert.AreEqual(-1443, teamA.FirstScoresSet);
        Assert.AreEqual(301, teamA.Score);

        var teamB = scoring.TeamB;
        Assert.IsNotNull(teamB);
        Assert.AreEqual('B', teamB.Letter);
        Assert.AreEqual(-1501, teamB.FirstScoresSet);
        Assert.AreEqual(392, teamB.Score);

        Assert.AreEqual(line, scoring.ToString());
    }
}