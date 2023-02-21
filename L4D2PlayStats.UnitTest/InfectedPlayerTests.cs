using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest;

[TestClass]
public class InfectedPlayerTests
{
    [TestMethod]
    public void GivenValidLineShouldBeAbleToExtractValues()
    {
        const string line = "1;5;STEAM_1:1:57113046;43;43;0;0;10;0;0;21;0;0;0;0;0;0;1;5;1;0;1;1;0;2;0;1675480206;1675480402;";

        var infectedPlayer = new InfectedPlayer(line);

        infectedPlayer.Index.Should().Be(1);
        infectedPlayer.Client.Should().Be(5);
        infectedPlayer.SteamId.Should().Be("STEAM_1:1:57113046");
        infectedPlayer.CommunityId.Should().Be("76561198074491821");
        infectedPlayer.Steam3.Should().Be("[U:1:114226093]");
        infectedPlayer.ProfileUrl.Should().Be("https://steamcommunity.com/profiles/76561198074491821");
        infectedPlayer.DmgTotal.Should().Be(43);
        infectedPlayer.DmgUpright.Should().Be(43);
        infectedPlayer.DmgTank.Should().Be(0);
        infectedPlayer.DmgTankIncap.Should().Be(0);
        infectedPlayer.DmgScratch.Should().Be(10);
        infectedPlayer.DmgSpit.Should().Be(0);
        infectedPlayer.DmgBoom.Should().Be(0);
        infectedPlayer.DmgTankUp.Should().Be(21);
        infectedPlayer.HunterDPs.Should().Be(0);
        infectedPlayer.HunterDpDmg.Should().Be(0);
        infectedPlayer.JockeyDPs.Should().Be(0);
        infectedPlayer.DeathCharges.Should().Be(0);
        infectedPlayer.Booms.Should().Be(0);
        infectedPlayer.Ledged.Should().Be(0);
        infectedPlayer.Common.Should().Be(1);
        infectedPlayer.Spawns.Should().Be(5);
        infectedPlayer.SpawnSmoker.Should().Be(1);
        infectedPlayer.SpawnBoomer.Should().Be(0);
        infectedPlayer.SpawnHunter.Should().Be(1);
        infectedPlayer.SpawnCharger.Should().Be(1);
        infectedPlayer.SpawnSpitter.Should().Be(0);
        infectedPlayer.SpawnJockey.Should().Be(2);
        infectedPlayer.TankPasses.Should().Be(0);
        infectedPlayer.TimeStartPresent.Should().Be(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc));
        infectedPlayer.TimeStopPresent.Should().Be(new DateTime(2023, 2, 4, 3, 13, 22, DateTimeKind.Utc));
        infectedPlayer.TimePresentElapsed.Should().Be(new TimeSpan(0, 3, 16));
    }
}