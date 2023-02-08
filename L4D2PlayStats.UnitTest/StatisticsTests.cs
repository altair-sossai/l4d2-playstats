using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest;

[TestClass]
public class StatisticsTests
{
    [TestMethod]
    public void FullMapStatistics()
    {
        var type = typeof(StatisticsTests);
        var assembly = type.Assembly;
        const string resourceName = "L4D2PlayStats.UnitTest.Statistics.2023-02-04_03-13_0011_c8m1_apartment.txt";

        using var stream = assembly.GetManifestResourceStream(resourceName)!;
        using var streamReader = new StreamReader(stream);
        var content = streamReader.ReadToEnd();

        var statistics = new Statistics(content);

        statistics.GameRound.Should().NotBeNull();
        statistics.Halves.Should().HaveCount(2);
        statistics.Scoring.Should().NotBeNull();
        statistics.PlayerNames.Should().HaveCount(20);

        var firstHalf = statistics.Halves[0];

        firstHalf.RoundHalf.Should().NotBeNull();
        firstHalf.RoundHalf!.Round.Should().Be(0);

        firstHalf.Progress.Should().NotBeNull();
        firstHalf.Progress!.Round.Should().Be(0);

        firstHalf.Players.Should().HaveCount(4);
        firstHalf.InfectedPlayers.Should().HaveCount(4);

        var secondHalf = statistics.Halves[1];

        secondHalf.RoundHalf.Should().NotBeNull();
        secondHalf.RoundHalf!.Round.Should().Be(1);

        secondHalf.Progress.Should().NotBeNull();
        secondHalf.Progress!.Round.Should().Be(1);

        secondHalf.Players.Should().HaveCount(4);
        secondHalf.InfectedPlayers.Should().HaveCount(4);
    }
}