using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        teamA.Should().NotBeNull();
        teamA!.Letter.Should().Be('A');
        teamA.FirstScoresSet.Should().Be(-1443);
        teamA.Score.Should().Be(301);

        var teamB = scoring.TeamB;
        teamB.Should().NotBeNull();
        teamB!.Letter.Should().Be('B');
        teamB.FirstScoresSet.Should().Be(-1501);
        teamB.Score.Should().Be(392);
    }
}