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

        Assert.AreEqual(5, playerName.Index);
        Assert.AreEqual("STEAM_1:0:90628109", playerName.SteamId);
        Assert.AreEqual("76561198141521946", playerName.CommunityId);
        Assert.AreEqual("[U:1:181256218]", playerName.Steam3);
        Assert.AreEqual("https://steamcommunity.com/profiles/76561198141521946", playerName.ProfileUrl);
        Assert.AreEqual(";Alt;air;", playerName.Name);

        Assert.AreEqual(line, playerName.ToString());
    }
}