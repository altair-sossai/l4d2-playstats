using System.Text.RegularExpressions;

namespace L4D2PlayStats.Helpers;

public static class SteamIdHelper
{
    private const string SteamIdPattern = @"^STEAM_\d:(\d):(\d+)$";

    private const long MagicNumber = 76561197960265728;

    private static readonly Regex SteamIdRegex = new(SteamIdPattern);

    public static long? SteamIdToCommunityId(string value)
    {
        var match = SteamIdRegex.Match(value);
        if (!match.Success)
            return null;

        var authServer = long.Parse(match.Groups[1].Value);
        var authid = long.Parse(match.Groups[2].Value);

        return authid * 2 + MagicNumber + authServer;
    }

    public static string? CommunityIdToSteam3(long communityId)
    {
        if (communityId <= 0)
            return null;

        var authserver = communityId - MagicNumber;

        return $"[U:1:{authserver}]";
    }

    public static string? ProfileUrl(long communityId)
    {
        return communityId <= 0 ? null : $"https://steamcommunity.com/profiles/{communityId}";
    }
}