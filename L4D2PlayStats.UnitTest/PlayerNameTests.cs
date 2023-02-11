using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

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
        playerName.CommunityId.Should().Be(76561198141521946);
        playerName.Steam3.Should().Be("[U:1:181256218]");
        playerName.ProfileUrl.Should().Be("https://steamcommunity.com/profiles/76561198141521946");
        playerName.Name.Should().Be(";Alt;air;");
    }
}