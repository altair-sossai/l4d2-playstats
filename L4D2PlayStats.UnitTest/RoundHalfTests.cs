using FluentAssertions;
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

		roundHalf.Round.Should().Be(0);
		roundHalf.Team.Should().Be('A');
		roundHalf.Restarts.Should().Be(0);
		roundHalf.PillsUsed.Should().Be(3);
		roundHalf.KitsUsed.Should().Be(0);
		roundHalf.DefibsUsed.Should().Be(0);
		roundHalf.Common.Should().Be(145);
		roundHalf.SiKilled.Should().Be(16);
		roundHalf.SiDamage.Should().Be(4721);
		roundHalf.SiSpawned.Should().Be(20);
		roundHalf.WitchKilled.Should().Be(1);
		roundHalf.TankKilled.Should().Be(0);
		roundHalf.Incaps.Should().Be(4);
		roundHalf.Deaths.Should().Be(1);
		roundHalf.FfDamageTotal.Should().Be(36);
		roundHalf.StartTime.Should().Be(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc));
		roundHalf.EndTime.Should().Be(new DateTime(2023, 2, 4, 3, 13, 22, DateTimeKind.Utc));
		roundHalf.StartTimePause.Should().BeNull();
		roundHalf.StopTimePause.Should().BeNull();
		roundHalf.StartTimeTank.Should().Be(new DateTime(2023, 2, 4, 3, 11, 59, DateTimeKind.Utc));
		roundHalf.StopTimeTank.Should().Be(new DateTime(2023, 2, 4, 3, 13, 22, DateTimeKind.Utc));
	}
}