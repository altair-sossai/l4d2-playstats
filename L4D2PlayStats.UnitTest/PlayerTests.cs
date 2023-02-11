using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest;

[TestClass]
public class PlayerTests
{
    [TestMethod]
    public void GivenValidLineShouldBeAbleToExtractValues()
    {
        const string line = "1;8;STEAM_1:0:15152893;0;58;0;0;0;20;0;0;2;0;0;2;0;0;0;16;0;0;0;0;0;0;20;4;2;0;1230;0;1;1;0;0;0;0;0;0;0;0;0;0;0;0;0;84;15;8;0;0;0;0;0;0;0;13;0;2;0;0;0;0;0;7;0;0;0;0;1;15;8;0;0;1675480206;1675480402;1675480206;1675480359;1675480206;1675480324;";

        var player = new Player(line);

        player.Index.Should().Be(1);
        player.Client.Should().Be(8);
        player.SteamId.Should().Be("STEAM_1:0:15152893");
        player.CommunityId.Should().Be(76561197990571514);
        player.Steam3.Should().Be("[U:1:30305786]"); 
        player.ProfileUrl.Should().Be("https://steamcommunity.com/profiles/76561197990571514");
        player.ShotsShotgun.Should().Be(0);
        player.ShotsSmg.Should().Be(58);
        player.ShotsSniper.Should().Be(0);
        player.ShotsPistol.Should().Be(0);
        player.HitsShotgun.Should().Be(0);
        player.HitsSmg.Should().Be(20);
        player.HitsSniper.Should().Be(0);
        player.HitsPistol.Should().Be(0);
        player.HeadshotsSmg.Should().Be(2);
        player.HeadshotsSniper.Should().Be(0);
        player.HeadshotsPistol.Should().Be(0);
        player.HeadshotsSiSmg.Should().Be(2);
        player.HeadshotsSiSniper.Should().Be(0);
        player.HeadshotsSiPistol.Should().Be(0);
        player.HitsSiShotgun.Should().Be(0);
        player.HitsSiSmg.Should().Be(16);
        player.HitsSiSniper.Should().Be(0);
        player.HitsSiPistol.Should().Be(0);
        player.HitsTankShotgun.Should().Be(0);
        player.HitsTankSmg.Should().Be(0);
        player.HitsTankSniper.Should().Be(0);
        player.HitsTankPistol.Should().Be(0);
        player.Common.Should().Be(20);
        player.CommonTankUp.Should().Be(4);
        player.SiKilled.Should().Be(2);
        player.SiKilledTankUp.Should().Be(0);
        player.SiDamage.Should().Be(1230);
        player.SiDamageTankUp.Should().Be(0);
        player.Incaps.Should().Be(1);
        player.Died.Should().Be(1);
        player.Skeets.Should().Be(0);
        player.SkeetsHurt.Should().Be(0);
        player.SkeetsMelee.Should().Be(0);
        player.Levels.Should().Be(0);
        player.LevelsHurt.Should().Be(0);
        player.Pops.Should().Be(0);
        player.Crowns.Should().Be(0);
        player.CrownsHurt.Should().Be(0);
        player.Shoves.Should().Be(0);
        player.DeadStops.Should().Be(0);
        player.TongueCuts.Should().Be(0);
        player.SelfClears.Should().Be(0);
        player.FallDamage.Should().Be(0);
        player.DmgTaken.Should().Be(84);
        player.FfGiven.Should().Be(15);
        player.FfTaken.Should().Be(8);
        player.FfHits.Should().Be(0);
        player.TankDamage.Should().Be(0);
        player.WitchDamage.Should().Be(0);
        player.MeleesOnTank.Should().Be(0);
        player.RockSkeets.Should().Be(0);
        player.RockEats.Should().Be(0);
        player.FfGivenPellet.Should().Be(0);
        player.FfGivenBullet.Should().Be(13);
        player.FfGivenSniper.Should().Be(0);
        player.FfGivenMelee.Should().Be(2);
        player.FfGivenFire.Should().Be(0);
        player.FfGivenIncap.Should().Be(0);
        player.FfGivenOther.Should().Be(0);
        player.FfGivenSelf.Should().Be(0);
        player.FfTakenPellet.Should().Be(0);
        player.FfTakenBullet.Should().Be(7);
        player.FfTakenSniper.Should().Be(0);
        player.FfTakenMelee.Should().Be(0);
        player.FfTakenFire.Should().Be(0);
        player.FfTakenIncap.Should().Be(0);
        player.FfTakenOther.Should().Be(1);
        player.FfGivenTotal.Should().Be(15);
        player.FfTakenTotal.Should().Be(8);
        player.Clears.Should().Be(0);
        player.AvgClearTime.Should().Be(0);
        player.TimeStartPresent.Should().Be(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc));
        player.TimeStopPresent.Should().Be(new DateTime(2023, 2, 4, 3, 13, 22, DateTimeKind.Utc));
        player.TimeStartAlive.Should().Be(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc));
        player.TimeStopAlive.Should().Be(new DateTime(2023, 2, 4, 3, 12, 39, DateTimeKind.Utc));
        player.TimeStartUpright.Should().Be(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc));
        player.TimeStopUpright.Should().Be(new DateTime(2023, 2, 4, 3, 12, 04, DateTimeKind.Utc));
    }
}