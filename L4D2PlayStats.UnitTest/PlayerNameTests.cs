using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest;

[TestClass]
public class PlayerNameTests
{
    [TestMethod]
    public void GivenValidLineShouldBeAbleToExtractValues()
    {
        const string line = "5;STEAM_1:0:90628109;;Alt;air;";

        var playerName = new PlayerName(line);

        playerName.Index.Should().Be(5);
        playerName.SteamId.Should().Be("STEAM_1:0:90628109");
        playerName.Name.Should().Be(";Alt;air;");
    }
}