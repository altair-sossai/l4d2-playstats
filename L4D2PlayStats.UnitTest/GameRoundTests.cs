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

        Assert.AreEqual(11, gameRound.Round);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 13, 0, DateTimeKind.Utc), gameRound.When);
        Assert.AreEqual(4, gameRound.TeamSize);
        Assert.AreEqual("VanillaMod v2.8", gameRound.ConfigurationName);
        Assert.AreEqual("c8m1_apartment", gameRound.MapName);

        Assert.AreEqual(line, gameRound.ToString());
    }
}