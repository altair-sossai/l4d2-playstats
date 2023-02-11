using L4D2PlayStats.Structures;

namespace L4D2PlayStats.Steam;

public abstract class SteamUser
{
    private readonly SteamIdentifiers? _identifiers;
    private readonly string? _steamId;

    public string? SteamId
    {
        get => _steamId;
        protected init
        {
            _steamId = value;
            _identifiers = SteamIdentifiers.TryParse(value ?? string.Empty, out var identifiers) ? identifiers : null;
        }
    }

    public long? CommunityId => _identifiers?.CommunityId;
    public string? Steam3 => _identifiers?.Steam3;
    public string? ProfileUrl => _identifiers?.ProfileUrl;
}