using L4D2PlayStats.Enums;
using L4D2PlayStats.Extensions;
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

        Assert.AreEqual(1, infectedPlayer.Index);
        Assert.AreEqual(5, infectedPlayer.Client);
        Assert.AreEqual("STEAM_1:1:57113046", infectedPlayer.SteamId);
        Assert.AreEqual("76561198074491821", infectedPlayer.CommunityId);
        Assert.AreEqual("[U:1:114226093]", infectedPlayer.Steam3);
        Assert.AreEqual("https://steamcommunity.com/profiles/76561198074491821", infectedPlayer.ProfileUrl);

        Assert.AreEqual(43, infectedPlayer.DmgTotal);
        Assert.AreEqual(43, infectedPlayer.DmgUpright);
        Assert.AreEqual(0, infectedPlayer.DmgTank);
        Assert.AreEqual(0, infectedPlayer.DmgTankIncap);
        Assert.AreEqual(10, infectedPlayer.DmgScratch);
        Assert.AreEqual(0, infectedPlayer.DmgSpit);
        Assert.AreEqual(0, infectedPlayer.DmgBoom);
        Assert.AreEqual(21, infectedPlayer.DmgTankUp);
        Assert.AreEqual(0, infectedPlayer.HunterDPs);
        Assert.AreEqual(0, infectedPlayer.HunterDpDmg);
        Assert.AreEqual(0, infectedPlayer.JockeyDPs);
        Assert.AreEqual(0, infectedPlayer.DeathCharges);
        Assert.AreEqual(0, infectedPlayer.Booms);
        Assert.AreEqual(0, infectedPlayer.Ledged);
        Assert.AreEqual(1, infectedPlayer.Common);
        Assert.AreEqual(5, infectedPlayer.Spawns);
        Assert.AreEqual(1, infectedPlayer.SpawnSmoker);
        Assert.AreEqual(0, infectedPlayer.SpawnBoomer);
        Assert.AreEqual(1, infectedPlayer.SpawnHunter);
        Assert.AreEqual(1, infectedPlayer.SpawnCharger);
        Assert.AreEqual(0, infectedPlayer.SpawnSpitter);
        Assert.AreEqual(2, infectedPlayer.SpawnJockey);
        Assert.AreEqual(0, infectedPlayer.TankPasses);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc), infectedPlayer.TimeStartPresent);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 13, 22, DateTimeKind.Utc), infectedPlayer.TimeStopPresent);
        Assert.AreEqual(new TimeSpan(0, 3, 16), infectedPlayer.TimePresentElapsed);

        Assert.AreEqual(infectedPlayer.DmgTotal, infectedPlayer[InfectedStats.DmgTotal]);
        Assert.AreEqual(infectedPlayer.DmgUpright, infectedPlayer[InfectedStats.DmgUpright]);
        Assert.AreEqual(infectedPlayer.DmgTank, infectedPlayer[InfectedStats.DmgTank]);
        Assert.AreEqual(infectedPlayer.DmgTankIncap, infectedPlayer[InfectedStats.DmgTankIncap]);
        Assert.AreEqual(infectedPlayer.DmgScratch, infectedPlayer[InfectedStats.DmgScratch]);
        Assert.AreEqual(infectedPlayer.DmgSpit, infectedPlayer[InfectedStats.DmgSpit]);
        Assert.AreEqual(infectedPlayer.DmgBoom, infectedPlayer[InfectedStats.DmgBoom]);
        Assert.AreEqual(infectedPlayer.DmgTankUp, infectedPlayer[InfectedStats.DmgTankUp]);
        Assert.AreEqual(infectedPlayer.HunterDPs, infectedPlayer[InfectedStats.HunterDPs]);
        Assert.AreEqual(infectedPlayer.HunterDpDmg, infectedPlayer[InfectedStats.HunterDpDmg]);
        Assert.AreEqual(infectedPlayer.JockeyDPs, infectedPlayer[InfectedStats.JockeyDPs]);
        Assert.AreEqual(infectedPlayer.DeathCharges, infectedPlayer[InfectedStats.DeathCharges]);
        Assert.AreEqual(infectedPlayer.Booms, infectedPlayer[InfectedStats.Booms]);
        Assert.AreEqual(infectedPlayer.Ledged, infectedPlayer[InfectedStats.Ledged]);
        Assert.AreEqual(infectedPlayer.Common, infectedPlayer[InfectedStats.Common]);
        Assert.AreEqual(infectedPlayer.Spawns, infectedPlayer[InfectedStats.Spawns]);
        Assert.AreEqual(infectedPlayer.SpawnSmoker, infectedPlayer[InfectedStats.SpawnSmoker]);
        Assert.AreEqual(infectedPlayer.SpawnBoomer, infectedPlayer[InfectedStats.SpawnBoomer]);
        Assert.AreEqual(infectedPlayer.SpawnHunter, infectedPlayer[InfectedStats.SpawnHunter]);
        Assert.AreEqual(infectedPlayer.SpawnCharger, infectedPlayer[InfectedStats.SpawnCharger]);
        Assert.AreEqual(infectedPlayer.SpawnSpitter, infectedPlayer[InfectedStats.SpawnSpitter]);
        Assert.AreEqual(infectedPlayer.SpawnJockey, infectedPlayer[InfectedStats.SpawnJockey]);
        Assert.AreEqual(infectedPlayer.TankPasses, infectedPlayer[InfectedStats.TankPasses]);
        Assert.AreEqual(infectedPlayer.TimeStartPresent.ToUnixTimeSeconds(), infectedPlayer[InfectedStats.TimeStartPresent]);
        Assert.AreEqual(infectedPlayer.TimeStopPresent.ToUnixTimeSeconds(), infectedPlayer[InfectedStats.TimeStopPresent]);
    }
}