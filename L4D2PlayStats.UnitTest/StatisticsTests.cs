using System.Text;
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

        Assert.IsNotNull(statistics.GameRound);
        Assert.AreEqual(2, statistics.Halves.Count);
        Assert.IsNotNull(statistics.Scoring);
        Assert.AreEqual(20, statistics.PlayerNames.Count);
        Assert.AreEqual(4, statistics.TeamA.Count);
        Assert.AreEqual(4, statistics.TeamB.Count);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc), statistics.MapStart);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 18, 37, DateTimeKind.Utc), statistics.MapEnd);
        Assert.AreEqual(new TimeSpan(0, 8, 31), statistics.MapElapsed);

        var firstHalf = statistics.Halves[0];
        Assert.IsNotNull(firstHalf.RoundHalf);
        Assert.AreEqual(0, firstHalf.RoundHalf!.Round);
        Assert.IsNotNull(firstHalf.Progress);
        Assert.AreEqual(0, firstHalf.Progress!.Round);
        Assert.AreEqual(4, firstHalf.Players.Count);
        Assert.AreEqual(4, firstHalf.InfectedPlayers.Count);

        var secondHalf = statistics.Halves[1];
        Assert.IsNotNull(secondHalf.RoundHalf);
        Assert.AreEqual(1, secondHalf.RoundHalf!.Round);
        Assert.IsNotNull(secondHalf.Progress);
        Assert.AreEqual(1, secondHalf.Progress!.Round);
        Assert.AreEqual(4, secondHalf.Players.Count);
        Assert.AreEqual(4, secondHalf.InfectedPlayers.Count);
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

        var result = Statistics.TryParse(content, out var statistics);

        Assert.IsTrue(result);
        Assert.IsNotNull(statistics);
    }

    [TestMethod]
    public void TryParse_MustReturnFalseWhenContentIsInvalid()
    {
        const string content = "";

        var result = Statistics.TryParse(content, out var statistics);

        Assert.IsFalse(result);
        Assert.IsNull(statistics);
    }
}