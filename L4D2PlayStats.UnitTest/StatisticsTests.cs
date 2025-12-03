using System.Text;

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
        Assert.HasCount(2, statistics.Halves);
        Assert.IsNotNull(statistics.Scoring);
        Assert.HasCount(20, statistics.PlayerNames);
        Assert.HasCount(4, statistics.TeamA);
        Assert.HasCount(4, statistics.TeamB);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 10, 6, DateTimeKind.Utc), statistics.MapStart);
        Assert.AreEqual(new DateTime(2023, 2, 4, 3, 18, 37, DateTimeKind.Utc), statistics.MapEnd);
        Assert.AreEqual(new TimeSpan(0, 8, 31), statistics.MapElapsed);

        var firstHalf = statistics.Halves[0];
        Assert.IsNotNull(firstHalf.RoundHalf);
        Assert.AreEqual(0, firstHalf.RoundHalf!.Round);
        Assert.IsNotNull(firstHalf.Progress);
        Assert.AreEqual(0, firstHalf.Progress!.Round);
        Assert.HasCount(4, firstHalf.Players);
        Assert.HasCount(4, firstHalf.InfectedPlayers);

        var secondHalf = statistics.Halves[1];
        Assert.IsNotNull(secondHalf.RoundHalf);
        Assert.AreEqual(1, secondHalf.RoundHalf!.Round);
        Assert.IsNotNull(secondHalf.Progress);
        Assert.AreEqual(1, secondHalf.Progress!.Round);
        Assert.HasCount(4, secondHalf.Players);
        Assert.HasCount(4, secondHalf.InfectedPlayers);

        char[] separator = ['\r', '\n'];

        var conentLines = content.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        var statisticsLines = statistics.ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);

        Assert.HasCount(conentLines.Length, statisticsLines);

        for (var i = 0; i < conentLines.Length; i++)
            Assert.AreEqual(conentLines[i], statisticsLines[i]);
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