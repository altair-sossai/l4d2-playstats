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

            if (_identifiers == null)
                return;

            CommunityId = _identifiers.Value.CommunityId?.ToString();
            Steam3 = _identifiers.Value.Steam3;
            ProfileUrl = _identifiers.Value.ProfileUrl;
        }
    }

    public string? CommunityId { get; set; }
    public string? Steam3 { get; set; }
    public string? ProfileUrl { get; set; }
}