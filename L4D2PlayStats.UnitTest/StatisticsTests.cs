using System.Text;
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
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        var content = streamReader.ReadToEnd();

        var statistics = new Statistics(content);

        statistics.GameRound.Should().NotBeNull();
        statistics.Halves.Should().HaveCount(2);
        statistics.Scoring.Should().NotBeNull();
        statistics.PlayerNames.Should().HaveCount(20);
        statistics.TeamA.Should().HaveCount(4);
        statistics.TeamB.Should().HaveCount(4);
        statistics.MapStart.Should().Be(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc));
        statistics.MapEnd.Should().Be(new DateTime(2023, 2, 4, 3, 18, 37, DateTimeKind.Utc));
        statistics.MapElapsed.Should().Be(new TimeSpan(0, 8, 31));

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

    [TestMethod]
    public void TryParse_MustReturnTrueWhenContentIsValid()
    {
        var type = typeof(StatisticsTests);
        var assembly = type.Assembly;
        const string resourceName = "L4D2PlayStats.UnitTest.Statistics.2023-02-04_03-13_0011_c8m1_apartment.txt";

        using var stream = assembly.GetManifestResourceStream(resourceName)!;
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        var content = streamReader.ReadToEnd();

        Statistics.TryParse(content, out var statistics).Should().BeTrue();

        statistics.Should().NotBeNull();
    }

    [TestMethod]
    public void TryParse_MustReturnFalseWhenContentIsValid()
    {
        const string content = "";

        Statistics.TryParse(content, out var statistics).Should().BeFalse();

        statistics.Should().BeNull();
    }
}