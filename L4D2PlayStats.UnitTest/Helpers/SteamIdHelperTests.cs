using FluentAssertions;
using L4D2PlayStats.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest.Helpers;

[TestClass]
public class SteamIdHelperTests
{
	[TestMethod]
	public void SteamIdToCommunityId()
	{
		SteamIdHelper.SteamIdToCommunityId("STEAM_0:0:90628109").Should().Be(76561198141521946);
		SteamIdHelper.SteamIdToCommunityId("STEAM_0:1:91233069").Should().Be(76561198142731867);
		SteamIdHelper.SteamIdToCommunityId("STEAM_0:1:11181514").Should().Be(76561197982628757);
	}

	[TestMethod]
	public void CommunityIdToSteam3()
	{
		SteamIdHelper.CommunityIdToSteam3(76561198141521946).Should().Be("[U:1:181256218]");
		SteamIdHelper.CommunityIdToSteam3(76561198142731867).Should().Be("[U:1:182466139]");
		SteamIdHelper.CommunityIdToSteam3(76561197982628757).Should().Be("[U:1:22363029]");
	}

	[TestMethod]
	public void ProfileUrl()
	{
		SteamIdHelper.ProfileUrl(76561198141521946).Should().Be("https://steamcommunity.com/profiles/76561198141521946");
		SteamIdHelper.ProfileUrl(76561198142731867).Should().Be("https://steamcommunity.com/profiles/76561198142731867");
		SteamIdHelper.ProfileUrl(76561197982628757).Should().Be("https://steamcommunity.com/profiles/76561197982628757");
	}
}