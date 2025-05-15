using L4D2PlayStats.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest.Helpers;

[TestClass]
public class SteamIdHelperTests
{
    [TestMethod]
    public void SteamIdToCommunityId()
    {
        Assert.AreEqual(76561198141521946, SteamIdHelper.SteamIdToCommunityId("STEAM_0:0:90628109"));
        Assert.AreEqual(76561198142731867, SteamIdHelper.SteamIdToCommunityId("STEAM_0:1:91233069"));
        Assert.AreEqual(76561197982628757, SteamIdHelper.SteamIdToCommunityId("STEAM_0:1:11181514"));
    }

    [TestMethod]
    public void CommunityIdToSteam3()
    {
        Assert.AreEqual("[U:1:181256218]", SteamIdHelper.CommunityIdToSteam3(76561198141521946));
        Assert.AreEqual("[U:1:182466139]", SteamIdHelper.CommunityIdToSteam3(76561198142731867));
        Assert.AreEqual("[U:1:22363029]", SteamIdHelper.CommunityIdToSteam3(76561197982628757));
    }

    [TestMethod]
    public void ProfileUrl()
    {
        Assert.AreEqual("https://steamcommunity.com/profiles/76561198141521946", SteamIdHelper.ProfileUrl(76561198141521946));
        Assert.AreEqual("https://steamcommunity.com/profiles/76561198142731867", SteamIdHelper.ProfileUrl(76561198142731867));
        Assert.AreEqual("https://steamcommunity.com/profiles/76561197982628757", SteamIdHelper.ProfileUrl(76561197982628757));
    }
}