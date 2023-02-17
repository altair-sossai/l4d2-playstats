using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest;

[TestClass]
public class GameRoundTests
{
    [TestMethod]
    public void GivenValidLineShouldBeAbleToExtractValues()
    {
        const string line = "11;2023-02-04;03:13;4;VanillaMod v2.8;c8m1_apartment;";

        var gameRound = new GameRound(line);

        gameRound.Round.Should().Be(11);
        gameRound.When.Should().Be(new DateTime(2023, 2, 4, 3, 13, 0, DateTimeKind.Utc));
        gameRound.TeamSize.Should().Be(4);
        gameRound.ConfigurationName.Should().Be("VanillaMod v2.8");
        gameRound.MapName.Should().Be("c8m1_apartment");
    }
}