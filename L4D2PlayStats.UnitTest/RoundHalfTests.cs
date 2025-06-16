using L4D2PlayStats.Enums;
using L4D2PlayStats.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest;

[TestClass]
public class RoundHalfTests
{
    [TestMethod]
    public void GivenValidLineShouldBeAbleToExtractValues()
    {
        const string line = "0;A;0;3;0;0;145;16;4721;20;1;0;4;1;36;1675480206;1675480402;0;0;1675480319;1675480402;";

        var roundHalf = new RoundHalf(line);

        Assert.AreEqual(0, roundHalf.Round);
        Assert.AreEqual('A', roundHalf.Team);
        Assert.AreEqual(0, roundHalf.Restarts);
        Assert.AreEqual(3, roundHalf.PillsUsed);
        Assert.AreEqual(0, roundHalf.KitsUsed);
        Assert.AreEqual(0, roundHalf.DefibsUsed);
        Assert.AreEqual(145, roundHalf.Common);
        Assert.AreEqual(16, roundHalf.SiKilled);
        Assert.AreEqual(4721, roundHalf.SiDamage);
        Assert.AreEqual(20, roundHalf.SiSpawned);
        Assert.AreEqual(1, roundHalf.WitchKilled);
        Assert.AreEqual(0, roundHalf.TankKilled);
        Assert.AreEqual(4, roundHalf.Incaps);
        Assert.AreEqual(1, roundHalf.Deaths);
        Assert.AreEqual(36, roundHalf.FfDamageTotal);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc), roundHalf.StartTime);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 13, 22, DateTimeKind.Utc), roundHalf.EndTime);
        Assert.AreEqual(new TimeSpan(0, 3, 16), roundHalf.RoundElapsed);
        Assert.IsNull(roundHalf.StartTimePause);
        Assert.IsNull(roundHalf.StopTimePause);
        Assert.IsNull(roundHalf.PauseElapsed);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 11, 59, DateTimeKind.Utc), roundHalf.StartTimeTank);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 13, 22, DateTimeKind.Utc), roundHalf.StopTimeTank);
        Assert.AreEqual(new TimeSpan(0, 1, 23), roundHalf.TankElapsed);

        Assert.AreEqual(roundHalf.Restarts, roundHalf[RoundStats.Restarts]);
        Assert.AreEqual(roundHalf.PillsUsed, roundHalf[RoundStats.PillsUsed]);
        Assert.AreEqual(roundHalf.KitsUsed, roundHalf[RoundStats.KitsUsed]);
        Assert.AreEqual(roundHalf.DefibsUsed, roundHalf[RoundStats.DefibsUsed]);
        Assert.AreEqual(roundHalf.Common, roundHalf[RoundStats.Common]);
        Assert.AreEqual(roundHalf.SiKilled, roundHalf[RoundStats.SiKilled]);
        Assert.AreEqual(roundHalf.SiDamage, roundHalf[RoundStats.SiDamage]);
        Assert.AreEqual(roundHalf.SiSpawned, roundHalf[RoundStats.SiSpawned]);
        Assert.AreEqual(roundHalf.WitchKilled, roundHalf[RoundStats.WitchKilled]);
        Assert.AreEqual(roundHalf.TankKilled, roundHalf[RoundStats.TankKilled]);
        Assert.AreEqual(roundHalf.Incaps, roundHalf[RoundStats.Incaps]);
        Assert.AreEqual(roundHalf.Deaths, roundHalf[RoundStats.Deaths]);
        Assert.AreEqual(roundHalf.FfDamageTotal, roundHalf[RoundStats.FfDamageTotal]);
        Assert.AreEqual(roundHalf.StartTime.ToUnixTimeSeconds(), roundHalf[RoundStats.StartTime]);
        Assert.AreEqual(roundHalf.EndTime.ToUnixTimeSeconds(), roundHalf[RoundStats.EndTime]);
        Assert.AreEqual(roundHalf.StartTimePause.ToUnixTimeSeconds(), roundHalf[RoundStats.StartTimePause]);
        Assert.AreEqual(roundHalf.StopTimePause.ToUnixTimeSeconds(), roundHalf[RoundStats.StopTimePause]);
        Assert.AreEqual(roundHalf.StartTimeTank.ToUnixTimeSeconds(), roundHalf[RoundStats.StartTimeTank]);
        Assert.AreEqual(roundHalf.StopTimeTank.ToUnixTimeSeconds(), roundHalf[RoundStats.StopTimeTank]);

        Assert.AreEqual(line, roundHalf.ToString());
    }
}