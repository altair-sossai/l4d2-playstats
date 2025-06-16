using System.Text;
using System.Text.RegularExpressions;

namespace L4D2PlayStats;

public class Statistics
{
    public Statistics()
    {
    }

    public Statistics(string content)
    {
        var lines = content.Split('\n').Select(l => l.Trim());
        var queue = new Queue<string>(lines);

        while (queue.Any())
        {
            var line = queue.Dequeue();

            if (string.IsNullOrEmpty(line))
                continue;

            if (Regex.IsMatch(line, @"\[Gameround:\d+\]"))
                GameRound = new GameRound(queue.Dequeue());

            else if (Regex.IsMatch(line, @"\[RoundHalf:\d\]"))
                AddRoundHalf(new RoundHalf(queue.Dequeue()));

            else if (Regex.IsMatch(line, @"\[Progress:\w\]"))
                AddProgress(new Progress(queue.Dequeue()));

            else if (Regex.IsMatch(line, @"\[Players:\w\]"))
            {
                while (queue.Any() && !string.IsNullOrEmpty(queue.Peek()))
                    AddPlayer(new Player(queue.Dequeue()));
            }

            else if (Regex.IsMatch(line, @"\[InfectedPlayers:\w\]"))
            {
                while (queue.Any() && !string.IsNullOrEmpty(queue.Peek()))
                    AddInfectedPlayer(new InfectedPlayer(queue.Dequeue()));
            }

            else if (Regex.IsMatch(line, @"\[Scoring:\]"))
                Scoring = new Scoring(queue.Dequeue());

            else if (Regex.IsMatch(line, @"\[PlayerNames:\]"))
            {
                while (queue.Any() && !string.IsNullOrEmpty(queue.Peek()))
                    PlayerNames.Add(new PlayerName(queue.Dequeue()));
            }
        }

        UpdatePlayerName();
        UpdateMapPeriod();
    }

    public GameRound? GameRound { get; set; }
    public List<Half> Halves { get; set; } = [];
    public Scoring? Scoring { get; set; }
    public List<PlayerName> PlayerNames { get; set; } = [];
    public List<PlayerName> TeamA { get; set; } = [];
    public List<PlayerName> TeamB { get; set; } = [];
    public DateTime? MapStart { get; set; }
    public DateTime? MapEnd { get; set; }
    public TimeSpan? MapElapsed => MapStart == null || MapEnd == null ? null : MapEnd - MapStart;

    public static bool TryParse(string? content, out Statistics? statistics)
    {
        try
        {
            if (string.IsNullOrEmpty(content?.Trim()))
            {
                statistics = null;
                return false;
            }

            statistics = new Statistics(content);
            return true;
        }
        catch (Exception)
        {
            statistics = null;
            return false;
        }
    }

    private Half AddHalf()
    {
        var half = new Half();

        Halves.Add(half);

        return half;
    }

    private void AddRoundHalf(RoundHalf roundHalf)
    {
        var half = Halves.FirstOrDefault(f => f.RoundHalf == null) ?? AddHalf();

        half.RoundHalf = roundHalf;
    }

    private void AddProgress(Progress progress)
    {
        var half = Halves.FirstOrDefault(f => f.Progress == null) ?? AddHalf();

        half.Progress = progress;
    }

    private void AddPlayer(Player player)
    {
        var half = Halves.Last(f => f.RoundHalf != null);

        half.Players.Add(player);
    }

    private void AddInfectedPlayer(InfectedPlayer infectedPlayer)
    {
        var half = Halves.Last(f => f.RoundHalf != null);

        half.InfectedPlayers.Add(infectedPlayer);
    }

    private void UpdatePlayerName()
    {
        var names = PlayerNames
            .Where(p => !string.IsNullOrEmpty(p.CommunityId))
            .ToDictionary(k => k.CommunityId!, v => v);

        foreach (var half in Halves)
        {
            var team = half.Progress?.Team == 'A' ? TeamA : TeamB;

            foreach (var player in half.Players.Where(player => !string.IsNullOrEmpty(player.CommunityId) && names.ContainsKey(player.CommunityId)))
            {
                var playerName = names[player.CommunityId!];

                player.PlayerName = playerName.Name;
                team.Add(playerName);
            }

            foreach (var infectedPlayer in half.InfectedPlayers.Where(player => !string.IsNullOrEmpty(player.CommunityId) && names.ContainsKey(player.CommunityId)))
                infectedPlayer.PlayerName = names[infectedPlayer.CommunityId!].Name;
        }
    }

    private void UpdateMapPeriod()
    {
        MapStart = Halves
            .Select(h => h.RoundHalf?.StartTime)
            .Where(d => d != null)
            .DefaultIfEmpty(null)
            .Min();

        MapEnd = Halves
            .Select(h => h.RoundHalf?.EndTime)
            .Where(d => d != null)
            .DefaultIfEmpty(null)
            .Max();
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        if (GameRound != null)
        {
            stringBuilder.Append($"[Gameround:{GameRound.Round}]\n");
            stringBuilder.Append($"{GameRound}\n\n");
        }

        foreach (var half in Halves)
            stringBuilder.Append(half);

        if (Scoring != null)
        {
            stringBuilder.Append("[Scoring:]\n");
            stringBuilder.Append($"{Scoring}\n\n");
        }

        if (PlayerNames.Any())
        {
            stringBuilder.Append("[PlayerNames:]:\n");

            foreach (var playerName in PlayerNames)
                stringBuilder.Append($"{playerName}\n");

            stringBuilder.Append("\n");
        }

        return stringBuilder.ToString();
    }

    public class Half
    {
        public RoundHalf? RoundHalf { get; set; }
        public Progress? Progress { get; set; }
        public List<Player> Players { get; set; } = [];
        public List<InfectedPlayer> InfectedPlayers { get; set; } = [];

        public Player? MvpSiDamage => MvpsSiDamage.FirstOrDefault();
        public Player? MvpCommon => MvpsCommon.FirstOrDefault();
        public Player? LvpFfGiven => LvpsFfGiven.FirstOrDefault();

        public IEnumerable<Player> MvpsSiDamage => Players.OrderByDescending(o => o.SiDamage);
        public IEnumerable<Player> MvpsCommon => Players.OrderByDescending(o => o.Common);
        public IEnumerable<Player> LvpsFfGiven => Players.OrderByDescending(o => o.FfGiven);

        public override string ToString()
        {
            if (RoundHalf == null)
                return string.Empty;

            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"[RoundHalf:{RoundHalf.Round}]\n");
            stringBuilder.Append($"{RoundHalf}\n\n");

            if (Progress != null)
            {
                stringBuilder.Append($"[Progress:{RoundHalf.Team}]\n");
                stringBuilder.Append($"{Progress}\n\n");
            }

            if (Players.Any())
            {
                stringBuilder.Append($"[Players:{RoundHalf.Team}]:\n");

                foreach (var player in Players)
                    stringBuilder.Append($"{player}\n");

                stringBuilder.Append("\n");
            }

            if (InfectedPlayers.Any())
            {
                stringBuilder.Append($"[InfectedPlayers:{RoundHalf.Team}]:\n");

                foreach (var infectedPlayer in InfectedPlayers)
                    stringBuilder.Append($"{infectedPlayer}\n");

                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}