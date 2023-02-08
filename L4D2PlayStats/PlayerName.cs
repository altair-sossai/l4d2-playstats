using L4D2PlayStats.Extensions;

namespace L4D2PlayStats;

public class PlayerName
{
    public PlayerName(string line)
        : this(line.Queue(3))
    {
    }

    private PlayerName(Queue<string> queue)
    {
        Index = queue.DequeueAsInt();
        SteamId = queue.Dequeue();
        Name = queue.Dequeue();
    }

    public int Index { get; }
    public string? SteamId { get; }
    public string? Name { get; }
}