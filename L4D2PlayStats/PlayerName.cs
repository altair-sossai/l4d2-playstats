using L4D2PlayStats.Extensions;
using L4D2PlayStats.Structures;

namespace L4D2PlayStats;

public class PlayerName
{
    private SteamIdentifiers? _identifiers;
    private string? _steamId;

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

    public string? SteamId
    {
        get => _steamId;
        set
        {
            _steamId = value;
            _identifiers = SteamIdentifiers.TryParse(value ?? string.Empty, out var identifiers) ? identifiers : null;
        }
    }

    public long? CommunityId => _identifiers?.CommunityId;
    public string? Steam3 => _identifiers?.Steam3;
    public string? Name { get; }
}