using System.Globalization;
using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class GameRound
{
    private static readonly CultureInfo CultureInfo = new("en-us");

    public GameRound(string line)
        : this(line.Queue())
    {
    }

    private GameRound(Queue<string> queue)
    {
        Round = queue.DequeueAsInt();

        var date = queue.Dequeue();
        var time = queue.Dequeue();
        var dateTime = $"{date} {time}";

        When = DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm", CultureInfo);
        TeamSize = queue.DequeueAsInt();
        ConfigurationName = queue.Dequeue();
        MapName = queue.Dequeue();
    }

    public int Round { get; }
    public DateTime When { get; }
    public int TeamSize { get; }
    public string? ConfigurationName { get; }
    public string? MapName { get; }
}